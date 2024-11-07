using System.IO.Compression;

namespace CoreLayer.Helpers
{
    public class ZipResponse
    {
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public bool IsSucces { get; set; }
    }
    public class ZipHelper
    {
        /// <summary>
        ///  Takes a folder and contents of that folder and creates a zip archive
        /// </summary>
        /// <param name="folderName">Name of the folder</param>
        /// <param name="basePath">Path that folder is located (usualy WebRootPath or combination of any other paths)</param>
        /// <returns>ZipResponse</returns>
        public async Task<ZipResponse> DownloadFolderAsZipAsync(string folderName, string basePath)
        {
            // Build the full folder path
            var fPath = Path.Combine(basePath, folderName);
            if (string.IsNullOrEmpty(fPath) || !Directory.Exists(fPath))
            {
                return new ZipResponse()
                {
                    IsSucces = false
                };
            }
            // Get the folder name
            string fName = Path.GetFileName(fPath.TrimEnd(Path.DirectorySeparatorChar));
            // Generate a unique file name for the ZIP file
            string uniqueFileName = $"{fName}_{Guid.NewGuid()}.zip";
            string tempZipPath = Path.Combine(Path.GetTempPath(), uniqueFileName);

            try
            {
                // Create the ZIP file
                ZipFile.CreateFromDirectory(fPath, tempZipPath);
                // Return the ZIP file as a download
                byte[] fileBytes = await File.ReadAllBytesAsync(tempZipPath);
                return new ZipResponse()
                {
                    IsSucces = true,
                    Data = fileBytes,
                    Name = fName
                };
            }
            catch (Exception ex)
            {
                await LogExceptionFileHelper.LogExceptionToFile(ex);
                // Handle exceptions (e.g., log the error)
                return new ZipResponse()
                {
                    IsSucces = false
                };
            }
            finally
            {
                // Ensure the temporary ZIP file is deleted after the download
                if (File.Exists(tempZipPath))
                {
                    File.Delete(tempZipPath);
                }
            }
        }
    }
}
