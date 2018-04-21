using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    public class MyList<T> : IList<T>
    {   
        private T[] arr;
        private int count;
        private int currentPoss;
        
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new ArgumentOutOfRangeException("индекс за пределами");
                return arr[index];
            }
            set
            {
                if (index < 0 || index >= count)
                    throw new ArgumentOutOfRangeException("индекс за пределами");
                arr[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public MyList(int capacity = 10)
        {
            arr = new T[capacity];
            count = 0;
            currentPoss = -1;
        }

        public void Add(T val)
        {
           
            if (count == arr.Length)
            {
            
                T[] tmp = new T[arr.Length +1];
                for (int i = 0; i < arr.Length; ++i)
                {
                    tmp[i] = arr[i];
                   
                }
                arr = tmp;
            }
            arr[count++] = val;
        }

        public void Clear()
        {
            count = 0;
        }

        public bool Contains(T value)
        {
            for ( int i =0; i<count;i++)
            {
                if (arr[i].Equals( value))
                {        
                    return true;  
                }     
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for(int i = arrayIndex;i<count;i++)
            {
                array[i - arrayIndex] = arr[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {

            for (int i = 0; i < arr.Length; i++)
            {

                yield return arr[i];
            }
        }

        public int IndexOf(T val)
        {
            for (int i = 0; i < count; i++)
            {
                if (arr[i].Equals(val))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T val)
        {
            T[] tmp = new T[count - index];
            for (int i = index; i < count; i++)
            {
                tmp[i - index] = arr[i];
            }
            arr[index] = val;
           
            T[] tmp1 = new T[arr.Length +1];
            for (int i = 0; i < arr.Length; ++i)
            {
                tmp1[i] = arr[i];

            }
            arr = tmp1;
            
            for (int i = index+1; i<count+1;i++)
            {
                arr[i] = tmp[i - index-1];
            }
        }

        public bool Remove(T val)
        {
            for (int i = 0; i < count; i++)
            {
                if (arr[i].Equals(val))
                {
                    T[] temp = new T[arr.Length - 1];
                    
                    T[] tmp = new T[arr.Length - i-1];
                    for (int j =i+1;j<count;j++)
                    {
                        tmp[j - i-1] = arr[j];

                    }
                    T[] tmp1 = new T[ i];
                    for (int j = 0; j < i; j++)
                    {
                        tmp1[j ] = arr[j];

                    }
                    arr = temp;
                    for(int j=0;j<i;j++)
                    {
                        arr[j] = tmp1[j ];
                    }
                    for (int j = i; j < tmp.Length+i; j++)
                    {
                        arr[j] = tmp[j-i];
                    }
                    
                    return true;
                    
                }
               
            }
            return false;
             }

        public void RemoveAt(int index)
        {
            for (int i = 0; i < count; i++)
            {
                if (i == index)
                {
                    T[] temp = new T[arr.Length - 1];
                    T[] tmp = new T[arr.Length - i -1];
                    for (int j = i + 1; j < count; j++)
                    {
                        tmp[j - i -1] = arr[j];

                    }
                    T[] tmp1 = new T[i];
                    for (int j = 0; j < i; j++)
                    {
                        tmp1[j] = arr[j];

                    } 
                    arr = temp;
                    for (int j = 0; j < i; j++)
                    {
                        arr[j] = tmp1[j];
                    }
                    for (int j = i; j < tmp.Length + i; j++)
                    {
                        arr[j] = tmp[j - i];
                    }

                }

            }
        }

       IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < arr.Length; i++)
            {

                yield return arr[i];
            }
        }
    }
}
