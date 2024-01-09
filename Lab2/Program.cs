using ALab2.Controller;
using ALab2.Model;
using ALab2.View;

namespace ALab2;

public static class Program
{
    public static void Main(string[] args)
    {
        var wordList = new List<WordDto>();
        var aView = new AView();
        var aController = new AController(aView, wordList);
        aController.Run();
    }
}
