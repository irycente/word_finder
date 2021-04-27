using System.Collections.Generic;

namespace Application.WordFinders
{
    public interface IWordFinder
    {
        IEnumerable<string> FindWords(IEnumerable<string> wordStream);
    }
}
