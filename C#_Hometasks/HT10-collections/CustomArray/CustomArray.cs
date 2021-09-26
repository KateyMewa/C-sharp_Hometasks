using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace CustomArray
{
    [Serializable]
    public class NullReferenceException : Exception
    {
        public NullReferenceException(string message) : base(message)
        {
        }
    }
    public class CustomArray<T> : IEnumerable<T>
    {
        /// <summary>
        /// Should return first index of array
        /// </summary>
        public int First { get; private set; }

        /// <summary>
        /// Should return last index of array
        /// </summary>
        public int Last => First + Length - 1;

        /// <summary>
        /// Should return length of array
        /// <exception cref="ArgumentException">Thrown when value was smaller than 0</exception>
        /// </summary>
        public int Length
        {
            get
            {
                return Array.Length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("ArgumentException");
                }
            }
        }

        /// <summary>
        /// Should return array 
        /// </summary>
        public T[] Array { get; }

        /// <summary>
        /// Constructor with first index and length
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="length">Length</param>      
        public CustomArray(int first, int length)
        {
            this.First = first;
            this.Length = length;
            this.Array = new T[length];
        }

        /// <summary>
        /// Constructor with first index and collection  
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="list">Collection</param>
        ///  <exception cref="NullReferenceException">Thrown when list is null</exception>
        /// <exception cref="ArgumentException">Thrown when count is smaler than 0</exception>       
        public CustomArray(int first, IEnumerable<T> list)
        {
            this.First = first;
            if (list == null)
            {
                throw new NullReferenceException("The list is null");
            }
            if (!list.Any())
            {
                throw new ArgumentException("The count is smaller that 0", nameof(list));
            }
            this.Array = list.ToArray();
        }

        /// <summary>
        /// Constructor with first index and params
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="list">Params</param>
        ///  <exception cref="ArgumentNullException">Thrown when list is null</exception>
        /// <exception cref="ArgumentException">Thrown when list without elements </exception>
        public CustomArray(int first, params T[] list)
        {
            this.First = first;
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), "The list is null");
            }
            if (!list.Any())
            {
                throw new ArgumentException("The list is empty", nameof(list));
            }
            this.Array = list;
        }

        /// <summary>
        /// Indexer with get and set  
        /// </summary>
        /// <param name="item">Int index</param>        
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown when index out of array range</exception>  
        /// <exception cref="ArgumentNullException">Thrown in set  when value passed in indexer is null</exception>       
        public T this[int item]
        {
            get
            {
                if (item < First || item >= First + Length)
                {
                    throw new ArgumentException("The index is out of array range", nameof(item));
                }
                return Array[item - First];
            }
            set
            {
                if (item < First || item >= First + Length)
                {
                    throw new ArgumentException("The index is out of array range", nameof(item));
                }
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "The passed value is null");
                }
                Array[item - First] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)Array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Array.GetEnumerator();
        }

    }
}
