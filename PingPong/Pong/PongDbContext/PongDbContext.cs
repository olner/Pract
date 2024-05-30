using Microsoft.EntityFrameworkCore;
using Pong.PongDbContext.Tables;

namespace Pong.PongDbContext
{
    public class PongDbContext : DbContext
    {
        public DbSet<Messages> Messages {get;set;}
        public DbSet<Users> Users { get; set; }
        public PongDbContext(DbContextOptions<PongDbContext> connection) : base(connection) { }
    }
}
