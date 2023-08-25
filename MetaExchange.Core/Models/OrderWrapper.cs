using System.Text.Json.Serialization;

namespace MetaExchange.Core.Models
{
    public class OrderWrapper
    {
        [JsonPropertyName("Order")]
        public Order Order { get; set; }
    }
}
