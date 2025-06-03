using System.Diagnostics;
using ShoppyWeb.Data;
using ShoppyWeb.Models;
using ShoppyWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace ShoppyWeb.Areas.Customer.Controllers
{
    [Authorize]
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductView> productView = await(from p in _dbContext.Product
                                                  join img in _dbContext.ProductImages on p.Id equals img.ProductId
                                                  select new ProductView
                                                  {
                                                      ProductName = p.ProductName,
                                                      ProductCode = p.ProductCode,
                                                      Price = p.Price,
                                                      Quantity = p.Quantity,
                                                      Ratings = p.Ratings,
                                                      CreatedOn = p.CreatedOn,
                                                      imageurl = img.url
                                                  }).ToListAsync();
            return View(productView);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
