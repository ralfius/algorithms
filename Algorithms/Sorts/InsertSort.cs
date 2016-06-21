using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorts
{
    class InsertSort : ISort
    {
        public List<int> Sort(List<int> data, ref long iterations)
        {
            for (int i = 1; i < data.Count; i++)
            {
                for (int j = 0; j < data.Count; j++)
                {
                    iterations++;

                    if (data[i] < data[j])
                    {
                        var item = data[i];
                        data.RemoveAt(i);
                        data.Insert(j, item);

                        break;
                    }
                }
            }

            return data;
        }
    }
}
