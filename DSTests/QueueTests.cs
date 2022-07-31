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
        #endregion
        #region LinkedList
        #endregion
        #region DoubleLinkedList
        #endregion
    }
}
