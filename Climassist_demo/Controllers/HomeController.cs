using Climassist_demo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Climassist_demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<Users> _userManager;

        // UserManager'ı başlatmak için bir yapılandırıcı ekleyin
        public HomeController(UserManager<Users> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = _userManager.FindByNameAsync(User.Identity.Name).Result; // Kullanıcıyı bul
                if (user != null) // Kullanıcıyı kontrol et
                {
                    string greeting = $"Merhaba {user.Fullname} {user.Surname}"; // Ad ve soyad birleştir
                    ViewBag.GreetingMessage = greeting; // Mesajı ViewBag'e ekle
                }
                else
                {
                    // Kullanıcı bulunamazsa, gerekli işlemleri yapabilirsiniz
                    ViewBag.GreetingMessage = "Kullanıcı bulunamadı.";
                }
            }
            return View();
        }
    }
}
