using MetaExchange.Core.Data.Providers;
using MetaExchange.Core.Data.Repositories;
using MetaExchange.Core.Enums;
using MetaExchange.Core.Models;
using MetaExchange.Core.Services;

var dataProvider = new RowDataProvider<OrderBook>();
var orderBookRepository = new OrderBookRepository(dataProvider);
var exchangeService = new MetaExchangeService(orderBookRepository);

var requestType = AskForType();
var amount = AskForAmount();

var recomendedOrders = exchangeService.GetRecommendedOrders(requestType, amount);

OutputResults();

RequestType AskForType()
{
    Console.Write("Do you want to buy BTC or sell BTC? Enter 'Buy' or 'Sell': ");
    var input = Console.ReadLine();

    if (!Enum.TryParse<RequestType>(input, true, out RequestType type))
    {
        Console.WriteLine("Invalid input try again.");
        type = AskForType();
    }

    return type;
}

decimal AskForAmount()
{
    Console.Write("Amount of BTC you want to buy/sell: ");
    var input = Console.ReadLine();

    if (!decimal.TryParse(input, out decimal result) || result <= 0)
    {
        return AskForAmount();
    }

    return result;
}

void OutputResults()
{
    Console.WriteLine();
    Console.WriteLine("Recommended Orders");
    Console.WriteLine();

    foreach (var order in recomendedOrders)
    {
        Console.WriteLine("ExchangerId: " + order.ExchangerId);
        Console.WriteLine("Price: " + order.Price);
        Console.WriteLine("Amount: " + order.Amount);
        Console.WriteLine("----------");
    }

    Console.WriteLine($"Total amount: {recomendedOrders.Sum(o => o.Amount)}");
    Console.WriteLine($"Total price: {recomendedOrders.Sum(o => o.Price * o.Amount)}");
}
