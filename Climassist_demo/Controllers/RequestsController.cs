using Microsoft.AspNetCore.Mvc;
using Climassist_demo.Data;
using Climassist_demo.Models;
using Climassist_demo.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Climassist_demo.Controllers
{
    public class RequestController : Controller
    {
        private readonly WebDbContext _context;
        private readonly UserManager<Users> _userManager;

        public RequestController(WebDbContext context, UserManager<Users> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                int userId = user != null && int.TryParse(user.Id, out int parsedId) ? parsedId : 0;

                var request = new Request
                {
                    UserId = userId,
                    UserName = model.FullName,
                    Email = model.Email,
                    CompanyType = model.CompanyType,
                    Phone = model.Phone,
                    RequestType = model.RequestType,
                    SparePart = model.SparePartType,
                    RecoveryTime = model.RecoveryTime,
                    UnitType = model.UnitType,
                    Message = model.Message
                };

                _context.Requests.Add(request);
                await _context.SaveChangesAsync();

                return RedirectToAction("Show", new { id = request.Id });
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Show(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null) return NotFound();

            return View(request);
        }
    }
}
