using System.Collections.Generic;

namespace CollectionsPractice
{
    /// <summary>
    /// An interface of methods to implement and test
    /// </summary>
    public interface ITestCollection : ICollection<int>
    {
        /// <summary>
        /// Initialize the collection with the content of the provided array
        /// </summary>
        void Initialize(int[] init);

        /// <summary>
        /// For sorted collections, merge another collection into this one
        /// For non-sorted collections, concat the collection onto this one
        /// No-op if the two collections are different implementations.
        /// </summary>
        void Merge(ITestCollection collection);

        /// <summary>
        /// Duplicate each value in this collection, maintaining current order
        /// </summary>
        void Stutter();

        /// <summary>
        /// For sorted collections, no-op
        /// For non-sorted collections, reverse the values in this collection
        /// </summary>
        void Reverse();

        /// <summary>
        /// Return a stringified version of the values in the format: "[]", "[VAL1]", "[VAL1, VAL2, ...]"
        /// </summary>
        string ToString();
    }
}
