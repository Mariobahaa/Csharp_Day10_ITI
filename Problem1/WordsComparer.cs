using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class WordsComparer : IEqualityComparer<String>
    {

        public bool Equals(string x, string y)
        {
            String X = x.Trim();
            String Y = y.Trim();
            int Xval = X.Sum(ch => (int)ch * ((int)ch%65));
            int Yval = Y.Sum(ch => (int)ch * ((int)ch % 65));

            return Xval == Yval;
        }

        public int GetHashCode([DisallowNull] string obj)
        {
            return 1;
        }
    }
}
