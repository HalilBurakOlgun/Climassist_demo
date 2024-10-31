using Climassist_demo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Climassist_demo.Data
{
    public class WebDbContext : IdentityDbContext<Users>
    {
        public WebDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Requests> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring the foreign key relationship between Request and Users
            modelBuilder.Entity<Requests>()
                .HasOne(r => r.User)
                .WithMany(u => u.Requests)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Optional: Specify delete behavior
        }
    }
}
