using HiddenVilla_Server.Service.IService;
using Microsoft.AspNetCore.Components.Forms;

namespace HiddenVilla_Server.Service
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUpload(IWebHostEnvironment webHostEnvironment)
        {
           _webHostEnvironment = webHostEnvironment;
        }

        public bool DeleteFile(string fileName)
        {  
            try
            {
                var path = $"{_webHostEnvironment.WebRootPath}\\RoomImages\\{fileName}";
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> UploadFile(IBrowserFile file)
        {
            //upload file to wwwroot folder
            try
            {
                FileInfo fileInfo = new FileInfo(file.Name);
                var fileName = Guid.NewGuid().ToString() + fileInfo.Extension;
                //create folder
                var folderDirectory = $"{_webHostEnvironment.WebRootPath}\\RoomImages";
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "RoomImages", fileName);

                var memoryStream = new MemoryStream();
                await file.OpenReadStream().CopyToAsync(memoryStream);

                if (!Directory.Exists(folderDirectory))
                {
                    Directory.CreateDirectory(folderDirectory);
                }

                //move file to new location
                await using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write)) 
                {
                    memoryStream.WriteTo(fs);
                }

                var fullPath = $"RoomImages/{fileName}";
                return fullPath;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
