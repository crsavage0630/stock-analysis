using Microsoft.AspNetCore.Mvc;
using StockInfoApp.Core.Services;
using StockInfoApp.Models.Stock;

namespace StockInfoApp.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockInformationService _stockInformationService;

        public StockController(IStockInformationService stockInformationService)
        {
            _stockInformationService = stockInformationService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _stockInformationService.GetStockInfo("UBER");

            var model = new StockModel
            {
                Symbol = result.Symbol,
                RegularMarketPrice = result.RegularMarketPrice
            };

            return View(model);
        }
    }
}
