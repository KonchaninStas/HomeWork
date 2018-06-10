using System;
using System.Collections.Generic;
using System.Linq;
using EntityMethods;
using LibraryEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestForConnectionDateBase
{
    [TestClass]
    public class ProductTest
    {
        private Product product;
        private Product productTemp;
        [TestInitialize]
        public void StartVoid()
        {
            UnitWeight unit = new UnitWeight("кг");
            DateTime time = DateTime.Now;
            product = new Product("Молоко", 10, unit, time, 10);
        }
        [TestMethod]
        public void AddItem()
        {
            Assert.IsTrue(ProductMethods.AddItem(product));
        }
        [TestMethod]
        public void AddItems()
        {
            List<Product> list = new List<Product>();
            Product p = product;
            Product p1 = p;
            list.Add(product );
            list.Add( p);
            list.Add(p1);
         Assert.IsTrue( ProductMethods.AddItem(product));
        }
        [TestMethod]
        public void DeleteItem()
        {
            Assert.IsTrue(ProductMethods.DeleteItem(1));
        }
        [TestMethod]
        public void GetItem()
        {
            productTemp = ProductMethods.GetItem(2);
            Assert.AreEqual(2, productTemp.Id);
        }
        [TestMethod]
        public void ChangeItem()
        {
            Assert.IsTrue(ProductMethods.ChangeItem(productTemp));
        }
        [TestMethod]
        public void OutItem()
        {
            List<Product> list = ProductMethods.Outpoot().ToList();
            Assert.AreNotEqual(null, list);
        }
    }
}
