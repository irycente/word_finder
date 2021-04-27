using System.Collections.Generic;

namespace Domain.Model.Abstractions
{
    public interface IMatrix
    {
        IList<string> Rows { get; }
        IList<string> Columns { get; }
    }
}
