using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using Microsoft.AspNetCore.Http;

namespace CoreLayer.Helpers;

public enum FileType
{
    document,
    image,
    compressed,
    documentAndImage,
    video
}
public static class FileHelper
{
    private static readonly List<string> documentExtentions = [".pdf", ".docx", ".rtf", ".doc", ".csv", ".xlsx", ".xls"];
    private static readonly List<string> imageExtentions = [".jpg", ".jpeg", ".png", ".tiff", ".jfif", ".bmp"];
    private static readonly List<string> compressedExtentions = [".rar", ".zip", ".7z", ".tar"];
    private static readonly List<string> videoExtentions = [".mp4", ".mov"];
    public static async Task<string?> UploadAsync(string folderName, IFormFile file, FileType type, string randomName = null!)
    {
        if (!Directory.Exists(Path.Combine("wwwroot", folderName)))
        {
            Directory.CreateDirectory(Path.Combine("wwwroot", folderName));
        }
        string? extent = Path.GetExtension(file.FileName);

        if (type == FileType.document)
        {
            if (!documentExtentions.Contains(extent.ToLower()))
            {
                return null;
            }
            randomName = $"{DateTime.Now:dd-MM-yy--HH-mm}-{file.FileName}";
        }
        else if (type == FileType.image)
        {
            if (!imageExtentions.Contains(extent.ToLower()))
            {
                return null;
            }

            var imageStream = file.OpenReadStream();
            var image = await Image.LoadAsync<Rgba32>(imageStream);

            bool isPng = file.ContentType == "image/png";
            bool hasTransparency = isPng && HasTransparency(image);

            var extension = (isPng && hasTransparency) ? ".png" : ".jpeg";

            if (image == null)
            {
                return null;
            }

            randomName = $"{Guid.NewGuid()}{extension}";

            string? imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName, randomName);

            using (var outputStream = new FileStream(imagePath, FileMode.Create))
            {
                if (isPng && hasTransparency)
                {
                    var encoder = new PngEncoder
                    {
                        CompressionLevel = PngCompressionLevel.BestCompression
                    };
                    await image.SaveAsync(outputStream, encoder);
                }
                else
                {
                    var encoder = new JpegEncoder
                    {
                        Quality = 75
                    };
                    await image.SaveAsync(outputStream, encoder);
                }
            }

            return randomName;
        }
        else if (type == FileType.video)
        {
            if (!videoExtentions.Contains(extent.ToLower()))
            {
                return null; // Invalid video extension
            }

            // Generate a random name for the video file
            randomName = $"{DateTime.Now:dd-MM-yy--HH-mm}-{file.FileName}";

            // Define the path to save the video file
            string? videoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName, randomName);

            // Save the video file to the specified path
            using (var outputStream = new FileStream(videoPath, FileMode.Create))
            {
                await file.CopyToAsync(outputStream);
            }

            return randomName; // Return the generated file name
        }

        else if (type == FileType.compressed)
        {
            if (!compressedExtentions.Contains(extent.ToLower()))
            {
                return null;
            }
            randomName = $"{DateTime.Now:dd-MM-yy--HH-mm}-{file.FileName}";
        }
        else if (type == FileType.documentAndImage)
        {
            if (documentExtentions.Contains(extent.ToLower()))
            {
                randomName = $"{DateTime.Now:dd-MM-yy--HH-mm}-{file.FileName}";
            }
            else if (imageExtentions.Contains(extent.ToLower()))
            {
                var imageStream = file.OpenReadStream();
                var image = await Image.LoadAsync<Rgba32>(imageStream);

                bool isPng = file.ContentType == "image/png";
                bool hasTransparency = isPng && HasTransparency(image);

                var extension = (isPng && hasTransparency) ? ".png" : ".jpeg";

                if (image == null)
                {
                    return null;
                }

                randomName = $"{Guid.NewGuid()}{extension}";

                string? imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName, randomName);

                using (var outputStream = new FileStream(imagePath, FileMode.Create))
                {
                    if (isPng && hasTransparency)
                    {
                        var encoder = new PngEncoder
                        {
                            CompressionLevel = PngCompressionLevel.BestCompression
                        };
                        await image.SaveAsync(outputStream, encoder);
                    }
                    else
                    {
                        var encoder = new JpegEncoder
                        {
                            Quality = 75
                        };
                        await image.SaveAsync(outputStream, encoder);
                    }
                }
                return randomName;
            }
            else
            {
                return null;
            }
        }

        if (string.IsNullOrEmpty(randomName))
        {
            randomName = $"{Guid.NewGuid()}{extent}";
        }

        string? path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName, randomName);

        FileStreamOptions opt = new()
        {
            Access = FileAccess.ReadWrite,
            Mode = FileMode.OpenOrCreate,
            Share = FileShare.ReadWrite,
            Options = FileOptions.Asynchronous
        };

        using FileStream stream = new(path, opt);

        await file.CopyToAsync(stream);

        return randomName;
    }

    /// <summary>
    /// It is used for adding more than one file.
    /// If ExistFileNames exists, it returns the updated name of the files, if not, it returns only the newly added file names separated by commas. 
    /// </summary>
    /// <param name="folderName">The name of the folder where the files will be uploaded.</param>
    /// <param name="files">Parameter containing the data of the files.</param>
    /// <param name="type">Parameter for file types.</param>
    /// <param name="existFileNames">Parameter for file locations to be overwritten. Appends with a comma.</param>
    /// <returns>Returns with commas separating the file names.</returns>
    public static async Task<string?> UploadsAsync(string folderName, IFormFile[] files, FileType type, string? existFileNames = null)
    {
        if (files != null)
        {
            if (files.Length == 0)
            {
                if (string.IsNullOrEmpty(existFileNames))
                {
                    return null;
                }

                return existFileNames;
            }
            if (string.IsNullOrEmpty(existFileNames))
            {
                return await AddUploadsAsync(folderName, files, type);
            }
            else
            {
                return await UpdateUploadsAsync(existFileNames, folderName, files, type);
            }
        }
        else
        {
            return existFileNames;
        }
    }

    private static async Task<string> AddUploadsAsync(string folderName, IFormFile[] files, FileType type)
    {

        if (!Directory.Exists(Path.Combine("wwwroot", folderName)))
        {
            Directory.CreateDirectory(Path.Combine("wwwroot", folderName));
        }

        string randomNames = string.Empty;
        List<string> wrongFiles = [];
        for (int i = 0; i < files.Length; i++)
        {
            var extent = Path.GetExtension(files[i].FileName);
            if (type == FileType.document)
            {
                if (!documentExtentions.Contains(extent))
                {
                    wrongFiles.Add(files[i].FileName);
                    continue;
                }
            }
            else if (type == FileType.image)
            {
                if (!imageExtentions.Contains(extent))
                {
                    wrongFiles.Add(files[i].FileName);
                    continue;
                }
            }
            else if (type == FileType.compressed)
            {
                if (!compressedExtentions.Contains(extent))
                {
                    wrongFiles.Add(files[i].FileName);
                    continue;
                }
            }
            else if (type == FileType.documentAndImage)
            {
                if (!documentExtentions.Contains(extent) && !imageExtentions.Contains(extent))
                {
                    wrongFiles.Add(files[i].FileName);
                    continue;
                }
            }

            string randomName = await UploadAsync(folderName, files[i], type);

            if (i == (files.Length - 1))
            {
                randomNames += randomName;
            }
            else
            {
                randomNames += randomName + ",";
            }
        }

        return randomNames;
    }
    /// <summary>
    /// This method can be used for updating existing files inside a folder
    /// </summary>
    /// <param name="existFileNames">List of existing files, used for adding them later to returned string</param>
    /// <param name="folderName">Folder that contains files that is going to be updated</param>
    /// <param name="files">New files for adding in folder</param>
    /// <param name="type">Type of file, this indicated if the file is image, document or both, or zip file</param>
    /// <returns>String, this string contains new files paths along with existing ones seperated by ","</returns>
    private static async Task<string> UpdateUploadsAsync(string existFileNames, string folderName, IFormFile[] files, FileType type)
    {
        if (!Directory.Exists(Path.Combine("wwwroot", folderName)))
        {
            Directory.CreateDirectory(Path.Combine("wwwroot", folderName));
        }

        existFileNames += ",";
        List<string> wrongFiles = [];
        for (int i = 0; i < files.Length; i++)
        {
            var extent = Path.GetExtension(files[i].FileName);

            if (type == FileType.document)
            {
                if (!documentExtentions.Contains(extent))
                {
                    wrongFiles.Add(files[i].FileName);
                    continue;
                }
            }
            else if (type == FileType.image)
            {
                if (!imageExtentions.Contains(extent))
                {
                    wrongFiles.Add(files[i].FileName);
                    continue;
                }
            }
            else if (type == FileType.compressed)
            {
                if (!compressedExtentions.Contains(extent))
                {
                    wrongFiles.Add(files[i].FileName);
                    continue;
                }
            }

            string randomName = await UploadAsync(folderName, files[i], type);

            if (i == (files.Length - 1))
            {
                existFileNames += randomName;
            }
            else
            {
                existFileNames += randomName + ",";
            }
        }

        return existFileNames;
    }

    private static bool HasTransparency(Image<Rgba32> image)
    {
        for (int y = 0; y < image.Height; y += 10)
        {
            for (int x = 0; x < image.Width; x += 10)
            {
                if (image[x, y].A < 255)
                {
                    return true;
                }
            }
        }
        return false;
    }
    /// <summary>
    /// For deleting a single file
    /// </summary>
    /// <param name="fileLocation">Location of the file that will be deleted</param>
    /// <param name="folderLocation">Folder that contains file that you want to delete</param>
    /// <returns>Bool, This indicates if the file deletion is succesfull</returns>
    public static bool DeleteFile(string fileLocation, string? folderLocation = null)
    {
        try
        {
            string mainPath = "wwwroot";

            string path = Path.Combine(Directory.GetCurrentDirectory(), mainPath, folderLocation, fileLocation);

            File.Delete(path);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message.ToString());
            return false;
        }
    }
    /// <summary>
    /// This method can be used for deleteing multiple entities
    /// </summary>
    /// <param name="fileLocationsParams">Array of file locations that will be deleted</param>
    public static void DeleteFiles(params string[] fileLocationsParams)
    {
        string mainPath = "wwwroot";
        foreach (var fileLocations in fileLocationsParams)
        {
            if (string.IsNullOrEmpty(fileLocations)) continue;
            foreach (string fileLocation in fileLocations.Split(","))
            {
                if (string.IsNullOrEmpty(fileLocation)) continue;
                try
                {
                    File.Delete(Path.Combine(Directory.GetCurrentDirectory(), mainPath + fileLocation));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                    continue;
                }
            }
        }
    }
    /// <summary>
    /// This method is used for deleting a file and updating entity, This should only be used if you store file paths in a single string seperated by ","
    /// </summary>
    /// <typeparam name="T">Entity type that will be updated</typeparam>
    /// <param name="entity">Entity that will be updated</param>
    /// <param name="filePath">File that will be deleted</param>
    /// <param name="propertyName">Property of entity that stores sting file paths</param>
    /// <param name="folderLocation">Folder location of file that will be deleted</param>
    /// <param name="forceDelete">Entity will be updated regardles of if file is deleted or not</param>
    /// <returns>Updated entity</returns>
    public static T? DeleteFileAndUpdateEntity<T>(T entity, string filePath, string propertyName,string folderLocation=null, bool forceDelete = false) where T : class
    {
        if (entity == null)
        {
            return null;
        }

        if (ReflectionHelper.TryGetPropertyValue(entity, propertyName, out var propertyValue))
        {
            if (propertyValue is string propertyStringValue)
            {
                bool isDelete = DeleteFile(filePath, folderLocation);
                if (isDelete || forceDelete)
                {
                    string[] updatedValue = propertyStringValue
                        .Split(',')
                        .Where(p => p != filePath)
                        .ToArray();

                    string? newValue = updatedValue.Length > 0 ? string.Join(",", updatedValue) : null;

                    if (ReflectionHelper.TrySetPropertyValue(entity, propertyName, newValue))
                    {
                        return entity;
                    }
                }
            }
        }

        return null;
    }
    /// <summary>
    /// Method to delete all contents in the folder (files and subfolders)
    /// </summary>
    /// <param name="folderPath">Folder that will be deleted with its content</param>
    /// <returns>Bool, This indicates if the folder deletion is succesfull</returns>
    public static bool DeleteFolderContents(string folderPath)
    {
        try
        {
            // Delete files first
            foreach (var file in Directory.EnumerateFiles(folderPath))
            {
                try
                {
                    System.IO.File.Delete(file);
                }
                catch (IOException ex)
                {
                    // If file is in use, log or handle exception
                    Console.WriteLine($"Error deleting file {file}: {ex.Message}");
                    return false;
                }
            }

            // Delete subdirectories
            foreach (var dir in Directory.EnumerateDirectories(folderPath))
            {
                DeleteFolderContents(dir); // Recursive delete for subdirectories
            }

            // Finally, delete the folder itself
            Directory.Delete(folderPath, true);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting folder contents {folderPath}: {ex.Message}");
            return false;
        }
    }

    // Retry logic for deleting a directory
    /// <summary>
    /// Method to delete all contents in the folder (files and subfolders), but with retry logic
    /// </summary>
    /// <param name="directoryPath">Folder that will be deleted with its content</param>
    /// <param name="maxAttempts">Max try attempts to delete the folder</param>
    /// <param name="delay">Time that is in between atempts</param>
    /// <returns>Bool, This indicates if the folder deletion is succesfull</returns>
    public static bool TryDeleteDirectory(string directoryPath, int maxAttempts, TimeSpan delay)
    {
        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                Directory.Delete(directoryPath, true); // true to delete non-empty directories
                return true;
            }
            catch (IOException)
            {
                if (attempt == maxAttempts)
                {
                    return false; // Failed after max attempts
                }
                Thread.Sleep(delay); // Wait before retrying
            }
            catch (UnauthorizedAccessException)
            {
                if (attempt == maxAttempts)
                {
                    return false; // Failed after max attempts
                }
                Thread.Sleep(delay); // Wait before retrying
            }
        }

        return false;
    }
}
