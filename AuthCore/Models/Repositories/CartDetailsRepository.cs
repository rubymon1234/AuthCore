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
            if (userId != Guid.Empty) // Fix: Check if userId is not empty  
            {
                // Add to cart  
                int totalPrice = cartData.Price * cartData.Quantity;
                CartDetails cartDetails = new CartDetails
                {
                    UserId = userId.ToString(), // Fix: Convert Guid to string for CartDetails.UserId  
                    Quantity = cartData.Quantity,
                    TotalPrice = totalPrice,
                    Status = "1",
                    PaymentStatus = "pending",
                    ProductId = cartData.pId
                };
                _dbContext.CartDetails.Add(cartDetails);
                await _dbContext.SaveChangesAsync();

                return cartDetails;
            }

            // Fix: Return null or throw an exception if userId is empty  
            return null;
        }
    }
}
