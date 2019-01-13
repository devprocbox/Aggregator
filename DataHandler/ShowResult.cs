using System;
using System.Collections.Generic;

namespace DataHandler {
    public static class ShowResult {
        public static void ShowArrayOneUniqueOddValuesOccurence(Dictionary<int, int> input)
        {
            Console.WriteLine("The unique odd values from first array and number of occurence in second array.");
            Console.WriteLine("{0,-7}| {1,-20}", "Value", "Number of occurences");

            foreach (var item in input)
            {
                Console.WriteLine("{0,-7}| {1,-20}", item.Key, item.Value);
            }
        }

        public static void ShowUniqueArraysItem(int[] uniquedata)
        {
            Console.WriteLine("Unique values from both arrays:");
            foreach (var item in uniquedata) Console.WriteLine($"{item}");
        }

        public static void ShowTotalFirstArrayEvenNumbersOutOfSecondArray(int total) =>
            Console.WriteLine($"Total of even numbers from first array does not existed in second array: {total}");
    }
}
