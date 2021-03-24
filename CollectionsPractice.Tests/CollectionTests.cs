using NUnit.Framework;
using System;

namespace CollectionsPractice.Tests
{
    public class CollectionTests
    {
        public enum TestableType { ArrayList, SortedArrayList, LinkedList, ArrayStack, LinkedQueue, BinarySearchTree }
        public enum InitType { Empty, Single, Asc, Desc, Mixed }

        [Test]
        public void TestAdd([Values] TestableType testableType, [Values] InitType initType)
        {
            var (expected, collection) = Startup(testableType, initType);

            expected.Add(1);
            collection.Add(1);
            Check(expected, collection);

            expected.Add(-11);
            collection.Add(-11);
            Check(expected, collection);

            expected.Add(11);
            collection.Add(11);
            Check(expected, collection);

            for (int i = 0; i < 500; i++)
            {
                expected.Add(i);
                collection.Add(i);
            }
            Check(expected, collection);
        }

        private (ITestCollection, ITestCollection) Startup(TestableType testableType, InitType initType)
        {
            var initial = initType switch
            {
                InitType.Empty => new int[] { },
                InitType.Single => new int[] { 1 },
                InitType.Asc => new int[] { -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5 },
                InitType.Desc => new int[] { 5, 4, 3, 2, 1, 0, -1, -2, -3, -4, -5 },
                InitType.Mixed => new int[] { 0, 2, -2, 5, -4, 1, 3, -1, -3, 4, -5 },
                _ => throw new ArgumentException("Unknown InitType"),
            };

            ITestCollection collection = testableType switch
            {
                TestableType.ArrayList => new ArrayList(),
                TestableType.SortedArrayList => new SortedArrayList(),
                TestableType.LinkedList => new LinkedList(),
                TestableType.ArrayStack => new ArrayStack(),
                TestableType.LinkedQueue => new LinkedQueue(),
                TestableType.BinarySearchTree => new BinarySearchTree(),
                _ => throw new ArgumentException("Unknown TestableType"),
            };

            var expected = new ControlList(collection.GetType());

            expected.Initialize(initial);
            collection.Initialize(initial);

            Check(expected, collection);
            return (expected, collection);
        }

        private void Check(ITestCollection expected, ITestCollection collection)
        {
            Assert.AreEqual(expected.ToString(), collection.ToString());
            Assert.IsFalse(collection.Contains(777));

            if (expected.Count > 0)
            {
                Assert.IsTrue(collection.Contains(1));
            }
        }
    }
}