using ALab4.DB;
using ALab4.Model;
using Microsoft.EntityFrameworkCore;

namespace ALab4.Repository;

public class ARepository:IARepository
{
    private readonly AContext _context;

    public ARepository(AContext context)
    {
        _context = context;
    }

    public Task Add(WordDto wordDto)
    {
        if (_context.WordDtos!.Any(w => w.Word == wordDto.Word && w.Construction == wordDto.Construction
                                                               && w.Root == wordDto.Root))
            throw new Exception("Слово уже есть в словаре.");
        _context.WordDtos?.Add(wordDto);
        return _context.SaveChangesAsync();

    }

    public Task<List<string>> FindRelatedWords(string keyword)
    {
        if (!_context.WordDtos!.Any(w => w.Word == keyword)) throw new Exception("Однокоренных слов нет.");
        {
            var wm = _context.WordDtos?.FirstOrDefault(w => w.Word == keyword);
            var root = wm!.Root;
            return  _context.WordDtos!.Where(w => w.Root == root)
                .Select(w => w.Construction)
                .ToListAsync();
        }
    }
}
