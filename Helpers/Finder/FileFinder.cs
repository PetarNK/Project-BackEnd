using System.IO;
using System.Reflection;
using log4net;
using System;

namespace Backend.Helpers
{
    public class FileFinder
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(FileFinder));

        // Method to find a file by its name, starting from the application startup path through all the parent paths.
        // If file is not found or root folder has been reached, null is returned.
        public static FileInfo FindApplicationFile(string fileName)
        {
            log.Info($"Starting search for file: {fileName}");

            string startPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
            log.Debug($"Initial start path: {startPath}");

            FileInfo file = new FileInfo(startPath);
            try
            {
                while (!file.Exists)
                {
                    if (file.Directory?.Parent == null)
                    {
                        log.Warn($"File not found: {fileName}");
                        throw new FileNotFoundException();
                    }

                    DirectoryInfo parentDir = file.Directory.Parent;
                    file = new FileInfo(Path.Combine(parentDir.FullName, file.Name));
                    log.Debug($"Checking in parent directory: {parentDir.FullName}");

                }
                
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            log.Info($"File found: {file.FullName}");
            return file;
        }
    }
}

