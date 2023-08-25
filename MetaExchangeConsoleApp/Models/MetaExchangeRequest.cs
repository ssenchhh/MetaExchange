using MetaExchangeConsoleApp.Enums;

namespace MetaExchangeConsoleApp.Models
{
    public class MetaExchangeRequest
    {
        public RequestType RequestType { get; set; }
        public decimal Amount { get; set; }
    }
}
