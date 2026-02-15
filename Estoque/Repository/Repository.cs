using Microsoft.EntityFrameworkCore;
using Estoque.Data;

namespace Estoque.Repository
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class 
    {
        
        protected readonly AppDbContext _appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _appDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _appDbContext.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _appDbContext.Set<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Remove(entity);
        }


        public Task SaveChangesAsync()
        {
            return _appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
  
}
