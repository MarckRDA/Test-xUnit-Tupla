using System.Collections.Generic;
using System.Linq;

namespace Test_tupla_theory
{
    public class TuplaTest
    {
        public int soma((int n1, int n2) numeros)
        {
            return numeros.n1 + numeros.n2;
        }

        public int soma(List<int> numbers)
        {
            int sum = 0;

            foreach (var number in numbers)
            {
                sum += number;                
            }

            return sum;
        }
    }
}