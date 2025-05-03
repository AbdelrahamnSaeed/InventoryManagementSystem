using InventoryManagementSystem.InventoryMSAPIServices.Enums;

namespace InventoryManagementSystem.InventoryMSAPIServices.DTOS.TransactionDTO
{
    public class TransactionTransfareProduct
    {
        public int ProductId { get; set; }
        public int FromProductWarehouseId { get; set; }
        public int ToProductWarehouseId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        TransactionType TransactionType { get; set; }
    }
}
