using ProductAPI.Entities;

namespace ProductAPI.Services
{
    public interface IProductService
    {
        public ValueTask<Product> AddAsync(Product product);
        public ValueTask<Product> DeleteAsync(int id);
        public ValueTask<List<Product>> GetAllAsync();
    }
}
