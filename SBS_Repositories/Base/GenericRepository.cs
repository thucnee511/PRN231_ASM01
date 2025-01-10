using Microsoft.EntityFrameworkCore;
using SBS_Repositories.DBContext;
using System.Reflection.Metadata.Ecma335;

namespace SBS_Repositories.Base
{
    public class GenericRepository<T> where T : class
    {
        private DataContext? _context;
        private DbSet<T>? _dbSet;

        protected DataContext Context
        {
            get
            {
                return _context ??= new();
            }
        }

        protected DbSet<T> DbSet
        {
            get
            {
                return _dbSet ??= Context.Set<T>();
            }
        }

        public GenericRepository()
        {
        }

        public Task<List<T>> GetAllAsync() => DbSet.ToListAsync();

        public List<T> GetAll() => DbSet.ToList();

        public T? GetById(object id)
        {
            var entity = DbSet.Find(id);
            if (entity != null)
            {
                Context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity != null)
            {
                Context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public int Insert(T entity)
        {
            DbSet.Add(entity);
            return Context.SaveChanges();
        }

        public async Task<int> InsertAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            return await Context.SaveChangesAsync();
        }

        public int Update(T entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChanges();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return await Context.SaveChangesAsync();
        }

        public int Delete(T entity)
        {
            DbSet.Remove(entity);
            return Context.SaveChanges();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            DbSet.Remove(entity);
            return await Context.SaveChangesAsync();
        }
    }
}
