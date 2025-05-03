using InventoryManagementSystem.InventoryMSAPIServices.DTOS.WarehouseDTO;
using InventoryManagementSystem.InventoryMSAPIServices.IServises;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseServises servises;

        public WarehouseController( IWarehouseServises servises)
        {
            this.servises = servises;
        }


        [HttpGet]
        [Route("GetWarehouses")]
        public IEnumerable<GetAllWarehouseDto> GetWarehouses() 
        {
            return servises.GetWarehouses();
        }


        [HttpGet]
        [Route("GetWarehouseDetails")]
        public async Task<WarehouseDetailsDto> GetWarehouseDetails(int id)
        {
            return await servises.GetWarehouseDetails(id);
        }


        [HttpPost]
        [Route("AddWarehouse")]
        [Authorize("Admin")]

        public void AddWarehouse(AddWareouseDto warehouse)
        {
            servises.AddWareouse(warehouse);
        }


        [HttpPut]
        [Route("UpdateWarehouse")]
        [Authorize("Admin")]

        public void UpdateWrehouse(WarehouseDetailsDto warehouse)
        {
            servises.UpdateWarehouse(warehouse);
        }


        [HttpDelete]
        [Route("DeleteWarehouse")]
        [Authorize("Admin")]

        public void DeleteWarehouse(int id)
        {
            servises.DeleteWarehouse(id);
        }



    }
}
