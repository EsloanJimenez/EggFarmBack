using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Domain.Interface.Repository
{
    public interface IBaseRespository<TEntity> where TEntity : class
    {
        Task<TEntity> GetId(int Id);
        Task Save(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);
    }
}
