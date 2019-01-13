using DataHandler;
using System;
using System.Collections.Generic;
using System.IO;

namespace EntryPoint {
    class Program {
        static void Main(string[] args)
        {
            bool proceedfile = true;
            Console.WriteLine("Hello.");
            Console.WriteLine("Put data.json file in to current directory press any key to continue.");
            Console.ReadKey();

            while (proceedfile)
            {
                TwoArrays<int> data = LoadDataFromLocalDirectoryJsonFile();
                if (data == null)
                {
                    Console.WriteLine("Press any key to exit or (c) to continue.");
                    char key = Console.ReadKey().KeyChar;
                    Console.Write("\n");
                    if (key != 'c')
                    {
                        proceedfile = false;
                        break;
                    }
                }
                else
                {
                    bool proceeddata = false;
                    do
                    {
                        char key = ShowAvaliableOptions();
                        switch (key)
                        {
                            case 'u':
                                int[] uniquedata = ArraysAggregator.TwoArraysUniqueValues<int>(data.arrone, data.arrtwo);
                                ShowResult.ShowUniqueArraysItem(uniquedata);
                                proceeddata = true;
                                break;
                            case 'o':
                                Dictionary<int, int> uniqueodd = ArraysAggregator.ArrayOneUniqueOddValuesOccurInSecondArray(data);
                                ShowResult.ShowArrayOneUniqueOddValuesOccurence(uniqueodd);
                                proceeddata = true;
                                break;
                            case 's':
                                int total = ArraysAggregator.ArrayOneEvenNumbersTotalOutOfArrayTwo(data);
                                ShowResult.ShowTotalFirstArrayEvenNumbersOutOfSecondArray(total);
                                proceeddata = true;
                                break;
                            case 'r':
                                proceeddata = false;
                                break;
                            default:
                                proceeddata = false;
                                proceedfile = false;
                                break;
                        }
                    } while (proceeddata);
                }
            }
        }

        private static TwoArrays<int> LoadDataFromLocalDirectoryJsonFile()
        {
            string directory = Directory.GetCurrentDirectory();
            string filepath = directory + @"\data.json";
            TwoArrays<int> data = JsonReader.LoadJsonData<TwoArrays<int>>(filepath);
            return data;
        }

        private static char ShowAvaliableOptions()
        {
            Console.WriteLine("Press (u) to get unique values from both arrays.");
            Console.WriteLine("Press (o) to get unique odd values from first array and number of occurence in second array.");
            Console.WriteLine("Press (s) to get total of even numbers from first array does not existed in second array.");
            Console.WriteLine("Press (r) to reload data file.");
            Console.WriteLine("Press any key to exit without actions.");
            char key = Console.ReadKey().KeyChar;
            Console.Write("\n");
            return key;
        }
    }
}