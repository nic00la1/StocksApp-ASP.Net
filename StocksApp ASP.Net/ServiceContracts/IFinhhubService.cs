namespace StocksApp_ASP.Net.ServiceContracts;

public interface IFinhhubService
{
    Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol);
}
