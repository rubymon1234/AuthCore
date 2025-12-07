using Microsoft.EntityFrameworkCore;
using ShoppyWeb.Data;
using ShoppyWeb.Models.Repositories.IRepository;
using ShoppyWeb.Services;
using ShoppyWeb.ViewModel;

namespace ShoppyWeb.Models.Repositories
{
    public class CartDetailsRepository : ICartDetailsRepository
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserService _userService;

        public CartDetailsRepository(IServiceScopeFactory scopeFactory, UserService userService, ApplicationDbContext dbContext)
        {
            _scopeFactory = scopeFactory;
            _dbContext = dbContext;
            _userService = userService;
        }

        public async Task<CartDetails> Create(ProductDetailsVm cartData)
        {
            try
            {
                // Create a new scope for this operation
                using var scope = _scopeFactory.CreateScope();
                var _dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                Guid userId = _userService.GetCurrentUserId();
                DateTime localNow = DateTime.Now;
                // Add to cart  
                int totalPrice = cartData.Price * cartData.Quantity;
                CartDetails cartDetails = new CartDetails
                {
                    UserId = userId.ToString(), // Fix: Convert Guid to string for CartDetails.UserId  
                    Quantity = cartData.Quantity,
                    TotalPrice = cartData.Price,
                    Status = "1",
                    PaymentStatus = "pending",
                    ProductId = cartData.pId,
                    CreatedOn = localNow,
                    ModifiedOn = localNow,
                    CreatedBy = userId.ToString()
                };
                 _dbContext.CartDetails.Add(cartDetails);
                int rowsAffected = await _dbContext.SaveChangesAsync();
                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Database updated successfully. {rowsAffected} row(s) affected.");
                    return cartDetails;
                }
                else
                {
                    Console.WriteLine("No changes were saved to the database.");
                }
            return null;
            }
            catch (DbUpdateException ex)
            {
                // Log the detailed error
                Console.WriteLine($"Database error: {ex.InnerException?.Message ?? ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public IQueryable<CartDetailsViewModel> getAllCartDetails()
        {
            //return _dbContext.CartDetails
            //    .Include(c => c.Product)
            //    .Include(c => c.Product.ProductImages)
            //    .Take(100).ToList();
            // Create a new scope for this operation
            var cartDetails = _dbContext.CartDetails.Include(c => c.Product).Include(c => c.Product.ProductImages).Select(
                    cart => new CartDetailsViewModel {
                        Id = cart.Id,
                        ProductName = cart.Product.ProductName,
                        url = cart.Product.ProductImages.First().url,
                        Title = null,
                        Description = null,
                        Quantity = cart.Quantity,
                        TotalPrice = cart.TotalPrice
                    }
                );
            //List< CartDetailsViewModel> cartDetailsViewModels = new List<CartDetailsViewModel>();
            //foreach (var cartDetail in cartDetails)
            //{
            //    var cartDetailsViewModel = new CartDetailsViewModel
            //    {
            //        Id = cartDetail.Id,
            //        ProductName = cartDetail.product.Id,
            //    }

            //        //ProductImages
            //        //Title
            //        //Description
            //        //Quantity
            //        //TotalPrice
            //}
            return cartDetails;
        }
        public List<CartDetails> Get(string cartId)
        {
            return null;
        }
    }
}
