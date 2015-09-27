﻿using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using UGoFor.API.Models;

namespace UGoFor.API.Services
{
    public class BlobService : IBlobService
    {
        public async Task<List<BlobUploadModel>> UploadBlobs(HttpContent httpContent)
        {
            var blobUploadProvider = new BlobStorageUploadProvider();

            var list = await httpContent.ReadAsMultipartAsync(blobUploadProvider)
                .ContinueWith(task =>
                {
                    if (task.IsFaulted || task.IsCanceled)
                    {
                        throw task.Exception;
                    }

                    var provider = task.Result;
                    return provider.Uploads.ToList();
                });

            // TODO: Use data in the list to store blob info in your
            // database so that you can always retrieve it later.

            return list;
        }

        public async Task<BlobDownloadModel> DownloadBlob(int blobId)
        {
            // TODO: You must implement this helper method. It should retrieve blob info
            // from your database, based on the blobId. The record should contain the
            // blobName, which you should return as the result of this helper method.
            var blobName = blobId+".jpg";// GetBlobName(blobId);

            if (!String.IsNullOrEmpty(blobName))
            {
                var container = BlobHelper.GetBlobContainer();
                var blob = container.GetBlockBlobReference(blobName);

                // Download the blob into a memory stream. Notice that we're not putting the memory
                // stream in a using statement. This is because we need the stream to be open for the
                // API controller in order for the file to actually be downloadable. The closing and
                // disposing of the stream is handled by the Web API framework.
                var ms = new MemoryStream();
                await blob.DownloadToStreamAsync(ms);

                // Strip off any folder structure so the file name is just the file name
                var lastPos = blob.Name.LastIndexOf('/');
                var fileName = blob.Name.Substring(lastPos + 1, blob.Name.Length - lastPos - 1);

                // Build and return the download model with the blob stream and its relevant info
                var download = new BlobDownloadModel
                {
                    BlobStream = ms,
                    BlobFileName = fileName,
                    BlobLength = blob.Properties.Length,
                    BlobContentType = blob.Properties.ContentType
                };

                return download;
            }

            // Otherwise
            return null;
        }
    }
    public interface IBlobService
    {
        Task<List<BlobUploadModel>> UploadBlobs(HttpContent httpContent);
        Task<BlobDownloadModel> DownloadBlob(int blobId);
    }
    public static class BlobHelper
    {
        public static CloudBlobContainer GetBlobContainer()
        {
            // Pull these from config
            var blobStorageConnectionString = ConfigurationManager.AppSettings["BlobStorageConnectionString"];
            var blobStorageContainerName = ConfigurationManager.AppSettings["BlobStorageContainerName"];

            // Create blob client and return reference to the container
            var blobStorageAccount = CloudStorageAccount.Parse(blobStorageConnectionString);
            var blobClient = blobStorageAccount.CreateCloudBlobClient();
            return blobClient.GetContainerReference(blobStorageContainerName);
        }
    }
    public class BlobStorageUploadProvider : MultipartFileStreamProvider
    {
        public List<BlobUploadModel> Uploads { get; set; }

        public BlobStorageUploadProvider() : base(Path.GetTempPath())
        {
            Uploads = new List<BlobUploadModel>();
        }

        public override Task ExecutePostProcessingAsync()
        {
            //Calling this method for new registration
            SignUpModel signUp = new SignUpModel();

            // NOTE: FileData is a property of MultipartFileStreamProvider and is a list of multipart
            // files that have been uploaded and saved to disk in the Path.GetTempPath() location.

            foreach (var fileData in FileData)
            {

                if (fileData.Headers.ContentDisposition.FileName == null)
                {
                    //do something here with the form data
                    var pair = fileData.Headers.ContentDisposition.Name.Trim('"').Split('-');
                    switch (pair[0])
                    {
                        case("uname"):
                            signUp.Username = pair[1];
                            break;
                        case("email"):
                            signUp.Email = pair[1];
                            break;
                        case("pass"):
                            signUp.Password = pair[1];
                            break;
                    }
                    continue;
                }
                
                // Sometimes the filename has a leading and trailing double-quote character
                // when uploaded, so we trim it; otherwise, we get an illegal character exception
                var fileName = Path.GetFileName(fileData.Headers.ContentDisposition.FileName.Trim('"'));

                //signUp.Password = pair[1];

                // Retrieve reference to a blob
                var blobContainer = BlobHelper.GetBlobContainer();
                var blob = blobContainer.GetBlockBlobReference(fileName);

                // Set the blob content type
                blob.Properties.ContentType = fileData.Headers.ContentType.MediaType;

                // Upload file into blob storage, basically copying it from local disk into Azure
                using (var fs = File.OpenRead(fileData.LocalFileName))
                {
                    blob.UploadFromStream(fs);
                }

                // Delete local file from disk
                File.Delete(fileData.LocalFileName);

                //Adding New User
                signUp.ProfilePicURL = blob.Uri.AbsoluteUri;
                //int id = new SignUpModel().InsertNewUser(signUp);
                int id = 0;

                // Create blob upload model with properties from blob info
                var blobUpload = new BlobUploadModel
                {
                    FileName = blob.Name,
                    FileUrl = blob.Uri.AbsoluteUri,
                    FileSizeInBytes = blob.Properties.Length,
                    CustomData = id.ToString()
                };

                // Add uploaded blob to the list
                Uploads.Add(blobUpload);
            }

            return base.ExecutePostProcessingAsync();
        }
    }
}