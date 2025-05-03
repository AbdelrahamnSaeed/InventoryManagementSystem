using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.InventoryMSAPIDomain.Entities
{
    public class ProductWarehouse : Entity
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey(nameof(Warehouse))]
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
