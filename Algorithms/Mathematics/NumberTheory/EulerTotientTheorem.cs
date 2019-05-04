using System.Collections.Generic;

namespace Algorithms.Mathematics.NumberTheory {
    public class EulerTotientTheorem {
        private readonly Primes primeGenerator;

        public EulerTotientTheorem(Primes primeGenerator) {
            this.primeGenerator = primeGenerator;
        }

        public double PhiEulerFunction(int n) {
            return PhiEulerFunction(n, DecomposeNumberInMultiples(n));
        }

        private double PhiEulerFunction(int n, params int[] p) {
            double mult = 1;
            for (int i = 0; i < p.Length; i++) {
                mult *= 1 - (double) 1 / p[i];
            }
            return mult*n;
        }

        private int[] DecomposeNumberInMultiples(int n) {
            List<int> numbers = new List<int>();
            var primes = (IList<int>)primeGenerator.GetPrimesSieve(n);
            for (int i = 0; i < primes.Count; i++) {
                int currentValue = primes[i];
                if (n % currentValue != 0) {
                    continue;
                } else {
                    numbers.Add(currentValue);
                    n = n / currentValue;
                    if (n == 1) break;
                }              
            }
            return numbers.ToArray();
        }
    }
}
