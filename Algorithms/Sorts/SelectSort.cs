using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorts
{
    class SelectSort : ISort
    {
        public List<int> Sort(List<int> data, ref long iterations)
        {
            for (int i = 0; i < data.Count - 1; i++)
            {
                var min = data[i];

                for (int j = i; j < data.Count; j++)
                {
                    if (min > data[j])
                    {
                        min = data[j];
                    }

                    iterations++;
                }

                var swap = data[i];
                data[i] = min;
                min = swap;
            }

            return data;
        }
    }
}
