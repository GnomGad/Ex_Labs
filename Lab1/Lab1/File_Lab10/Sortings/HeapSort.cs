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
        /*
        private void Heapify(int[] a, int i, int N)
        {
            while (2 * i + 1 < N)
            {
                int k = 2 * i + 1;

                if (2 * i + 2 < N && a[2 * i + 2] >= a[k])
                {
                    k = 2 * i + 2;
                }
                if (a[i] < a[k])
                {
                    Swap(ref a[i], ref a[k]);
                    i = k;
                }
                else
                    break;
            }
        }

        public void Sort( int l, int r)
        {
            int N = r - l + 1;

            // build heap
            for (int i = r; i >= l; i--)
            {
                Heapify(a, i, N);
            }

            // sort heap
            while (N > 0)
            {
                Swap(ref a[l], ref a[N - 1]);
                Heapify(a, l, --N);
            }
        }
        */
        void heapify(int[] a, int n, int i)
        {
            // Find largest among root, left child and right child
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && a[l] > a[largest])
                largest = l;

            if (r < n && a[r] > a[largest])
                largest = r;

            // Swap and continue heapifying if root is not largest
            if (largest != i)
            {
                Swap(ref a[i], ref a[largest]);
                heapify(a, n, largest);
            }
        }

        // main function to do heap sort
        public void Sort(int l, int r)
        {
            int n = a.Length;
            // Build max heap
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(a, n, i);
                
            // Heap sort
            for (int i = n - 1; i >= 0; i--)
            {
                Swap(ref a[0], ref a[i]);

                // Heapify root element to get highest element at root again
                heapify(a, i, 0);
            }
        }

    }
    
}
