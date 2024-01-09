using ALab5.Models;
using Microsoft.EntityFrameworkCore;

namespace ALab5.Database;

public class AContext:DbContext
{
    public DbSet<WordDto>? WordDtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Dictionary.db");
    }
}
