using Algorithms.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        public delegate List<int> Sort(List<int> data, ref long iterations);

        static void Main(string[] args)
        {
            //var sortService = new SortService();
            //sortService.CompareSorts();

            var searchService = new SearchService();
            var data = new List<int>(16) { 13, -3, -25, 20, -3, -16, -23, 18, 20, -7, 12, -5, -22, 15, -4, 7 };
            //var data = new List<int>(6) { 3, -4, 5, -1, 7, -5 };

            var maxSubarray = searchService.GetMaximumSubArray(data);

            Console.WriteLine("Finding max subarray:");
            Console.WriteLine("Initial data array: " + string.Join(",", data));
            Console.WriteLine("Result: " + string.Join(",", maxSubarray));
        }


    }
}
