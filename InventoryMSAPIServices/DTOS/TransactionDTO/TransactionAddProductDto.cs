using InventoryManagementSystem.InventoryMSAPIServices.Enums;
using System.Transactions;

namespace InventoryManagementSystem.InventoryMSAPIServices.DTOS.TransactionDTO
{
    public class TransactionAddProductDto
    {

        public int ProductId { get; set; }
        public int ProductWarehouseId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        TransactionType TransactionType { get; set; }

    }
}
