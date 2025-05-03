using InventoryManagementSystem.InventoryMSAPIServices.DTOS.AccountDTO;
using InventoryManagementSystem.InventoryMSAPIServices.IServises;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServices services;

        public AccountController(IAccountServices services)
        {
            this.services = services;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IdentityResult> Register(RegisterDto userFromReq)
        {
            return await services.RegisterAsync(userFromReq);
        }

        [HttpPost]
        [Route("Login")]
        public Task<string> Login(LoginDto loginReq)
        {
            return services.LoginAsync(loginReq);
        }
    }
}
