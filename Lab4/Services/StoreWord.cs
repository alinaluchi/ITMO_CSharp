using ALab4.Model;
using ALab4.Services;

namespace ALab4.Services;

public class StoreWord : IStoreWord
{
    private readonly IValidation _validator;
    public StoreWord(IValidation validator)
    {
        _validator = validator;
    }
    
    public WordDto SetWord(string word, string construction, string root)
    {
        var wordDto = new WordDto{Word = word, Construction = construction, Root = root};

        _validator.ValidateWord(wordDto);
        return wordDto;

    }
}
