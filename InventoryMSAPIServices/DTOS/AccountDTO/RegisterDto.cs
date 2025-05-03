using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.InventoryMSAPIServices.DTOS.AccountDTO
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber {  get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
