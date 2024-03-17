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
            ISubstringSearch brutforce = new BruteForceAlgorithm();
            string pattern = "aa";
            string text = "aaaaaaaaaa";
            foreach (var item in brutforce.IndexesOf(pattern, text))
            {
                Console.Write(item + " ");
            }
        }
    }
}
