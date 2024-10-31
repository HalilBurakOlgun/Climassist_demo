using Microsoft.AspNetCore.Identity;

namespace Climassist_demo.Models
{
    public enum AccountTypeEnum
    {
        Customer,
        Staff,
        Admin
    }

    public class Users : IdentityUser
    {
        public string Fullname { get; set; } // Ad ve soyadı birleştirin
        public string Surname { get; set; } // Opsiyonel ayrı soyad özelliği

        public AccountTypeEnum AccountType { get; set; } = AccountTypeEnum.Customer; // Varsayılan olarak Customer
    }
}
