using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BotWhatsApp.Interfaces
{
    public interface IFileAzureStorage
    {
        Task<string> Save(string path, IFormFile file);
    }
}
