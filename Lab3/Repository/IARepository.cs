using ALab3.Model;

namespace ALab3.Repository;

public interface IARepository
{
    void SaveToDb(IEnumerable<WordDto> words);
    List<WordDto> LoadFromDb();
    void SaveToJson(List<WordDto> words);
    List<WordDto> LoadFromJson();
}
