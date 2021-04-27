using Domain.Exceptions;

namespace Application.Validators.MatrixValidators.Rules
{
    public class MatrixMustNotExceedSize : IRule
    {
        private readonly int maxLength;
        private readonly int maxHeight;
        private readonly int actualLength;
        private readonly int actualHeight;

        public MatrixMustNotExceedSize(
            int maxLength, 
            int maxHeight, 
            int actualLength, 
            int actualHeight)
        {
            this.maxLength = maxLength;
            this.maxHeight = maxHeight;
            this.actualLength = actualLength;
            this.actualHeight = actualHeight;
        }

        public string ErrorMessage => "Matrix must not exceed a size of {0}x{1}";

        public void Validate()
        {
            if(!IsValidHeight() || !IsValidHeight())
            {
                var errorMessage = string.Format(ErrorMessage, maxHeight, maxLength);

                throw new InvalidMatrixException(errorMessage);
            }
        }

        private bool IsValidLength()
        {
            return actualLength <= maxLength;
        }

        private bool IsValidHeight()
        {
            return actualHeight <= maxHeight;
        }
    }
}
