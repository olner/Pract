using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Pong.PongDbContext
{
    public class DbContextFactory : IDesignTimeDbContextFactory<PongDbContext>
    {
        public PongDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PongDbContext>();
            optionsBuilder.UseMySql("Server=127.0.0.1;Database=ping_pong;port=3306;User Id=root;password=Olegka_2003",
                new MySqlServerVersion(new Version(8, 0, 30)));

            return new PongDbContext(optionsBuilder.Options);
        }
    }
}
