using System;
using System.Collections.Generic;
using ISubstringSearchInterface;

namespace Algorithms
{
    public class BoyerMooreAlgorithm : ISubstringSearch
    {
        const int NO_OF_CHARS = 256;

        public List<int> IndexesOf(string txt, string pat)
        {
            List<int> result = new List<int>();

            int m = pat.Length;
            int n = txt.Length;
            int[] badChar = new int[NO_OF_CHARS];
            BadCharHeuristic(pat, m, badChar);
            int s = 0;
            while (s <= (n - m))
            {
                int j = m - 1;
                while (j >= 0 && pat[j] == txt[s + j])
                    j--;

                if (j < 0)
                {
                    result.Add(s);
                    s += (s + m < n) ? m - badChar[txt[s + m]] : 1;
                }
                else
                {
                    s += Math.Max(1, j - badChar[txt[s + j]]);
                }
            }
            return result;
        }

        private void BadCharHeuristic(string pat, int size, int[] badChar)
        {
            for (int i = 0; i < NO_OF_CHARS; i++)
                badChar[i] = -1;
            for (int i = 0; i < size; i++)
                badChar[pat[i]] = i;
        }
    }
}
