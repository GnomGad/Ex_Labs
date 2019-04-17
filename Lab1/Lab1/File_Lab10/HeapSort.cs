using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sorting = Labs.Interfaces.ISorts<int>;
namespace Labs.File_Lab10
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

        private void Heapify(int[] a, int i, int N)
        {
            while (2 * i + 1 < N)
            {
                int k = 2 * i + 1;

                if (2 * i + 2 < N && a[2 * i + 2] >= a[k])
                {
                    k = 2 * i + 2;
                }
                if (a[i] > a[k])
                {
                    Swap(ref a[i], ref a[k]);
                    i = k;
                }
                else
                    break;
            }
        }

        /// <summary>
        /// In-place heapsort
        /// </summary>
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

        /*
        /// <summary>
        /// Sort using priority queue:
        /// 1. Add all elements to priority queue
        /// 2. Extract elements from priority queue one-by-one
        /// </summary>
        public void SortWithPQ(int[] a, int l, int r)
        {
            // needa additional structure !!!
            PriorityQueue pq = new PriorityQueue();
            for (int i = l; i <= r; i++)
            {
                pq.Insert(a[i]);
            }
            for (int i = r; i >= l; i--)
            {
                a[i] = pq.GetMax();
            }
        }*/
        
    }
    /*
    public class PriorityQueue
    {
        private int[] a = new int[1000001];
        int N = 0;


        private void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }


        private void FixUp()
        {
            int i = N;
            while (i > 1 && a[i / 2] < a[i])
            {
                Swap(ref a[i / 2], ref a[i]);
                i /= 2;
            }
        }


        private void FixDown()
        {
            int i = 1;

            while (2 * i <= N - 1)
            {
                int j = 2 * i;

                if (j < N - 1 && a[j] < a[j + 1])
                    j++;

                if (a[i] >= a[j])
                    break;

                Swap(ref a[i], ref a[j]);
                i = j;
            }
        }


        public void Insert(int elem)
        {
            a[++N] = elem;
            FixUp();
        }

        public int GetMax()
        {
            Swap(ref a[1], ref a[N]);
            FixDown();
            return a[N--];
        }

        public bool IsEmpty()
        {
            return N == 0;
        }
    }*/
}
