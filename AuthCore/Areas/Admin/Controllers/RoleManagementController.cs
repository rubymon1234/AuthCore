using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppyWeb.Data;
using ShoppyWeb.Models;
using ShoppyWeb.Models.Repositories;
using ShoppyWeb.Models.Repositories.IRepository;
using ShoppyWeb.ViewModel;
using System.Drawing.Printing;
using System.Security.Claims;
namespace ShoppyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleManagementController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IRoleRepository _roleService;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IRolePermissionsRepository _rolepermissionsRepository;
        public RoleManagementController(ApplicationDbContext dbContext, IRoleRepository roleService, IPermissionRepository permissionRepository, IRolePermissionsRepository rolepermissionsRepository)
        {
            _dbContext = dbContext;
            _roleService = roleService;
            _permissionRepository = permissionRepository;
            _rolepermissionsRepository = rolepermissionsRepository;
        }
        public async Task<IActionResult> Index(string searchString, string sortOrder, int pageNumber, string currentFilter)
        {
            int pageSize = 10;
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
            
            return View(await PaginatedList<ListRoleViewModel>.CreateAsync(allRoles, pageNumber, pageSize));
        }
        public async Task<IActionResult> ListPermission(ListPermissionViewModel permission , string searchString, string sortOrder, int pageNumber, string currentFilter)
        {
            int pageSize = 10;
            if (permission == null) {
                return NotFound();
            }
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var allPermissionList = _permissionRepository.getAllPermissionList(permission);
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            return View(await PaginatedList<ListPermissionViewModel>.CreateAsync(allPermissionList, pageNumber, pageSize));

        }
        [HttpGet]
        public IActionResult CreatePermission()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePermission(CreatePermissionViewModel permissionVM)
        {
            if (permissionVM.Id == null)
            {
                permissionVM.Scenario = "Create";
                if (ModelState.IsValid)
                {
                    _permissionRepository.CreatePermission(permissionVM);
                    TempData["success"] = "Permission Added Successfully";
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public async Task<IActionResult> UserPermission(string Id, ListPermissionViewModel permission, string searchString, string sortOrder, int pageNumber, string currentFilter)
        {
            int pageSize = 10;
            if (permission == null)
            {
                return NotFound();
            }
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            TempData["RoleId"] = Id;
            
            var allPermissionList = _permissionRepository.getAllUserPermissionList(permission, Id);
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            var allPermissionListnew = await _rolepermissionsRepository.getUserPermissionList(Id);
            ViewBag.UserRoleList = allPermissionListnew;
            return View(await PaginatedList<ListPermissionViewModel>.CreateAsync(allPermissionList, pageNumber, pageSize));
        }

        [HttpPost]
        public IActionResult UserPermissionAssign(string RoleId, string PermissionId, bool checkbox)
        {
            // RoleId is automatically bound from the AJAX data
            if (string.IsNullOrEmpty(RoleId))
            {
                return BadRequest("RoleId is required");
            }
            if (checkbox)
            {
                _rolepermissionsRepository.CreateUserRolePermission(RoleId, PermissionId);
            }
            // Your logic here
            Console.WriteLine($"RoleId: {RoleId}, Checkbox: {checkbox}");

            return Ok(new { success = true, message = "Permission assigned" });
        }
    }
}
