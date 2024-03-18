using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISubstringSearchInterface;

namespace Algorithms
{
    public class RabinKarpAlgorithm : ISubstringSearch
    {
        public List<int> IndexesOf(string text, string pattern)
        {
            List<int> result = new List<int>();
            int n = text.Length, m = pattern.Length;
            ulong d = 128, q = 100007;
            ulong p = 0, ts = 0;
            ulong h = (ulong)Math.Pow(d, m - 1) % q;
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
                    ts = (ts + q - h * text[i] % q) % q;
                    ts = (ts * d + text[i + m]) % q;
                }
            }
            return result;
        }
    }
}
