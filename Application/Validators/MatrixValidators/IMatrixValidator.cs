using System.Collections.Generic;

namespace Application.Validators.MatrixValidators
{
    public interface IMatrixValidator
    {
        void ValidateMatrix(ICollection<string> matrix);
    }
}
