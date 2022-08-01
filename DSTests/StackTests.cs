using DataStructuresCs;
using DataStructuresCs.Stack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DSTests
{
    [TestClass]
    public class StackTests
    {
        Stack<GenericParameterHelper> stack;
        readonly GenericParameterHelper item = new GenericParameterHelper();
        readonly GenericParameterHelper item2 = new GenericParameterHelper();

        void Limit(IStack<GenericParameterHelper> stack, int limitLength)
        {
            stack = new Stack<GenericParameterHelper>(stack);
            for (int i = 0; i < Math.Abs(limitLength) * 2; i++)
                stack.Push(item);
            Assert.IsFalse(stack.Push(item));
            Assert.AreEqual(Math.Abs(limitLength), stack.Count);
        }

        #region Array
        void ArrayInit() => stack = new Stack<GenericParameterHelper>(new StackArray<GenericParameterHelper>());
        #region Limited
        [TestMethod]
        public void ALimitedPos() => Limit(new StackArray<GenericParameterHelper>(4), 4);
        [TestMethod]
        public void ALimitedPos1() => Limit(new StackArray<GenericParameterHelper>(1), 1);
        [TestMethod]
        public void ALimited0() => Limit(new StackArray<GenericParameterHelper>(0), 0);
        [TestMethod]
        public void ALimitedMin1() => Limit(new StackArray<GenericParameterHelper>(-1), -1);
        [TestMethod]
        public void ALimitedMin() => Limit(new StackArray<GenericParameterHelper>(-4), -4);
        #endregion
        #region Push
        [TestMethod]
        public void APush1()
        {
            ArrayInit();
            Assert.IsTrue(stack.Push(item));
            Assert.AreEqual(1, stack.Count);
            Assert.AreSame(item, stack.Peek());
        }
        [TestMethod]
        public void APush2()
        {
            ArrayInit();
            stack.Push(item);
            stack.Push(item2);
            Assert.AreEqual(2, stack.Count);
            Assert.AreSame(item2, stack.Peek());
        }
        #endregion
        #region Peek
        [TestMethod]
        public void APeek1()
        {
            ArrayInit();
            Assert.IsNull(stack.Peek());
        }
        [TestMethod]
        public void APeek2()
        {
            ArrayInit();
            stack.Push(item);
            Assert.AreEqual(1, stack.Count);
            Assert.IsNotNull(stack.Peek());
            Assert.AreSame(item, stack.Peek());
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
        #region ChangeStrategy
        [TestMethod]
        public void AChangeStrategyL()
        {
            ArrayInit();
            stack.Push(item);
            stack.Push(item2);
            stack.Push(item);
            stack.ChangeStrategy(new StackLinkedList<GenericParameterHelper>());
            Assert.AreSame(item, stack.Pop());
            Assert.AreSame(item2, stack.Peek());
        }
        [TestMethod]
        public void AChangeStrategyD()
        {
            ArrayInit();
            stack.Push(item);
            stack.Push(item2);
            stack.Push(item);
            stack.ChangeStrategy(new StackDoubleLinkedList<GenericParameterHelper>());
            Assert.AreSame(item, stack.Pop());
            Assert.AreSame(item2, stack.Peek());
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
        [TestMethod]
        public void AIsFull1()
        {
            ArrayInit();
            for (int i = 0; i < 100; i++)
                stack.Push(item);
            Assert.IsFalse(stack.IsFull);
        }
        [TestMethod]
        public void AIsFull2()
        {
            stack = new Stack<GenericParameterHelper>(new StackArray<GenericParameterHelper>(5));
            for (int i = 0; i < 3; i++)
                stack.Push(item);
            Assert.IsFalse(stack.IsFull);
        }
        [TestMethod]
        public void AIsFull3()
        {
            stack = new Stack<GenericParameterHelper>(new StackArray<GenericParameterHelper>(5));
            for (int i = 0; i < 10; i++)
                stack.Push(item);
            Assert.IsTrue(stack.IsFull);
        }
        #endregion
        #endregion
        #region LinkedList
        void LinkedListInit() => stack = new Stack<GenericParameterHelper>(new StackLinkedList<GenericParameterHelper>());
        #region Limited
        [TestMethod]
        public void LLimitedPos() => Limit(new StackLinkedList<GenericParameterHelper>(4), 4);
        [TestMethod]
        public void LLimitedPos1() => Limit(new StackLinkedList<GenericParameterHelper>(1), 1);
        [TestMethod]
        public void LLimited0() => Limit(new StackLinkedList<GenericParameterHelper>(0), 0);
        [TestMethod]
        public void LLimitedMin1() => Limit(new StackLinkedList<GenericParameterHelper>(-1), -1);
        [TestMethod]
        public void LLimitedMin() => Limit(new StackLinkedList<GenericParameterHelper>(-4), -4);
        #endregion
        #region Push
        [TestMethod]
        public void LPush1()
        {
            LinkedListInit();
            Assert.IsTrue(stack.Push(item));
            Assert.AreEqual(1, stack.Count);
            Assert.AreSame(item, stack.Peek());
        }
        [TestMethod]
        public void LPush2()
        {
            LinkedListInit();
            stack.Push(item);
            stack.Push(item2);
            Assert.AreEqual(2, stack.Count);
            Assert.AreSame(item2, stack.Peek());
        }
        #endregion
        #region Peek
        [TestMethod]
        public void LPeek1()
        {
            LinkedListInit();
            Assert.IsNull(stack.Peek());
        }
        [TestMethod]
        public void LPeek2()
        {
            LinkedListInit();
            stack.Push(item);
            Assert.AreEqual(1, stack.Count);
            Assert.IsNotNull(stack.Peek());
            Assert.AreSame(item, stack.Peek());
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
        #region ChangeStrategy
        [TestMethod]
        public void LChangeStrategyA()
        {
            LinkedListInit();
            stack.Push(item);
            stack.Push(item2);
            stack.Push(item);
            stack.ChangeStrategy(new StackArray<GenericParameterHelper>());
            Assert.AreSame(item, stack.Pop());
            Assert.AreSame(item2, stack.Peek());
        }
        [TestMethod]
        public void LChangeStrategyD()
        {
            LinkedListInit();
            stack.Push(item);
            stack.Push(item2);
            stack.Push(item);
            stack.ChangeStrategy(new StackDoubleLinkedList<GenericParameterHelper>());
            Assert.AreSame(item, stack.Pop());
            Assert.AreSame(item2, stack.Peek());
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
        [TestMethod]
        public void LIsFull1()
        {
            LinkedListInit();
            for (int i = 0; i < 100; i++)
                stack.Push(item);
            Assert.IsFalse(stack.IsFull);
        }
        [TestMethod]
        public void LIsFull2()
        {
            stack = new Stack<GenericParameterHelper>(new StackLinkedList<GenericParameterHelper>(5));
            for (int i = 0; i < 3; i++)
                stack.Push(item);
            Assert.IsFalse(stack.IsFull);
        }
        [TestMethod]
        public void LIsFull3()
        {
            stack = new Stack<GenericParameterHelper>(new StackLinkedList<GenericParameterHelper>(5));
            for (int i = 0; i < 10; i++)
                stack.Push(item);
            Assert.IsTrue(stack.IsFull);
        }
        #endregion
        #endregion
        #region DoubleLinkedList
        void DoubleLinkedListInit() => stack =
            new Stack<GenericParameterHelper>(new StackDoubleLinkedList<GenericParameterHelper>());
        #region Limited
        [TestMethod]
        public void DLimitedPos() => Limit(new StackDoubleLinkedList<GenericParameterHelper>(4), 4);
        [TestMethod]
        public void DLimitedPos1() => Limit(new StackDoubleLinkedList<GenericParameterHelper>(1), 1);
        [TestMethod]
        public void DLimited0() => Limit(new StackDoubleLinkedList<GenericParameterHelper>(0), 0);
        [TestMethod]
        public void DLimitedMin1() => Limit(new StackDoubleLinkedList<GenericParameterHelper>(-1), -1);
        [TestMethod]
        public void DLimitedMin() => Limit(new StackDoubleLinkedList<GenericParameterHelper>(-4), -4);
        #endregion
        #region Push
        [TestMethod]
        public void DPush1()
        {
            DoubleLinkedListInit();
            Assert.IsTrue(stack.Push(item));
            Assert.AreEqual(1, stack.Count);
            Assert.AreSame(item, stack.Peek());
        }
        [TestMethod]
        public void DPush2()
        {
            DoubleLinkedListInit();
            stack.Push(item);
            stack.Push(item2);
            Assert.AreEqual(2, stack.Count);
            Assert.AreSame(item2, stack.Peek());
        }
        #endregion
        #region Peek
        [TestMethod]
        public void DPeek1()
        {
            DoubleLinkedListInit();
            Assert.IsNull(stack.Peek());
        }
        [TestMethod]
        public void DPeek2()
        {
            DoubleLinkedListInit();
            stack.Push(item);
            Assert.AreEqual(1, stack.Count);
            Assert.IsNotNull(stack.Peek());
            Assert.AreSame(item, stack.Peek());
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
        #region ChangeStrategy
        [TestMethod]
        public void DChangeStrategyA()
        {
            DoubleLinkedListInit();
            stack.Push(item);
            stack.Push(item2);
            stack.Push(item);
            stack.ChangeStrategy(new StackArray<GenericParameterHelper>());
            Assert.AreSame(item, stack.Pop());
            Assert.AreSame(item2, stack.Peek());
        }
        [TestMethod]
        public void DChangeStrategyL()
        {
            DoubleLinkedListInit();
            stack.Push(item);
            stack.Push(item2);
            stack.Push(item);
            stack.ChangeStrategy(new StackLinkedList<GenericParameterHelper>());
            Assert.AreSame(item, stack.Pop());
            Assert.AreSame(item2, stack.Peek());
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
        [TestMethod]
        public void DIsFull1()
        {
            DoubleLinkedListInit();
            for (int i = 0; i < 100; i++)
                stack.Push(item);
            Assert.IsFalse(stack.IsFull);
        }
        [TestMethod]
        public void DIsFull2()
        {
            stack = new Stack<GenericParameterHelper>(new StackDoubleLinkedList<GenericParameterHelper>(5));
            for (int i = 0; i < 3; i++)
                stack.Push(item);
            Assert.IsFalse(stack.IsFull);
        }
        [TestMethod]
        public void DIsFull3()
        {
            stack = new Stack<GenericParameterHelper>(new StackDoubleLinkedList<GenericParameterHelper>(5));
            for (int i = 0; i < 10; i++)
                stack.Push(item);
            Assert.IsTrue(stack.IsFull);
        }
        #endregion
        #endregion
    }
}
