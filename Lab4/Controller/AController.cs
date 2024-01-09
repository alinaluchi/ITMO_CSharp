using ALab4.Model;
using ALab4.Repository;
using ALab4.Services;
using Microsoft.AspNetCore.Mvc;

namespace ALab4.Controller;

public class AController
{
    private readonly IARepository _aRepository;

    public AController(IARepository aRepository)
    {
        _aRepository = aRepository;
    }

    [HttpPost]
    [Route("/add-word")]
    public Task Add([FromBody] string fake, string word, string construction, string root)
    {
        var validator = new Validation();
        var storeWord = new StoreWord(validator);
        var wm = storeWord.SetWord(word, construction, root);

        return _aRepository.Add(wm);
    }
    
    [HttpGet]
    [Route("/find-related-words")]
    public Task<List<string>> GetRelatedWords(string word)
    {
        return _aRepository.FindRelatedWords(word);
    }
}
