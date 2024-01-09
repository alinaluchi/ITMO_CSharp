using System.ComponentModel.DataAnnotations;
using ReactiveUI;

namespace ALab5.Models;

public class WordDto:ReactiveObject
{
    [Key]
    public int Id { get; set; }
    
    
    private string _word;
    public string Word
    {
        get => _word;
        set => this.RaiseAndSetIfChanged(ref _word, value);
    }
    
    private string _construction;
    public string Construction
    {
        get => _construction;
        set => this.RaiseAndSetIfChanged(ref _construction, value);
    }
    
    private string _root;
    public string Root
    {
        get => _root;
        set => this.RaiseAndSetIfChanged(ref _root, value);
    }
}