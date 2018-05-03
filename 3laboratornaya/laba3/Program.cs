using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QS
{
    public class Program
    {
        public static void QuickSort(int[] array, int start, int end)
        {
            if ((start == end) | (array.Length == 0)) return;
            var index = start;
            var turn = array[end];
            for (int i = start; i < end; i++)
            {
                if (array[i] < turn)
                {
                    var buf = array[i];
                    array[i] = array[index];
                    array[index] = buf;
                    index++;
                }
            }
            var n = array[index];
            array[index] = array[end];
            array[end] = n;
            if (index > start) QuickSort(array, start, index - 1);
            if (index < end) QuickSort(array, index + 1, end);
        }

        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }
        static void Main(string[] args)
        {

        }
    }
}