using DataHandler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Test {
    [TestClass]
    public class TestCalculations {

        [TestMethod]
        public void OneUniqueValueInBothArrays()
        {
            int[] arrone = new int[] { 1, 1, 1 };
            int[] arrtwo = new int[] { 1, 1, 1 };

            int[] result = ArraysAggregator.TwoArraysUniqueValues<int>(arrone, arrtwo);
            int[] expected = new int[] { 1 };
            Assert.IsTrue(Enumerable.SequenceEqual(expected, result));
        }

        [TestMethod]
        public void OneElementInBothArrays()
        {
            int[] arrone = new int[] { 1, 1, 1 };
            int[] arrtwo = new int[] { 1, 1, 1 };

            int[] uniqueresult = ArraysAggregator.TwoArraysUniqueValues<int>(arrone, arrtwo);
            int[] expected = new int[] { 1 };
            Assert.IsTrue(Enumerable.SequenceEqual(expected, uniqueresult));

            TwoArrays<int> twoArrays = new TwoArrays<int>();
            twoArrays.arrone = arrone;
            twoArrays.arrtwo = arrtwo;
            Dictionary<int, int> expectedDictionary = new Dictionary<int, int>() { { 1, 3 } };
            Dictionary<int, int> aggrresult = ArraysAggregator.ArrayOneUniqueOddValuesOccurInSecondArray(twoArrays);
            Assert.IsTrue(Enumerable.SequenceEqual(expectedDictionary, aggrresult));

            int totalresult = ArraysAggregator.ArrayOneEvenNumbersTotalOutOfArrayTwo(twoArrays);
            Assert.IsTrue(totalresult == 0);
        }

        [TestMethod]
        public void EvenOddNumbersInBothArrays()
        {
            int[] arrone = new int[] { 1, 2, 3, 4, 44 };
            int[] arrtwo = new int[] { 3, 4, 5, 6 };
            TwoArrays<int> twoArrays = new TwoArrays<int>();
            twoArrays.arrone = arrone;
            twoArrays.arrtwo = arrtwo;
            int[] uniqueresult = ArraysAggregator.TwoArraysUniqueValues<int>(twoArrays.arrone,twoArrays.arrtwo);
            int[] expected = new int[] { 1, 2, 3, 4, 44, 5, 6 };
            Assert.IsTrue(Enumerable.SequenceEqual(expected, uniqueresult));

            Dictionary<int, int> aggrresult = ArraysAggregator.ArrayOneUniqueOddValuesOccurInSecondArray(twoArrays);
            Dictionary<int, int> expectedDictionary = new Dictionary<int, int>() { { 3, 1 } };
            Assert.IsTrue(Enumerable.SequenceEqual(expectedDictionary, aggrresult));

            int totalresult = ArraysAggregator.ArrayOneEvenNumbersTotalOutOfArrayTwo(twoArrays);
            Assert.IsTrue(totalresult == twoArrays.arrone[1]+twoArrays.arrone[4]);
        }
    }
}
