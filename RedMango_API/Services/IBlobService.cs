namespace RedMango_API.Services
{//definitions for a group of related functionalities(Blobs or Azure storage files) that a non-abstract class or a struct must implement
    public interface IBlobService
    {
        Task<string> GetBlob(string blobName, string containerName);
        Task<bool> DeleteBlob(string blobName, string containerName);
        Task<string> UploadBlob(string blobName, string containerName, IFormFile file);
    }
}
