using System.Collections.Generic;
using System.Collections.ObjectModel;
using ALab5.Models;

namespace ALab5.Repository;

public interface IARepository
{
    void SaveToDb(ObservableCollection<WordDto> wordDtos);
    List<WordDto> LoadFromDb();
}
