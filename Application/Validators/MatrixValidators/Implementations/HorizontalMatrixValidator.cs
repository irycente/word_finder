using System.Collections.Generic;
using Application.Validators.MatrixValidators.Rules;
using Domain.Constants;
using Domain.ValueObjects;
using Utils.Extensions;

namespace Application.Validators.MatrixValidators.Implementations
{
    public class HorizontalMatrixValidator : IMatrixValidator
    {
        public HorizontalMatrixValidator(ICollection<string> matrix)
        {
            var matrixSize = new MatrixSize(matrix);
            var maxMatrixSize = new MatrixSize(MatrixConstants.MATRIX_MAX_HEIGHT, MatrixConstants.MATRIX_MAX_LENGTH);
            
            Entity = matrix;
            Rules = new List<IRule>
            {
                new AllMatrixRowsMustHaveSameLength(matrix, matrixSize.Length),
                new MatrixMustNotExceedSize(maxMatrixSize, matrixSize)
            };
        }

        public ICollection<string> Entity { get; }

        public ICollection<IRule> Rules { get; }

        public void Validate()
        {
            foreach(var rule in Rules)
            {
                rule.Validate();
            }           
        }
    }
}
