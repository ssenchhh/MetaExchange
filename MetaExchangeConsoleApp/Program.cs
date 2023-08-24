using MetaExchangeConsoleApp.Data.Providers;
using MetaExchangeConsoleApp.Models;
using MetaExchangeConsoleApp.Services;

//var dataProvider = new JsonDataProvider();
var dataProvider = new RowDataProvider<OrderBook>();
var dataService = new DataService<OrderBook>(dataProvider);
var exchangeService = new MetaExchangeService(dataService);
MetaExchangeRequest request = new MetaExchangeRequest();

request.RequestType = AskForType();
request.Amount = AskForAmount();

var recomendedOrders = exchangeService.GetRecommendedOrders(request);

OutputResults();

string AskForType()
{
    Console.Write("Do you want to buy BTC or sell BTC? Enter 'Buy' or 'Sell': ");
    var input = Console.ReadLine();

    if (string.IsNullOrEmpty(input) || (input.Trim().ToLower() != "buy" && input.Trim().ToLower() != "sell"))
    {
        Console.WriteLine("Invalid input try again.");
        input = AskForType();
    }

    return input;
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
