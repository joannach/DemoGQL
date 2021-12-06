using DemoGQL.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoGQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(u => u.User!)
                .HasForeignKey(u => u.UserId);

            modelBuilder
                .Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(p => p.Posts!)
                .HasForeignKey(u => u.UserId);
        }
    }
}
