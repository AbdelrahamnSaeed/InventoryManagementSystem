using InventoryManagementSystem.InventoryMSAPIDomain.Entities;
using InventoryManagementSystem.InventoryMSAPIDomain.Interface;
using InventoryManagementSystem.InventoryMSAPIInfrastructure.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace InventoryManagementSystem.InventoryMSAPIInfrastructure.Repository
{
    public class ProductWarehouseRepository: GeneralRepository<ProductWarehouse, int>, IProductWarehouseRepository
    {
        public ProductWarehouseRepository(DataBaseContext context) : base(context) { }
    }
}
