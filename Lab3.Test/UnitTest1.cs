using ALab3.Controller;
using ALab3.Model;
using ALab3.Repository;
using ALab3.View;
using Moq;

namespace ALab3.Test;

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
        var mock = new Mock<IARepository>();
        mock.Setup(c => c.LoadFromDb()).Returns([]);
        mock.Setup(c => c.LoadFromJson()).Returns([]);
        var aView = new AView();
        var aController = new AController(aView, mock.Object, wordList);
        Assert.Equal(expected.Construction, aController.FindRelatedWords("диван")[0]);
    }

    [Theory]
    [InlineData("qwerty", "qwe-rty", "qwe")]
    public void AddWordTest(string word, string construction, string root)
    {
        var wordList = new List<WordDto>();
        var mock = new Mock<IARepository>();
        mock.Setup(c => c.LoadFromDb()).Returns([]);
        mock.Setup(c => c.LoadFromJson()).Returns([]);
        var aView = new AView();
        var aController = new AController(aView, mock.Object, wordList);
        aController.AddWord(new WordDto { Word = word, Construction = construction, Root = root });
        Assert.Single(wordList);
    }
}
