using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sorting = Labs.Interfaces.ISorts<int>;

namespace Labs.File_Lab10
{
    /// <summary>
    /// Переделать под убывание
    /// </summary>
    class QuickSort : Swapper<int>,Sorting
    {
        public int[] a { get; set; }
        public QuickSort(int[] a)
        {
            this.a = a;
        }
        private int Partition(int[] a, int l, int r)
        {
            int pivot = a[r];

            int i = l - 1, j = r;

            while (i < j)
            {
                while (a[++i] < pivot) ;
                while (a[--j] > pivot)
                    if (j == l)
                        break;

                if (i < j)
                    this.Swap(ref a[i], ref a[j]);
                else
                    break;
            }

            this.Swap(ref a[i], ref a[r]);

            return i;
        }

        public void Sort( int l, int r)
        {
            if (r <= l)
                return;

            int p = Partition(a, l, r);
            Sort( l, p - 1);
            Sort( p + 1, r);
        }
    }
}
