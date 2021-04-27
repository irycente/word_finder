using System.Collections.Generic;
using System.Linq;
using Domain.Model.Abstractions;

namespace Domain.Model.Concretions
{
    public class HorizontalMatrix : IMatrix
    {
        private IList<string> columns; 

        public HorizontalMatrix(IEnumerable<string> rows)
        {
            Rows = rows.ToList();
            Height = Rows.Count();
            Length = Height != 0 ? Rows.First().Length : 0;
        }

        public int Length { get; }

        public int Height { get; }

        public IList<string> Rows { get; }

        public IList<string> Columns
        {
            get
            {
                if(columns == null) {

                    columns = new List<string>();

                    for (int x = 0; x < Length; x++)
                    {
                        var column = string.Empty;

                        for (int y = 0; y < Height; y++)
                        {
                            var cell = Rows[y][x];

                            column += cell;
                        }

                        columns.Add(column);
                    }
                }

                return columns;
            }
        }
    }
}
