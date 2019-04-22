using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sorting = Labs.Interfaces.ISorts<int>;

namespace Labs.File_Lab10.Sortings
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
        public void Sort(int b, int e)
        {
            int l = b, r = e;
            int piv = a[(l + r) / 2]; // Опорным элементом для примера возьмём средний
            while (l <= r)
            {
                while (a[l] > piv)
                    l++;
                while (a[r] < piv)
                    r--;
                if (l <= r)
                    Swap(ref a[l++], ref a[r--]);
            }
            if (b < r)
                Sort(b, r);
            if (e > l)
                Sort(l, e);
        }
    }
}
