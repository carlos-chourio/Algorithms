using System;

namespace Algorithms.Mathematics.LinearAlgebra {
    public class Matrix {
        private double[,] values;
        public double this[int row, int column] {
            get {
                return values[row, column];
            }
            set {
                values[row, column] = value;
            }
        }

        public int columnSize {
            get { return values.GetLength(1); }
        }

        public int rowSize {
            get { return values.GetLength(0); }
        }

        public Matrix(double[,] values) {
            this.values = values;
        }

        public Matrix(int rowSize, int columnSize) {
            values = new double[rowSize,columnSize ];
        }

        public static Matrix operator + (Matrix matrix1, Matrix matrix2) {
            return Sum(matrix1, matrix2, false);
        }

        public static Matrix operator - (Matrix matrix1, Matrix matrix2) {
            return Sum(matrix1, matrix2, true);
        }

        public static Matrix operator *(Matrix matrix, int alfa) {
            if (matrix != null) {
                for (int i = 0; i < matrix.rowSize; i++) {
                    for (int j = 0; j < matrix.columnSize; j++) {
                        matrix[i, j] = matrix[i, j] * alfa;
                    }
                }
                return matrix;
            }
            throw new ArgumentNullException("The matrix is null");
        }

        public static Matrix Sum(Matrix matrix1, Matrix matrix2, bool isSubtraction) {
            if (matrix1 != null && matrix2 != null) {
                if (matrix1.rowSize == matrix2.columnSize && matrix1.rowSize == matrix2.columnSize) {
                    double[,] result = new double[matrix1.rowSize, matrix1.columnSize];
                    for (int i = 0; i < matrix1.rowSize; i++) {
                        for (int j = 0; j < matrix1.columnSize; j++) {
                            result[i, j] = (isSubtraction)
                                ? matrix1[i, j] - matrix2[i, j]
                                : matrix1[i, j] + matrix2[i, j];
                        }
                    }
                    return new Matrix(result);
                }
                throw new ArgumentOutOfRangeException("The Matrices are not the same size");
            }
            throw new ArgumentNullException("At least one of the matrices is null");
        }

        public Matrix Transpose() {
            Matrix resultMatrix = new Matrix(columnSize, rowSize);
            for (int i = 0; i < rowSize; i++) {
                for (int j = 0; j < columnSize; j++) {
                    resultMatrix[j, i] = this[i, j];
                }
            }
            return resultMatrix;
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2) {
            if (matrix1 != null && matrix2 != null) {
                if (matrix1.columnSize == matrix2.rowSize) {
                    Matrix resultMatrix = new Matrix(matrix1.rowSize, matrix2.columnSize);
                    resultMatrix.Zero();
                    for (int i = 0; i < matrix1.rowSize; i++) {
                        for (int j = 0; j < matrix2.rowSize; j++) {
                            for (int k = 0; k < matrix1.rowSize; k++) {
                                resultMatrix[i, j] = resultMatrix[i, j] + matrix1[i, k] * matrix2[k, j]; 
                            }
                        }
                        Console.WriteLine();
                    }
                    return resultMatrix;
                }
                throw new ArgumentOutOfRangeException("These matrices can't be multiplied");
            }
            throw new ArgumentNullException("At least one of the matrices is null");
        }
        
        public Matrix Zero() {
            for (int i = 0; i < rowSize; i++) {
                for (int j = 0; j < columnSize; j++) {
                    this[i, j] = 0;
                }
            }
            return this;
        }
    }
}