using Azure.Storage.Blobs;
using BotWhatsApp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BotWhatsApp.Utilities
{
    public class FileAzureStorage: IFileAzureStorage
    {
        private string _connectiomString;
        public FileAzureStorage(IConfiguration configuration)
        {
            _connectiomString = configuration.GetConnectionString("AzureStorage");
        }
        public async Task<string> Save(string path, IFormFile file)
        {
            var client = new BlobContainerClient(_connectiomString, path);
            await client.CreateIfNotExistsAsync();
            client.SetAccessPolicy(Azure.Storage.Blobs.Models.PublicAccessType.Blob);

            var extension = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{extension}";
            var blob = client.GetBlobClient(fileName);
            await blob.UploadAsync(file.OpenReadStream());
            return blob.Uri.ToString();
        }
    }
}
