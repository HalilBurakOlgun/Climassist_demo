using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Climassist_demo.Models;

namespace Climassist_demo.Controllers
{
    [Authorize] // Kullanıcı giriş yapmış olmalı
    public class UserInfoController : Controller
    {
        private readonly UserManager<Users> _userManager; // UserManager kullanarak kullanıcı bilgilerini yönetin

        public UserInfoController(UserManager<Users> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Kullanıcı kimliğini al
            var user = await _userManager.FindByIdAsync(userId); // Kullanıcıyı veritabanından çek

            if (user == null)
            {
                return NotFound(); // Kullanıcı bulunamazsa 404 döndür
            }

            return View(user); // Kullanıcı bilgilerini görüntüle
        }
    }
}
