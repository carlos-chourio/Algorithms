using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Mathematics.NumberTheory {
    public class Primes {
        public IEnumerable<int> GetPrimesSieve(int finalNumber) {
            List<int> numbers = new List<int>();
            numbers.AddRange(Enumerable.Range(2, finalNumber-1));
            for (int i = 0; numbers[i] < finalNumber/2; i++) {
                int currentValue = numbers[i] * 2;
                for (int j = i*2; j < numbers.Count; j++) {
                    if (currentValue== numbers[j]) {
                        numbers.RemoveAt(j);j--;
                    } else if (numbers[j] > currentValue) {
                        currentValue += numbers[i];
                    }
                }
            }
            return numbers;
        }
    }
}
