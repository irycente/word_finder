using System.Collections.Generic;

namespace Application.MatrixProviders
{
    public interface IMatrixProvider
    {
        IEnumerable<string> GetValidMatrix();                
    }
}
