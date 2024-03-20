using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Algorithms;
using ISubstringSearchInterface;

namespace AlgorithmsRealize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ISubstringSearch alg = new KMPAlgorithm();
            string pattern = "aa";
            string text = "aaaaaaaaaa";
            foreach (var item in alg.IndexesOf(text, pattern))
            {
                Console.Write(item + " ");
            }
        }
    }
}
