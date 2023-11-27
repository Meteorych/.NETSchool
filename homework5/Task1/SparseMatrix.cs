using System;
using System.Collections;
using System.Text;

namespace Task1
{
    public class SparseMatrix : IEnumerable<long>
    {
        private readonly int _columns;
        private readonly int _rows;
        private Dictionary<(int, int), long> _data;
        
        public SparseMatrix(int rows, int columns)
        {
            if (columns <= 0 || rows <= 0)
            {
                throw new ArgumentException("Wrong arguments! Rows and columns should be greater that zero.");
            }
            _columns = columns;
            _rows = rows;
            _data = new Dictionary<(int, int), long>();
        }

        public long this[int row, int column]
        {
            set
            {
                CheckIndices(row, column);
                _data.Add((row, column), value);
            }
            get
            {
                CheckIndices(row, column);
                return _data.ContainsKey((row, column)) ? _data[(row, column)] : 0L;
            }
        }

        public override string ToString()
        {
            var resultBuilder = new StringBuilder();
            for (var i = 0; i < _rows; i++)
            {
                for (var j = 0; j < _columns; j++)
                {
                    //Очевидна идея использовать просто индексатор при построении строки, но я предполагаю, что таким образом программа будет исполняться быстрее, как минимум из-за остутствия постоянных
                    //обращений к CheckIndices и тесты показали небольшой выигрыш в миллисекундах, поэтому решился на такой эксперимент в данном конкретном случае, заодно интересно
                    //что вы считает насчёт подобной реализации.
                    if (_data.ContainsKey((i, j)))
                    {
                        resultBuilder.Append($" {_data[(i, j)]} ");
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



        public IEnumerator<long> GetEnumerator()
        {
            for (var i = 0; i < _rows; i++)
            {
                for (var j = 0; j < _columns; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<(int, int, long)> GetNonZeroElements()
        {
            var sortedElements = _data.OrderBy(pair => pair.Key.Item2).ThenBy(pair => pair.Key.Item1);
            foreach (var el in sortedElements)
            {
                yield return (el.Key.Item1, el.Key.Item2, el.Value);
            }
        }

        public int GetCount(long x)
        {
            if (x == 0) return _columns * _rows - _data.Count;
            var occurrencesOfValue = _data.Where(pair => pair.Value == x);
            return occurrencesOfValue.Count();

        }

        private void CheckIndices(int row, int column)
        {
            if (row < 0 || row >= _rows || column < 0 || column >= _columns) 
            {
                throw new ArgumentOutOfRangeException(nameof(row));
            }
            
        }

    }
}
