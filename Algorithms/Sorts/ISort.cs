using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorts
{
    interface ISort
    {
        List<int> Sort(List<int> data, ref long iteractions);
    }
}
