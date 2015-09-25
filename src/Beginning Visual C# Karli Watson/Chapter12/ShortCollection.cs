using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Chapter12
{
    class ShortCollection<T> : IList<T>
    {
        protected Collection<T> innerCollection;
        protected int maxSize = 10;
        public ShortCollection() : this(10)
        {
        }
        public ShortCollection(int size)
        {
            maxSize = size;
            innerCollection = new Collection<T>();
        }
        public ShortCollection(List<T> list) : this(10, list)
        {
        }
        public ShortCollection(int size, List<T> list)
        {
            maxSize = size;
            if (list.Count <= maxSize)
            {
                innerCollection = new Collection<T>(list);
            }
            else
            {
                ThrowTooManyItemsException();
            }
        }
        protected void ThrowTooManyItemsException()
        {
            throw new IndexOutOfRangeException(
               "Больше нельзя добавить ни одного элемента, максимальный размер "
               + maxSize.ToString()
               + " элементов.");
        }
        #region IList<T> Members
        public int IndexOf(T item)
        {
            return (innerCollection as IList<T>).IndexOf(item);
        }
        public void Insert(int index, T item)
        {
            if (Count < maxSize)
            {
                (innerCollection as IList<T>).Insert(index, item);
            }
            else
            {
                ThrowTooManyItemsException();
            }
        }
        public void RemoveAt(int index)
        {
            (innerCollection as IList<T>).RemoveAt(index);
        }
        public T this[int index]
        {
            get
            {
                return (innerCollection as IList<T>)[index];
            }
            set
            {
                (innerCollection as IList<T>)[index] = value;
            }
        }
        #endregion
        #region ICollection<T> Members
        public void Add(T item)
        {
            if (Count < maxSize)
            {
                (innerCollection as ICollection<T>).Add(item);
            }
            else
            {
                ThrowTooManyItemsException();
            }
        }
        public void Clear()
        {
            (innerCollection as ICollection<T>).Clear();
        }
        public bool Contains(T item)
        {
            return (innerCollection as ICollection<T>).Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            (innerCollection as ICollection<T>).CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get
            {
                return (innerCollection as ICollection<T>).Count;
            }
        }
        public bool IsReadOnly
        {
            get
            {
                return (innerCollection as ICollection<T>).IsReadOnly;
            }
        }
        public bool Remove(T item)
        {
            return (innerCollection as ICollection<T>).Remove(item);
        }
        #endregion
        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            return (innerCollection as IEnumerable<T>).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<T>)innerCollection).GetEnumerator();
        }
        #endregion
    }
}
