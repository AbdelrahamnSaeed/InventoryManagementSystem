using System.Linq.Expressions;

namespace InventoryManagementSystem.InventoryMSAPIDomain.Interface
{
    public interface IGenericRepository<TEntity, Tid> 
        where TEntity : Entity
        where Tid : IEquatable<int>
    {
        IQueryable<TEntity> GetAll(bool track = false);

        Task<TEntity> GetByIdAsync(int id, bool track = false);

        void InsertAsync(TEntity entity);

        void Delete(TEntity entity);
        void Update(TEntity entity);
        //Task<IEnumerable<TEntity>> GetAllPagination(int pageNumber, int pageSize, Expression<Func<TEntity, object>>? orderExpression = default);

    }
}
