using ALab2.Controller;
using ALab2.Model;
using ALab2.View;

namespace ALab2.Test;

public class UnitTest1
{
    [Fact]
    public void FindRelatedWordsTest()
    {
        var expected = new WordDto
        {
            Word = "диван",
            Construction = "диван",
            Root = "диван"
        };
        var wordList = new List<WordDto>
        {
            new()
            {
                Word = "тумба",
                Construction = "тумб-а",
                Root = "тумб"
            },
            expected,
            new()
            {
                Word = "тумбочка",
                Construction = "тумб-очк-а",
                Root = "тумб"
            }
        };
        var aView = new AView();
        var aController = new AController(aView, wordList);
        Assert.Equal(expected.Construction, aController.FindRelatedWords("диван")[0]);
    }

    [Theory]
    [InlineData("qwerty", "qwe-rty", "qwe")]
    public void AddWordTest(string word, string construction, string root)
    {
        var wordList = new List<WordDto>();
        var aView = new AView();
        var aController = new AController(aView, wordList);
        aController.AddWord(new WordDto{Word = word, Construction = construction, Root = root});
        Assert.Single(wordList);
    }
}
