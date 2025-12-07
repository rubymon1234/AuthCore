using ShoppyWeb.ViewModel;

namespace ShoppyWeb.Models.Repositories.IRepository
{
    public interface IRolePermissionsRepository
    {
        Task<RolePermissions> CreateUserRolePermission(string RoleId, string PermissionId);

        //Task DeleteUserRolePermision(string RoleId,string PermissionId);
        Task<List<ListUserPermissionViewModel>> getUserPermissionList(string roleId);
    }
}
