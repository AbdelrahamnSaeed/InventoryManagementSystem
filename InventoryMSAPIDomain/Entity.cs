namespace InventoryManagementSystem.InventoryMSAPIDomain
{
    public class Entity
    {
        public int Id { get; protected set; }

        public Entity() { }

        public Entity(int id) {
        Id = id;
        }
        public DateTime? CreatedAt { get; set; }

        public override bool Equals(object? obj)
        {

            if (obj is Entity entity)
            {
                return Id.Equals(entity.Id);
            }

            return base.Equals(obj);
        }
    }
}
