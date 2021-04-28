using System.Collections.Generic;
using Utils.Extensions;

namespace Domain.ValueObjects
{
    public class MatrixSize
    {
        public MatrixSize(ICollection<string> matrixRows)
        {
            Length = matrixRows.GetLengthOfFirstElement();
            Height = matrixRows.Count;
        }

        public MatrixSize(int height, int length)
        {
            Height = height;
            Length = length;
        }

        public int Height { get; }
        public int Length { get; }
    }
}
