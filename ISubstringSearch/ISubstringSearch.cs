using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISubstringSearchInterface
{
    public interface ISubstringSearch
    {
        List<int> IndexesOf(string pattern, string text);
    }
}
