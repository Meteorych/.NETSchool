namespace Task2
{
    public class DiagonalMatrix
    {
        private int[] _data;
        public int Size => _data.Length;

        public DiagonalMatrix(params int[]? data) //По-моему еще не проходили переменные с поддержкой null (?), но без них первая строчка конструктора же бессмысленна
        {
            data ??= new int[0];
            _data = data;

        }

        public int Track()
        {
            var sum = 0;
            foreach (var element in _data)
            {
                sum += element;
            }
            return sum;
        }

        public int this[int col, int row]
        {
            get
            {
                if (col != row || col > Size || row > Size || row < 0 || col < 0)
                {
                    return 0;
                }
                return _data[col];
            }
            set
            {
                if (col == row && 0 < row && 0 < col && Size > col && Size > row)
                {
                    _data[col] = value;
                }
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is not DiagonalMatrix otherdm)
            {
                return false;
            }

            if (Size != otherdm.Size)
            {
                return false;
            }

            for (var i = 0; i < Size; i++)
            {
                if (this[i, i] != otherdm[i, i])
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            var hash = Size.GetHashCode();

            for (var i = 0; i < Size; i++)
            {
                hash *= 17; //Рекомендовалось в интернете для лучшего распределения
                hash += this[i, i].GetHashCode();
            }

            return hash;
        }

        public override string ToString()
        {
            var result = "";
            for (var i = 0; i < Size; i++)
            {
                result += "[";
                for (var j = 0; j < Size; j++)
                {
                    if (i == j)
                    {
                        result += _data[i].ToString();
                        if (j != Size - 1)
                        {
                            result += " ";
                        }
                    }
                    else
                    {
                        result += "0";
                        if (j != Size - 1)
                        {
                            result += " ";
                        }
                    }
                }
                result += "]\n";
            }
            return result;
        }
    }
    
}
