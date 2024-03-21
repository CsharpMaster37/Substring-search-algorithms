using System.Collections.Generic;
using ISubstringSearchInterface;

namespace Algorithms
{
    public class KMPAlgorithm : ISubstringSearch
    {
        public List<int> IndexesOf(string text, string pattern)
        {
            List<int> result = new List<int>();

            int n = text.Length;
            int m = pattern.Length;
            int[] prefixFunc = PrefixFunction(pattern);

            int j = 0;
            for (int i = 0; i < n; i++)
            {
                while (j > 0 && text[i] != pattern[j])
                {
                    j = prefixFunc[j - 1];
                }
                if (text[i] == pattern[j])
                {
                    j++;
                }
                if (j == m)
                {
                    result.Add(i - j + 1);
                    j = prefixFunc[j - 1];
                }
            }

            return result;
        }
        private int[] PrefixFunction(string pattern)
        {
            int m = pattern.Length;
            int[] prefixFunc = new int[m];
            int j = 0;
            for (int i = 1; i < m; i++)
            {
                while (j > 0 && pattern[j] != pattern[i])
                {
                    j = prefixFunc[j - 1];
                }
                if (pattern[j] == pattern[i])
                {
                    j++;
                }
                prefixFunc[i] = j;
            }

            return prefixFunc;
        }
    }
}
