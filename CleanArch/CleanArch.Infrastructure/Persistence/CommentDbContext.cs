using CleanArch.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Persistence
{
    public class CommentDbContext : DbContext
    {
        public CommentDbContext()
        {
        }

        public CommentDbContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}
