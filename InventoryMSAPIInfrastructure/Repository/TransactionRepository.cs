using InventoryManagementSystem.InventoryMSAPIInfrastructure.Context;
using InventoryManagementSystem.InventoryMSAPIDomain.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using InventoryManagementSystem.InventoryMSAPIDomain.Interface;

namespace InventoryManagementSystem.InventoryMSAPIInfrastructure.Repository
{
    public class TransactionRepository:GeneralRepository<Transaction, int>, ITransactionRepository
    {

        public TransactionRepository(DataBaseContext context) : base(context) { }

    }
}
