using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace RedMango_API.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobClient;
        //Allows manipulation of Azure Storage services in this Service

        public BlobService(BlobServiceClient blobClient)
        {
            _blobClient = blobClient; 
        }

        public async Task<bool> DeleteBlob(string blobName, string containerName)
        {
            BlobContainerClient blobContainerClient = _blobClient.GetBlobContainerClient(containerName);//gets the container name where your files are uploaded for example ours is "reactecommerceredmango" within"reactredmangopiczures" 
            BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);
            //gets the file (our case is a pic file)

            return await blobClient.DeleteIfExistsAsync();
        }

        public async Task<string> GetBlob(string blobName, string containerName)
        {
            BlobContainerClient blobContainerClient = _blobClient.GetBlobContainerClient(containerName);//gets the container name where your files are uploaded for example ours is "reactecommerceredmango" within"reactredmangopiczures" 
            BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);
            //gets the file (our case is a pic file)
            return blobClient.Uri.AbsoluteUri;
            //returns url that can be saved in the DB
        }

        public async Task<string> UploadBlob(string blobName, string containerName, IFormFile file)
        {
            BlobContainerClient blobContainerClient = _blobClient.GetBlobContainerClient(containerName);//gets the container name where your files are uploaded for example ours is "reactecommerceredmango" within"reactredmangopiczures" 
            BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);
            //gets the file (our case is a pic file)

            var httpHeaders = new BlobHttpHeaders()
            {
                ContentType = file.ContentType
            };
            var result = await blobClient.UploadAsync(file.OpenReadStream(), httpHeaders);
            if (result != null)
            {
                return await GetBlob(blobName, containerName);
            }
            return "";
            //if failed it returns an empty string
        }
    }
}
