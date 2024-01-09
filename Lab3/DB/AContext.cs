using ALab3.Model;
using Microsoft.EntityFrameworkCore;

namespace ALab3.DB;

public class AContext:DbContext
{
    public DbSet<WordDto>? WordDtos { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Dictionary.db");
    }
}
