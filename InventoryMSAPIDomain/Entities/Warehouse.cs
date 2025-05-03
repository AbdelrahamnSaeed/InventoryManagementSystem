using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.InventoryMSAPIDomain.Entities
{
    public class Warehouse : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }       
        public string Location { get; set; }   
        //
        public ApplicationUser User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        //
        public Product Product { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }


    }
}
