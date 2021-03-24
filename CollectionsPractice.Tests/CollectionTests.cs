using NUnit.Framework;
using System;

namespace CollectionsPractice.Tests
{
    public class CollectionTests
    {
        public enum TestableType { ArrayList, SortedArrayList, LinkedList, ArrayStack, LinkedQueue, BinarySearchTree }

        [Test]
        public void TestAdd([Values] TestableType testableType)
        {
            var (expected, collection) = Startup(testableType);

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

        private (ITestCollection, ITestCollection) Startup(TestableType testableType)
        {
            var initial = new int[] { 1 };

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