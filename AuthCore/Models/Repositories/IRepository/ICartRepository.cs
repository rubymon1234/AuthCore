using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using SQLitePCL;

namespace ShoppyWeb.Models.Repositories.IRepository
{
    public interface ICartRepository
    {
        Cart Create(Cart cart);
    }
}
