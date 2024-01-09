using ALab3.Controller;
using ALab3.Model;
using ALab3.Repository;
using ALab3.View;

namespace ALab3;

public static class Program
{
    public static void Main(string[] args)
    {
        var aRepository = new ARepository();
        var wordList = new List<WordDto>();
        var aView = new AView();
        var aController = new AController(aView, aRepository, wordList);
        aController.Run();
    }
}
