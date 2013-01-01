using System;

namespace Algorithms.Mathematics.LinearAlgebra {
    public class Matrix {
        private double[,] values;
        public double this [int x, int y] {
            get {
                return values[x,y];
            }
            set {
                values[x,y] = value;
            }
        }

        public int columnSize {
            get { return values.GetLength(0); }
        }

        public int rowSize {
            get { return values.GetLength(1); }
        }

        public Matrix(double[,] values) {
            this.values = values;
        }

        public static Matrix operator + (Matrix matrix1, Matrix matrix2){
            if (matrix1 !=null && matrix2!=null) {
                if (matrix1.rowSize == matrix2.rowSize && matrix1.columnSize == matrix2.columnSize) {
                    double[,] result = new double[matrix1.columnSize, matrix1.rowSize];
                    for (int i = 0; i < matrix1.columnSize; i++) {
                        for (int j = 0; j < matrix1.rowSize; j++) {
                            result[i,j] = matrix1[i,j] + matrix2[i,j];
                        }
                    }
                    return new Matrix(result);
                } 
                throw new ArgumentOutOfRangeException("The Matrices are not the same size");
            }
            throw new ArgumentNullException("At least one of the matrices is null");
        }

        public static Matrix operator - (Matrix matrix1, Matrix matrix2){
            if (matrix1 !=null && matrix2!=null) {
                if (matrix1.rowSize == matrix2.rowSize && matrix1.columnSize == matrix2.columnSize) {
                    double[,] result = new double[matrix1.columnSize, matrix1.rowSize];
                    for (int i = 0; i < matrix1.columnSize; i++) {
                        for (int j = 0; j < matrix1.rowSize; j++) {
                            result[i,j] = matrix1[i,j] - matrix2[i,j];
                        }
                    }
                    return new Matrix(result);
                } 
                throw new ArgumentOutOfRangeException("The Matrices are not the same size");
            }
            throw new ArgumentNullException("At least one of the matrices is null");
        }

        public static Matrix operator * (Matrix matrix, int alfa){
            if (matrix !=null ) {
                for (int i = 0; i < matrix.columnSize; i++) {
                    for (int j = 0; j < matrix.rowSize; j++) {
                        matrix[i,j] = matrix[i,j]*alfa;
                    }
                }
                return matrix;
            }
            throw new ArgumentNullException("The matrix is null");
        }
    }
}