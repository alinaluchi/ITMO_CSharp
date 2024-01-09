using ALab4.Model;

namespace ALab4.Repository;

public interface IARepository
{
    Task Add(WordDto wordDto);
    Task<List<string>> FindRelatedWords(string word);
}
