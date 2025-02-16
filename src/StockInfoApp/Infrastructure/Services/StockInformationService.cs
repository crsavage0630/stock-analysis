using StockInfoApp.Core.Domain.Securities;
using StockInfoApp.Core.Services;
using YahooFinanceApi;

namespace StockInfoApp.Core.Services
{
    public class StockInformationService : IStockInformationService
    {
        private readonly IObjectMapperService _objectMapperService;

        public StockInformationService(IObjectMapperService objectMapperService)
        {
            _objectMapperService = objectMapperService;
        }

        public async Task<StockInfo> GetStockInfo(string symbol)
        {
            var stock = await Yahoo.Symbols(symbol).QueryAsync();
            var result = stock[symbol];
            StockInfo stockData = _objectMapperService.MapObjects<YahooFinanceApi.Security, StockInfo>(result);
            return stockData;
        }
    }

}
