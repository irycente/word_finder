using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Application.Validators.MatrixValidators.Implementations;

namespace Application.MatrixProviders.Implementations
{
    public class FileHorizontalMatrixProvider : IMatrixProvider
    {
        private readonly string filePath;

        public FileHorizontalMatrixProvider(string filePath)
        {
            this.filePath = filePath;
        }

        public IEnumerable<string> GetValidMatrix()
        {
            var matrix = GetMatrix();

            ValidateMatrix(matrix);

            return matrix;
        }

        private IEnumerable<string> GetMatrix()
        { 
            // TO-DO: Extract file reading to helper.
            var fileLines = File.ReadAllLines(filePath, Encoding.UTF8);

            return fileLines.ToList();
        }

        private void ValidateMatrix(IEnumerable<string> matrix)
        {
            var matrixValidator = new HorizontalMatrixValidator(matrix.ToList());

            matrixValidator.Validate();            
        }
    }
}
