using System.Text.RegularExpressions;

namespace OceanaAura.Web.Extensions
{
    public static class FileExtensions
    {
        public static async Task<string> ConvertFileToStringAsync(IFormFile file, IWebHostEnvironment webHostEnvironment)
        {
            string uniqueFileName = null;
            try
            {
                string uniqueUpload = Path.Combine(webHostEnvironment.WebRootPath, "File/ColorsImg");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uniqueUpload, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while copying the file.", ex);
            }

            return uniqueFileName;
        }

        public static void DeleteFileFromFileFolder(string url, IWebHostEnvironment webHostEnvironment)
        {
            string uniqueUpload = Path.Combine(webHostEnvironment.WebRootPath, "File/ColorsImg");
            string filePath = Path.Combine(uniqueUpload, url);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static string TypeOfFile(string FileName)
        {
            string type = null;
            string regex = @"^.+\.(jpg|jpeg|png|gif|bmp|tiff|webp|svg)$";
            if (Regex.IsMatch(FileName.ToLower(), regex))
            {
                int indexDot = FileName.LastIndexOf(".");
                type = FileName.Substring(indexDot);
            }
            return type;
        }
    }
}
