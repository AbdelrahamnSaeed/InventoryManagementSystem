namespace InventoryManagementSystem.InventoryMSAPIServices.DTOS.ProductDTO
{
    public class ProductDetailsDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int LowStockThreshold { get; set; }

    }
}
