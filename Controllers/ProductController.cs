using InventoryManagementSystem.InventoryMSAPIServices.DTOS.ProductDTO;
using InventoryManagementSystem.InventoryMSAPIServices.IServises;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServises servises;

        public ProductController(IProductServises servises)
        {
            this.servises = servises;
        }

        [HttpGet]
        [Route("GetProducts")]
        public IEnumerable<GetAllProductDto> GetProducts()
        {
            return servises.GetProducts();
        }

        [HttpGet]
        [Route("GetProductDetails")]
        public async Task<ProductDetailsDto> GetProductDetails(int id)
        {
            return await servises.GetProductDetails(id);
        }

        [HttpPost]
        [Route("AddProduct")]
        [Authorize("Admin")]
        public void AddProduct(AddProductDto product)
        {
             servises.AddProduct(product);
        }


        [HttpPut]
        [Route("UpdateProduct")]
        [Authorize("Admin")]

        public void UpdateProduct(ProductDetailsDto product)
        {
            servises.UpdateProduct(product);
        }


        [HttpDelete]
        [Route("DeleteProducts")]
        [Authorize("Admin")]

        public void DeleteProduct(int id)
        {
            servises.DeleteProduct(id);
        }


    }
}
