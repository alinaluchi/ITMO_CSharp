using ALab4.Model;
using Microsoft.EntityFrameworkCore;

namespace ALab4.DB;

public class AContext:DbContext
{
    public DbSet<WordDto>? WordDtos { get; set; }
    
    public AContext(DbContextOptions<AContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
