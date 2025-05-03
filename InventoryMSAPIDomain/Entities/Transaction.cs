using System.ComponentModel.DataAnnotations.Schema;
using InventoryManagementSystem.InventoryMSAPIServices.Enums;
namespace InventoryManagementSystem.InventoryMSAPIDomain.Entities
{
    public class Transaction : Entity
    {

        public int Id { get; set; }

        public TransactionType TransactionType { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; } 


        [ForeignKey("User")]
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }


        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }


        public ProductWarehouse FromProductWarehouse { get; set; }
        [ForeignKey(nameof(FromProductWarehouse))]
        public int? FromProductWarehouseId { get; set; }


        public ProductWarehouse ToProductWarehouse { get; set; }
        [ForeignKey(nameof(ToProductWarehouse))]
        public int? ToProductWarehouseId { get;set; }

    }
}
