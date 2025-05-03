using InventoryManagementSystem.InventoryMSAPIServices.DTOS.AccountDTO;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystem.InventoryMSAPIServices.IServises
{
    public interface IAccountServices
    {
        Task<IdentityResult> RegisterAsync(RegisterDto userFromReq);

        Task<string> LoginAsync(LoginDto loginReq);
    }
}
