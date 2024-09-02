using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entities.Concrete;

namespace MultiShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        public CommentContext(DbContextOptions<CommentContext> options) : base(options)
        {

        }

        public DbSet<UserComment> UserComments { get; set; }

    }
}
