using CRUDWithRepository.Controllers;
using CRUDWithRepository.DAL;
using CRUDWithRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDWithRepository.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {

        private readonly MyAppDbContext _appDbContext;

        public ProductRepository(MyAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task Add(Product product)
        {
            _appDbContext.Products.Add(product);
            await _appDbContext.SaveChangesAsync();
        }

        public Task Add(ProductController product)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            var product = await _appDbContext.Products.FindAsync(id);
            if(product != null)
            {
                _appDbContext.Remove(product);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _appDbContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _appDbContext.Products.ToListAsync();
        }

        public async Task Update(Product product)
        {
            _appDbContext.Entry(product).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }

        public Task Update(object product)
        {
            throw new NotImplementedException();
        }
    }
}
