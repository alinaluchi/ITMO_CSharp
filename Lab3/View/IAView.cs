using ALab3.Model;

namespace ALab3.View;

public interface IAView
{
    void QuitInfo();
    string InputWord();
    void ShowRelatedWords(List<string> rw);
    string AddWord(string word);
    WordDto InputComponents();
    void WordHasBeenAdded(string construction);
    void DoesntMatch();
    int Options();
}
