
using CRUDWithRepository.DAL;

namespace CRUDWithRepository.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyAppDbContext _appDbContext;
        public IProductRepository ProductRepository { get; private set; }
        public UnitOfWork(MyAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            ProductRepository = new ProductRepository(_appDbContext);
        }

        public async Task<int> SaveASync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
