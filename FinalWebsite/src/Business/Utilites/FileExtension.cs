using Microsoft.AspNetCore.Http;

namespace FinalWebsite.Business.Utilites
{
    public static class FileExtension
    {
        public static bool CheckFileType(this IFormFile file, string fileType)
        {
            return file.ContentType.Contains(fileType + "/");
        }

        public static bool CheckFileSize(this IFormFile file, int fileSize)
        {
            return file.Length / 1024 > fileSize;
        }

        public static async Task<string> SaveFileAsync(this IFormFile file, string root)
        {
            string unuqieName = Guid.NewGuid().ToString() + file.FileName;
            string path = Path.Combine(root, "manage", "img", "uploads", unuqieName);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return unuqieName;
        }

        public static void DeleteFile(this IFormFile file, string root, string fileName)
        {
            string path = Path.Combine(root, "manage", "img", "uploads", fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
