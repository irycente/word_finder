using System.Collections;
using System.Collections.Generic;

namespace Application.WordStreamProviders
{
    public interface IWordStreamProvider
    {
        IEnumerable<string> GetValidWordStream();
    }
}
