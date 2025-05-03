using InventoryManagementSystem.InventoryMSAPIDomain.Entities;
using InventoryManagementSystem.InventoryMSAPIDomain.Interface;
using InventoryManagementSystem.InventoryMSAPIServices.DTOS.WarehouseDTO;
using InventoryManagementSystem.InventoryMSAPIServices.IServises;

namespace InventoryManagementSystem.InventoryMSAPIServices.Servises
{
    public class WarehouseServises: IWarehouseServises
    {
        private readonly IUnitOfWork unitOfWork;

        public WarehouseServises(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<GetAllWarehouseDto> GetWarehouses()
        {
            return unitOfWork.Warehouse
                .GetAll()
                .Select(w => new GetAllWarehouseDto
                {
                    Id = w.Id,
                    Name = w.Name,
                    Location = w.Location,
                });
        }

        public async Task<WarehouseDetailsDto> GetWarehouseDetails(int id)
        {
            Warehouse warehouse = await unitOfWork.Warehouse.GetByIdAsync(id);

            return new WarehouseDetailsDto
            {
                Name = warehouse.Name,
                Location = warehouse.Location,
            };
        }

        public  void AddWareouse(AddWareouseDto warehouse)
        {
            Warehouse warehouseToDB = new Warehouse()
            {
                Name = warehouse.Name,
                Location = warehouse.Location,
            };
            unitOfWork.Warehouse.InsertAsync(warehouseToDB);

            unitOfWork.SaveAsync();
        }

        public void UpdateWarehouse(WarehouseDetailsDto warehouse)
        {

            Warehouse warehouseToDB = new Warehouse()
            {
                Name = warehouse.Name,
                Location = warehouse.Location,
            };
            unitOfWork.Warehouse.Update(warehouseToDB);

            unitOfWork.SaveAsync();
        }

        public async void DeleteWarehouse(int id)
        {
            Warehouse warehouse = await unitOfWork.Warehouse.GetByIdAsync(id);
            if (warehouse != null)
            {
                unitOfWork.Warehouse.Delete(warehouse);

                unitOfWork.SaveAsync();
            }
        }

    }
}
