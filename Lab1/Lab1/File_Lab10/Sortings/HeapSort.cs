using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sorting = Labs.Interfaces.ISorts<int>;

namespace Labs.File_Lab10.Sortings
{
    class HeapSorter : Sorting
    {
        public HeapSorter(int[] a)
        {
            this.a = a;
        }
        public int[] a { get; set; }
        private void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
        void heapify(int[] a, int n, int i)
        {
            // для нахождения левой и правой и собственно сравнение их на элементы
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && a[l] < a[largest])
                largest = l;

            if (r < n && a[r] < a[largest])
                largest = r;

            // свапнуть и продолжать накапливать
            if (largest != i)
            {
                Swap(ref a[i], ref a[largest]);
                heapify(a, n, largest);
            }
        }

        /// <summary>
        /// сортировать
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        public void Sort(int l, int r)
        {
            int n = a.Length;
            // стройка хипа
            for (int i = n/2 -1; i>=0; i--)
                heapify(a, n, i);
                
            // сортировка хипа
            for (int i = n - 1; i >= 0; i--)
            {
                Swap(ref a[0], ref a[i]);

                // даем массив количество элементов в списке  и корень элемент 0
                heapify(a, i, 0);
            }
        }

    }
    
}
