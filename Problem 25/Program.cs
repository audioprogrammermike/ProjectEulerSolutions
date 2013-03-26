using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
http://projecteuler.net/problem=25

The Fibonacci sequence is defined by the recurrence relation:

Fn = Fn1 + Fn2, where F1 = 1 and F2 = 1.
Hence the first 12 terms will be:

F1 = 1
F2 = 1
F3 = 2
F4 = 3
F5 = 5
F6 = 8
F7 = 13
F8 = 21
F9 = 34
F10 = 55
F11 = 89
F12 = 144
The 12th term, F12, is the first term to contain three digits.

What is the first term in the Fibonacci sequence to contain 1000 digits?
*/

namespace Problem_25
{
    class Program
    {
        static void Main(string[] args)
        {
            double numdigits = 1000;
            double PHI = 1.6180339;
            double term = 0;

// From http://www.maths.surrey.ac.uk/hosted-sites/R.Knott/Fibonacci/fibFormula.html#logs we get:
//             numdigits = 1 + term*Math.Log10(PHI) - Math.Log10(5)/2;
//            numdigits -1 = term * Math.Log10(PHI) - Math.Log10(5) / 2;
//             numdigits - 1 +  Math.Log10(5)/2 = term*Math.Log10(PHI);
//             (numdigits + Math.Log10(5) / 2) / Math.Log10(PHI) = term;

//             term = (numdigits - 1 + Math.Log(5)/2) / Math.Log(PHI);

            term = Math.Round((numdigits - 1 + Math.Log10(5) / 2) / Math.Log10(PHI));
            Console.WriteLine("First Fibonnaci term with 1000 digits is {0}", term);
            Console.ReadLine();
        }
    }
}
