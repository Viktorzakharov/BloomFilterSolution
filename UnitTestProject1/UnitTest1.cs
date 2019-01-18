using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public string[] lines = new string[] {"0123456789", "1234567890", "2345678901", "3456789012", "4567890123",
                                                "5678901234", "6789012345", "7890123456", "8901234567", "9012345678" };

        [TestMethod]
        public void TestAdd()
        {
            var filter = new BloomFilter(32);
            var slot1 = filter.Hash1(lines[0]);
            var slot2 = filter.Hash2(lines[0]);
            filter.Add(lines[0]);
            filter.Add(null);
            Assert.IsTrue(filter.IsValue(lines[0]));
            Assert.IsTrue(filter.bitArray[slot1]);
            Assert.IsTrue(filter.bitArray[slot2]);
            Assert.IsTrue(filter.IsValue(null));
            Assert.IsTrue(filter.bitArray[0]);
        }

        [TestMethod]
        public void TestIsValue()
        {
            var filter = new BloomFilter(32);
            foreach (var line in lines) filter.Add(line);
            foreach (var line in lines) Assert.IsTrue(filter.IsValue(line));
            Assert.IsFalse(filter.IsValue("0113456789"));

        }
    }
}
