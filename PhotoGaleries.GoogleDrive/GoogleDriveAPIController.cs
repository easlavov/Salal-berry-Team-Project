namespace PhotoGaleries.GoogleDrive
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Drive.v2;
    using Google.Apis.Drive.v2.Data;
    using Google.Apis.Services;

    public class GoogleDriveAPIController
    {
        private const string ClientId = "304349750930-heaqvcv081jlel2m21fprn9unh7llp25.apps.googleusercontent.com";
        private const string ClientSecret = "7h7e806cMYaDgFOCgYh5GF5w";
        private const string FolderId = "0B4y_-gLZ6-kbOHRrSGNaa2FOeVk";

        private DriveService service;
        private ParentReference cloudFolder;

        public GoogleDriveAPIController()
        {
            this.cloudFolder = new ParentReference() { Kind = "drive#file", Id = FolderId };
            this.service = Initialize();
        }

        public string UploadFile(string uploadDirectory, string fileName)
        {
            string fileType = "image/jpg";

            File body = new File()
            {
                Title = fileName,
                MimeType = fileType,
                Parents = new List<ParentReference>() { this.cloudFolder }
            };

            var fileinfo = System.IO.Path.Combine(uploadDirectory, fileName);
            byte[] byteArray = System.IO.File.ReadAllBytes(fileinfo);
            System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);

            FilesResource.InsertMediaUpload request = this.service.Files.Insert(body, stream, fileType);
            request.Upload();
            File file = request.ResponseBody;

            return file.Id;
        }

        public ICollection<string> UploadAll(string uploadDirectory)
        {
            var result = new List<string>();

            var directory = new System.IO.DirectoryInfo(uploadDirectory);
            foreach (var file in directory.GetFiles())
            {
                if (file.Extension == ".jpg")
                {
                    result.Add(this.UploadFile(uploadDirectory, file.Name));
                }
            }

            return result;
        }

        public PhotoInfo GetPictureInfo(string fileId)
        {
            try
            {
                File file = service.Files.Get(fileId).Execute();

                string downloadUrl = file.WebContentLink;
                string thumbNailUrl = file.ThumbnailLink;

                int index = downloadUrl.LastIndexOf("&");
                string viewUrl = downloadUrl.Substring(0, index);

                var result = new PhotoInfo()
                {
                    Name = file.Title,
                    Url = viewUrl,
                };

                return result;
            }
            catch (Exception e)
            {
                return new PhotoInfo();
            }
        }

        public string GetPictureUrl(string fileId)
        {
            var result = GetPictureInfo(fileId);
            return result.Url;
        }

        public string GetPictureName(string fileId)
        {
            var result = GetPictureInfo(fileId);
            return result.Name;
        }

        public ICollection<string> AllFiles()
        {
            FilesResource.ListRequest request = this.service.Files.List();
            FileList files = request.Execute();

            var result = new List<string>();

            foreach (var file in files.Items)
            {
                if (file.FileExtension == "jpg" && file.Parents != null && file.Parents.Any(p => p.Id == FolderId))
                {
                    result.Add(file.Id);
                }
            }

            return result;
        }

        private DriveService Initialize()
        {
            var secrets = new ClientSecrets { ClientId = ClientId, ClientSecret = ClientSecret };
            var scopes = new[] { DriveService.Scope.Drive };

            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(secrets, scopes, "user", CancellationToken.None).Result;

            // Create the service.
            var initialiser = new BaseClientService.Initializer();
            initialiser.HttpClientInitializer = credential;
            initialiser.ApplicationName = "PhotoGallery";
            var service = new DriveService(initialiser);

            return service;
        }
    }
}

