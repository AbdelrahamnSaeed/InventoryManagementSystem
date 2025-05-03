using InventoryManagementSystem.InventoryMSAPIDomain.Entities;
using InventoryManagementSystem.InventoryMSAPIServices.DTOS.ProductDTO;

namespace InventoryManagementSystem.InventoryMSAPIServices.IServises
{
    public interface IProductServises
    {
        void DeleteProduct(int id);

        void AddProduct(AddProductDto productFromReq);

        Task<ProductDetailsDto> GetProductDetails(int id);

        IEnumerable<GetAllProductDto> GetProducts();

        void UpdateProduct(ProductDetailsDto productFromReq);
    }
}
