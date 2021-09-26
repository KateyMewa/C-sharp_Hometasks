using System;
using System.Runtime.Serialization;

namespace Exceptions
{
    [Serializable]
    public class MatrixException : Exception
    {
        public MatrixException()
        {
        }
        public MatrixException(string message) : base(message)
        {
        }
        public MatrixException(string message, Exception innerException) : base(message, innerException)
        {
        }
        protected MatrixException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    public class Matrix
    {
        /// <summary>
        /// Number of rows.
        /// </summary>
        public int Rows
        {
            get { return Array.GetLength(0); }
        }

        /// <summary>
        /// Number of columns.
        /// </summary>
        public int Columns
        {
            get { return Array.GetLength(1); }
        }

        /// <summary>
        /// An array of floating-point values that represents the elements of this Matrix.
        /// </summary>
        public double[,] Array
        {
            get;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when row or column is zero or negative.</exception>
        public Matrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rows), "The parameter is out of range");
            }
            this.Array = new double[rows, columns];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class with the specified elements.
        /// </summary>
        /// <param name="array">An array of floating-point values that represents the elements of this Matrix.</param>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        public Matrix(double[,] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "The array is null");
            }
            this.Array = array;
        }

        /// <summary>
        /// Allows instances of a <see cref="Matrix"/> to be indexed just like arrays.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <exception cref="ArgumentException">Thrown when index is out of range.</exception>
        public double this[int row, int column]
        {
            get
            {
                if (row < 0 || column < 0 || row >= Rows || column >= Columns)
                {
                    throw new ArgumentException("The index is out of range");
                }
                return Array[row, column];
            }
            set
            {
                if (row < 0 || column < 0 || row >= Rows || column >= Columns)
                {
                    throw new ArgumentException("The index is out of range");
                }
                Array[row, column] = value;
            }
        }

        /// <summary>
        /// Adds <see cref="Matrix"/> to the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for adding.</param>
        /// <exception cref="ArgumentNullException">Thrown when parameter is null.</exception>
        /// <exception cref="MatrixException">Thrown when the matrix has the wrong dimensions for the operation.</exception>
        /// <returns><see cref="Matrix"/></returns>
        public Matrix Add(Matrix matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix), "The parameter is null");
            }
            if (this.Rows != matrix.Rows || this.Columns != matrix.Columns)
            {
                throw new MatrixException();
            }
            Matrix result = new Matrix(Rows, Columns);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result[i, j] = this[i, j] + matrix[i, j];
                }
            }
            return result;
        }

        /// <summary>
        /// Subtracts <see cref="Matrix"/> from the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for subtracting.</param>
        /// <exception cref="ArgumentNullException">Thrown when parameter is null.</exception>
        /// <exception cref="MatrixException">Thrown when the matrix has the wrong dimensions for the operation.</exception>
        /// <returns><see cref="Matrix"/></returns>
        public Matrix Subtract(Matrix matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix), "The parameter is null");
            }
            if (this.Rows != matrix.Rows || this.Columns != matrix.Columns)
            {
                throw new MatrixException();
            }
            Matrix result = new Matrix(Rows, Columns);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result[i, j] = this[i, j] - matrix[i, j];
                }
            }
            return result;
        }

        /// <summary>
        /// Multiplies <see cref="Matrix"/> on the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for multiplying.</param>
        /// <exception cref="ArgumentNullException">Thrown when parameter is null.</exception>
        /// <exception cref="MatrixException">Thrown when the matrix has the wrong dimensions for the operation.</exception>
        /// <returns><see cref="Matrix"/></returns>
        public Matrix Multiply(Matrix matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix), "The parameter is null");
            }
            if (Columns != matrix.Rows)
            {
                throw new MatrixException();
            }
            double[,] temp = new double[this.Rows, matrix.Columns];
            Matrix result = new Matrix(temp);
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    for (int k = 0; k < this.Columns; k++)
                    {
                        result[i, j] += this[i, k] * matrix[k, j];
                    }                    
                }
            }
            return result;
        }
    }
}