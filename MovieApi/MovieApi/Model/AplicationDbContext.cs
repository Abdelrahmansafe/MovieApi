using Microsoft.EntityFrameworkCore;

namespace MovieApi.Model
{
    public class AplicationDbContext:DbContext
    {

        public AplicationDbContext(DbContextOptions<AplicationDbContext>options):base(options) {
        
        
        
        
        
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }


    }
}
