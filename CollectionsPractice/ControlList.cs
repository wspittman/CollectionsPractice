using System;
using System.Collections.Generic;

namespace CollectionsPractice
{
    public class ControlList : List<int>, ITestCollection
    {
        private readonly Type mirrorType;

        private bool IsSorted => mirrorType == typeof(BinarySearchTree) || mirrorType == typeof(SortedArrayList);

        public ControlList(Type mirrorType)
        {
            this.mirrorType = mirrorType;
        }

        public void Initialize(int[] init)
        {
            Clear();
            AddRange(init);

            if (IsSorted)
            {
                Sort();
            }
        }

        public new void Add(int item)
        {
            base.Add(item);

            if (IsSorted)
            {
                Sort();
            }
        }

        public void Merge(ITestCollection collection)
        {
            AddRange(collection);

            if (IsSorted)
            {
                Sort();
            }
        }

        public new bool Remove(int item)
        {
            if (mirrorType == typeof(ArrayStack))
            {
                if (Count > 0)
                {
                    RemoveAt(Count - 1);
                    return true;
                }
            }
            else if (mirrorType == typeof(LinkedQueue))
            {
                if (Count > 0)
                {
                    RemoveAt(0);
                    return true;
                }
            }
            else
            {
                return base.Remove(item);
            }

            return false;
        }

        public new void Reverse()
        {
            if (!IsSorted)
            {
                base.Reverse();
            }
        }

        public void Stutter()
        {
            for (int i = 0; i < Count; i += 2)
            {
                Insert(i, this[i]);
            }
        }

        public override string ToString()
        {
            return $"[{string.Join(',', this)}]";
        }
    }
}
