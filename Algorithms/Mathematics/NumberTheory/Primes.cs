using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Mathematics.NumberTheory {
    public class Primes {
        public IEnumerable<int> GetPrimesSieve(int finalNumber) {
            List<int> numbers = new List<int>();
            numbers.AddRange(Enumerable.Range(2, finalNumber-1));
            int index = 1;
            int currentValue = numbers[0]*2;
            int pivot = numbers[0];
            int fullTurns = 0;
            while (true) {
                if (currentValue == numbers[index]) {
                    numbers.RemoveAt(index);
                } else {
                    if (numbers[index] > currentValue) {
                        currentValue += pivot;
                    }
                    index++;
                }
                if (index == numbers.Count) {
                    if (numbers[fullTurns] > numbers[numbers.Count - 1]/2) {
                        break;
                    }
                    fullTurns++;
                    index = fullTurns;
                    currentValue = numbers[fullTurns]*2;
                    pivot = numbers[fullTurns];
                }
            }
            return numbers;
        }
    }
}
