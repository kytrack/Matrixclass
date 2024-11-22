using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Matrix<T>
    {
        private T[,] data;
        public Matrix(int rows, int cols)
        {
            if (rows <= 0 || cols <= 0)
                throw new ArgumentException("Rows and columns must be positive integers.");

            data = new T[rows, cols];
        }
        public Matrix(int size) : this(size, size)
        {
        }
        public Matrix() : this(3, 3)
        {
        }

        public int Rows => data.GetLength(0);
        public int Columns => data.GetLength(1);

        public override string ToString()
        {
            return string.Join("\n", Enumerable.Range(0, Rows)
                .Select(row => "| " + string.Join(" , ", Enumerable.Range(0, Columns).Select(col => data[row, col]?.ToString())) + " |"));
        }

        public void Fill(T element)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    data[i, j] = element;
                }
            }
        }

        public (int rows, int columns) GetSize() => (Rows, Columns);

        public T this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= Rows || col < 0 || col >= Columns)
                    throw new IndexOutOfRangeException("Index out of range.");
                return data[row, col];
            }
            set
            {
                if (row < 0 || row >= Rows || col < 0 || col >= Columns)
                    throw new IndexOutOfRangeException("Index out of range.");
                data[row, col] = value;
            }
        }

        public static Matrix<T> Add(Matrix<T> A, Matrix<T> B)
        {
            if (A.Rows != B.Rows || A.Columns != B.Columns)
                throw new ArgumentException("Matrices must be the same size to add.");

            var result = new Matrix<T>(A.Rows, A.Columns);

            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < A.Columns; j++)
                {
                    dynamic a = A[i, j];
                    dynamic b = B[i, j];

                    try
                    {
                        result[i, j] = a + b;
                    }
                    catch
                    {
                        throw new InvalidOperationException("Addition only works with numeric types.");
                    }
                }
            }

            return result;
        }

        public void RotateX()
        {
            for (int i = 0; i < Rows / 2; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    var temp = data[i, j];
                    data[i, j] = data[Rows - 1 - i, j];
                    data[Rows - 1 - i, j] = temp;
                }
            }
        }

        public void RotateY()
        {
            for (int j = 0; j < Columns / 2; j++)
            {
                for (int i = 0; i < Rows; i++)
                {
                    var temp = data[i, j];
                    data[i, j] = data[i, Columns - 1 - j];
                    data[i, Columns - 1 - j] = temp;
                }
            }
        }
    }

}
