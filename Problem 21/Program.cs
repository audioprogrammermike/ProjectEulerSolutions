using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
http://projecteuler.net/problem=21

Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
If d(a) = b and d(b) = a, where a  b, then a and b are an amicable pair and each of a and b are called amicable numbers.

For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

Evaluate the sum of all the amicable numbers under 10000.
*/

namespace Problem_21
{
    class Program
    {
        static void Main(string[] args)
        {
            uint amicablesum = 0;
            int divSumA;
            int divSumB;
            for (int i = 0; i < 10000; i++)
            {
                if (i == 220)
                {
                    Console.WriteLine("Gotcha");
                }
                List<int> divisorsA = ProperDivisors(i);
                divSumA = 0;
                foreach (int div in divisorsA)
                {
                    divSumA += div;
                }

                List<int> divisorsB = ProperDivisors(divSumA);
                divSumB = 0;
                foreach (int div in divisorsB)
                {
                    divSumB += div;
                }

                if (divSumA != i && divSumB == i)
                {
                    amicablesum += (uint)i;
                }
            }
            Console.WriteLine("Sum of amicable numbers below 10000 is {0}", amicablesum);
        }

        static List<int> ProperDivisors(int number)
        {
            int n = 1;
            List<int> divisors = new List<int>();

            while (n <= number / 2)
            {
                if (number % n == 0)
                {
                    divisors.Add(n);
                }
                n++;
            }
            return divisors;
        }
    }
}
