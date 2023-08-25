using MetaExchange.Core.Enums;

namespace MetaExchange.API.Controllers.Requests
{
    public class ExchangeRequest
    {
        public RequestType RequestType { get; set; }
        public decimal Amount { get; set; }
    }
}
