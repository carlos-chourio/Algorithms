using Algorithms.Mathematics.NumberTheory;
using System;
using System.Collections.Generic;

namespace Algorithms {
    class Program {
        static void Main(string[] args) {
            Primes primeGenerator = new Primes();
            int finalNumber = 100;
            var primes = primeGenerator.GetPrimesSieve(finalNumber);
            int i = 0;
            Console.WriteLine($"There are {((IList<int>)primes).Count} primes from 2 to {finalNumber}");
            foreach (var prime in primes) {
                Console.WriteLine($"prime {++i}: {prime}");
            }
            Console.ReadKey();
        }
    }
}
