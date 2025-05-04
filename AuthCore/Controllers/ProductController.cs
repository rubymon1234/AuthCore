using AuthCore.Data;
using AuthCore.Models;
using AuthCore.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Drawing.Drawing2D;
using static AuthCore.Data.ApplicationConst.ApplicationConst;

namespace AuthCore.Controllers
{
    //[Area("Admin")]
    [Authorize(Roles = CustomRole.MasterAdmin + "," + CustomRole.Admin)]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            //ProductView productView = new ProductView();
            var products = await(from p in _dbContext.Product
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

            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            try
            {
                //to get web base path
                ProductImages productImg = new ProductImages();
                product.Ratings = 0;
                string webRootPath = _webHostEnvironment.WebRootPath;
                //retrive file from form
                var file = HttpContext.Request.Form.Files;
                if (file.Count > 0)
                {
                
                string newFileName = Guid.NewGuid().ToString();

                    //to store img in this base path
                    var upload = Path.Combine(webRootPath, @"images\productImage");
                    var extension = Path.GetExtension(file[0].FileName);
                    using (var fileStream = new FileStream(Path.Combine(upload, newFileName + extension), FileMode.Create))
                    {
                        file[0].CopyTo(fileStream);
                    }
                    
                    productImg.url = @"images\brand\" + newFileName + extension;
            }
            if (ModelState.IsValid)
                {
                    _dbContext.Product.Add(product);
                    _dbContext.SaveChanges();
                    //product image save
                    productImg.ProductId = product.Id;
                    _dbContext.ProductImages.Add(productImg);
                    _dbContext.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
