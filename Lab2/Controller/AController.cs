using ALab2.Model;
using ALab2.View;

namespace ALab2.Controller;

public class AController
{
    private readonly IAView _aView;
    private readonly List<WordDto> _wordList;

    public AController(IAView aView, List<WordDto> wordList) // конструктор
    {
        _aView = aView;
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
    }
}
