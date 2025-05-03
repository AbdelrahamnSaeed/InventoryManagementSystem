using InventoryManagementSystem.InventoryMSAPIDomain.Interface;
using InventoryManagementSystem.InventoryMSAPIServices.DTOS.TransactionDTO;
using InventoryManagementSystem.InventoryMSAPIServices.IServises;
using InventoryManagementSystem.InventoryMSAPIServices.Enums;
using InventoryManagementSystem.InventoryMSAPIDomain.Entities;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystem.InventoryMSAPIServices.Servises
{
    public class TransactionServices : ITransactionServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;

        public TransactionServices(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }

        public IEnumerable<GetAllTransactionDto> GetAllTransactions()
        {
            return unitOfWork.Transaction.GetAll().Select(t => new GetAllTransactionDto
            {
                Id = t.Id,
                TransactionType = t.TransactionType,
                ProductName = t.Product.Name
            });
        }

        /*public async Task<TransactionDetailsDto> GetTransactionDetails(int id)
        {
            Transaction transaction = await unitOfWork.Transaction.GetByIdAsync(id);
            
            return new TransactionDetailsDto
            {
                Date = transaction.Date,
                TransactionType = transaction.TransactionType,
                ProductName = transaction.Product.Name,
                Quantity = transaction.Quantity,
                UserName = transaction.User.Name,
                WarehouseName = transaction.FromWarehouse.Name,
            };
        }*/

        public async Task<bool> TransactionAdd(TransactionAddProductDto transactionDto)
        {
            if (transactionDto == null)
            {
                return false;
            }
            Product productFromDB = await unitOfWork.Product.GetByIdAsync(transactionDto.ProductId);
            if (productFromDB == null)
            {
                return false;
            }
            productFromDB.Quantity += transactionDto.Quantity;


            ProductWarehouse productWarehouseFromDB = await unitOfWork.ProductWarehouse.GetByIdAsync(transactionDto.ProductWarehouseId);
            if (productWarehouseFromDB == null)
            {
                return false;
            }
            productWarehouseFromDB.Quantity += transactionDto.Quantity;


            ApplicationUser user = await userManager.FindByIdAsync(transactionDto.UserId.ToString());
            if (user == null)
            {
                return false;
            }

            unitOfWork.Transaction.InsertAsync(new Transaction
            {
                TransactionType = TransactionType.ProductAdded,
                Date = DateTime.Now,
                ProductId = transactionDto.ProductId,
                UserId = transactionDto.UserId,
                FromProductWarehouseId = transactionDto.ProductWarehouseId,
                Quantity = transactionDto.Quantity,
            });

            await unitOfWork.SaveAsync();

            return true;
        }

        public async Task<bool> TransactionDelete(TransactionRemoveProductDto transactionDto)
        {
            if(transactionDto.Quantity <= 0)
            { 
                return false; 
            }

            Product productFromDB = await unitOfWork.Product.GetByIdAsync(transactionDto.ProductId);
            if(productFromDB == null) 
            { 
                return false; 
            }
            productFromDB.Quantity -= transactionDto.Quantity;


            ProductWarehouse productWarehouseFromDB = await unitOfWork.ProductWarehouse.GetByIdAsync(transactionDto.ProductWarehouseId);
            if(productWarehouseFromDB == null)
            {
                return false; 
            }
            productWarehouseFromDB.Quantity -= transactionDto.Quantity;


            Transaction transaction = new Transaction
            {
                Date = DateTime.Now,
                TransactionType = TransactionType.ProductDeleted,
                FromProductWarehouseId = transactionDto.ProductWarehouseId,
                Quantity = transactionDto.Quantity,
                UserId= transactionDto.UserId,
                ProductId = transactionDto.ProductId,
            };

            unitOfWork.Transaction.Delete(transaction);
            await unitOfWork.SaveAsync();

            return true;

        }

        public async Task<bool> TransactionTransfare(TransactionTransfareProduct transactionDto)
        {
            if(transactionDto.Quantity <= 0)
            {
                return false;
            }

            Product productFromDB = await unitOfWork.Product.GetByIdAsync(transactionDto.ProductId);
            if (productFromDB == null)
            {
                return false;
            }

            ProductWarehouse FromProductWarehouseDB = await unitOfWork.ProductWarehouse.GetByIdAsync(transactionDto.FromProductWarehouseId);
            if (FromProductWarehouseDB == null)
            {
                return false;
            }
            FromProductWarehouseDB.Quantity -= transactionDto.Quantity;

            ProductWarehouse toProductWarehouseDB = await unitOfWork.ProductWarehouse.GetByIdAsync(transactionDto.ToProductWarehouseId);
            if (toProductWarehouseDB == null)
            {
                return false;
            }
            toProductWarehouseDB.Quantity += transactionDto.Quantity;

            Transaction transaction = new Transaction
            {
                FromProductWarehouseId = transactionDto.FromProductWarehouseId,
                ToProductWarehouseId = transactionDto.ToProductWarehouseId,
                ProductId = transactionDto.ProductId,
                Date = transactionDto.Date,
                Quantity = transactionDto.Quantity,
                TransactionType = TransactionType.ProductTransfare
            };

            unitOfWork.Transaction.Update(transaction);
            await unitOfWork.SaveAsync();

            return true;
             
        }
    }
}