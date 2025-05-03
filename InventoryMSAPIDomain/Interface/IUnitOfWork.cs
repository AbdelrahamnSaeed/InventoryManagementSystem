namespace InventoryManagementSystem.InventoryMSAPIDomain.Interface
{
    public interface IUnitOfWork: IDisposable
    {
        IProductRepository Product {  get; }
        IWarehouseRepository Warehouse { get; }
        IProductWarehouseRepository ProductWarehouse { get; }
        ITransactionRepository Transaction { get; }

        Task<int> SaveAsync();

    }
}
