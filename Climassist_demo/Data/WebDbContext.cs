using Microsoft.EntityFrameworkCore;
using Climassist_demo.Models;

namespace Climassist_demo.Data
{
    public class WebDbContext : DbContext
    {
        public WebDbContext(DbContextOptions<WebDbContext> options) : base(options) { }

        public DbSet<Request> Requests { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
