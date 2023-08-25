namespace MetaExchange.Core.Utility
{
    public static class PathUtility
    {
        public static string FindFilePath(string fileName)
        {
            var rootDirectory = FindSolutionDirectoryInfo();

            var dataDirectory = Path.Combine(rootDirectory, "MetaExchange.Core", "Data");

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

        public static string FindSolutionDirectoryInfo(string currentPath = null)
        {
            var directory = new DirectoryInfo(
                currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            return directory.FullName;
        }
    }
}
