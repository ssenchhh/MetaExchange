using MetaExchange.Core.Data.Providers.Interfaces;
using MetaExchange.Core.Data.Repositories.Interfaces;
using MetaExchange.Core.Models;

namespace MetaExchange.Core.Data.Repositories
{
    public class OrderBookRepository : IRepository<OrderBook>
    {
        private const string FileName = "order_books_data";
        private readonly IDataProvider<OrderBook> _fileProvider;

        public OrderBookRepository(IDataProvider<OrderBook> fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public IEnumerable<OrderBook> GetAll()
        {
            return _fileProvider.GetData(FileName);
        }
    }
}
