using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _4laboratornaya;

namespace HTable.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LittleElementsTest()
        {
            var hashTable = new _4laboratornaya.HashTable(3);
            hashTable.PutPair("1", "A");
            hashTable.PutPair("2", "B");
            hashTable.PutPair("3", "C");
            Assert.AreEqual(hashTable.GetValueByKey("1"), "A");
            Assert.AreEqual(hashTable.GetValueByKey("2"), "B");
            Assert.AreEqual(hashTable.GetValueByKey("3"), "C");
        }
        [TestMethod]
        public void TheSameKeysTest()
        {
            var hashTable = new _4laboratornaya.HashTable(3);
            hashTable.PutPair("1", "A");
            hashTable.PutPair("1", "B");
            Assert.AreEqual(hashTable.GetValueByKey("1"), "B");
        }
        [TestMethod]
        public void HugeTableElements()
        {
            var hashTable = new _4laboratornaya.HashTable(10000);
            for (int i = 0; i < 10000; i++)
            {
                hashTable.PutPair(i, i + "/");
            }
            Assert.AreEqual(hashTable.GetValueByKey(12), "12/");
        }
        [TestMethod]
        public void ThausandNullTest()
        {
            var hashTable = new _4laboratornaya.HashTable(10000);
            for (int i = 0; i < 9000; i++)
            {
                hashTable.PutPair(i, i + "/");
            }
            Assert.AreEqual(hashTable.GetValueByKey(503), "503/");
            Assert.AreEqual(hashTable.GetValueByKey(9001), null);
        }
    }
}
