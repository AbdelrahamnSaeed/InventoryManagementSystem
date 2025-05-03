using InventoryManagementSystem.InventoryMSAPIDomain.Entities;
using InventoryManagementSystem.InventoryMSAPIDomain.Interface;
using InventoryManagementSystem.InventoryMSAPIInfrastructure.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace InventoryManagementSystem.InventoryMSAPIInfrastructure.Repository
{
    public class ProductRepository: GeneralRepository<Product, int> ,IProductRepository
    {

        public ProductRepository(DataBaseContext context) : base(context) { }

    }
}
