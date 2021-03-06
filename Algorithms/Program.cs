﻿using Algorithms.Mathematics.LinearAlgebra;
using System;

namespace Algorithms {
    class Program {
        static void Main(string[] args) {
            // Primes primeGenerator = new Primes();
            // int finalNumber = 100;
            // var primes = primeGenerator.GetPrimesSieve(finalNumber);
            // int i = 0;
            // Console.WriteLine($"There are {((IList<int>)primes).Count} primes from 2 to {finalNumber}");
            // foreach (var prime in primes) {
            //     Console.WriteLine($"prime {++i}: {prime}");
            // }
            
            TestMatrices();
            Console.ReadKey();
        }

        private static void TestMatrices() {
            Matrix matrix1 = new Matrix(new double[,] {
                {1,4,7},
                {2,5,8},
                {3, 6, 9}
            });
            Matrix matrix2 = new Matrix(new double[,] {
                {1, -1, 2},
                {2, -1, 2},
                {3, -3, 0}
            });
            Matrix result = matrix1 * matrix2; // matrix1 *2;//  matrix2;
            PrintMatrix(result);
        }

         private static void PrintMatrix(Matrix matrix) {
             for (int i = 0; i < matrix.rowSize; i++) {
                 for (int j = 0; j < matrix.columnSize; j++) {
                    Console.Write($"{matrix[i,j]}\t");       
                 }
                 Console.WriteLine();
             }
        }
    }
}
