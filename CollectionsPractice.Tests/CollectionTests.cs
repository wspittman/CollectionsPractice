using NUnit.Framework;
using System;

namespace CollectionsPractice.Tests
{
    public class CollectionTests
    {
        public enum TestableType { ArrayList, SortedArrayList, LinkedList, ArrayStack, LinkedQueue, BinarySearchTree }
        public enum InitType { Empty, Single, Asc, Desc, Mixed }

        // Note: Initialize(int[] init) is tested implicitly by Startup()

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

        [Test]
        public void TestClear([Values] TestableType testableType, [Values] InitType initType)
        {
            var (expected, collection) = Startup(testableType, initType);

            expected.Clear();
            collection.Clear();
            Check(expected, expected);

            expected.Clear();
            collection.Clear();
            Check(expected, expected);
        }

        // Note: Contains(int item) is tested implicitly by Check()

        [Test]
        public void TestMerge([Values] TestableType testableType, [Values] InitType initType)
        {
            var (expected, collection) = Startup(testableType, initType);

            expected.Merge(null);
            collection.Merge(null);
            Check(expected, collection);

            foreach (var val in Enum.GetValues(typeof(InitType)))
            {
                var (tempExpected, tempCollection) = Startup(testableType, (InitType)val);
                expected.Merge(tempExpected);
                collection.Merge(tempCollection);
                Check(expected, collection);
            }

            expected.Merge(expected);
            collection.Merge(collection);
            Check(expected, collection);
        }

        [Test]
        public void TestRemove([Values] TestableType testableType, [Values] InitType initType)
        {
            var (expected, collection) = Startup(testableType, initType);

            // Note: Stacks and Queues ignore the value argument, performing pop or dequeue instead.

            bool expectedResult = expected.Remove(777);
            bool collectionResult = collection.Remove(777);
            Assert.AreEqual(expectedResult, collectionResult);
            Check(expected, collection);

            expectedResult = expected.Remove(1);
            collectionResult = collection.Remove(1);
            Assert.AreEqual(expectedResult, collectionResult);
            Check(expected, collection);

            for (int i = -20; i < 20; i++)
            {
                expectedResult = expected.Remove(i);
                collectionResult = collection.Remove(i);
                Assert.AreEqual(expectedResult, collectionResult);
                Check(expected, collection);
            }
        }

        [Test]
        public void TestReverse([Values] TestableType testableType, [Values] InitType initType)
        {
            var (expected, collection) = Startup(testableType, initType);

            expected.Reverse();
            collection.Reverse();
            Check(expected, collection);

            expected.Reverse();
            collection.Reverse();
            Check(expected, collection);
        }

        [Test]
        public void TestStutter([Values] TestableType testableType, [Values] InitType initType)
        {
            var (expected, collection) = Startup(testableType, initType);

            expected.Stutter();
            collection.Stutter();
            Check(expected, collection);

            expected.Stutter();
            collection.Stutter();
            Check(expected, collection);
        }

        // Note: ToString() is tested implicitly by Check()

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
            Assert.AreEqual(expected.Contains(777), collection.Contains(777));
            Assert.AreEqual(expected.Contains(1), collection.Contains(1));
        }
    }
}