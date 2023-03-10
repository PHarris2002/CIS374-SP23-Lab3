using System;
using System.Collections.Generic;
using Lab3.SortingAlgorithms;
using System.Diagnostics;
using System.Linq;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = GenerateRandomIntList(10000000, 5000);
            
            //List<double> doubleList = GenerateRandomDoubleList(100, 500);

            //Console.WriteLine("[{0}]", string.Join(", ", intList.ToArray()));
            //Console.WriteLine("[{0}]", string.Join(", ", doubleList.ToArray()));



            double totalTime = 0;
            double averageTime = 0;

            //// BUBBLE SORT
            //BubbleSort<int> bubbleSort = new BubbleSort<int>();
            //Console.WriteLine("BUBBLE SORT");

            //for (int i = 0; i < 11; i++)
            //{
            //    List<int> intListCopy = new List<int>(intList);   // make a copy of the original unsorted array

            //    totalTime += TimeSort<int>(bubbleSort, intListCopy);
            //}

            //averageTime = totalTime / 11;
            //Console.WriteLine($"Average: {averageTime}");


            //// INSERTION SORT
            //InsertionSort<int> insertionSort = new InsertionSort<int>();
            //Console.WriteLine("INSERTION SORT");
            //totalTime = 0;

            //for (int i = 0; i < 11; i++)
            //{
            //    List<int> intListCopy = new List<int>(intList);   // make a copy of the original unsorted array

            //    totalTime += TimeSort<int>(insertionSort, intListCopy);
            //}

            //averageTime = totalTime / 11;
            //Console.WriteLine($"Average: {averageTime}");

            // -- Log-Linear Time --
            //// MERGE SORT
            //MergeSort<int> mergeSort = new MergeSort<int>();
            //Console.WriteLine("MERGE SORT");
            //totalTime = 0;

            //for (int i = 0; i < 11; i++)
            //{
            //    List<int> intListCopy = new List<int>(intList);   // make a copy of the original unsorted array

            //    totalTime += TimeSort<int>(mergeSort, intListCopy);
            //}

            //averageTime = totalTime / 11;
            //Console.WriteLine($"Average: {averageTime}");

            //// QUICK SORT
            //QuickSort<int> quickSort = new QuickSort<int>();
            //Console.WriteLine("QUICK SORT");
            //totalTime = 0;

            //for (int i = 0; i < 11; i++)
            //{
            //    List<int> intListCopy = new List<int>(intList);   // make a copy of the original unsorted array

            //    totalTime += TimeSort<int>(quickSort, intListCopy);
            //}

            //averageTime = totalTime / 11;
            //Console.WriteLine($"Average: {averageTime}");

            // -- Linear Time --
            // BUCKET SORT
            BucketSort bucketSort = new BucketSort();
            Console.WriteLine("BUCKET SORT");
            totalTime = 0;

            for (int i = 0; i < 11; i++)
            {
                List<int> intListCopy = new List<int>(intList);   // make a copy of the original unsorted array

                totalTime += TimeSort(bucketSort, intListCopy);
            }

            averageTime = totalTime / 11;
            Console.WriteLine($"Average: {averageTime}");

            // RADIX SORT
            RadixSort radixSort = new RadixSort();
            Console.WriteLine("RADIX SORT");
            totalTime = 0;

            for (int i = 0; i < 11; i++)
            {
                List<int> intListCopy = new List<int>(intList);   // make a copy of the original unsorted array

                totalTime += TimeSort(radixSort, intListCopy);
            }

            averageTime = totalTime / 11;
            Console.WriteLine($"Average: {averageTime}");

            //Console.WriteLine("[{0}]", string.Join(", ", intList.ToArray()));


            //bubbleSort.Sort(ref intListCopy);

            //BucketSort<int> bucketSort = new BucketSort<int>();
            //bucketSort.Sort(ref intListCopy);

            //HeapSort<int> heapSort = new HeapSort<int>();
            //heapSort.Sort(ref intList);

            //MergeSort<int> mergeSort = new MergeSort<int>();
            //mergeSort.Sort(ref intList);

            //InsertionSort<int> insertionSort = new InsertionSort<int>();
            //insertionSort.Sort(ref intList);

            //SelectionSort<int> selectionSort = new SelectionSort<int>();
            //selectionSort.Sort(ref intList);

            //quickSort.Sort(ref intList);
            //QuickSort<double> quickSortDouble = new QuickSort<double>();
            //quickSortDouble.Sort(ref doubleList);

            //TreeSort<int> treeSort = new TreeSort<int>();
            //treeSort.Sort(ref intList);

            //Console.WriteLine("[{0}]", string.Join(", ", intList.ToArray()));
            //Console.WriteLine("[{0}]", string.Join(", ", doubleList.ToArray()));

            //MergeSort<int> mergeSort = new MergeSort<int>();
            //intListCopy = new List<int>(intList);   // make a copy of the original unsorted array
            //TimeSort(mergeSort, intListCopy);
        }

        public static double TimeSort<T>(ISortable<T> sortable, List<T> items) where T : IComparable<T>
        {
            // start timer
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            sortable.Sort(ref items);

            // end timer
            stopWatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // print info
            //Console.WriteLine(sortable.GetType().ToString());

            // print elapsed time data
            Console.WriteLine(ts.TotalSeconds);

            return ts.TotalSeconds;

        }

        public static double TimeSort(ISortableInt sortable, List<int> items)
        {
            int[] array = items.ToArray();

            // start timer
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var sorted = sortable.Sort(array);

            // end timer
            stopWatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // print info
            //Console.WriteLine(sortable.GetType().ToString());

            // print elapsed time data
            Console.WriteLine(ts.TotalSeconds);

            return ts.TotalSeconds;
        }


        public static List<int> GenerateRandomIntList(int length, int maxValue)
        {
            List<int> list = new List<int>();

            Random random = new Random();

            for(int i=0; i < length; i++)
            {
                list.Add(random.Next(maxValue));               
            }

            return list;
        }

        public static List<double> GenerateRandomDoubleList(int length, double maxValue)
        {
            List<double> list = new List<double>();

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                list.Add(random.NextDouble()* maxValue);
            }

            return list;
        }

        public static List<int> GenerateReverseIntList(int length, int maxValue)
        {
            List<int> list = new List<int>();

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                list.Add(random.Next(maxValue));
            }

            list.Sort();
            list.Reverse();

            return list;
        }

        public static List<int> GenerateNearlySortedIntList(int length, int maxValue)
        {
            List<int> list = new List<int>();

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                list.Add(random.Next(maxValue));
            }

            list.Sort();

            return list;
        }
    }
}
