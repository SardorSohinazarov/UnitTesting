using ProductAPI.Entities;

namespace ProductAPI.Repositories
{
    public interface IProductRepository
    {
        public ValueTask<Product> InsertAsync(Product product);
        public ValueTask<Product> RemoveAsync(int id);
        public ValueTask<List<Product>> SelectAllAsync();
    }
}
