using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CollectionsPractice
{
    public class ArrayStack : ITestCollection
    {
        public int Count => throw new NotImplementedException();

        public void Initialize(int[] init)
        {
            throw new NotImplementedException();
        }

        public void Add(int item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(int item)
        {
            throw new NotImplementedException();
        }

        public void Merge(ITestCollection collection)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int item)
        {
            throw new NotImplementedException();
        }

        public void Reverse()
        {
            throw new NotImplementedException();
        }

        public void Stutter()
        {
            throw new NotImplementedException();
        }

        #region Things we don't care about

        public void CopyTo(int[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool IsReadOnly => throw new NotImplementedException();

        #endregion
    }
}
