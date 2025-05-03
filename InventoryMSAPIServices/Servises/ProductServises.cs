using InventoryManagementSystem.InventoryMSAPIDomain.Entities;
using InventoryManagementSystem.InventoryMSAPIDomain.Interface;
using InventoryManagementSystem.InventoryMSAPIServices.DTOS.ProductDTO;
using InventoryManagementSystem.InventoryMSAPIServices.IServises;

namespace InventoryManagementSystem.InventoryMSAPIServices.Servises
{
    public class ProductServises: IProductServises
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductServises(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        public IEnumerable<GetAllProductDto> GetProducts()
        {

            return unitOfWork.Product.GetAll().Select(p => new GetAllProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
            });

        }

        public async Task<ProductDetailsDto> GetProductDetails(int id)
        {

            Product productFomDB =await unitOfWork.Product.GetByIdAsync(id);

            return new ProductDetailsDto
            {
                Name = productFomDB.Name,
                Price = productFomDB.Price,
                Description = productFomDB.Description,
                Quantity = productFomDB.Quantity,
                LowStockThreshold = productFomDB.LowStockThreshold,
            };
        }

        public void AddProduct(AddProductDto productFromReq)
        {

            Product productToDB = new Product()
            {
                Name = productFromReq.Name,
                Price = productFromReq.Price,
                Description = productFromReq.Description,
                Quantity = productFromReq.Quantity,
                LowStockThreshold = productFromReq.LowStockThreshold,
            };

            unitOfWork.Product.InsertAsync(productToDB);
            unitOfWork.SaveAsync();
        }

        public async void DeleteProduct(int id)
        {
            Product product = await unitOfWork.Product.GetByIdAsync(id);
            if (product != null)
            {
                unitOfWork.Product.Delete(product);
            }
            unitOfWork.SaveAsync();
        }

        public void UpdateProduct(ProductDetailsDto productFromReq)
        {
            Product productToDB = new Product
            {
                Name = productFromReq.Name,
                Price = productFromReq.Price,
                Description = productFromReq.Description,
                Quantity = productFromReq.Quantity,
                LowStockThreshold= productFromReq.LowStockThreshold,

            };

            unitOfWork.Product.Update(productToDB);

            unitOfWork.SaveAsync();

        }

    }
}
