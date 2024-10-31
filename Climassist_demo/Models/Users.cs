using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

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
        public string Fullname { get; set; }

        // Use enum for AccountType
        public AccountTypeEnum AccountType { get; set; } = AccountTypeEnum.Customer; // Default to Customer

        // Navigation property for related Requests
        public virtual ICollection<Requests> Requests { get; set; } // Collection of Requests
    }
}
