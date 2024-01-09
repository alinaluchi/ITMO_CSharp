using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ALab5.Database;
using ALab5.Models;
using ALab5.Repository;
using ALab5.Views;
using DynamicData;
using ReactiveUI;

namespace ALab5.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
private readonly AContext _context;
    private readonly IARepository _repository;
    private string _inputWord;
    private bool _isInputValid;
    
    public MainWindowViewModel()
    {
        _context = new AContext();
        _repository = new ARepository(_context);
        var t = _repository.LoadFromDb();
        WordList.AddRange(t);
        WordList = new ObservableCollection<WordDto>(_repository.LoadFromDb());
        Nodes = new ObservableCollection<Node>();
    }

    private void ValidateInput()
    {
        IsInputValid = !string.IsNullOrEmpty(InputWord);
    }

    public bool IsInputValid
    {
        set => this.RaiseAndSetIfChanged(ref _isInputValid, value);
    }
    
    public string InputWord
    {
        get => _inputWord;
        set
        {
            this.RaiseAndSetIfChanged(ref _inputWord, value); 
            ValidateInput();
        }
    }
    


    public ObservableCollection<WordDto> WordList { get; set; } = [];

    public void ShowAddWordDialog()
    {
        var flag = WordList.Where(w => w.Word == InputWord).Aggregate(true, (current, w) => !current);
        if (InputWord != null && flag)
        {
            var dialog = new DialogWindow();
            dialog.DataContext = new DialogViewModel(this, dialog, InputWord);

            dialog.Show();
        }
    }

    

    public async Task AddWord(string word, string construction, string root)
    {
        await Task.Delay(1000);
        var newWord = new WordDto
        {
            Word = word,
            Construction = construction,
            Root = root
        };
        WordList.Add(newWord);
        _repository.SaveToDb(WordList);
    }
    
    public ObservableCollection<Node> Nodes { get; set; }
    
    public void Search()
    {
        var flag = true;
        Nodes.Clear();
        
        
        foreach (var wl in WordList)
        {
            if (wl.Root != InputWord) continue;
            if (flag)
                Nodes.Add(new Node(InputWord, new ObservableCollection<Node>()));
            flag = false;
            Nodes[0].SubNodes.Add(new Node(wl.Construction));
        }
        
    }
}