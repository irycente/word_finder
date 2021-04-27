using System.Collections.Generic;
using Application.Validators.MatrixValidators.Rules;
using Domain.Constants;
using Utils.Extensions;

namespace Application.Validators.MatrixValidators.Implementations
{
    public class HorizontalMatrixValidator : IMatrixValidator
    {
        private readonly ICollection<IRule> rules;

        // TO-DO: Create value object for matrix size.
        public HorizontalMatrixValidator(ICollection<string> matrixRows)
        {
            var length = matrixRows.GetLengthOfFirstElement();
            var height = matrixRows.Count;

            rules = new List<IRule>
            {
                new AllMatrixRowsMustHaveSameLength(matrixRows, length),
                new MatrixMustNotExceedSize(MatrixConstants.MATRIX_MAX_LENGTH, MatrixConstants.MATRIX_MAX_HEIGHT, length, height)
            };

        }

        public void Validate(ICollection<string> matrix)
        {
            foreach(var rule in rules)
            {
                rule.Validate();
            }           
        }
    }
}
