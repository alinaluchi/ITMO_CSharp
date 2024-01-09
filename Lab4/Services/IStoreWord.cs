using ALab4.Model;

namespace ALab4.Services;

public interface IStoreWord
{
    WordDto SetWord(string word, string construction, string root);
}
