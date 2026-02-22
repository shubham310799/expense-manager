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
        public DbSet<Expense> Expenses {get; set;}
        public DbSet<ExpenseGroup> ExpenseGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().Property(u => u.UserId).ValueGeneratedOnAdd();

            modelBuilder.Entity<ExpenseGroup>().Property(e => e.GroupId).ValueGeneratedOnAdd();
            modelBuilder.Entity<ExpenseGroup>()
                .HasOne(e => e.User)
                .WithMany(u => u.ExpenseGroups)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
         }
    }
}
