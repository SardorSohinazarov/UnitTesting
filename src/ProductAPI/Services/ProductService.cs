using ProductAPI.Entities;
using ProductAPI.Exceptions;
using ProductAPI.Repositories;

namespace ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async ValueTask<Product> AddAsync(Product product)
        {
            if(product == null)
            {
                throw new InputNullException();
            }
            var newproduct = await _repository.InsertAsync(product);

            return newproduct;
        }

        public async ValueTask<Product> DeleteAsync(int id)
            => await _repository.RemoveAsync(id);

        public async ValueTask<List<Product>> GetAllAsync()
            => await _repository.SelectAllAsync();
    }
}
