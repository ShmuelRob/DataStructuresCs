using DataStructuresCs;
using DataStructuresCs.Stack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSTests
{
    [TestClass]
    public class StackTests
    {
        Stack<GenericParameterHelper> stack;
        readonly GenericParameterHelper item = new GenericParameterHelper();
        readonly GenericParameterHelper item2 = new GenericParameterHelper();
        #region Array
        void ArrayInit() => stack = new Stack<GenericParameterHelper>(StackImplementaion.Array);
        #region Peek
        [TestMethod]
        public void APeek1()
        {
            ArrayInit();
            Assert.IsFalse(stack.Peek(out var data));
            Assert.IsNull(data);
        }
        [TestMethod]
        public void APeek2()
        {
            ArrayInit();
            stack.Push(item);
            Assert.IsTrue(stack.Peek(out var data));
            Assert.AreEqual(1, stack.Count);
            Assert.IsNotNull(data);
            Assert.AreSame(item, data);
        }
        #endregion
        #region Push
        [TestMethod]
        public void APush1()
        {
            ArrayInit();
            stack.Push(item);
            stack.Peek(out var data);
            Assert.AreEqual(1, stack.Count);
            Assert.AreSame(item, data);
        }
        [TestMethod]
        public void APush2()
        {
            ArrayInit();
            stack.Push(item);
            stack.Push(item2);
            stack.Peek(out var data);
            Assert.AreEqual(2, stack.Count);
            Assert.AreSame(item2, data);
        }
        #endregion
        #region Pop
        [TestMethod]
        public void APop1()
        {
            ArrayInit();
            Assert.IsNull(stack.Pop());
            Assert.AreEqual(0, stack.Count);
        }
        [TestMethod]
        public void APop2()
        {
            ArrayInit();
            stack.Push(item);
            Assert.AreSame(item, stack.Pop());
            Assert.AreEqual(0, stack.Count);
        }
        [TestMethod]
        public void APop3()
        {
            ArrayInit();
            stack.Push(item);
            stack.Push(item2);
            Assert.AreSame(item2, stack.Pop());
            Assert.AreEqual(1, stack.Count);
        }
        #endregion
        #region OtherFunctions
        [TestMethod]
        public void AIsEmpty1()
        {
            ArrayInit();
            Assert.IsTrue(stack.IsEmpty);
            Assert.AreEqual(0, stack.Count);
        }
        [TestMethod]
        public void AIsEmpty2()
        {
            ArrayInit();
            stack.Push(item);
            Assert.IsFalse(stack.IsEmpty);
            Assert.AreEqual(1, stack.Count);
        }
        #endregion
        #endregion
        #region LinkedList
        void LinkedListInit() => stack = new Stack<GenericParameterHelper>(StackImplementaion.linkedList);
        #region Peek
        [TestMethod]
        public void LPeek1()
        {
            LinkedListInit();
            Assert.IsFalse(stack.Peek(out var data));
            Assert.IsNull(data);
        }
        [TestMethod]
        public void LPeek2()
        {
            LinkedListInit();
            stack.Push(item);
            Assert.IsTrue(stack.Peek(out var data));
            Assert.AreEqual(1, stack.Count);
            Assert.IsNotNull(data);
            Assert.AreSame(item, data);
        }
        #endregion
        #region Push
        [TestMethod]
        public void LPush1()
        {
            LinkedListInit();
            stack.Push(item);
            stack.Peek(out var data);
            Assert.AreEqual(1, stack.Count);
            Assert.AreSame(item, data);
        }
        [TestMethod]
        public void LPush2()
        {
            LinkedListInit();
            stack.Push(item);
            stack.Push(item2);
            stack.Peek(out var data);
            Assert.AreEqual(2, stack.Count);
            Assert.AreSame(item2, data);
        }
        #endregion
        #region Pop
        [TestMethod]
        public void LPop1()
        {
            LinkedListInit();
            Assert.IsNull(stack.Pop());
            Assert.AreEqual(0, stack.Count);
        }
        [TestMethod]
        public void LPop2()
        {
            LinkedListInit();
            stack.Push(item);
            Assert.AreSame(item, stack.Pop());
            Assert.AreEqual(0, stack.Count);
        }
        [TestMethod]
        public void LPop3()
        {
            LinkedListInit();
            stack.Push(item);
            stack.Push(item2);
            Assert.AreSame(item2, stack.Pop());
            Assert.AreEqual(1, stack.Count);
        }
        #endregion
        #region OtherFunctions
        [TestMethod]
        public void LIsEmpty1()
        {
            LinkedListInit();
            Assert.IsTrue(stack.IsEmpty);
            Assert.AreEqual(0, stack.Count);
        }
        [TestMethod]
        public void LIsEmpty2()
        {
            LinkedListInit();
            stack.Push(item);
            Assert.IsFalse(stack.IsEmpty);
            Assert.AreEqual(1, stack.Count);
        }
        #endregion
        #endregion
        #region DoubleLinkedList
        void DoubleLinkedListInit() => stack = new Stack<GenericParameterHelper>(StackImplementaion.doubleLinkedList);
        #region Peek
        [TestMethod]
        public void DPeek1()
        {
            DoubleLinkedListInit();
            Assert.IsFalse(stack.Peek(out var data));
            Assert.IsNull(data);
        }
        [TestMethod]
        public void DPeek2()
        {
            DoubleLinkedListInit();
            stack.Push(item);
            Assert.IsTrue(stack.Peek(out var data));
            Assert.AreEqual(1, stack.Count);
            Assert.IsNotNull(data);
            Assert.AreSame(item, data);
        }
        #endregion
        #region Push
        [TestMethod]
        public void DPush1()
        {
            DoubleLinkedListInit();
            stack.Push(item);
            stack.Peek(out var data);
            Assert.AreEqual(1, stack.Count);
            Assert.AreSame(item, data);
        }
        [TestMethod]
        public void DPush2()
        {
            DoubleLinkedListInit();
            stack.Push(item);
            stack.Push(item2);
            stack.Peek(out var data);
            Assert.AreEqual(2, stack.Count);
            Assert.AreSame(item2, data);
        }
        #endregion
        #region Pop
        [TestMethod]
        public void DPop1()
        {
            DoubleLinkedListInit();
            Assert.AreEqual(0, stack.Count);
        }
        [TestMethod]
        public void DPop2()
        {
            DoubleLinkedListInit();
            stack.Push(item);
            Assert.AreSame(item, stack.Pop());
            Assert.AreEqual(0, stack.Count);
        }
        [TestMethod]
        public void DPop3()
        {
            DoubleLinkedListInit();
            stack.Push(item);
            stack.Push(item2);
            Assert.AreEqual(item2.Data, stack.Pop().Data);
            Assert.AreEqual(1, stack.Count);
        }
        #endregion
        #region OtherFunctions
        [TestMethod]
        public void DIsEmpty1()
        {
            DoubleLinkedListInit();
            Assert.IsTrue(stack.IsEmpty);
            Assert.AreEqual(0, stack.Count);
        }
        [TestMethod]
        public void DIsEmpty2()
        {
            DoubleLinkedListInit();
            stack.Push(item);
            Assert.IsFalse(stack.IsEmpty);
            Assert.AreEqual(1, stack.Count);
        }
        #endregion
        #endregion
    }
}
