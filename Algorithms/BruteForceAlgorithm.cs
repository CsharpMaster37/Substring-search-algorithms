using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISubstringSearchInterface;

namespace Algorithms
{
    public class BruteForceAlgorithm : ISubstringSearch
    {
        public List<int> IndexesOf(string pattern, string text)
        {
            int n = text.Length;
            int m = pattern.Length;
            List<int> result = new List<int>();
            bool flag;
            for (int i = 0; i < n - m + 1; i++)
            {
                flag = true;
                for (int j = 0; j < m; j++)
                {
                    if (text[i + j] != pattern[j])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                    result.Add(i);
            }
            return result;
        }
    }
}
