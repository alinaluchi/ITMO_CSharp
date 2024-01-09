using System.ComponentModel.DataAnnotations;

namespace ALab4.Model;

public class WordDto
{
    [Key]
    public int Id { get; set; }
    public string Word { get; set; }
    public string Construction { get; set; }
    public string Root { get; set; }
}
