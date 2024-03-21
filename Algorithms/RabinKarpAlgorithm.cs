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
            int n = text.Length;
            int m = pattern.Length;
            int h = 1;
            int d = 128;
            int q = 33554432;
            for (int i = 0; i < m - 1; i++)
            {
                h = (h * d) % q;
            }
            int p = 0;
            int ts = 0;
            for (int i = 0; i < m; i++)
            {
                p = (d * p + pattern[i]) % q;
                ts = (d * ts + text[i]) % q;
            }
            for (int s = 0; s <= n - m; s++)
            {
                if (p == ts)
                {
                    bool match = true;
                    for (int i = 0; i < m; i++)
                    {
                        if (pattern[i] != text[s + i])
                        {
                            match = false;
                            break;
                        }
                    }
                    if (match)
                    {
                        result.Add(s);
                    }
                }
                if (s < n - m)
                {
                    ts = (d * (ts - text[s] * h) + text[s + m]) % q;
                    if (ts < 0)
                    {
                        ts = ts + q;
                    }
                }
            }
            return result;
        }
    }
}
