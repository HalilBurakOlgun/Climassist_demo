using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Climassist_demo.Data;
using Climassist_demo.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Climassist_demo.Controllers
{
    public class RequestsController : Controller
    {
        private readonly WebDbContext _context;

        public RequestsController(WebDbContext context)
        {
            _context = context;
        }

        // GET: Requests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Requests/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Requests request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            request.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                _context.Add(request);
                await _context.SaveChangesAsync(); // Veritabanına kaydetme işlemi
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message); // Hata varsa konsola yazdır
                return View(request);
            }

            return RedirectToAction("Index", "Home");
        }


        // GET: Requests/MyRequests
        [Authorize]
        public async Task<IActionResult> MyRequests()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Kullanıcının kendi taleplerini getirin
            var requests = await _context.Requests
                .Where(r => r.UserId == userId)
                .ToListAsync();

            return View(requests);
        }
    }
}
