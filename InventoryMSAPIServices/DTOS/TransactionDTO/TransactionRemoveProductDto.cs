using InventoryManagementSystem.InventoryMSAPIServices.Enums;

namespace InventoryManagementSystem.InventoryMSAPIServices.DTOS.TransactionDTO
{
    public class TransactionRemoveProductDto
    {
        public int ProductId { get; set; }
        public int ProductWarehouseId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        TransactionType TransactionType { get; set; }

    }
}
