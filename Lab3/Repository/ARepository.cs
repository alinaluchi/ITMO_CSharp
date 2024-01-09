using ALab3.DB;
using ALab3.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ALab3.Repository;

public class ARepository:IARepository
{
    private readonly string _jsonFilePath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "dictionary.json");

    private readonly AContext _context = new();

    public ARepository()
    {
        _context.Database.EnsureCreated();
    }

    public void SaveToDb(IEnumerable<WordDto> words)
    {
        _context.WordDtos?.RemoveRange(_context.WordDtos);
        _context.SaveChanges();
        _context.WordDtos?.AddRange(words);
        _context.SaveChanges();
    }
    
    public List<WordDto> LoadFromDb()
    {
        return _context.WordDtos!.ToList();
    }

    public void SaveToJson(List<WordDto> words)
    {
        var jsonData = JsonConvert.SerializeObject(words, Formatting.Indented);
        File.WriteAllText(_jsonFilePath, jsonData);
    }

    public List<WordDto> LoadFromJson()
    {
        File.Create(_jsonFilePath).Close();

        var jsonData = File.ReadAllText(_jsonFilePath);
        var data = JsonConvert.DeserializeObject<List<WordDto>>(jsonData) ?? [];

        return data.Select(wordDto => new WordDto
            { Word = wordDto.Word, Construction = wordDto.Construction, Root = wordDto.Root }).ToList();
    }
}
