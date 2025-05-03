using InventoryManagementSystem.InventoryMSAPIServices.DTOS.TransactionDTO;
using InventoryManagementSystem.InventoryMSAPIServices.IServises;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionServices services;

        public TransactionController(ITransactionServices services)
        {
            this.services = services;
        }

        [HttpGet]
        [Route("GetTransactions")]
        public IEnumerable<GetAllTransactionDto> GetAllTransactions()
        {
            return services.GetAllTransactions();
        }
        

        [HttpPost]
        [Route("TransactionAdd")]
        [Authorize("Admin")]

        public async Task<bool> TransactionAdd(TransactionAddProductDto transactionDto)
        {
            return await services.TransactionAdd(transactionDto);
        }


        [HttpPut]
        [Route("TransactionTransfare")]
        [Authorize("Admin")]

        public Task<bool> TransactionTransfare(TransactionTransfareProduct transactionDto)
        {
            return services.TransactionTransfare(transactionDto);
        }


        [HttpDelete]
        [Route("TransactionDelete")]
        [Authorize("Admin")]

        public Task<bool> TransactionDelete(TransactionRemoveProductDto transactionDto)
        {
            return services.TransactionDelete(transactionDto);
        }

    }
}
