using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISubstringSearchInterface;

namespace Algorithms
{
    public class BoyerMooreAlgorithm : ISubstringSearch
    {
        private const int ASCII_SIZE = 128;
        private int[] _badChar;
        public BoyerMooreAlgorithm()
        {
            _badChar = new int[ASCII_SIZE];
            for (int i = 0; i < ASCII_SIZE; i++)
                _badChar[i] = -1;
        }
        private void Shifts(string pattern)
        {
            for (int i = 0; i < pattern.Length; i++)
                _badChar[pattern[i]] = i;
        }
        public List<int> IndexesOf(string text, string pattern)
        {
            List<int> result = new List<int>();
            int m = pattern.Length;
            int n = text.Length;
            Shifts(pattern);
            int s = 0;
            while (s <= (n - m))
            {
                int j = m - 1;
                while (j >= 0 && pattern[j] == text[s + j])
                    j--;
                if (j < 0)
                {
                    result.Add(s);
                    s += (s + m < n) ? m - _badChar[text[s + m]] : 1;
                }
                else
                {
                    s += Math.Max(1, j - _badChar[text[s + j]]);
                }
            }
            return result;
        }
    }
}
