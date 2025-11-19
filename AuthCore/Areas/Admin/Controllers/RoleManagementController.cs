using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppyWeb.Data;
using ShoppyWeb.Models;
using ShoppyWeb.Models.Repositories.IRepository;
using ShoppyWeb.ViewModel;
using System.Drawing.Printing;
namespace ShoppyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleManagementController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IRoleRepository _roleService;
        public RoleManagementController(ApplicationDbContext dbContext, IRoleRepository roleService)
        {
            _dbContext = dbContext;
            _roleService = roleService;
        }
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
            var allRoles = _roleService.getAllRoles();

            // Ensure pageNumber is at least 1
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            int pageSize = 5;
            return View(await PaginatedList<ListRoleViewModel>.CreateAsync(allRoles, pageNumber, pageSize));
        }
    }
}
