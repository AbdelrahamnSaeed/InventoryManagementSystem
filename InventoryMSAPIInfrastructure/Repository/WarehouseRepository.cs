using InventoryManagementSystem.InventoryMSAPIDomain.Entities;
using InventoryManagementSystem.InventoryMSAPIDomain.Interface;
using InventoryManagementSystem.InventoryMSAPIInfrastructure.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace InventoryManagementSystem.InventoryMSAPIInfrastructure.Repository
{
    public class WarehouseRepository: GeneralRepository<Warehouse, int>, IWarehouseRepository
    {
        public WarehouseRepository(DataBaseContext context) : base(context) { } 

    }
}
