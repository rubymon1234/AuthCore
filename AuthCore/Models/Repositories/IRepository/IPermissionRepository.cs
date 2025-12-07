using ShoppyWeb.ViewModel;

namespace ShoppyWeb.Models.Repositories.IRepository
{
    public interface IPermissionRepository
    {
        IQueryable<ListPermissionViewModel> getAllPermissionList(ListPermissionViewModel permission);
        Task<Permissions> CreatePermission(CreatePermissionViewModel permissionVm);
        IQueryable<ListPermissionViewModel> getAllUserPermissionList(ListPermissionViewModel permission, string Id);
    }
}
