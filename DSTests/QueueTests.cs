using DataStructuresCs;
using DataStructuresCs.Queue;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DSTests
{
    [TestClass]
    public class QueueTests
    {
        Queue<GenericParameterHelper> queue;
        readonly GenericParameterHelper item = new GenericParameterHelper();
        readonly GenericParameterHelper item2 = new GenericParameterHelper();

        void Limit(QueueImplementaion imp, int limitLength)
        {
            queue = new Queue<GenericParameterHelper>(imp, limitLength);
            for (int i = 0; i < Math.Abs(limitLength) * 2; i++)
                queue.EnQueue(item);
            Assert.AreEqual(Math.Abs(limitLength), queue.Count);
        }

        #region Array
        void ArrayInit() => queue = new Queue<GenericParameterHelper>(QueueImplementaion.Array);
        #region Limited
        [TestMethod]
        public void ALimitedPos() => Limit(QueueImplementaion.Array, 4);
        [TestMethod]
        public void ALimitedPos1() => Limit(QueueImplementaion.Array, 1);
        [TestMethod]
        public void ALimited0() => Limit(QueueImplementaion.Array, 0);
        [TestMethod]
        public void ALimitedMin1() => Limit(QueueImplementaion.Array, -1);
        [TestMethod]
        public void ALimitedMin() => Limit(QueueImplementaion.Array, -4);
        #endregion
        #region Enqueue
        [TestMethod]
        public void AEnQueue0()
        {
            queue = new Queue<GenericParameterHelper>(QueueImplementaion.Array, 0);
            Assert.IsFalse(queue.EnQueue(item));
        }
        [TestMethod]
        public void AEnQueue1()
        {
            ArrayInit();
            queue.EnQueue(item);
            Assert.AreEqual(1, queue.Count);
        }
        [TestMethod]
        public void AEnQueue2()
        {
            ArrayInit();
            queue.EnQueue(item);
            queue.EnQueue(item);
            Assert.AreEqual(2, queue.Count);
        }
        [TestMethod]
        public void AEnQueue3()
        {
            ArrayInit();
            for (int i = 0; i < 30; i++)
                Assert.IsTrue(queue.EnQueue(item));
            Assert.AreEqual(30, queue.Count);
        }
        #endregion
        #region Dequeue
        [TestMethod]
        public void ADeQueue1()
        {
            ArrayInit();
            queue.EnQueue(item);
            Assert.IsTrue(queue.DeQueue(out var data));
            Assert.AreEqual(0, queue.Count);
            Assert.AreSame(item, data);
        }
        [TestMethod]
        public void ADeQueue2()
        {
            ArrayInit();
            Assert.IsFalse(queue.DeQueue(out _));
            Assert.AreEqual(0, queue.Count);
        }
        #endregion
        #region Peek
        [TestMethod]
        public void APeek1()
        {
            ArrayInit();
            queue.EnQueue(item);
            Assert.IsTrue(queue.Peek(out var data));
            Assert.AreSame(item, data);
        }
        [TestMethod]
        public void APeek2()
        {
            ArrayInit();
            queue.EnQueue(item);
            queue.EnQueue(item2);
            Assert.IsTrue(queue.Peek(out var data));
            Assert.AreSame(item, data);
        }
        [TestMethod]
        public void APeek3()
        {
            ArrayInit();
            Assert.IsFalse(queue.Peek(out _));
        }
        #endregion
        #region OtherFunctions
        [TestMethod]
        public void AIsEmpty1()
        {
            ArrayInit();
            Assert.IsTrue(queue.IsEmpty);
            Assert.AreEqual(0, queue.Count);
        }
        [TestMethod]
        public void AIsEmpty2()
        {
            ArrayInit();
            queue.EnQueue(item);
            Assert.IsFalse(queue.IsEmpty);
            Assert.AreNotEqual(0, queue.Count);
        }
        [TestMethod]
        public void AIsEmpty3()
        {
            ArrayInit();
            Assert.IsFalse(queue.DeQueue(out _));
            Assert.IsTrue(queue.IsEmpty);
        }
        [TestMethod]
        public void AIsFull1()
        {
            var length = 3;
            queue = new Queue<GenericParameterHelper>(QueueImplementaion.Array, length);
            for (int i = 0; i < length + 1; i++)
                queue.EnQueue(item);
            Assert.IsTrue(queue.IsFull);
            Assert.AreEqual(length, queue.Count);
        }
        [TestMethod]
        public void AIsFull2()
        {
            queue = new Queue<GenericParameterHelper>(QueueImplementaion.Array, 5);
            Assert.IsFalse(queue.IsFull);

        }
        [TestMethod]
        public void AIsFull3()
        {
            ArrayInit();
            for (int i = 0; i < 50; i++)
                queue.EnQueue(item);
            Assert.IsFalse(queue.IsFull);
        }
        #endregion
        #endregion
        #region LinkedList
        void LinkedListInit() => queue = new Queue<GenericParameterHelper>(QueueImplementaion.LinkedList);
        #region Limited
        [TestMethod]
        public void LLimitedPos() => Limit(QueueImplementaion.LinkedList, 4);
        [TestMethod]
        public void LLimitedPos1() => Limit(QueueImplementaion.LinkedList, 1);
        [TestMethod]
        public void LLimited0() => Limit(QueueImplementaion.LinkedList, 0);
        [TestMethod]
        public void LLimitedMin1() => Limit(QueueImplementaion.LinkedList, -1);
        [TestMethod]
        public void LLimitedMin() => Limit(QueueImplementaion.LinkedList, -4);
        #endregion
        #region Enqueue
        [TestMethod]
        public void LEnQueue0()
        {
            queue = new Queue<GenericParameterHelper>(QueueImplementaion.LinkedList, 0);
            Assert.IsFalse(queue.EnQueue(item));
        }
        [TestMethod]
        public void LEnQueue1()
        {
            LinkedListInit();
            queue.EnQueue(item);
            Assert.AreEqual(1, queue.Count);
        }
        [TestMethod]
        public void LEnQueue2()
        {
            LinkedListInit();
            queue.EnQueue(item);
            queue.EnQueue(item);
            Assert.AreEqual(2, queue.Count);
        }
        [TestMethod]
        public void LEnQueue3()
        {
            LinkedListInit();
            for (int i = 0; i < 30; i++)
                Assert.IsTrue(queue.EnQueue(item));
            Assert.AreEqual(30, queue.Count);
        }
        #endregion
        #region Dequeue
        [TestMethod]
        public void LDeQueue1()
        {
            LinkedListInit();
            queue.EnQueue(item);
            Assert.IsTrue(queue.DeQueue(out var data));
            Assert.AreEqual(0, queue.Count);
            Assert.AreSame(item, data);
        }
        [TestMethod]
        public void LDeQueue2()
        {
            LinkedListInit();
            Assert.IsFalse(queue.DeQueue(out _));
            Assert.AreEqual(0, queue.Count);
        }
        #endregion
        #region Peek
        [TestMethod]
        public void LPeek1()
        {
            LinkedListInit();
            queue.EnQueue(item);
            Assert.IsTrue(queue.Peek(out var data));
            Assert.AreSame(item, data);
        }
        [TestMethod]
        public void LPeek2()
        {
            LinkedListInit();
            queue.EnQueue(item);
            queue.EnQueue(item2);
            Assert.IsTrue(queue.Peek(out var data));
            Assert.AreSame(item, data);
        }
        [TestMethod]
        public void LPeek3()
        {
            LinkedListInit();
            Assert.IsFalse(queue.Peek(out _));
        }
        #endregion
        #region OtherFunctions
        [TestMethod]
        public void LIsEmpty1()
        {
            LinkedListInit();
            Assert.IsTrue(queue.IsEmpty);
            Assert.AreEqual(0, queue.Count);
        }
        [TestMethod]
        public void LIsEmpty2()
        {
            LinkedListInit();
            queue.EnQueue(item);
            Assert.IsFalse(queue.IsEmpty);
            Assert.AreNotEqual(0, queue.Count);
        }
        [TestMethod]
        public void LIsEmpty3()
        {
            LinkedListInit();
            Assert.IsFalse(queue.DeQueue(out _));
            Assert.IsTrue(queue.IsEmpty);
        }
        [TestMethod]
        public void LIsFull1()
        {
            var length = 3;
            queue = new Queue<GenericParameterHelper>(QueueImplementaion.LinkedList, length);
            for (int i = 0; i < length + 1; i++)
                queue.EnQueue(item);
            Assert.IsTrue(queue.IsFull);
            Assert.AreEqual(length, queue.Count);
        }
        [TestMethod]
        public void LIsFull2()
        {
            queue = new Queue<GenericParameterHelper>(QueueImplementaion.LinkedList, 5);
            Assert.IsFalse(queue.IsFull);

        }
        [TestMethod]
        public void LIsFull3()
        {
            LinkedListInit();
            for (int i = 0; i < 50; i++)
                queue.EnQueue(item);
            Assert.IsFalse(queue.IsFull);
        }
        #endregion
        #endregion
        #region DoubleLinkedList
        void DoubleLinkedListInit() => queue = new Queue<GenericParameterHelper>(QueueImplementaion.DoubleLinkedList);
        #region Limited
        [TestMethod]
        public void DLimitedPos() => Limit(QueueImplementaion.DoubleLinkedList, 4);
        [TestMethod]
        public void DLimitedPos1() => Limit(QueueImplementaion.DoubleLinkedList, 1);
        [TestMethod]
        public void DLimited0() => Limit(QueueImplementaion.DoubleLinkedList, 0);
        [TestMethod]
        public void DLimitedMin1() => Limit(QueueImplementaion.DoubleLinkedList, -1);
        [TestMethod]
        public void DLimitedMin() => Limit(QueueImplementaion.DoubleLinkedList, -4);
        #endregion
        #region Enqueue
        [TestMethod]
        public void DEnQueue0()
        {
            queue = new Queue<GenericParameterHelper>(QueueImplementaion.DoubleLinkedList, 0);
            Assert.IsFalse(queue.EnQueue(item));
        }
        [TestMethod]
        public void DEnQueue1()
        {
            DoubleLinkedListInit();
            queue.EnQueue(item);
            Assert.AreEqual(1, queue.Count);
        }
        [TestMethod]
        public void DEnQueue2()
        {
            DoubleLinkedListInit();
            queue.EnQueue(item);
            queue.EnQueue(item);
            Assert.AreEqual(2, queue.Count);
        }
        [TestMethod]
        public void DEnQueue3()
        {
            DoubleLinkedListInit();
            for (int i = 0; i < 30; i++)
                Assert.IsTrue(queue.EnQueue(item));
            Assert.AreEqual(30, queue.Count);
        }
        #endregion
        #region Dequeue
        [TestMethod]
        public void DDeQueue1()
        {
            DoubleLinkedListInit();
            queue.EnQueue(item);
            Assert.IsTrue(queue.DeQueue(out var data));
            Assert.AreEqual(0, queue.Count);
            Assert.AreSame(item, data);
        }
        [TestMethod]
        public void DDeQueue2()
        {
            DoubleLinkedListInit();
            Assert.IsFalse(queue.DeQueue(out _));
            Assert.AreEqual(0, queue.Count);
        }
        #endregion
        #region Peek
        [TestMethod]
        public void DPeek1()
        {
            DoubleLinkedListInit();
            queue.EnQueue(item);
            Assert.IsTrue(queue.Peek(out var data));
            Assert.AreSame(item, data);
        }
        [TestMethod]
        public void DPeek2()
        {
            DoubleLinkedListInit();
            queue.EnQueue(item);
            queue.EnQueue(item2);
            Assert.IsTrue(queue.Peek(out var data));
            Assert.AreSame(item, data);
        }
        [TestMethod]
        public void DPeek3()
        {
            DoubleLinkedListInit();
            Assert.IsFalse(queue.Peek(out _));
        }
        #endregion
        #region OtherFunctions
        [TestMethod]
        public void DIsEmpty1()
        {
            DoubleLinkedListInit();
            Assert.IsTrue(queue.IsEmpty);
            Assert.AreEqual(0, queue.Count);
        }
        [TestMethod]
        public void DIsEmpty2()
        {
            DoubleLinkedListInit();
            queue.EnQueue(item);
            Assert.IsFalse(queue.IsEmpty);
            Assert.AreNotEqual(0, queue.Count);
        }
        [TestMethod]
        public void DIsEmpty3()
        {
            DoubleLinkedListInit();
            Assert.IsFalse(queue.DeQueue(out _));
            Assert.IsTrue(queue.IsEmpty);
        }
        [TestMethod]
        public void DIsFull1()
        {
            var length = 3;
            queue = new Queue<GenericParameterHelper>(QueueImplementaion.DoubleLinkedList, length);
            for (int i = 0; i < length + 1; i++)
                queue.EnQueue(item);
            Assert.IsTrue(queue.IsFull);
            Assert.AreEqual(length, queue.Count);
        }
        [TestMethod]
        public void DIsFull2()
        {
            queue = new Queue<GenericParameterHelper>(QueueImplementaion.DoubleLinkedList, 5);
            Assert.IsFalse(queue.IsFull);

        }
        [TestMethod]
        public void DIsFull3()
        {
            DoubleLinkedListInit();
            for (int i = 0; i < 50; i++)
                queue.EnQueue(item);
            Assert.IsFalse(queue.IsFull);
        }
        #endregion
        #endregion
    }
}
