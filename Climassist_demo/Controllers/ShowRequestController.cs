using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Climassist_demo.Data;
using Climassist_demo.Models;
using System.Linq;

namespace Climassist_demo.Controllers
{
    [Authorize]
    public class ShowRequestController : Controller
    {
        private readonly WebDbContext _context;
        private readonly UserManager<Users> _userManager;

        public ShowRequestController(WebDbContext context, UserManager<Users> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Show()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var requests = _context.Requests.AsQueryable();

            if (user.AccountType == AccountTypeEnum.Customer)
            {
                requests = requests.Where(r => r.UserName == user.UserName); // Sadece kendi taleplerini görebilir
            }

            return View(requests.ToList());
        }
    }
}
