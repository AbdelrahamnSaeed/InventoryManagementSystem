using InventoryManagementSystem.InventoryMSAPIServices.DTOS.TransactionDTO;

namespace InventoryManagementSystem.InventoryMSAPIServices.IServises
{
    public interface ITransactionServices
    {

        IEnumerable<GetAllTransactionDto> GetAllTransactions();
        Task<bool> TransactionAdd(TransactionAddProductDto transactionDto);
        Task<bool> TransactionDelete(TransactionRemoveProductDto transactionDto);
        Task<bool> TransactionTransfare(TransactionTransfareProduct transactionDto);

    }
}
