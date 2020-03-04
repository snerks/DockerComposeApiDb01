using Microsoft.EntityFrameworkCore;

namespace DockerComposeApiDb01.Models
{
    public class ColourContext : DbContext
    {
        public ColourContext(DbContextOptions<ColourContext> options) : base(options)
        {

        }

        public DbSet<Colour> ColourItems { get; set; }
    }
}