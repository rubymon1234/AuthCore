using Microsoft.AspNetCore.Identity;
using ShoppyWeb.Data;
using ShoppyWeb.Models.Repositories.IRepository;

namespace ShoppyWeb.Models.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public CartRepository(IHttpContextAccessor httpContextAccessor,ApplicationDbContext dbContext, UserManager<IdentityUser> userManager) {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
            _userManager = userManager;
        }
        //public async Cart Create(Cart cartData)
        //{
        //    var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        //    Cart cart = new Cart();
        //    cart.UserId = user?.Id;
        //    cart.IsActive = 1;
        //    _dbContext.Cart.Add(cart);
        //    await _dbContext.SaveChangesAsync();
        //    var id = cart.Id;

        //    return cart;
        //}
    }
}
