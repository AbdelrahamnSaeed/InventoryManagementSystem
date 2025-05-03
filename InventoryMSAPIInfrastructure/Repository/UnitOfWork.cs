using InventoryManagementSystem.InventoryMSAPIDomain.Interface;
using InventoryManagementSystem.InventoryMSAPIInfrastructure.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace InventoryManagementSystem.InventoryMSAPIInfrastructure.Repository
{
    public class UnitOfWork(DataBaseContext context) : IUnitOfWork
    {
        private readonly DataBaseContext _context = context;

       
        public IProductRepository Product => new ProductRepository(context);

        public IWarehouseRepository Warehouse => new WarehouseRepository(context);

        public IProductWarehouseRepository ProductWarehouse => new ProductWarehouseRepository(context);

        public ITransactionRepository Transaction => new TransactionRepository(context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
