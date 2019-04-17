using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sorting = Labs.Interfaces.ISorts<int>;

namespace Labs.File_Lab10
{
    /// <summary>
    /// Реализация сортировки слиянием
    /// </summary>
    class MergeSort : Sorting
    {
        public int[] a { get; set; }
        public MergeSort(int[] a)
        {
            this.a = a;
        }
        private void Merge(int[] a, int l, int mid, int r)
        {
            int[] temp = new int[r - l + 1];

            int i = l, j = mid + 1;
            int k = 0;

            for (k = 0; k < temp.Length; k++)
            {
                if (i > mid)
                {
                    temp[k] = a[j++];
                }
                else if (j > r)
                {
                    temp[k] = a[i++];
                }
                else
                {
                    temp[k] = (a[i] > a[j]) ? a[i++] : a[j++];
                }
            }

            k = 0;
            i = l;
            while (k < temp.Length && i <= r)
            {
                a[i++] = temp[k++];
            }
        }

        public void Sort( int l, int r)
        {
            if (r <= l)
                return;

            int mid = (l + r) / 2;
            Sort(l, mid);
            Sort(mid + 1, r);
            Merge(a, l, mid, r);
        }
    }
}
