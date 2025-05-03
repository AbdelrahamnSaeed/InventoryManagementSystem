using InventoryManagementSystem.InventoryMSAPIServices.Enums;

namespace InventoryManagementSystem.InventoryMSAPIServices.DTOS.TransactionDTO
{
    public class GetAllTransactionDto
    {

        public int Id { get; set; }

        public TransactionType TransactionType { get; set; }

        public string ProductName { get; set; }

        public string WarehousetName { get; set; }



    }
}
