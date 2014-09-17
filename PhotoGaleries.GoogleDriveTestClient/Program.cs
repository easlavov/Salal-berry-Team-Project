namespace PhotoGaleries.GoogleDriveTestClient
{
    using System;
    using PhotoGaleries.GoogleDrive;

    public class Program
    {
        public static void Main()
        {
            var google = new GoogleDriveAPIController();

            //var id = google.UploadFile(@"..\..\", "IMG101_4704.jpg");
            // Console.WriteLine(id);

            // var pics = google.AllFiles();

            var pics = google.UploadAll(@"..\..\Upload");

            foreach (var pic in pics)
            {
                Console.WriteLine(pic);
            }

            //var result = google.GetPictureUrl(id);
            //Console.WriteLine(result);
        }
    }
}
