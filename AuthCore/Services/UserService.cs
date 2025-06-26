using System.Security.Claims;

namespace ShoppyWeb.Services
{
    public class UserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetCurrentUserId()
        {

            var userIdString = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            // Parse to Guid first
            return Guid.Parse(userIdString);
        }
    }
}
