using System;
using System.IO;
using System.Collections;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;
        public BitArray bitArray;

        public BloomFilter(int f_len)
        {
            filter_len = f_len;
            bitArray = new BitArray(filter_len);
        }

        public int Hash1(string str1)
        {
            return GetSlot(str1, 17);
        }

        public int Hash2(string str1)
        {
            return GetSlot(str1, 223);
        }

        private int GetSlot(string line, int random)
        {
            if (line == null) return 0;
            var result = 0;
            for (int i = 0; i < line.Length; i++) result = (result * random + line[i]) % filter_len;
            return result;
        }

        public void Add(string str1)
        {
            bitArray[Hash1(str1)] = true;
            bitArray[Hash2(str1)] = true;
        }

        public bool IsValue(string str1)
        {
            if (bitArray[Hash1(str1)] && bitArray[Hash2(str1)]) return true;
            return false;
        }
    }
}
