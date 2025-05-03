using Azure.Core;
using InventoryManagementSystem.InventoryMSAPIDomain.Entities;
using InventoryManagementSystem.InventoryMSAPIServices.DTOS.AccountDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InventoryManagementSystem.InventoryMSAPIServices.Servises
{
    public class AccountServices
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configration;

        public AccountServices(UserManager<ApplicationUser> userManager, IConfiguration configration)
        {
            this.userManager = userManager;
            this.configration = configration;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterDto userFromReq)
        {
            ApplicationUser userForChecked = await userManager.FindByEmailAsync(userFromReq.Email);
            if (userForChecked != null)
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Description = "Email is founded"
                });
            }

            ApplicationUser createUser = new()
            {
                UserName = userFromReq.UserName,
                Email = userFromReq.Email,
                Name = userFromReq.Name,
                PhoneNumber = userFromReq.PhoneNumber,
            };

            IdentityResult resultOfCreation = await userManager.CreateAsync(createUser, userFromReq.Password);
            if (!resultOfCreation.Succeeded) 
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Description = "there are Some Field Info"
                });
            }
    
            return resultOfCreation;
        }

        public async Task<string> LoginAsync(LoginDto loginReq)
        {
            ApplicationUser user = await userManager.FindByNameAsync(loginReq.UserName);
            bool result = await userManager.CheckPasswordAsync(user, loginReq.Password);

            if (!result)
            {
                return null;
            }

            JwtSecurityTokenHandler tokenHandler = new();
            SecurityTokenDescriptor tokenDiscriptor = new()
            {
                Issuer = configration["Jwt:Issure"],
                Audience = configration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configration["Jwt:Issure"])),
                    SecurityAlgorithms.HmacSha256
                ),
                Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.NameIdentifier, loginReq.UserName),
                        new Claim(ClaimTypes.Email , loginReq.UserName),
                        new Claim(ClaimTypes.Role , "Admin")
                    }),
            };
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDiscriptor);
            string token = tokenHandler.WriteToken(securityToken);

            return token;

        }
    }
}
