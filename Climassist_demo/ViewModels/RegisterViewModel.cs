using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Climassist_demo.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "Şifreler eşleşmiyor")]
        public string Password { get; set; }
        [Required(ErrorMessage = " Confirm password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]

        public string ConfirmPassword { get; set; }
    }
}
