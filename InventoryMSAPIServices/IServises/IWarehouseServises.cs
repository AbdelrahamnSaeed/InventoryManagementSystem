using InventoryManagementSystem.InventoryMSAPIServices.DTOS.WarehouseDTO;

namespace InventoryManagementSystem.InventoryMSAPIServices.IServises
{
    public interface IWarehouseServises
    {
        IEnumerable<GetAllWarehouseDto> GetWarehouses();

        Task<WarehouseDetailsDto> GetWarehouseDetails(int id);

        void AddWareouse(AddWareouseDto warehouse);

        void UpdateWarehouse(WarehouseDetailsDto warehouse);

        void DeleteWarehouse(int id);
    }
}
