using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
http://projecteuler.net/problem=26

A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given:
    1/2	= 	0.5
    1/3	= 	0.(3)
    1/4	= 	0.25
    1/5	= 	0.2
    1/6	= 	0.1(6)
    1/7	= 	0.(142857)
    1/8	= 	0.125
    1/9	= 	0.(1)
    1/10	= 	0.1
Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle.

Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.

http://en.wikipedia.org/wiki/Cyclic_number#Construction_of_cyclic_numbers
 */

namespace Problem_26
{
    class Program
    {
        static void Main(string[] args)
        {
            int longest = 0;
            List<int> primes = GetPrimes(1000);

            foreach (int number in primes)
            {
                int t = 0;
                int r = 1;
                int n = 0;

                do 
                {
                    t = t + 1;
                    int x = r * 10;
                    int d = x / number;
                    r = x % number;
                    n = n * 10 + d;

                    if (t > number / 2)
                    {
                        break;
                    }
                } while (r != 1);

                if (t == number - 1 || t > number/2)
                {
                    longest = number;
                }
            }
            Console.WriteLine("Number below 1000 that produces the longest cyclic fraction is {0}", longest);
            Console.Read();
        }
 
        public static List<int> GetPrimes(int number)
        {
            List<int> primes = new List<int>();
            if (number < 2) return primes;
 
            Dictionary<int, bool> numberdict = new Dictionary<int, bool>();
            for (int i = 3; i < number; i += 2)
            {
                numberdict[i] = true;
            }
 
            primes.Add(2);
 
            int testnumber = 3;
            float numbersqrt = (float)Math.Sqrt(number);
            while (testnumber < numbersqrt)
            {
                if (numberdict[testnumber])
                {
                    primes.Add(testnumber);
                    int multiplier = 2;
                    while (testnumber * multiplier < number)
                    {
                        numberdict[testnumber * multiplier] = false;
                        multiplier++;
                    }
                }
                testnumber += 2;
            }
            while (testnumber < number)
            {
                if (numberdict[testnumber])
                {
                    primes.Add(testnumber);
                }
                testnumber += 2;
            }
 
            return primes;
        }
    }
}
