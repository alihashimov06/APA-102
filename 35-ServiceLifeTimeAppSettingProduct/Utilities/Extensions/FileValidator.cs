using _34_Front_To_BackSqlConnection.Models;
using _34_Front_To_BackSqlConnection.Utilities.Enums;
using System.IO;

namespace _34_Front_To_BackSqlConnection.Utilities.Extensions
{
    public static class FileValidator
    {

        public static bool IsImage(this IFormFile file, string type)
        {
            if (file.ContentType.Contains(type)) return false;

            return true;
        }
        public static bool isSizeAllowed(this IFormFile file, FileSize sizeUnite, long size)
        {
            switch (sizeUnite)
            {
                case FileSize.KB:
                    return file.Length <= size * 1024;

                case FileSize.MB:
                    return file.Length <= size * 1024 * 1024;

                case FileSize.GB:
                    return file.Length <= size * 1024 * 1024;

            }
            return false;
        }
        public static async Task<string> CreateFileAsync(this IFormFile file, params string[] roots)
        {
            string fileName = string.Concat(Guid.NewGuid().ToString(), file.FileName);

            string path = string.Empty;

            for (int i = 0; i < roots.Length; i++)
            {
                path = Path.Combine(path, roots[i]);
            }
            path = Path.Combine(path,fileName);

            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return fileName;

        }
        public static void DeleteFile(this string fileName, params string[] roots)
        {
            string path = string.Empty;
            for (int i = 0; i < roots.Length; i++)
            {
                path = Path.Combine(path, roots[i]);
            }
            path = Path.Combine(path, fileName);

            File.Delete(path);
            
        }

    }
}
