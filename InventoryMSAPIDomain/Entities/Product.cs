using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.InventoryMSAPIDomain.Entities
{
    public class Product : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int LowStockThreshold { get; set; }

        public ApplicationUser User { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public Warehouse Warehouse { get; set; }
        [ForeignKey(nameof(Warehouse))]
        public int WarehouseId { get; set; }

    }
}
