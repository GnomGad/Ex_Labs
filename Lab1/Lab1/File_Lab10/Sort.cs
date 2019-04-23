using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sorting = Labs.Interfaces.ISorts<int>;
using Labs.File_Lab10.Sortings;

namespace Labs.File_Lab10
{
    /// <summary>
    /// Здесь только тесты 
    /// смотреть в 7 лабу
    /// </summary>
    public class Sorts 
    {
        int[] array;
        private int MinRandom = 0;
        private int MaxRandom = 5000;

        public Sorts(int leng)
        {
            Console.WriteLine("Массив был создан и готов к сортировке\r\nЭлементов: {0}\r\nРандом от {1} и до {2}", leng, MinRandom, MaxRandom);
            array = new int[leng];
        }

        Sorting sort1;

        /// <summary>
        /// Этот метод вызывается как первое задание
        /// </summary>
        public void StartSort()
        {

            array = new int[] { 8, 12, 1, 4, 5, 2, 9, 7 };
            Console.WriteLine();
            sort1 = new HeapSorter(array);
            sort1.Sort(0, array.Length);
            array = sort1.a;
            foreach (int i in array)
               Console.Write(i+" ");
        }
    }
    /// <summary>
    /// Реферальный свапер 2х любых элементов
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Swapper<T>
    {
        public  void Swap(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }
    }
}
