using Domain.Exceptions;
using Domain.ValueObjects;

namespace Application.Validators.MatrixValidators.Rules
{
    public class MatrixMustNotExceedSize : IRule
    {
        private readonly MatrixSize maxMatrixSize;
        private readonly MatrixSize matrixSize;

        public MatrixMustNotExceedSize(
            MatrixSize maxMatrixSize, 
            MatrixSize matrixSize)
        {
            this.maxMatrixSize = maxMatrixSize;
            this.matrixSize = matrixSize;
        }

        public string ErrorMessage => "Matrix must not exceed a size of {0}x{1}";

        public void Validate()
        {
            if(!IsValidHeight() || !IsValidLength())
            {
                var errorMessage = string.Format(ErrorMessage, maxMatrixSize.Height, maxMatrixSize.Length);

                throw new InvalidMatrixException(errorMessage);
            }
        }

        private bool IsValidLength()
        {
            return matrixSize.Length <= maxMatrixSize.Length;
        }

        private bool IsValidHeight()
        {
            return matrixSize.Height <= maxMatrixSize.Height;
        }
    }
}
