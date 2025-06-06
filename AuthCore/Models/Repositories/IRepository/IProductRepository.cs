namespace ShoppyWeb.Models.Repositories.IRepository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(Guid id);
    }
}
