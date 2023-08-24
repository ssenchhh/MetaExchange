using MetaExchangeConsoleApp.Data.Providers;
using MetaExchangeConsoleApp.Utilities;

namespace MetaExchangeConsoleApp.Services
{
    public class DataService<T>
    {
        private readonly IDataProvider<T> _dataProvider;

        public DataService(IDataProvider<T> dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public IEnumerable<T> GetData()
        {
            var path = PathUtility.FindFilePath("order_books_data");
            return _dataProvider.GetData(path);
        }
    }
}
