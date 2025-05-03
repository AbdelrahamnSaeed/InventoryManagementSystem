using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.InventoryMSAPIDomain.Entities
{
    public class ApplicationUser: IdentityUser<int>
    {
        public string Name { get; set; }

        [ForeignKey(nameof(Warehouse))]
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

    }
}
