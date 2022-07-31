using DataStructuresCs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSTests
{
    [TestClass]
    public class LinkedListTests
    {
        readonly GenericParameterHelper item = new GenericParameterHelper();
        readonly LinkedList<GenericParameterHelper> list = new LinkedList<GenericParameterHelper>();
        #region Add
        [TestMethod]
        public void AddFirst1()
        {
            list.AddFirst(item);
            Assert.AreSame(item, list.First);
            Assert.AreSame(list.First, list.Last);
            Assert.AreEqual(1, list.Count);
        }
        [TestMethod]
        public void AddFirst2()
        {
            var item2 = new GenericParameterHelper();
            list.AddFirst(item2);
            list.AddFirst(item);
            Assert.AreSame(item, list.First);
            Assert.AreSame(item2, list.Last);
            Assert.AreEqual(2, list.Count);
        }
        [TestMethod]
        public void AddLast1()
        {
            list.AddLast(item);
            Assert.AreSame(item, list.First);
            Assert.AreSame(item, list.Last);
            Assert.AreEqual(1, list.Count);
        }
        [TestMethod]
        public void AddLast2()
        {
            var item2 = new GenericParameterHelper();
            list.AddLast(item2);
            list.AddLast(item);
            Assert.AreSame(item2, list.First);
            Assert.AreSame(item, list.Last);
            Assert.AreEqual(2, list.Count);
        }
        [TestMethod]
        public void Add()
        {
            list.Add(item);
            Assert.AreSame(item, list.First);
            Assert.AreSame(item, list.Last);
            Assert.AreEqual(1, list.Count);
        }
        [TestMethod]
        public void AddSome()
        {
            var item2 = new GenericParameterHelper();
            list.Add(item, item, item2);

            Assert.AreSame(item, list.First);
            Assert.AreSame(item2, list.Last);
            Assert.AreEqual(3, list.Count);
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
        [TestMethod]
        public void Remove()
        {
            Assert.IsFalse(list.Remove(item));
            Assert.AreEqual(0, list.Count);
        }
        [TestMethod]
        public void Remove2()
        {
            list.Add(item);
            Assert.IsTrue(list.Remove(item));
            Assert.AreEqual(0, list.Count);
        }
        [TestMethod]
        public void Clear()
        {
            list.Clear();
            Assert.AreEqual(0, list.Count);
        }
        #endregion
        #region Contains
        [TestMethod]
        public void Contains1()
        {
            list.Add(item);
            Assert.IsTrue(list.Contains(item));
        }
        [TestMethod]
        public void Contains2() => Assert.IsFalse(list.Contains(item));
        #endregion
        #region CopyTo
        [TestMethod]
        public void CopyTo1()
        {
            var types = new GenericParameterHelper[3];
            list.CopyTo(types);
            foreach (var type in types)
                Assert.IsNull(type);
        }
        [TestMethod]
        public void CopyTo2()
        {
            var types = new GenericParameterHelper[3];
            list.Add(item);
            list.CopyTo(types);
            Assert.IsNotNull(types[0]);
        }
        [TestMethod]
        public void CopyTo3()
        {
            var types = new GenericParameterHelper[3];
            list.Add(item);
            list.Add(item);
            list.CopyTo(types);
            Assert.IsNotNull(types[1]);
        }
        [TestMethod]
        public void CopyTo4()
        {
            var items = new GenericParameterHelper[3];
            list.Add(item);
            list.CopyTo(items, 1);
            Assert.IsNotNull(items[1]);
        }
        #endregion
        #region IndexOf
        [TestMethod]
        public void IndexOf1() => Assert.AreEqual(-1, list.IndexOf(item));
        [TestMethod]
        public void IndexOf2()
        {
            list.Add(item);
            Assert.AreEqual(0, list.IndexOf(item));
        }
        #endregion
        #region Insert
        [TestMethod]
        public void Insert1()
        {
            list.Insert(0, item);
            Assert.AreEqual(1, list.Count);
            Assert.AreSame(item, list.First);
        }
        [TestMethod]
        public void Insert2()
        {
            var item2 = new GenericParameterHelper();
            list.Add(item);
            list.Insert(0, item2);
            Assert.AreEqual(2, list.Count);
            Assert.AreSame(item2, list.First);
            Assert.AreSame(item, list.Last);
        }
        [TestMethod]
        public void Insert3()
        {
            list.Insert(3, item);
            Assert.AreEqual(0, list.IndexOf(item));
            Assert.AreSame(item, list.First);
        }
        [TestMethod]
        public void Insert4()
        {
            var item2 = new GenericParameterHelper();
            list.Add(item);
            list.Add(item);
            list.Insert(1, item2);
            Assert.AreEqual(3, list.Count);
            Assert.AreSame(item2, list[1]);
        }
        #endregion
        #region RemoveAt
        [TestMethod]
        public void RemoveAt1()
        {
            list.Add(item, item, item);
            list.RemoveAt(0);
            Assert.AreEqual(2, list.Count);
            Assert.IsNotNull(list.First);
            Assert.IsNotNull(list[0]);
        }
        [TestMethod]
        public void RemoveAt2()
        {
            list.Add(item, item);
            list.RemoveAt(5);
            Assert.AreEqual(2, list.Count);
            Assert.IsNotNull(list[1]);
        }
        [TestMethod]
        public void RemoveAt3()
        {
            list.Add(item, item);
            list.RemoveAt(1);
            Assert.AreEqual(1, list.Count);
        }
        #endregion
        #region OtherFunctions
        [TestMethod]
        public void ToDoubleLinkedList()
        {
            var newList = list.ToDoubleLinkedList();
            Assert.IsInstanceOfType(newList, typeof(DoubleLinkedList<GenericParameterHelper>));
        }
        [TestMethod]
        public void CheckReadonly()
        {
            list.IsReadOnly = true;
            list.AddFirst(item);
            Assert.AreEqual(0, list.Count);
        }
        [TestMethod]
        public void CheckEmpty()
        {
            Assert.IsTrue(list.IsEmpty);
            Assert.AreEqual(0, list.Count);
        }
        #endregion
    }
}
