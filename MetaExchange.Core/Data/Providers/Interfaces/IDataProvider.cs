namespace MetaExchange.Core.Data.Providers.Interfaces
{
    public interface IDataProvider<T>
    {
        IEnumerable<T> GetData(string fileName);
    }
}
