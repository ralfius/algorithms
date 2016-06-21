using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Services
{
    class SearchService
    {
        public List<int> GetMaximumSubArray(List<int> data)
        {
            int resultLow, resultHigh, resultSum;
            FindMaxSubArray(data, 0, data.Count - 1, out resultLow, out resultHigh, out resultSum);

            return data.GetRange(resultLow, resultHigh - resultLow + 1);
        }

        private void FindMaxSubArray(List<int> data, int low, int high, 
            out int outLow, out int outHigh, out int outSum)
        {
            if (low == high)
            {
                outLow = low;
                outHigh = high;
                outSum = data[low];
            }
            else
            {
                var mid = low + (high - low) / 2;
                int leftLow, leftHigh, leftSum, rightLow, rightHigh, rightSum, midLow, midHigh, midSum;

                FindMaxSubArray(data, low, mid, out leftLow, out leftHigh, out leftSum);
                FindMaxSubArray(data, mid + 1, high, out rightLow, out rightHigh, out rightSum);
                FindMaxCrossingSubarray(data, low, mid, high, out midLow, out midHigh, out midSum);

                if (leftSum >= rightSum && leftSum >= midSum)
                {
                    outLow = leftLow;
                    outHigh = leftHigh;
                    outSum = leftSum;
                } 
                else if (rightSum >= leftSum && rightSum >= midSum)
                {
                    outLow = rightLow;
                    outHigh = rightHigh;
                    outSum = rightSum;
                }
                else
                {
                    outLow = midLow;
                    outHigh = midHigh;
                    outSum = midSum;
                }
            }
        }

        private void FindMaxCrossingSubarray(List<int> data, int low, int mid, int high, 
            out int outLow, out int outHigh, out int outSum)
        {
            int leftSum = Int32.MinValue, rightSum = Int32.MinValue, localSum;
            outLow = mid;
            outHigh = mid;

            localSum = 0;
            for (int i = mid; i >= low; i--)
            {
                localSum += data[i];

                if (localSum > leftSum)
                {
                    leftSum = localSum;
                    outLow = i;
                }
            }

            localSum = 0;
            for (int i = mid + 1; i <= high; i++)
            {
                localSum += data[i];

                if (localSum > rightSum)
                {
                    rightSum = localSum;
                    outHigh = i;
                }
            }

            outSum = leftSum + rightSum;
        }
    }
}
