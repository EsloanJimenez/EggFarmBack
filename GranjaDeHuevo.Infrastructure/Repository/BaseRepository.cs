using GranjaDeHuevo.Domain.Interface.Repository;
using GranjaDeHuevo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IBaseRespository<TEntity> where TEntity : class
    {
        protected readonly AppGranjaDeHuevoContext _context;
        private DbSet<TEntity> _entities;

        public BaseRepository(AppGranjaDeHuevoContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }
        public virtual async Task<TEntity> GetId(int Id)
        {
            return await _entities.FindAsync(Id);
        }

        public virtual async Task Save(TEntity entity)
        {
            _entities.Add(entity);
        }

        public virtual async Task Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        public virtual async Task Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }
        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _entities.AnyAsync(expression);
        }
    }
}
