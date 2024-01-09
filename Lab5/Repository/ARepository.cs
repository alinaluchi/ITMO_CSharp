using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ALab5.Database;
using ALab5.Models;

namespace ALab5.Repository;

public class ARepository : IARepository
{
    private readonly AContext _context;

    public ARepository(AContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    public void SaveToDb(ObservableCollection<WordDto> wordDtos)
    {
        _context.WordDtos?.RemoveRange(_context.WordDtos);
        _context.SaveChanges();

        // Добавление новых задач и сохранение изменений
        _context.WordDtos?.AddRange(wordDtos);
        _context.SaveChanges();
    }

    public List<WordDto> LoadFromDb()
    {
        return _context.WordDtos!.ToList();
    }
}
