using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructuresCs;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;
using System;

namespace DSTests
{
    [TestClass]
    public class BstTests
    {
        readonly BST<int> bst = new BST<int>();
        #region Add
        [TestMethod]
        public void Add1()
        {
            bst.Add(5);
            Assert.AreEqual(5, bst.Root);
        }
        [TestMethod]
        public void Add2()
        {
            bst.Add(5);
            bst.Add(3);
            bst.Add(2);
            Assert.AreEqual(5, bst.Root);
        }
        #endregion
        #region Levels
        [TestMethod]
        public void Level1()
        {
            bst.Add(3);
            Assert.AreEqual(1, bst.Levels);
        }
        [TestMethod]
        public void Level2()
        {
            bst.Add(3);
            bst.Add(5);
            bst.Add(3);
            Assert.AreEqual(3, bst.Levels);
        }
        #endregion
        #region IsEmpty
        [TestMethod]
        public void IsEmpty1()
        {
            Assert.IsTrue(bst.IsEmpty);
        }
        [TestMethod]
        public void IsEmpty2()
        {
            bst.Add(5);
            Assert.IsFalse(bst.IsEmpty);
        }
        #endregion
        #region Search
        [TestMethod]
        public void Search1()
        {
            bst.Add(5);
            bst.Add(3);
            bst.Add(8);
            Assert.IsTrue(bst.Search(5, out var data));
            Assert.AreEqual(5, data); ;
        }
        [TestMethod]
        public void Search2()
        {
            bst.Add(5);
            bst.Add(3);
            bst.Add(8);
            Assert.IsTrue(bst.Search(3, out var data));
            Assert.AreEqual(3, data);
        }
        [TestMethod]
        public void Search3()
        {
            bst.Add(5);
            bst.Add(3);
            bst.Add(8);
            bst.Add(15);
            bst.Add(7);
            bst.Add(10);
            bst.Add(2);
            Assert.IsTrue(bst.Search(7, out var data));
            Assert.AreEqual(7, data);
        }
        [TestMethod]
        public void Search4()
        {
            bst.Add(5);
            bst.Add(3);
            bst.Add(8);
            Assert.IsFalse(bst.Search(7, out var data));
            Assert.AreEqual(0, data);
        }
        [TestMethod]
        public void Search5()
        {
            Assert.IsFalse(bst.Search(5, out _));
        }
        #endregion
        #region Remove
        [TestMethod]
        public void Remove1()
        {
            bst.Add(5);
            Assert.IsTrue(bst.Remove(5));
            Assert.IsFalse(bst.Search(5, out _));
        }
        [TestMethod]
        public void Remove2()
        {
            bst.Add(5);
            bst.Add(3);
            bst.Add(8);
            Assert.IsTrue(bst.Remove(5));
            Assert.IsFalse(bst.Search(5, out _));
            Assert.AreEqual(8, bst.Root);
        }
        [TestMethod]
        public void Remove3()
        {
            bst.Add(5);
            bst.Add(3);
            bst.Add(8);
            bst.Add(1);
            bst.Add(4);
            bst.Add(7);
            bst.Add(9);
            Assert.IsTrue(bst.Remove(7));
            Assert.IsFalse(bst.Search(7, out _));
        }
        [TestMethod]
        public void Remove4()
        {
            Assert.IsFalse(bst.Remove(5));
        }
        #endregion
        #region GetEnumerator
        #region InOrder
        [TestMethod]
        public void In()
        {
            List<int> ints = new List<int> { 5, 3, 6, 4, 7, -6, 1, 4, 6, 0 };
            ints.ForEach(bst.Add);
            ints.Sort();
            CollectionAssert.AreEqual(ints, bst.GetEnumeratorInOrder().ToList());
        }
        #endregion
        #region PreOrder
        [TestMethod]
        public void Pre()
        {
            List<int> ints = new List<int> { 5, 3, 6, 4, 7, -6, 1, 4, 6, 0 };
            ints.ForEach(bst.Add);
            ints.Sort();
            CollectionAssert.AreNotEqual(ints, bst.GetEnumeratorPreOrder().ToList());
        }
        #endregion
        #region PostOrder
        [TestMethod]
        public void Post()
        {
            List<int> ints = new List<int> { 5, 3, 6, 4, 7, -6, 1, 4, 6, 0 };
            ints.ForEach(bst.Add);
            ints.Sort();
            CollectionAssert.AreNotEqual(ints, bst.GetEnumeratorPostOrder().ToList());
        }
        #endregion
        #endregion
    }
}
