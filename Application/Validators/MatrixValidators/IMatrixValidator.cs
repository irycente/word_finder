using System.Collections.Generic;

namespace Application.Validators.MatrixValidators
{
    public interface IMatrixValidator
    {
        void Validate(ICollection<string> matrix);
    }
}
