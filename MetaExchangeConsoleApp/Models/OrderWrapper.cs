using System.Text.Json.Serialization;

namespace MetaExchangeConsoleApp.Models
{
    public class OrderWrapper
    {
        [JsonPropertyName("Order")]
        public Order Order { get; set; }
    }
}
