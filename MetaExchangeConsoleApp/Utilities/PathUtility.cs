namespace MetaExchangeConsoleApp.Utilities
{
    public static class PathUtility
    {
        public static string FindFilePath(string fileName)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            var rootDirectory = Path.GetFullPath(@"..\..\..");
            var dataDirectory = Path.Combine(rootDirectory, "Data");

            string filePath = FindFileInDirectory(fileName, dataDirectory);

            if (!string.IsNullOrEmpty(filePath))
            {
                return filePath;
            }
            else
            {
                throw new InvalidOperationException("File not found");
            }
        }

        private static string FindFileInDirectory(string fileName, string directory)
        {
            string[] files = Directory.GetFiles(directory, fileName, SearchOption.AllDirectories);

            if (files.Length > 0)
            {
                return files[0];
            }

            return null;
        }
    }
}
