using DataStructuresCs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSTests
{
    [TestClass]
    public class DoubleLinkedListTests
    {
        readonly GenericParameterHelper item = new GenericParameterHelper();
        readonly DoubleLinkedList<GenericParameterHelper> list = new DoubleLinkedList<GenericParameterHelper>();
        #region Add
        [TestMethod]
        public void AddFirst1()
        {
            list.AddFirst(item);
            Assert.AreEqual(1, list.Count);
            Assert.AreSame(item, list.First);
            Assert.AreSame(list.Last, list.First);
        }
        [TestMethod]
        public void AddFirst2()
        {
            list.AddFirst(item);
            var item2 = new GenericParameterHelper();
            list.AddFirst(item2);
            Assert.AreEqual(2, list.Count);
            Assert.AreSame(item2, list.First);
            Assert.AreSame(list.Last, item);
        }
        [TestMethod]
        public void AddLast1()
        {
            list.AddLast(item);
            Assert.AreEqual(1, list.Count);
            Assert.AreSame(list.First, list.Last);
            Assert.AreSame(item, list.Last);
        }
        [TestMethod]
        public void AddLast2()
        {
            list.AddLast(item);
            var item2 = new GenericParameterHelper();
            list.AddLast(item2);
            Assert.AreEqual(2, list.Count);
            Assert.AreSame(item, list.First);
            Assert.AreSame(item2, list.Last);
        }
        #endregion
        #region Remove
        [TestMethod]
        public void RemoveFirst1()
        {
            list.AddFirst(item);
            Assert.IsTrue(list.RemoveFirst());
            Assert.AreEqual(0, list.Count);
        }
        [TestMethod]
        public void RemoveFirst2()
        {
            Assert.IsFalse(list.RemoveFirst());
            Assert.AreEqual(0, list.Count);
        }
        [TestMethod]
        public void RemoveFirst3()
        {
            list.AddFirst(item);
            Assert.IsTrue(list.RemoveFirst(out var item2));
            Assert.AreSame(item, item2);
            Assert.AreEqual(0, list.Count);
        }
        [TestMethod]
        public void RemoveLast1()
        {
            list.AddFirst(item);
            Assert.IsTrue(list.RemoveLast());
            Assert.AreEqual(0, list.Count);
        }
        [TestMethod]
        public void RemoveLast2()
        {
            Assert.IsFalse(list.RemoveLast());
            Assert.AreEqual(0, list.Count);
        }
        [TestMethod]
        public void RemoveLast3()
        {
            list.AddFirst(item);
            list.RemoveLast(out var type2);
            Assert.AreSame(item, type2);
            Assert.AreEqual(0, list.Count);
        }
        #endregion
        #region OtherFunctions
        [TestMethod]
        public void ToLinkedList()
        {
            var newList = list.ToLinkedList();
            Assert.IsInstanceOfType(newList, typeof(LinkedList<GenericParameterHelper>));
        }
        #endregion
    }
}
