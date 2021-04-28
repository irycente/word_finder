using System.Collections.Generic;

namespace Application.Validators.MatrixValidators
{
    public interface IValidator<T>
    {
        T Entity { get; }
        ICollection<IRule> Rules { get; }

        void Validate();
    }
}