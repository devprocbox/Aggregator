using System.Collections.Generic;
using System.Linq;

namespace DataHandler {
    public static class ArraysAggregator {
        public static T[] TwoArraysUniqueValues<T>(T[] one, T[] two) => one.Union(two).ToArray();

        public static Dictionary<int, int> ArrayOneUniqueOddValuesOccurInSecondArray(TwoArrays<int> data)
        {
            int[] oddone = data.arrone.Distinct().Where(x => x % 2 != 0).ToArray();
            Dictionary<int, int> odduniquetwo = data.arrtwo.Where(x => x % 2 != 0).GroupBy(x => x).ToDictionary(g => g.Key, g => g.ToList().Count);
            Dictionary<int, int> result = odduniquetwo.Select(x => x).Where(x => oddone.Contains(x.Key)).ToDictionary(g => g.Key, g => g.Value);
            return result;
        }

        public static int ArrayOneEvenNumbersTotalOutOfArrayTwo(TwoArrays<int> data)
        {
            int[] evenone = data.arrone.Where(x => x % 2 == 0).ToArray<int>();
            int[] eventwo = data.arrtwo.Where(x => x % 2 == 0).ToArray<int>();
            return evenone.Where(x => eventwo.Contains(x) == false).Sum();
        }
    }
}
