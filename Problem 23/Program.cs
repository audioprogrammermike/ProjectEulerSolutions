using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
http://projecteuler.net/problem=23

A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.

A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.

As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.

Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
*/

namespace Problem_23
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = 28123;
            List<uint> abundantnumbers = new List<uint>();
            uint sum = 0;

            for (int i = 0; i < limit; i++) {
                List<int> factors = ProperDivisors(i);
                int factorsum = 0;

                foreach (int factor in factors)
                {
                    factorsum += factor;
                }

                if (factorsum > i)
                {
                    abundantnumbers.Add((uint)i);
                }
            }

            Dictionary<uint, bool> nonabundantsum = new Dictionary<uint, bool>();
            for(uint i = 0; i < limit; i++) {
                nonabundantsum[i] = true;
            }


            for(int i = 0; i < abundantnumbers.Count; i++)
            {
                uint abundant = abundantnumbers[i];

                for(int j = i; j < abundantnumbers.Count; j++)
                {
                    uint current = abundantnumbers[i] + abundantnumbers[j];
                    if (current < limit)
                    {
                        nonabundantsum[current] = false;
                    }
                }
            }

            foreach(KeyValuePair<uint, bool> pair in nonabundantsum)
            {
                if(pair.Value == true)
                {
                    sum += pair.Key;
                }
            }

            Console.WriteLine("Sum of all abundant numbers below {0} is {1}", limit, sum);
            Console.ReadLine();
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
