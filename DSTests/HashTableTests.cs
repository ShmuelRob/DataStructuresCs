using DataStructuresCs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

/**
* TValue this[TKey key]
*/

namespace DSTests
{
    [TestClass]
    public class HashTableTests
    {
        #region Definitions
        const int numbersConst = 15;
        readonly HashTable<GenericParameterHelper, GenericParameterHelper> hash1 =
            new HashTable<GenericParameterHelper, GenericParameterHelper>(8);
        readonly HashTable<GenericParameterHelper, GenericParameterHelper> hash2 =
            new HashTable<GenericParameterHelper, GenericParameterHelper>(8, CustomHashFunc);
        static int CustomHashFunc(GenericParameterHelper param)
            => param.GetHashCode() + 16;
        #endregion
        #region Add
        [TestMethod]
        public void Add1()
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash1.Add(k, v);
            Assert.AreEqual(1, hash1.Count);
        }
        [TestMethod]
        public void Add1WC() //with custom 
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash2.Add(k, v);
            Assert.AreEqual(1, hash2.Count);
        }
        [TestMethod]
        public void Add2()
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash1.Add(k, v);
            Assert.ThrowsException<ArgumentException>(() => hash1.Add(k, v));
        }
        [TestMethod]
        public void Add2WC()
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash2.Add(k, v);
            Assert.ThrowsException<ArgumentException>(() => hash2.Add(k, v));
        }
        [TestMethod]
        public void Add3()
        {
            for (int i = 0; i < numbersConst; i++)
            {
                hash1.Add(new GenericParameterHelper(), new GenericParameterHelper());
            }
            Assert.AreEqual(numbersConst, hash1.Count);
        }
        [TestMethod]
        public void Add3WC()
        {
            for (int i = 0; i < numbersConst; i++)
            {
                hash2.Add(new GenericParameterHelper(), new GenericParameterHelper());
            }
            Assert.AreEqual(numbersConst, hash2.Count);
        }
        #endregion
        #region Remove
        [TestMethod]
        public void Remove1()
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash1.Add(k, v);
            Assert.IsTrue(hash1.Remove(k));
            Assert.AreEqual(0, hash1.Count);
        }
        [TestMethod]
        public void Remoce1WC()
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash2.Add(k, v);
            Assert.IsTrue(hash2.Remove(k));
            Assert.AreEqual(0, hash2.Count);
        }
        [TestMethod]
        public void Remove2()
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash1.Add(k, v);
            hash1.Add(new GenericParameterHelper(), v);
            Assert.IsTrue(hash1.Remove(k));
            Assert.AreEqual(1, hash1.Count);
        }
        [TestMethod]
        public void Remove2WC()
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash2.Add(k, v);
            hash2.Add(new GenericParameterHelper(), v);
            Assert.IsTrue(hash2.Remove(k));
            Assert.AreEqual(1, hash2.Count);
        }
        [TestMethod]
        public void Remove3()
        {
            var k = new GenericParameterHelper();
            Assert.IsFalse(hash1.Remove(k));
            Assert.AreEqual(0, hash1.Count);
        }
        [TestMethod]
        public void Remove3WC()
        {
            var k = new GenericParameterHelper();
            Assert.IsFalse(hash2.Remove(k));
            Assert.AreEqual(0, hash2.Count);
        }
        [TestMethod]
        public void Remove4()
        {
            var keys = new GenericParameterHelper[numbersConst];
            var values = new GenericParameterHelper[numbersConst];
            for (int i = 0; i < numbersConst; i++)
            {
                keys[i] = new GenericParameterHelper();
                values[i] = new GenericParameterHelper();
                hash1.Add(keys[i], values[i]);
            }
            for (int i = 0; i < numbersConst; i++)
            {
                Assert.IsTrue(hash1.Remove(keys[i]));
            }
            Assert.AreEqual(0, hash1.Count);
        }
        [TestMethod]
        public void Remove4WC()
        {
            var keys = new GenericParameterHelper[numbersConst];
            var values = new GenericParameterHelper[numbersConst];
            for (int i = 0; i < numbersConst; i++)
            {
                keys[i] = new GenericParameterHelper();
                values[i] = new GenericParameterHelper();
                hash2.Add(keys[i], values[i]);
            }
            for (int i = 0; i < numbersConst; i++)
            {
                Assert.IsTrue(hash2.Remove(keys[i]));
            }
            Assert.AreEqual(0, hash2.Count);
        }
        #endregion
        #region Clear
        [TestMethod]
        public void Clear1()
        {
            hash1.Add(new GenericParameterHelper(), new GenericParameterHelper());
            hash1.Clear();
            Assert.AreEqual(0, hash1.Count);
        }
        [TestMethod]
        public void Clear1WC()
        {
            hash2.Add(new GenericParameterHelper(), new GenericParameterHelper());
            hash2.Clear();
            Assert.AreEqual(0, hash2.Count);
        }
        [TestMethod]
        public void Clear2()
        {
            for (int i = 0; i < numbersConst; i++)
            {
                hash1.Add(new GenericParameterHelper(), new GenericParameterHelper());
            }
            hash1.Clear();
            Assert.AreEqual(0, hash1.Count);
        }
        [TestMethod]
        public void Clear2WC()
        {
            for (int i = 0; i < numbersConst; i++)
            {
                hash2.Add(new GenericParameterHelper(), new GenericParameterHelper());
            }
            hash2.Clear();
            Assert.AreEqual(0, hash2.Count);
        }
        [TestMethod]
        public void Clear3()
        {
            hash1.Clear();
            Assert.AreEqual(0, hash1.Count);
        }
        [TestMethod]
        public void Clear3WC()
        {
            hash2.Clear();
            Assert.AreEqual(0, hash2.Count);
        }
        #endregion
        #region ContainsKey
        [TestMethod]
        public void ContainsKey1()
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash1.Add(k, v);
            Assert.IsTrue(hash1.ContainsKey(k));
        }
        [TestMethod]
        public void ContainsKey1WC()
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash2.Add(k, v);
            Assert.IsTrue(hash2.ContainsKey(k));
        }
        [TestMethod]
        public void ContainsKey2()
        {
            var k = new GenericParameterHelper();
            var k2 = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash1.Add(k, v);
            hash1.Add(k2, v);
            Assert.IsTrue(hash1.ContainsKey(k));
            Assert.IsTrue(hash1.ContainsKey(k2));
        }
        [TestMethod]
        public void ContainsKey2WC()
        {
            var k = new GenericParameterHelper();
            var k2 = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash2.Add(k, v);
            hash2.Add(k2, v);
            Assert.IsTrue(hash2.ContainsKey(k));
            Assert.IsTrue(hash2.ContainsKey(k2));
        }
        [TestMethod]
        public void ContainsKey3()
        {
            var k = new GenericParameterHelper();
            Assert.IsFalse(hash1.ContainsKey(k));
        }
        [TestMethod]
        public void ContainsKey3WC()
        {
            var k = new GenericParameterHelper();
            Assert.IsFalse(hash2.ContainsKey(k));
        }
        #endregion
        #region ContainsValue
        [TestMethod]
        public void ContainsValue1()
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash1.Add(k, v);
            Assert.IsTrue(hash1.ContainsValue(v));
        }
        [TestMethod]
        public void ContainsValue1WC()
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash2.Add(k, v);
            Assert.IsTrue(hash2.ContainsValue(v));
        }
        [TestMethod]
        public void ContainsValue2()
        {
            var k = new GenericParameterHelper();
            var k2 = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash1.Add(k, v);
            hash1.Add(k2, v);
            Assert.IsTrue(hash1.ContainsValue(v));
        }
        [TestMethod]
        public void ContainsValue2WC()
        {
            var k = new GenericParameterHelper();
            var k2 = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash2.Add(k, v);
            hash2.Add(k2, v);
            Assert.IsTrue(hash2.ContainsValue(v));
        }
        [TestMethod]
        public void ContainsValue3()
        {
            var v = new GenericParameterHelper();
            Assert.IsFalse(hash1.ContainsValue(v));
        }
        [TestMethod]
        public void ContainsValue3WC()
        {
            var v = new GenericParameterHelper();
            Assert.IsFalse(hash2.ContainsValue(v));
        }
        #endregion
        #region TryGetValue
        [TestMethod]
        public void TryGetValue1()
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash1.Add(k, v);
            Assert.IsTrue(hash1.TryGetValue(k, out var output));
            Assert.AreEqual(v, output);
        }
        [TestMethod]
        public void TryGetValue1WC()
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash2.Add(k, v);
            Assert.IsTrue(hash2.TryGetValue(k, out var output));
            Assert.AreEqual(v, output);
        }
        [TestMethod]
        public void TryGetValue2()
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash1.Add(new GenericParameterHelper(), new GenericParameterHelper());
            hash1.Add(k, v);
            Assert.IsTrue(hash1.TryGetValue(k, out var output));
            Assert.AreEqual(v, output);
        }
        [TestMethod]
        public void TryGetValue2WC()
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash2.Add(new GenericParameterHelper(), new GenericParameterHelper());
            hash2.Add(k, v);
            Assert.IsTrue(hash2.TryGetValue(k, out var output));
            Assert.AreEqual(v, output);
        }
        [TestMethod]
        public void TryGetValue3()
        {
            var k = new GenericParameterHelper();
            Assert.IsFalse(hash1.TryGetValue(k, out _));
        }
        [TestMethod]
        public void TryGetValue3WC()
        {
            var k = new GenericParameterHelper();
            Assert.IsFalse(hash2.TryGetValue(k, out _));
        }
        #endregion
        #region IndexerGet
        [TestMethod]
        public void IndexerGet1()
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash1.Add(k, v);
            Assert.AreEqual(v, hash1[k]);
        }
        [TestMethod]
        public void IndexerGet1WC()
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash2.Add(k, v);
            Assert.AreEqual(v, hash2[k]);
        }
        [TestMethod]
        public void IndexerGet2()
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash1.Add(k, v);
            Assert.ThrowsException<KeyNotFoundException>(() => hash1[v]);
        }
        [TestMethod]
        public void IndexerGet2WC()
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash2.Add(k, v);
            Assert.ThrowsException<KeyNotFoundException>(() => hash2[v]);
        }
        #endregion
        #region IndexerSet
        [TestMethod]
        public void IndexerSet1()
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash1[k] = v;
            Assert.AreEqual(1, hash1.Count);
            Assert.IsTrue(hash1.ContainsValue(v));
        }
        [TestMethod]
        public void IndexerSet1WC()
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            hash2[k] = v;
            Assert.AreEqual(1, hash2.Count);
            Assert.IsTrue(hash2.ContainsValue(v));
        }
        [TestMethod]
        public void IndexerSet2()
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            var v2 = new GenericParameterHelper();
            hash1.Add(k, v);
            hash1[k] = v2;
            Assert.AreEqual(1, hash1.Count);
            Assert.IsTrue(hash1.ContainsValue(v2));
            Assert.IsFalse(hash1.ContainsValue(v));
        }
        [TestMethod]
        public void IndexerSet2WC()
        {
            var k = new GenericParameterHelper();
            var v = new GenericParameterHelper();
            var v2 = new GenericParameterHelper();
            hash2.Add(k, v);
            hash2[k] = v2;
            Assert.AreEqual(1, hash2.Count);
            Assert.IsTrue(hash2.ContainsValue(v2));
            Assert.IsFalse(hash2.ContainsValue(v));
        }
        #endregion
        #region Keys
        [TestMethod]
        public void Keys1()
        {
            var keys = new GenericParameterHelper[numbersConst];
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i] = new GenericParameterHelper();
                hash1.Add(keys[i], new GenericParameterHelper());
            }
            Assert.AreEqual(numbersConst, hash1.Keys.Length);
            Assert.IsTrue(hash1.Keys.Any(k => k.Equals(keys[0])));
        }
        [TestMethod]
        public void Keys1WC()
        {
            var keys = new GenericParameterHelper[numbersConst];
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i] = new GenericParameterHelper();
                hash2.Add(keys[i], new GenericParameterHelper());
            }
            Assert.AreEqual(numbersConst, hash2.Keys.Length);
            Assert.IsTrue(hash2.Keys.Any(k => k.Equals(keys[0])));
        }
        [TestMethod]
        public void Keys2()
        {
            var keys = new GenericParameterHelper[numbersConst];
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i] = new GenericParameterHelper();
                hash1.Add(keys[i], new GenericParameterHelper());
            }
            Assert.IsFalse(hash1.Keys.Any(k => k.Equals(new GenericParameterHelper())));
        }
        [TestMethod]
        public void Keys2WC()
        {
            var keys = new GenericParameterHelper[numbersConst];
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i] = new GenericParameterHelper();
                hash2.Add(keys[i], new GenericParameterHelper());
            }
            Assert.IsFalse(hash1.Keys.Any(k => k.Equals(new GenericParameterHelper())));
        }
        #endregion
        #region Values
        [TestMethod]
        public void Values1()
        {
            var keys = new GenericParameterHelper[numbersConst];
            var values = new GenericParameterHelper[numbersConst];
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i] = new GenericParameterHelper();
                values[i] = new GenericParameterHelper();
                hash1.Add(keys[i], values[i]);
            }
            Assert.AreEqual(numbersConst, hash1.Values.Length);
            Assert.IsTrue(hash1.Values.Any(k => k.Equals(values[0])));
        }
        [TestMethod]
        public void Values1WC()
        {
            var keys = new GenericParameterHelper[numbersConst];
            var values = new GenericParameterHelper[numbersConst];
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i] = new GenericParameterHelper();
                values[i] = new GenericParameterHelper();
                hash2.Add(keys[i], values[i]);
            }
            Assert.AreEqual(numbersConst, hash2.Values.Length);
            Assert.IsTrue(hash2.Values.Any(k => k.Equals(values[0])));
        }
        [TestMethod]
        public void Values2()
        {
            var keys = new GenericParameterHelper[numbersConst];
            var values = new GenericParameterHelper[numbersConst];
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i] = new GenericParameterHelper();
                values[i] = new GenericParameterHelper();
                hash1.Add(keys[i], values[i]);
            }
            Assert.IsFalse(hash1.Keys.Any(k => k.Equals(new GenericParameterHelper())));
        }
        [TestMethod]
        public void VAlues2WC()
        {
            var keys = new GenericParameterHelper[numbersConst];
            var values = new GenericParameterHelper[numbersConst];
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i] = new GenericParameterHelper();
                values[i] = new GenericParameterHelper();
                hash2.Add(keys[i], values[i]);
            }
            Assert.IsFalse(hash2.Keys.Any(k => k.Equals(new GenericParameterHelper())));
        }
        #endregion
    }
}
