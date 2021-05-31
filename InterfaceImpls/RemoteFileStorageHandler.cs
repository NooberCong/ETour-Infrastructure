using Azure.Storage;
using Azure.Storage.Blobs;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceImpls
{
    public class RemoteFileStorageHandler : IRemoteFileStorageHandler
    {
        public IConfiguration _configuration;

        public RemoteFileStorageHandler(IConfiguration configuration)
        {
            _configuration = configuration.GetSection("AzureStorageConfig");
        }

        public async Task<string> UploadAsync(Stream fileStream, string mimeType)
        {
            string fileName = GenerateFileName(mimeType);
            var (accountName, imageContainer, accountKey) = GetAzureStorageConfig();

            Uri blobUri = new Uri(
                $"https://{accountName}.blob.core.windows.net/{imageContainer}/{fileName}"
                );
            StorageSharedKeyCredential storageCredentials = new StorageSharedKeyCredential(accountName, accountKey);

            BlobClient blobClient = new BlobClient(blobUri, storageCredentials);

            await blobClient.UploadAsync(fileStream);

            return blobUri.AbsoluteUri;
        }

        public async Task DeleteAsync(string uri)
        {
            var (accountName, _, accountKey) = GetAzureStorageConfig();

            Uri blobUri = new Uri(uri);

            StorageSharedKeyCredential storageCredentials = new StorageSharedKeyCredential(accountName, accountKey);

            BlobClient blobClient = new BlobClient(blobUri, storageCredentials);

            await blobClient.DeleteAsync();
        }

        private string GenerateFileName(string mimetype)
        {
            return $"{Path.GetRandomFileName()}.{mimetype}";
        }

        private (string accountName, string imageContainer, string accountKey) GetAzureStorageConfig()
        {
            return (_configuration["AccountName"], _configuration["ImageContainer"], _configuration["AccountKey"]);
        }

        public bool IsHostedFile(string fileUrl)
        {
            var (accountName, imageContainer, _) = GetAzureStorageConfig();
            return fileUrl.StartsWith($"https://{accountName}.blob.core.windows.net/{imageContainer}/");
        }
    }
}
