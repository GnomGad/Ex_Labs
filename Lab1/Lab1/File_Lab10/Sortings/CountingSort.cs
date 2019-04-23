using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sorting = Labs.Interfaces.ISorts<int>;


namespace Labs.File_Lab10.Sortings
{
    class CountingSort: Sorting
    {
        public int[] a { get; set; }
        public CountingSort(int[] a)
        {
            this.a = a;
        }
        public void Counting(int l, int r)
        {
            int[] buckets = new int[r - l + 1];

            for (int i = l; i < r; i++)
                buckets[a[i]]++;

            for (int i = l, j = l; i <= r; i++)
                while (buckets[i]-- > 0)
                    a[j++] = i;

        }

        public void Sort(int l, int r)
        {
            Counting(0,a.Length);
        }
    }
}
