using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppyWeb.Data;
using ShoppyWeb.Models;
using ShoppyWeb.Models.Repositories.IRepository;
using ShoppyWeb.ViewModel;

namespace ShoppyWeb.Areas.Customer.Controllers
{
    [Authorize]
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly ICartDetailsRepository _cartDetailsRepository;
        private readonly ApplicationDbContext _dbContext;

        public CartController(ICartDetailsRepository cartDetailsRepository, ApplicationDbContext dbContext)
        {
            

            _cartDetailsRepository = cartDetailsRepository;
            _dbContext = dbContext;
        }
        // GET: CartController
        public async Task<IActionResult> Index(string searchString, string sortOrder, int pageNumber, string currentFilter)
        {
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            var cartDetails = _cartDetailsRepository.getAllCartDetails();

            // Ensure pageNumber is at least 1
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            int pageSize = 5;
            return View(await PaginatedList<CartDetailsViewModel>.CreateAsync(cartDetails, pageNumber, pageSize));
        }

        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public async Task<IActionResult> Plus(Guid cartId)
        {
            //get Cart details
            var cartDetails = await _dbContext.CartDetails.FirstOrDefaultAsync(cd => cd.Id == cartId);
            if (cartDetails.Quantity >1)
            {
                cartDetails.Quantity += 1;
                _dbContext.CartDetails.Update(cartDetails);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                _dbContext.CartDetails.Remove(cartDetails);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Minus(Guid cartId)
        {
            //get Cart details
            var cartDetails = await _dbContext.CartDetails.FirstOrDefaultAsync(cd => cd.Id == cartId);
            if (cartDetails.Quantity > 1)
            {
                cartDetails.Quantity -= 1;
                _dbContext.CartDetails.Update(cartDetails);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                _dbContext.CartDetails.Remove(cartDetails);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteCartItem(Guid cartId)
        {
            //get Cart details
            var cartDetails = await _dbContext.CartDetails.FirstOrDefaultAsync(cd => cd.Id == cartId);
            if (cartDetails != null)
            {
                _dbContext.CartDetails.Remove(cartDetails);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        // GET: CartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
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

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
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
