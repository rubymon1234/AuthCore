using System.Diagnostics;
using ShoppyWeb.Data;
using ShoppyWeb.Models;
using ShoppyWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.AspNetCore.Authorization;
using ShoppyWeb.Models.Repositories.IRepository;
using ShoppyWeb.Models.Repositories;
using System;
using System.Security.Cryptography;

namespace ShoppyWeb.Areas.Customer.Controllers
{
    [Authorize]
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly IProductRepository _productRepository;
        private readonly ICartDetailsRepository _cartDetailsRepository;

        public HomeController(ILogger<HomeController> logger, 
            ApplicationDbContext dbContext,
            IProductRepository productRepository,
            ICartDetailsRepository cartDetailsRepository)
        {
            _logger = logger;
            _dbContext = dbContext;
            _productRepository = productRepository;
            _cartDetailsRepository = cartDetailsRepository;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductView> productView = await(from p in _dbContext.Product
                                                  join img in _dbContext.ProductImages on p.Id equals img.ProductId
                                                  select new ProductView
                                                  {
                                                      Id=p.Id,
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
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            Product products = _productRepository.GetById(id);

            var ProductDetailsVm = new ProductDetailsVm {
                pId = products.Id,
                pName = products.ProductName,
                pCode = products.ProductCode,
                ImageUrl = products.ProductImages.FirstOrDefault()?.url,
                Price = products.Price,
                CatagoryName = products.ProductCatagory.Name
            };
            return View(ProductDetailsVm);
        }
        [HttpPost]
        public IActionResult Details(ProductDetailsVm productDetailsVm)
        {
            Task<CartDetails> cartDetails = _cartDetailsRepository.Create(productDetailsVm);
            return RedirectToAction("Index");
        }
    }
}
