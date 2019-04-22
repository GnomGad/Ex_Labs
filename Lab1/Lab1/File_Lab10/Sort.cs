using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sorting = Labs.Interfaces.ISorts<int>;
using Labs.File_Lab10.Sortings;

namespace Labs.File_Lab10
{
    public class Sorts 
    {
        Sorting sort;
        /// <summary>
        /// Этот метод вызывается как первое задание
        /// </summary>
        public void StartSort()
        {
            Console.WriteLine();
            int[] k = { 11, 5, 2, 7, 9, 3, 4, 10, 7, 8 };
            sort = new MergeSort(k);

            sort.Sort(0, k.Length-1);
            foreach (int i in sort.a)
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
