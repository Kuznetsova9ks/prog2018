using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication81
{
    class Program
    {
        public static int BinarySearch(int[] array, int value)
        //код поиска значения value в массиве array
        {
            var left = 0;
            var right = array.Length - 1;
            while (left < right)
            {
                var middle = (right + left) / 2;
                if (value <= array[middle])
                    right = middle;
                else left = middle + 1;
            }
            if (right > 0 && array[right] == value)
                return right;
            return -1;
        }
        static void Main(string[] args)
        {
            TestSearchElement();
            TestNegativeNumbers();
            TestNonExistentElement();
            TestRepeatElement();
            TestEmptyArray();
            TestManyElements();

            Console.ReadKey();
        }
        private static void TestSearchElement()
        {
            //Тестирование поиска элемента в массиве
            int[] element = new[] { 1, 3, 5, 7, 9 };
            if (BinarySearch(element, 5) != 2)
                Console.WriteLine("! Поиск не нашёл число 5 среди чисел {1, 3, 5, 7, 9}");
            else
                Console.WriteLine("Поиск одного элемента в массиве из 5 элементов работает корректно");
        }

        private static void TestNegativeNumbers()
        {
            //Тестирование поиска в отрицательных числах

            int[] negativeNumbers = new[] { -5, -4, -3, -2 };
            if (BinarySearch(negativeNumbers, -3) != 2)
                Console.WriteLine("! Поиск не нашёл число -3 среди чисел {-5, -4, -3, -2}");
            else
                Console.WriteLine("Поиск среди отрицательных чисел работает корректно");
        }
        private static void TestNonExistentElement()

        {
            //Тестирование поиска отсутствующего элемента
            int[] negativeNumbers = new[] { -5, -4, -3, -2 };
            if (BinarySearch(negativeNumbers, -1) >= 0)
                Console.WriteLine("! Поиск  не нашёл число -1 среди чисел {-5, -4, -3, -2}");
            else
                Console.WriteLine("Поиск отсутствующего элемента вернул корректный результат");
        }

        private static void TestRepeatElement()
        //Тестирование поиска элемента, повторяющегося несколько раз
        {
            int[] element = new[] { 1, 3, 5, 9, 9 };
            if (BinarySearch(element, 9) != 3)
                Console.WriteLine("! Поиск не нашёл повторяющийся элемент в массиве { 1, 3, 5, 9, 9 }");
            else
                Console.WriteLine("Поиск повторяющегося элемента работает корректно");

        }

        private static void TestEmptyArray()
        //Тестирование поиска в пустом массиве 
        {
            int[] empty = new int[0];
            if (BinarySearch(empty, 3) != -1)
                Console.WriteLine("! Поиск в пустом массиве(содержащем 0 элементов) работает НЕ корректно");
            else
                Console.WriteLine("Поиск в пустом массиве(содержащем 0 элементов) работает корректно");
        }

        private static void TestManyElements()
        //Тестирование поиска в массиве из 100001 элементов
        {
            int[] manyElements = new int[100001];
            for (int i = 0; i < 100001; i++)
            {
                manyElements[i] = i;
            }

            if (BinarySearch(manyElements, 3) != 3)
                Console.WriteLine("! Поиск в массиве из 100001 элементов работает НЕ корректно");
            else
                Console.WriteLine("Поиск в массиве из 100001 элементов работает корректно");
        }
    }

}