using Microsoft.AspNetCore.Http;
using SocialNet.Core.Application.Interfaces;


namespace SocialNet.Core.Application.Helpers
{
    public class UploadFiles<T> where T : class
    {
        public string UploadFile(IFormFile file, IEntity entity)
        {
            string basePath = $"/images/User/{entity.Id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            Guid guid = Guid.NewGuid();
            FileInfo fileInfor = new(file.FileName);
            string filename = guid + fileInfor.Extension;

            string fileNameWithPath = Path.Combine(path, filename);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return Path.Combine(basePath, filename);
        }
    }
}
