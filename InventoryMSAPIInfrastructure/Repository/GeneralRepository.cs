using InventoryManagementSystem.InventoryMSAPIDomain;
using InventoryManagementSystem.InventoryMSAPIDomain.Interface;
using InventoryManagementSystem.InventoryMSAPIInfrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace InventoryManagementSystem.InventoryMSAPIInfrastructure.Repository
{
    public class GeneralRepository<TEntity, Tid> : IGenericRepository<TEntity, Tid>
        where TEntity : Entity
        where Tid : IEquatable<int>
    {
        private readonly DataBaseContext context;
        protected readonly DbSet<TEntity> dbSet;


        public GeneralRepository(DataBaseContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }


        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }


        public IQueryable<TEntity> GetAll(bool track = false)
        {
            if (track)
            {
                return dbSet;
            }
            else
            {
                return dbSet.AsNoTracking();
            }
        }


        public async Task<TEntity> GetByIdAsync(int id, bool track = false)
        {
            if (track)
            {
                return await dbSet.FirstOrDefaultAsync(e => e.Id == id);
            }
            else
            {
                return await dbSet.AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id);           
            }
        }


        public async void InsertAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }
        
        
        /*public Task<IEnumerable<TEntity>> GetAllPagination(int pageNumber, int pageSize, Expression<Func<TEntity, object>>? orderExpression = null)
        {
            
        }*/




    }
}
