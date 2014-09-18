﻿namespace PhotoGaleries.GoogleDriveTestClient
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;

    using Newtonsoft.Json;

    using PhotoGaleries.GoogleDrive;

    public class Program
    {
        public static void Main()
        {
            string serverUrl = "http://localhost:7097/";

            var google = new GoogleDriveAPIController();

            var client = new HttpClient { BaseAddress = new Uri(serverUrl) };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var pics = google.UploadAll(@"..\..\Upload");

            Console.Write("Enter album Id: ");
            int albumId = int.Parse(Console.ReadLine());

            foreach (var picId in pics)
            {
                var picInfo = google.GetPictureInfo(picId);
                AddPhoto(client, albumId, picInfo.Name, picInfo.Url);
            }

            Console.WriteLine("{0} pictures uploaded!", pics.Count);
        }

        private static void AddPhoto(HttpClient client, int albumId, string name, string url)
        {
            string token = "N2D2pHov8Si2KhuRgQ4YR6gqe-Pq75BR3OVdg3rqFGHpNZN5NeVyMR9W8_K3sT3KIKcInyYIHjOjtxarvGqpdstLknH9QBpwSrw04sLZwkV6sMDBOaisHpKFbierHOCNuPBVp5-WoP1auBLrlFhxSRohFnYEJovKRnDyiXR4QbPVofgdEmJbQfD31kZq6DMq5QQ7vljyPtZyahELB267Xguk2SNd0mrK24kwbBQpS6OirRSzLq3nza-tV5wTv15aYGjMAucybuIaqf6f3QZqjNhljqINdzwvwscCri5-irq5fiQ7MLCvtoFodUfFmdCQ4vWnMMWfni8_0Tde-hSUwObCSM5koY9t7fo2iRVKzES5Hf8Y_K77QT1Eh691xLoKUEuFUUkLnqlmU63ztHoMdDOKn0dGNMAc8HUF-jRfJHPF4Do8JHRvsylVHE930DMHe2PaTD8d3kGo83rc9pFuWtPN-SOe3fwqXnZm4N2qGgM";

            var newPhoto = new PhotoInfo()
            {
                Name = name,
                Url = url,
                PhotoAlbumId = albumId
            };

            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(newPhoto));
            postContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            var response = client.PostAsync("api/photos/create", postContent).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Picture {0} added!", name);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
