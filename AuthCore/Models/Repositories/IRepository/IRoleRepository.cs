using ShoppyWeb.ViewModel;

namespace ShoppyWeb.Models.Repositories.IRepository
{
    public interface IRoleRepository
    {
        IQueryable<ListRoleViewModel> getAllRoles();
    }
}
