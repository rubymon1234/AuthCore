using Microsoft.EntityFrameworkCore;
using ShoppyWeb.Data;
using ShoppyWeb.Models.Repositories.IRepository;
using ShoppyWeb.Services;
using ShoppyWeb.ViewModel;

namespace ShoppyWeb.Models.Repositories
{
    public class CartDetailsRepository : ICartDetailsRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserService _userService;

        public CartDetailsRepository(UserService userService, IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
            _userService = userService;
        }

        public async Task<CartDetails> Create(ProductDetailsVm cartData)
        {
            Guid userId = _userService.GetCurrentUserId();
            //if (userId != Guid.Empty) // Fix: Check if userId is not empty  
            //{
                // Add to cart  
                int totalPrice = cartData.Price * cartData.Quantity;
                CartDetails cartDetails = new CartDetails
                {
                    UserId = userId.ToString(), // Fix: Convert Guid to string for CartDetails.UserId  
                    Quantity = cartData.Quantity,
                    TotalPrice = cartData.Price,
                    Status = "1",
                    PaymentStatus = "pending",
                    ProductId = cartData.pId
                };
                _dbContext.CartDetails.Add(cartDetails);
                await _dbContext.SaveChangesAsync();

                return cartDetails;
            //}

            // Fix: Return null or throw an exception if userId is empty  
           // return null;
        }

        public IQueryable<CartDetailsViewModel> getAllCartDetails()
        {
            //return _dbContext.CartDetails
            //    .Include(c => c.Product)
            //    .Include(c => c.Product.ProductImages)
            //    .Take(100).ToList();
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
