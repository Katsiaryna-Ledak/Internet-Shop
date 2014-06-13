using EShop.Domain.Entities;
using System.Data.Entity;

namespace EShop.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}