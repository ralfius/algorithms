using Algorithms.Sorts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Services
{
    class SortService
    {
        public void CompareSorts()
        {
            var data = Enumerable.Range(1000, 501).Reverse().ToList();
            data.AddRange(Enumerable.Range(-1000, 500).Reverse());

            //Console.WriteLine(string.Join(",", data));

            Console.WriteLine("Initial data: length = " + data.Count);
            Console.WriteLine("--- Insertion sort ---");
            ProcessArray(InsertionSort, new List<int>(data));
            Console.WriteLine("--- Selection sort ---");
            ProcessArray(SelectionSort, new List<int>(data));
            Console.WriteLine("--- Merge sort ---");
            ProcessArray(MergeSort, new List<int>(data));
        }

        public List<int> InsertionSort(List<int> data, ref long iterations)
        {
            return new InsertSort().Sort(data, ref iterations);
        }

        public List<int> SelectionSort(List<int> data, ref long iterations)
        {
            return new SelectSort().Sort(data, ref iterations);
        }

        public List<int> MergeSort(List<int> data, ref long iterations)
        {
            return new MergeSort().Sort(data, ref iterations);
        }

        public int[] QuickSort(int[] data)
        {
            throw new NotImplementedException();
        }


        private void ProcessArray(Program.Sort sort, List<int> data)
        {
            var before = DateTime.UtcNow.Ticks;
            long iterations = 0;
            data = sort(data, ref iterations);
            var after = DateTime.UtcNow.Ticks;

            PrintResults(data, before, after, iterations);
        }

        private void PrintResults(List<int> data, long start, long end, long iterations)
        {
            Console.Write("Result: correct = ");
            PrintDataSorted(data);
            Console.WriteLine(", length = " + data.Count + ", iterations = " + iterations);
            Console.WriteLine("Ticks: " + (end - start));
        }

        private bool PrintDataSorted(List<int> data)
        {
            for (int i = 0; i < data.Count - 1; i++)
            {
                if (data[i] > data[i + 1])
                {
                    Console.Write(false + ", incorrect values: [" + i + "] = " + data[i] + " > [" + (i + 1) + "] = " + data[i + 1]);
                    return false;

                }
            }

            Console.Write(true);
            return true;
        }
    }
}
