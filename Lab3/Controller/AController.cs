using ALab3.Model;
using ALab3.Repository;
using ALab3.View;

namespace ALab3.Controller;

public class AController
{
    private readonly IARepository _aRepository;
    private readonly IAView _aView;
    private List<WordDto> _wordList;

    public AController(IAView aView, IARepository aRepository, List<WordDto> wordList) // конструктор
    {
        _aView = aView;
        _aRepository = aRepository;
        _wordList = wordList;
    }

    public List<string> FindRelatedWords(string keyword)
    {
        return (from w in _wordList where w.Root == keyword select w.Construction).ToList();
    }

    public void AddWord(WordDto wordDto)
    {
        _wordList.Add(wordDto);
    }

    public void Run() // запуск контроллера
    {
        var options = _aView.Options();
        _wordList = options switch
        {
            1 => _aRepository.LoadFromDb(),
            2 => _aRepository.LoadFromJson(),
            _ => _wordList
        };
        _aView.QuitInfo();
        while (true)
        {
            var input = _aView.InputWord();

            if (input.Equals("q", StringComparison.CurrentCultureIgnoreCase))
                break;

            var relatedWords = FindRelatedWords(input);
            if (relatedWords.Count > 0)
                _aView.ShowRelatedWords(relatedWords);
            else
            {
                var choice = _aView.AddWord(input);
                switch (choice)
                {
                    case "y" or "Y":
                    {
                        while (true)
                        {
                            var comp = _aView.InputComponents();

                            if (input == comp.Construction.Replace("-", ""))
                            {
                                comp.Word = input;
                                AddWord(comp);
                                _aView.WordHasBeenAdded(comp.Construction);
                                break;
                            }

                            _aView.DoesntMatch();
                        }

                        break;
                    }
                    case "n" or "N":
                        continue;
                }
            }
        }

        switch (options)
        {
            case 1:
                _aRepository.SaveToDb(_wordList);
                break;
            case 2:
                _aRepository.SaveToJson(_wordList);
                break;
        }
    }
}
