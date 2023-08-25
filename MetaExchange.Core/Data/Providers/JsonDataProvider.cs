using System.Text.Json;
using MetaExchange.Core.Data.Providers.Interfaces;
using MetaExchange.Core.Utility;

namespace MetaExchange.Core.Data.Providers
{
    public class JsonDataProvider<T> : IDataProvider<T>
    {
        public IEnumerable<T> GetData(string fileName)
        {
            var pathToFile = PathUtility.FindFilePath(fileName);
            using (StreamReader reader = new StreamReader(pathToFile))
            {
                string jsonContent = reader.ReadToEnd();
                return JsonSerializer.Deserialize<IEnumerable<T>>(jsonContent);
            }
        }
    }
}
