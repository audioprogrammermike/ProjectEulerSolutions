using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

/*
http://projecteuler.net/problem=22

Using names.txt (right click and 'Save Link/Target As...'), a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would obtain a score of 938  53 = 49714.

What is the total of all the name scores in the file?
*/

namespace Problem_22
{
    class Program
    {
        static void Main(string[] args)
        {
            uint totalscore = 0;

            string namesstring = System.IO.File.ReadAllText(@"..\..\names.txt");
            string[] names = namesstring.Split(',');

            Array.Sort(names);
            uint namecount = 1;
            foreach(var name in names) {
                uint namescore = 0;
                char[] letters = new char[name.Length];
                StringReader sr = new StringReader(name);
                sr.Read(letters, 0, name.Length);

                foreach (var letter in letters)
                {
                    if (!char.IsPunctuation(letter))
                    {
                        namescore += (uint)(letter - 'A') + 1;
                    }
                }

                totalscore += namescore * namecount;
                namecount++;
            }

            Console.WriteLine("Total score of all names in file is {0}", totalscore);
            Console.ReadLine();
        }
    }
}
