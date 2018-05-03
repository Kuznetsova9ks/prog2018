using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4laboratornaya
{
    public class HashTable
    {
        public class KeyValuePair
        {
            public object Key { get; set; }
            public object Value { get; set; }
        }

        List<List<KeyValuePair>> list;

        public HashTable(int size)
        {
            list = new List<List<KeyValuePair>>();
            for (int i = 0; i < size; i++)
            {
                list.Add(new List<KeyValuePair>());
            }
        }

        public void PutPair(object key, object value)
        {
            var bag = GetBucketNumber(key);
            foreach (var pair in list[bag])
            {
                if (Equals(pair.Key, key))
                {
                    pair.Value = value;
                    return;
                }
            }

            list[bag].Add(new KeyValuePair { Key = key, Value = value });
        }

        public object GetValueByKey(object key)
        {
            var boolshi = GetBucketNumber(key);
            foreach (var i in list[boolshi])
            {
                if (Equals(i.Key, key))
                {
                    return i.Value;
                }
            }

            return null;
        }

        private int GetBucketNumber(object key)
        {
            return Math.Abs(key.GetHashCode()) % list.Count;
        }
        static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }
}
