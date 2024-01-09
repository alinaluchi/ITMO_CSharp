using ALab4.Model;

namespace ALab4.Services;

public class Validation : IValidation
{
    public void ValidateWord(WordDto wordDto)
    {
        if (wordDto.Word=="" || wordDto.Construction=="" || wordDto.Root=="")
            throw new Exception("Empty fields are not allowed");
    }
}
