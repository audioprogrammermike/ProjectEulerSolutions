using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
http://projecteuler.net/problem=24

A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:

012   021   102   120   201   210

What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
*/

namespace Problem_24
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numset = new List<int>();
            List<int> perumation = new List<int>();
            int max = 10;

            for (int i = 0; i < max; i++)
            {
                numset.Add(i);
            }

            int permuationindex = 1000000 - 1;
            for(int i = 1; i < max; i++)
            {
                int index = permuationindex / Factorial(max - i);
                perumation.Add(numset[index]);
                numset.RemoveAt(index);
                permuationindex = permuationindex % Factorial(max - i);

                if (permuationindex == 0)
                {
                    break;
                }
            }

            for (int i = 0; i < numset.Count; i++)
            {
                perumation.Add(numset[i]);
            }

                Console.Write("1000000th permutation is ");
            perumation.ForEach(item => Console.Write(item));
            Console.ReadLine();
        }

        static int Factorial(int number)
        {
            if (number == 1)
            {
                return 1;
            }
            return number * Factorial(number - 1);
        }
    }
}
