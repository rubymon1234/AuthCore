using Microsoft.EntityFrameworkCore;
using ShoppyWeb.Data;
using ShoppyWeb.Models.Repositories.IRepository;
using ShoppyWeb.Services;
using ShoppyWeb.ViewModel;
using System.Data;

namespace ShoppyWeb.Models.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserService _userService;
        public PermissionRepository(IServiceScopeFactory scopeFactory, ApplicationDbContext dbContext, UserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
            _scopeFactory = scopeFactory;
        }

        public async Task<Permissions> CreatePermission(CreatePermissionViewModel permissionVm)
        {
            try
            {
                // Create a new scope for this operation
            using var scope = _scopeFactory.CreateScope();
            var _dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            Guid userId = _userService.GetCurrentUserId();
            DateTime localNow = DateTime.Now;
            Permissions permissionDetails = new Permissions
            {
                DispalyName = permissionVm.DisplayName,
                PermissionName = permissionVm.PermissionName,
                Description = permissionVm.Discription,
                CreatedOn = localNow,
                ModifiedOn = localNow,
                CreatedBy = userId.ToString()
            };
            _dbContext.Permissions.Add(permissionDetails);
            int rowsAffected = await _dbContext.SaveChangesAsync();
            if (rowsAffected > 0)
            {
                Console.WriteLine($"Database updated successfully. {rowsAffected} row(s) affected.");
                return permissionDetails;
            }
            else
            {
                Console.WriteLine("No changes were saved to the database.");
                return null;
            }
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

        public IQueryable<ListPermissionViewModel> getAllPermissionList(ListPermissionViewModel permission)
        {
            var permissions = from perm in _dbContext.Permissions
                              //.Where(r => r.RoleId == permission.RoleId)
                              select new ListPermissionViewModel
                              {
                                  Id = perm.Id.ToString(),
                                  DispalyName = perm.DispalyName,
                                  PermissionName = perm.PermissionName,
                                  Description = perm.Description
                              };
            return permissions;
        }
        public IQueryable<ListPermissionViewModel> getAllUserPermissionList(ListPermissionViewModel permission ,string RoleId)
        {
            var UserPermissions = from perm in _dbContext.Permissions
                                      //join perm in _dbContext.Permissions on role.Id equals Guid.Parse(RoleId)
                                  //where perm.Id == role.Id
                                  select new ListPermissionViewModel
                              {
                                  Id = perm.Id.ToString(),
                                  DispalyName = perm.DispalyName,
                                  PermissionName = perm.PermissionName,
                                  Description = perm.Description
                              };
            return UserPermissions;
        }
        
    }
}
