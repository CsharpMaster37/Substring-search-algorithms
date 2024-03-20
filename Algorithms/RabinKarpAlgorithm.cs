using System;
using System.Collections.Generic;
using ISubstringSearchInterface;

namespace Algorithms
{
    public class RabinKarpAlgorithm : ISubstringSearch
    {
        public List<int> IndexesOf(string text, string pattern)
        {
            List<int> result = new List<int>();
            int n = text.Length, m = pattern.Length;
            ulong d = 128, q = 999983;
            ulong p = 0, ts = 0;
            ulong h = (ulong)Math.Pow(d, m - 1);
            for (int i = 0; i < m; i++)
            {
                p = (p * d + pattern[i]) % q;
                ts = (ts * d + text[i]) % q;
            }
            for (int i = 0; i < n - m + 1; i++)
            {
                if (p == ts && text.Substring(i, m) == pattern)
                {
                    result.Add(i);
                }
                if(i<n-m)
                {
                    ts = (d * (ts - text[i] * h) + text[i + m]) % q;
                }
            }
            return result;
        }
    }
}
