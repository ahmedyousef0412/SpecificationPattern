using Microsoft.EntityFrameworkCore;
using Specification_Pattern.Entitties;

namespace Specification_Pattern.Data;

public class ApplicationDbContext:DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ):base(options)  
    {
        
    }

    public DbSet<Game> Games { get; set; }
    public DbSet<Genre> Genres{ get; set; }
    public DbSet<DLC> DLCs { get; set; }
}
