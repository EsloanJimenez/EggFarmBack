using GranjaDeHuevo.Domain.Interface.Repository;
using GranjaDeHuevo.Infrastructure.Context;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Infrastructure.Service
{
    public class BaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRespository<TEntity> _repository;
        private readonly AppGranjaDeHuevoContext _context;

        public BaseService(IBaseRespository<TEntity> respository, AppGranjaDeHuevoContext context)
        {
            _repository = respository;
            _context = context;
        }

        public virtual async Task Save(TEntity entity)
        {
            await _repository.Save(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            await _repository.Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Remove(TEntity entity)
        {
            await _repository.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
