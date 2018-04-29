using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HomeWork_10_Dictionary
{/// <summary>
 /// 
 /// </summary>
 /// <typeparam name="Tkey">element key</typeparam>
 /// <typeparam name="TValue"> element value</typeparam>

    public class MyDictionary<Tkey, TValue> where Tkey : IComparable
    {
        #region 
        /// <summary>
        ///  Зrivate class in which a binary tree is implemented
        /// </summary>
        private class MyTree
        {

            public KeyValuePair<Tkey, TValue> pair;
            public MyTree parents;
            public MyTree left;
            public MyTree right;

            public MyTree(Tkey _key, TValue _value, MyTree _parents = null, MyTree _left = null, MyTree _right = null)
            {
                pair = new KeyValuePair<Tkey, TValue>(_key, _value);
                parents = _parents;
                left = _left;
                right = _right;
            }
            public MyTree(KeyValuePair<Tkey, TValue> _pair, MyTree _parent = null, MyTree _left = null, MyTree _right = null)
            {
                pair = _pair;
                parents = _parent;
                left = _left;
                right = _right;
            }
        }
        private MyTree Data;
        private MyTree root = null;
        private int counter = 0;
        #endregion
        #region constructor
        public MyDictionary(Tkey key, TValue value)
        {
            root = new MyTree(key, value);
        }
        public MyDictionary()
        {
        }
        #endregion
        #region Methods
        /// <summary>
        /// Displays a collection of keys
        /// </summary>
        public ICollection Keys
        {
            get
            {
                List<Tkey> list = new List<Tkey>();
                using (IEnumerator<MyTree> e = GetTreeItemEnumerator(root))
                {
                    while (e.MoveNext())
                    {
                        list.Add(e.Current.pair.Key);
                    }
                }
                return list;
            }
        }
        /// <summary>
        /// Displays a collection of values
        /// </summary>
        public ICollection Values
        {
            get
            {
                List<TValue> list = new List<TValue>();
                using (IEnumerator<MyTree> e = GetTreeItemEnumerator(root))
                {
                    while (e.MoveNext())
                    {
                        list.Add(e.Current.pair.Value);
                    }
                }
                return list;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// number of elements in the dictionary
        /// </summary>
        public int Count
        {
            get
            {
                return counter;
            }
        }

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// returns a value by its key
        /// </summary>
        /// <param name="key">key for value search</param>
        /// <returns></returns>
        public object this[object key]
        {
            get
            {
                using (IEnumerator<MyTree> e = GetTreeItemEnumerator(root))
                {
                    while (e.MoveNext())
                    {
                        if (e.Current.pair.Key.Equals(key))
                        {
                            return e.Current.pair.Value;
                        }
                    }
                }
                return false;
            }

        }
        /// <summary>
        /// returns a boolean expression found a key
        /// </summary>
        /// <param name="key">key for value search</param>
        /// <returns></returns>
        public bool Contains(object key)
        {
            using (IEnumerator<MyTree> e = GetTreeItemEnumerator(root))
            {
                while (e.MoveNext())
                {
                    if (e.Current.pair.Key.Equals(key))
                    {
                        return true;
                    }

                }
            }
            return false;
        }
        /// <summary>
        /// adds a new item to the dictionary
        /// </summary>
        /// <param name="key">the key of the element that we will add</param>
        /// <param name="value">value of the element that we will add</param>
        public void Add(Tkey key, TValue value)
        {
            Add(new KeyValuePair<Tkey, TValue>(key, value));
        }
        /// <summary>
        /// adds a new item to the dictionary
        /// </summary>
        /// <param name="pair">pair key value to be added</param>
        public void Add(KeyValuePair<Tkey, TValue> pair)
        {
            if (root == null)
            {
                Add_root(pair);
            }
            else
            {
                Add_two(pair);
            }
        }
        /// <summary>
        /// adding the first element
        /// </summary>
        /// <param name="pair">pair key value to be added</param>
        private void Add_root(KeyValuePair<Tkey, TValue> pair)
        {
            root = new MyTree(pair);
            counter++;
        }
        /// <summary>
        /// adding an element
        /// </summary>
        /// <param name="pair">pair key value to be added</param>
        private void Add_two(KeyValuePair<Tkey, TValue> pair)
        {
            Data = root;
            counter++;
            while (true)
            {
                MyTree item = new MyTree(pair);
                if (item.pair.Key.CompareTo(Data.pair.Key) == 0)
                {
                    Data.pair = item.pair;

                    return;
                }
                else if (item.pair.Key.CompareTo(Data.pair.Key) < 0)
                {
                    if (Data.left == null)
                    {
                        Data.left = item;
                        item.parents = Data;
                        return;
                    }
                    Data = Data.left;
                }
                else if (item.pair.Key.CompareTo(Data.pair.Key) > 0)
                {
                    if (Data.right == null)
                    {
                        Data.right = item;
                        item.parents = Data;
                        return;
                    }
                    Data = Data.right;
                }
            }
        }
        /// <summary>
        /// delete all items
        /// </summary>
        public void Clear()
        {
            counter = 0;
            root = root.left = root.right = null;

        }
        /// <summary>
        /// remove an element by key
        /// </summary>
        /// <param name="key">key of the element to be deleted</param>
        public void Remove(object key)
        {
            MyTree Data;
            using (IEnumerator<MyTree> e = GetTreeItemEnumerator(root))
            {
                while (e.MoveNext())
                {
                    {
                        if (e.Current.pair.Key.Equals(key))
                        {
                            Data = e.Current;
                            Remove(Data);
                        }
                    }
                }
            }


        }

        private void Remove(MyTree Data)
        {
            counter--;
            if (Data.left == null && Data.right == null)
            {
                if (Data == root)
                {
                    Data = null;
                }
                if (Data.parents.left == Data)
                {
                    Data.parents.left = null;

                }
                if (Data.parents.right == Data)
                {
                    Data.parents.right = null;
                }
                Data = null;
            }
            else if (Data.left != null && Data.right != null)
            {
                MyTree val = Data.right;
                Data.right.parents = Data.parents;
                while (val.left != null)
                {
                    val = val.left;
                }
                Data.left.parents = val;
                val.left = Data;
            }
            else if (Data.left != null || Data.right != null)
            {
                if (Data.left != null)
                {
                    Data.left.parents = Data.parents;
                    Data.parents.left = Data.left;
                    Data = null;
                }
                if (Data.right != null)
                {
                    Data.right.parents = Data.parents;
                    Data.parents.right = Data.right;
                    Data = null;
                }
            }

        }
        public void CopyTo(Array array, int index)//не реализовал
        {
            //array = new KeyValuePair<Tkey,TValue>[index +counter];

            int i = 0;
            using (IEnumerator<MyTree> e = GetTreeItemEnumerator(root))
            {
                while (e.MoveNext())
                {
                    {
                        var a = e.Current;


                    }
                    i++;
                }
            }
        }
        #endregion
        #region Enumerator
        /// <summary>
        /// enumerator for the dictionary
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<Tkey, TValue>> GetEnumerator()
        {
            using (IEnumerator<MyTree> e = GetTreeItemEnumerator(root))
            {
                while (e.MoveNext())
                {
                    yield return e.Current.pair;
                }
            }
        }
        /// <summary>
        /// tree traversing by elemets
        /// </summary>
        /// <param name="item">starting element for traversing a tree</param>
        /// <returns></returns>
        private IEnumerator<MyTree> GetTreeItemEnumerator(MyTree item)
        {
            Stack<MyTree> itemStack = new Stack<MyTree>();

            while (item != null || itemStack.Count != 0)
            {
                if (itemStack.Count != 0)
                {
                    item = itemStack.Pop();


                    yield return item;

                    if (item.right != null)
                    {
                        item = item.right;
                    }
                    else
                    {
                        item = null;
                    }
                }
                while (item != null)
                {
                    itemStack.Push(item);
                    item = item.left;
                }
            }
        }

        private IEnumerator<MyTree> GetTreeItemEnumerator_Queue(MyTree item)
        {
            Queue<MyTree> itemStack = new Queue<MyTree>();

            while (item != null || itemStack.Count != 0)
            {
                if (itemStack.Count != 0)
                {
                    item = itemStack.Dequeue();


                    yield return item;

                    if (item.right != null)
                    {
                        item = item.right;
                    }
                    else
                    {
                        item = null;
                    }
                }
                while (item != null)
                {
                    itemStack.Enqueue(item);
                    item = item.left;
                }
            }
        }
        #endregion
    }
}
