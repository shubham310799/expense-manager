using ExpenseManager_Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager_Backend.Datebase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().Property(u => u.UserId).ValueGeneratedOnAdd();     
         }
    }
}
