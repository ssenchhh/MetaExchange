using MetaExchange.Core.Enums;
using MetaExchange.Core.Models;

namespace MetaExchange.Core.Services.Interfaces
{
    public interface IMetaExchangeService
    {
        IEnumerable<Order> GetRecommendedOrders(RequestType requestType, decimal amount);
    }
}
