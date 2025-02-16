using StockInfoApp.Core.Domain.Securities;

namespace StockInfoApp.Core.Services
{
    public interface IStockInformationService
    {
        Task<StockInfo> GetStockInfo(string symbol);
    }

}
