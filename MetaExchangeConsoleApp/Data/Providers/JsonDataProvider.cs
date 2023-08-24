using System.Text.Json;

namespace MetaExchangeConsoleApp.Data.Providers
{
    public class JsonDataProvider<T> : IDataProvider<T>
    {
        public IEnumerable<T> GetData(string pathToFile)
        {
            using (StreamReader reader = new StreamReader(pathToFile))
            {
                string jsonContent = reader.ReadToEnd();
                return JsonSerializer.Deserialize<IEnumerable<T>>(jsonContent);
            }
        }
    }
}
