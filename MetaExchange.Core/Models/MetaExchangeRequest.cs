using MetaExchange.Core.Enums;

namespace MetaExchange.Core.Models
{
    public class MetaExchangeRequest
    {
        public RequestType RequestType { get; set; }
        public decimal Amount { get; set; }
    }
}
