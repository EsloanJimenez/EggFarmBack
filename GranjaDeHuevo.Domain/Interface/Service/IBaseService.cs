using System.Threading.Tasks;

namespace GranjaDeHuevo.Domain.Interface.Service
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task Save(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
    }
}
