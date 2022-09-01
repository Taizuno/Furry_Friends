using FurryFriends.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FurryFriends.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<PostEntity> Post { get; set; }
        public DbSet<CommentEntity> Comment { get; set; }
        public DbSet<ReplyEntity> Reply { get; set; }

    }
}