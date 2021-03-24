using System;
using NUnit.Framework;

namespace CollectionsPractice.Tests
{
    public class SortTests
    {
        public enum SortType { Merge, Quick, Radix }
        public enum InitType { Empty, Single, Asc, Desc, Mixed }

        [Test]
        public void TestSort([Values] SortType sortType, [Values] InitType initType)
        {
            Action<int[]> sortFunc = sortType switch
            {
                SortType.Merge => Sorts.MergeSort,
                SortType.Quick => Sorts.QuickSort,
                SortType.Radix => Sorts.RadixSort,
                _ => throw new ArgumentException("Unknown SortType"),
            };

            var array = initType switch
            {
                InitType.Empty => new int[] { },
                InitType.Single => new int[] { 1 },
                InitType.Asc => new int[] { -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5 },
                InitType.Desc => new int[] { 5, 4, 3, 2, 1, 0, -1, -2, -3, -4, -5 },
                InitType.Mixed => new int[] { 0, 2, -2, 5, -4, 1, 3, -1, -3, 4, -5 },
                _ => throw new ArgumentException("Unknown InitType"),
            };

            var expected = new ControlList(typeof(SortedArrayList));
            expected.Initialize(array);

            sortFunc(array);

            Assert.AreEqual(expected.ToString(), $"[{string.Join(',', array)}]");
        }
    }
}
