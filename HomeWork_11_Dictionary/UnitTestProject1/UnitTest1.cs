using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject1;
using HomeWork_10_Dictionary;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Constructor()
        {
            MyDictionary<int, int> dictionary = new MyDictionary<int, int>();
            Assert.AreEqual(0, dictionary.Count);

        }
        [TestMethod]
        public void Add_Head()
        {
            MyDictionary<int, int> dictionary = new MyDictionary<int, int>();
            Assert.AreEqual(0, dictionary.Count);
            dictionary.Add(5, 2);
            Assert.AreEqual(1, dictionary.Count);
        }
        [TestMethod]
        public void Add()
        {
            MyDictionary<int, int> dictionary = new MyDictionary<int, int>();
            Assert.AreEqual(0, dictionary.Count);
            dictionary.Add(5, 2);
            dictionary.Add(2, 6);
            dictionary.Add(6, 6);
            dictionary.Add(252, 6);
            Assert.AreEqual(4, dictionary.Count);
            foreach (var x in dictionary)
            {
                Console.WriteLine(x);
            }
        }
        [TestMethod]
        public void Clear()
        {
            MyDictionary<int, int> dictionary = new MyDictionary<int, int>();
            Assert.AreEqual(0, dictionary.Count);
            dictionary.Add(5, 2);
            dictionary.Add(2, 6);
            dictionary.Add(6, 6);
            dictionary.Add(252, 6);
            dictionary.Clear();
            Assert.AreEqual(0, dictionary.Count);
        }
        [TestMethod]
        public void Contains()
        {
            MyDictionary<int, int> dictionary = new MyDictionary<int, int>();
            Assert.AreEqual(0, dictionary.Count);
            dictionary.Add(5, 2);
            dictionary.Add(2, 6);
            dictionary.Add(6, 6);
            dictionary.Add(252, 6);
            Assert.AreEqual(true, dictionary.Contains(2));
        }
        [TestMethod]
        public void Remove()
        {
            MyDictionary<int, int> dictionary = new MyDictionary<int, int>();
            Assert.AreEqual(0, dictionary.Count);
            dictionary.Add(5, 2);
            dictionary.Add(2, 6);
            dictionary.Add(6, 6);
            dictionary.Add(252, 6);
            dictionary.Remove(2);
            Assert.AreEqual(3, dictionary.Count);
            Assert.AreNotEqual(4, dictionary.Count);

        }

    }
}
