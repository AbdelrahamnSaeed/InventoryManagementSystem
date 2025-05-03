using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.InventoryMSAPIDomain.Entities
{
    public class Notification: Entity
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public ApplicationUser User { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        
    }
}
