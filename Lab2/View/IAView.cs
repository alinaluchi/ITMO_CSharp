using ALab2.Model;

namespace ALab2.View;

public interface IAView
{
    void QuitInfo();
    string InputWord();
    void ShowRelatedWords(List<string> rw);
    string AddWord(string word);
    WordDto InputComponents();
    void WordHasBeenAdded(string construction);
    void DoesntMatch();
}
