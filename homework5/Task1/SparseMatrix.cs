using System.Text;

namespace Task1
{
    public class SparseMatrix
    {
        private readonly int _columns;
        private readonly int _rows;
        private Dictionary<(int, int), long> _data;
        
        public SparseMatrix(int columns, int rows)
        {
            if (columns <= 0 || rows <= 0)
            {
                throw new ArgumentException("Wrong arguments!");
            }
            _columns = columns;
            _rows = rows;
            _data = new Dictionary<(int, int), long>();
        }

        public long this[int column, int row]
        {
            set
            {
                CheckIndices(column, row);
                _data.Add((column, row), value);
            }
            get
            {
                CheckIndices(column, row);
                return _data.ContainsKey((column, row)) ? _data[(column, row)] : 0L;
            }
        }

        public override string ToString()
        {
            var resultBuilder = new StringBuilder();
            for (var i = 0; i < _rows; i++)
            {
                for (var j = 0; j < _columns; j++)
                {
                    if (_data.ContainsKey((j, i)))
                    {
                        resultBuilder.Append($" {_data[(j, i)]} ");
                    }
                    else
                    {
                        resultBuilder.Append(" 0 ");
                    }
                }
                resultBuilder.Append('\n');
            }
            return resultBuilder.ToString();
        }

        private void CheckIndices(int index1, int index2)
        {
            Check(index1, nameof(index1));
            Check(index2, nameof(index2));
            return;

            void Check(int index, string indexName)
            {
                if (index <= 0 || index > _columns * _rows)
                {
                    throw new ArgumentOutOfRangeException(nameof(indexName));
                }
            }
        }

    }
}
