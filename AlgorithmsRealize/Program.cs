using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;
using Algorithms;
using ISubstringSearchInterface;
using System.Diagnostics;

namespace AlgorithmsRealize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var algm = new RabinKarpAlgorithm();
            string text;
            using (var sr = new StreamReader("anna.txt", Encoding.Default))
            {
                text = sr.ReadToEnd().ToLower();
            }
            int number = 100;
            Regex rg = new Regex(@"\w+");
            var bag = new HashSet<string>();
            var matches = rg.Matches(text);
            foreach (var match in matches)
            {
                bag.Add(match.ToString());
                if (bag.Count > number) break;
            }
            var actual = new List<int>();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var pattern in bag)
            {
                actual = algm.IndexesOf(text, pattern);
            }
            sw.Stop();
            foreach (var item in actual)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Время:" + sw.ElapsedMilliseconds);
        }
    }
}
