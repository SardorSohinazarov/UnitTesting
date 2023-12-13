using Microsoft.EntityFrameworkCore;
using ProductAPI.Entities;
using ProductAPI.Exceptions;

namespace ProductAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
            => _context = context;

        public async ValueTask<Product> InsertAsync(Product product)
        {
            var storageProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);

            if (storageProduct != null)
                throw new DublicateKeyException();

            var entry = await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public async ValueTask<Product> RemoveAsync(int id)
        {
            var storageProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (storageProduct == null)
                throw new NotFoundProductException();

            var entry = _context.Products.Remove(storageProduct);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public async ValueTask<List<Product>> SelectAllAsync()
            => await _context.Products.ToListAsync();
    }
}
