using Microsoft.EntityFrameworkCore;
using ShoppyWeb.Data;
using ShoppyWeb.Models.Repositories.IRepository;
using ShoppyWeb.Services;
using ShoppyWeb.ViewModel;

namespace ShoppyWeb.Models.Repositories
{
    public class RolePermissionsRepository : IRolePermissionsRepository
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserService _userService;
        public RolePermissionsRepository(IServiceScopeFactory scopeFactory, UserService userService, ApplicationDbContext dbContext) {
            _scopeFactory = scopeFactory;
            _dbContext = dbContext;
            _userService = userService;
        }

        public async Task<RolePermissions> CreateUserRolePermission(string RoleId, string PermissionId)
        {
            try
            {
                // Create a new scope for this operation
                using var scope = _scopeFactory.CreateScope();
            var _dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            Guid userId = _userService.GetCurrentUserId();

            DateTime localNow = DateTime.Now;
                var existCount =  _dbContext.RolePermissions.Any(u => (u.PermissionId == Guid.Parse(PermissionId) && u.RoleId == RoleId));

                if (existCount == false)
                {
                    var RolePermission = new RolePermissions
                    {
                        RoleId = RoleId,
                        PermissionId = Guid.Parse(PermissionId),
                        CreatedOn = localNow,
                        ModifiedOn = localNow,
                        CreatedBy = userId.ToString()
                    };
                    _dbContext.RolePermissions.Add(RolePermission);
                    int rowsAffected = await _dbContext.SaveChangesAsync();
                    Console.WriteLine("rowsAffected" + rowsAffected);
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Database updated successfully. {rowsAffected} row(s) affected.");
                        return RolePermission;
                    }
                    else
                    {
                        Console.WriteLine("No changes were saved to the database.");
                        return null;
                    }
                }
                Console.WriteLine("No changes were saved to the database.");
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
        public async Task<List<ListUserPermissionViewModel>> getUserPermissionList(string roleId)
        {
            // Create a new scope for this operation
           // using var scope = _scopeFactory.CreateScope();
           // var _dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var permissions = await (from role in _dbContext.RolePermissions
                                         join perm in _dbContext.Permissions on role.PermissionId equals perm.Id
                                     where role.RoleId == roleId 
                                     select new ListUserPermissionViewModel
                                     {
                                         Id = perm.Id.ToString(),
                                         DispalyName = perm.DispalyName,
                                         PermissionName = perm.PermissionName,
                                         Description = perm.Description
                                     }).ToListAsync();
            return permissions;
        }
    }
}
