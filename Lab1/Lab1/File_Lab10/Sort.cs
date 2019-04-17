using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sorting = Labs.Interfaces.ISorts<int>;
namespace Labs.File_Lab10
{
   /// <summary>
   /// фронтед сортировок
   /// </summary>
    public class Sorts 
    {
        public void Sort()
        {
            Console.WriteLine();
            int[] k = { 11, 5, 2, 7, 9, 3, 4, 10, 7, 8 };
            Sorting sort = new QuickSort(k);

            sort.Sort(0, k.Length-1);
            foreach (int i in sort.a)
                Console.Write(i+" ");
        }

    }

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
