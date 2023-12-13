using Microsoft.EntityFrameworkCore;
using ProductAPI.Entities;

namespace ProductAPI
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
            => Database.Migrate();

        public DbSet<Product> Products { get; set; }
    }
}
