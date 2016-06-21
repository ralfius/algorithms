using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorts
{
    class MergeSort : ISort
    {
        public List<int> Sort(List<int> data, ref long iterations)
        {
            if (data.Count == 1)
            {
                return data;
            }

            int m = data.Count / 2;
            var leftList = data.GetRange(0, m);
            var rightList = data.GetRange(m, data.Count - m);

            leftList = Sort(leftList, ref iterations);
            rightList = Sort(rightList, ref iterations);

            return Merge(leftList, rightList, ref iterations);
        }

        private List<int> Merge(List<int> leftList, List<int> rightList, ref long iteractions)
        {
            var result = new List<int>(leftList.Count + rightList.Count);
            int li = 0, ri = 0;

            for (int i = 0; i < result.Capacity; i++)
            {
                if (li == leftList.Count)
                {
                    result.AddRange(rightList.GetRange(ri, rightList.Count - ri));
                    iteractions += rightList.Count - ri;
                    break;
                }
                else if (ri == rightList.Count)
                {
                    result.AddRange(leftList.GetRange(li, leftList.Count - li));
                    iteractions += leftList.Count - li;
                    break;
                }
                else if (leftList[li] > rightList[ri])
                {
                    result.Add(rightList[ri]);
                    iteractions++;
                    ri++;
                }
                else
                {
                    result.Add(leftList[li]);
                    iteractions++;
                    li++;
                }
            }

            return result;
        }
    }
}
