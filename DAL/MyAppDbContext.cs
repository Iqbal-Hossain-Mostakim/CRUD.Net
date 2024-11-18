using CRUDWithRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDWithRepository.DAL
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
