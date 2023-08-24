namespace MetaExchangeConsoleApp.Data.Providers
{
    public interface IDataProvider<T>
    {
        IEnumerable<T> GetData(string pathToFile);
    }
}
