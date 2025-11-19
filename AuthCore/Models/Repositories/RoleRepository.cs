using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShoppyWeb.Data;
using ShoppyWeb.Models.Repositories.IRepository;
using ShoppyWeb.ViewModel;

namespace ShoppyWeb.Models.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleRepository(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager) {
            _dbContext = dbContext;
            _roleManager = roleManager;
        }
        public IQueryable<ListRoleViewModel> getAllRoles()
        {
            var roles = _roleManager.Roles.Select(
                    static role => new ListRoleViewModel
                    {
                        //Id = role.Id,
                        Name = role.Name,
                        NormalizedName = role.NormalizedName
                    }
                );

            return roles;
        }
    }
}
