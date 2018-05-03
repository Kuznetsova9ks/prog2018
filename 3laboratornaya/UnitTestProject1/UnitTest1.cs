using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QS;

namespace QS.Test
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestLittleArray()
        {
            bool value = false;
            var testArr = new int[3];
            var rnd = new Random();
            for (int i = 0; i < testArr.Length; i++)
                testArr[i] = rnd.Next(0, 10);
            Program.QuickSort(testArr);
            if (testArr[0] <= testArr[1] && testArr[1] <= testArr[2])
                value = true;
            Assert.AreEqual(value, true);
        }
        [TestMethod]
        public void TestHundredElements()
        {
            bool value = false;
            var testArr = new int[100];
            var rnd = new Random();
            for (int i = 0; i < testArr.Length; i++)
                testArr[i] = rnd.Next(0, 10);
            Program.QuickSort(testArr);
            foreach (int e in testArr)
                if (testArr[e] <= testArr[e + 1])
                    value = true;
            Assert.AreEqual(value, true);
        }
        [TestMethod]
        public void TesThousandElementsArray()
        {
            int value = 0;
            var k = 0;
            var testArr = new int[1000];
            var rnd = new Random();
            for (int i = 0; i < testArr.Length; i++)
                testArr[i] = rnd.Next(0, 10);
            Program.QuickSort(testArr);
            while (k <= 9)
            {
                var num1 = rnd.Next(0, 998); 
                var num2 = rnd.Next(num1, 999); 
                if (testArr[num2] >= testArr[num1])
                {
                    value++; 
                }
                k++; 
            }
            Assert.AreEqual(value, k);
        }
        [TestMethod]
        public void TestEmptyArray()
        {
            bool value = false;
            var testArr = new int[0];
            Program.QuickSort(testArr);
            foreach (int e in testArr)
                if (testArr[e] <= testArr[e + 1])
                    value = true;
            Assert.AreEqual(value, false);
        }
        //слабенький ноутик
    }
}