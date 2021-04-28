using System.Collections.Generic;
using System.Linq;
using Domain.Exceptions;

namespace Application.Validators.MatrixValidators.Rules
{
    public class AllMatrixRowsMustHaveSameLength : IRule
    {
        private readonly ICollection<string> rows;
        private readonly int lengthOfFirstRow;

        public AllMatrixRowsMustHaveSameLength(
            ICollection<string> rows, 
            int lengthOfFirstRow)
        {
            this.rows = rows;
            this.lengthOfFirstRow = lengthOfFirstRow;
        }

        public string ErrorMessage => "All matrix rows must have the same length.";

        public void Validate()
        {
            var allRowsHaveSameLength = rows.All(x => x.Length == lengthOfFirstRow);

            if(!allRowsHaveSameLength)
            {
                throw new InvalidMatrixException(ErrorMessage);
            }
        }
    }
}
