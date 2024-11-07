using System.Collections;
using System.Text;

namespace CoreLayer.Helpers;

public static class LogExceptionFileHelper
{
    public static async Task LogExceptionToFile(Exception exception)
    {
        string logDirectory = Path.Combine("wwwroot", "logs"); // logs klasörü yolu
        string logFileName = $"error_{DateTime.Now:dd-MM-yyyy}.txt";
        string logPath = Path.Combine(logDirectory, logFileName);
        StringBuilder logMessageBuilder = new();

        // logs klasörünün var olup olmadığını kontrol edin, yoksa oluşturun
        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }

        logMessageBuilder.AppendLine($"[{DateTime.Now}] Exception Details:");

        Exception? currentException = exception;
        while (currentException != null)
        {
            logMessageBuilder.AppendLine($"Type: {currentException.GetType().FullName}");
            logMessageBuilder.AppendLine($"Message: {currentException.Message}");

            if (!string.IsNullOrEmpty(currentException.StackTrace))
            {
                string[] stackTraceLines = currentException.StackTrace.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                logMessageBuilder.AppendLine("StackTrace:");

                foreach (string stackTraceLine in stackTraceLines)
                {
                    logMessageBuilder.AppendLine($"{stackTraceLine}");
                }
            }

            foreach (DictionaryEntry dataEntry in currentException.Data)
            {
                logMessageBuilder.AppendLine($"Data - Key: {dataEntry.Key}, Value: {dataEntry.Value}");
            }

            logMessageBuilder.AppendLine();

            currentException = currentException.InnerException;
        }

        using StreamWriter writer = new(logPath, true, Encoding.UTF8);
        await writer.WriteLineAsync(logMessageBuilder.ToString());
    }
}
