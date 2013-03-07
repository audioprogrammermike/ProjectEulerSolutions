using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
 *
 * If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?
 *
 * NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. The use of "and" when writing out numbers is in compliance with British usage.
 * http://projecteuler.net/problem=17
*/

namespace Problem_17
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numlengths = new Dictionary<int, int>()
            {
                {0, "zero".Length },
                {1, "one".Length },
                {2, "two".Length },
                {3, "three".Length },
                {4, "four".Length },
                {5, "five".Length },
                {6, "six".Length },
                {7, "seven".Length },
                {8, "eight".Length },
                {9, "nine".Length },
                {10, "ten".Length },
                {11, "eleven".Length },
                {12, "twelve".Length },
                {13, "thirteen".Length },
                {14, "fourteen".Length },
                {15, "fifteen".Length },
                {16, "sixteen".Length },
                {17, "seventeen".Length },
                {18, "eighteen".Length },
                {19, "nineteen".Length },
                {20, "twenty".Length },
                {30, "thirty".Length },
                {40, "forty".Length },
                {50, "fifty".Length },
                {60, "sixty".Length },
                {70, "seventy".Length },
                {80, "eighty".Length },
                {90, "ninety".Length },
                {1000, "onethousand".Length}
            };

            int totallettercount = 0;
            for (int num = 1; num <= 1000; num++)
            {
                int lettercount = 0;

                if (num <= 20 || num == 1000) lettercount += numlengths[num];
                else
                {
                    int digit = num % 10;
                    int hundreds = num / 100;
                    int tens = num - (100 * hundreds) - digit;
                    if (tens < 20)
                    {
                        digit += tens;
                        tens = 0;
                    }

                    if (digit > 0) lettercount += numlengths[digit];
                    if (tens > 0) lettercount += numlengths[tens];
                    if (hundreds > 0) lettercount += numlengths[hundreds] + "hundred".Length;
                    if (hundreds > 0 && (tens > 0 || digit > 0)) lettercount += "and".Length;
                }

                totallettercount += lettercount;
            }

            Console.WriteLine("{0}", totallettercount);
        }
    }
}
