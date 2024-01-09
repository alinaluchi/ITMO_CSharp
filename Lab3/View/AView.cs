using ALab3.Model;

namespace ALab3.View;

public class AView:IAView
{
    public void QuitInfo()
    {
        Console.WriteLine("Для выхода из программы введите символ 'q'.");
    }

    public string InputWord()
    {
        Console.WriteLine("Введите слово:");
        var input = Console.ReadLine() ?? "";
        if (input == "")
            throw new Exception("Пустая строка недопустима.");
        return input;
    }

    public void ShowRelatedWords(List<string> rw)
    {
        Console.WriteLine("Однокоренные слова:");
        foreach (var w in rw)
        {
            Console.WriteLine(w);
        }
    }

    public string AddWord(string word)
    {
        Console.WriteLine($"Слово '{word}' не найдено в словаре.");
        Console.Write("Хотите добавить его в словарь? (y/n): ");
        var input = Console.ReadLine() ?? "";
        if (input == "" && input != "Y" && input!="y" && input!="N" && input!="n")
            throw new Exception("Пустая строка недопустима.");
        return input;
    }

    public WordDto InputComponents()
    {
        var construction = "";
        Console.Write("Введите приставку: ");
        var prefix = Console.ReadLine() ?? "";
        if (prefix != "")
            construction += prefix + "-";

        Console.Write("Введите корень слова: ");
        var root = Console.ReadLine() ?? "";
        if (root == "")
            throw new Exception("У слова не может не быть корня.");
        construction += root;

        while (true)
        {
            Console.Write("Введите суффикс или окончание: ");
            var suf = Console.ReadLine() ?? "";
            if (suf == "")
                break;
            construction += "-" + suf;
        }

        return new WordDto
        {
            Word = "",
            Construction = construction,
            Root = root
        };
    }

    public void WordHasBeenAdded(string construction)
    {
        Console.WriteLine($"Слово {construction} добавлено");
    }

    public void DoesntMatch()
    {
        Console.WriteLine("Слово и его состав не совпадают.");
    }

    public int Options()
    {
        Console.WriteLine("Выберите способ загрузки и сохранения данных:\n1 - Database\n2 - JSON");
        var isValid = int.TryParse(Console.ReadLine(), out var n);
        if (!isValid || n < 1 || n > 2)
            throw new Exception("Такой опции нет.");
        return n;
    }
}
