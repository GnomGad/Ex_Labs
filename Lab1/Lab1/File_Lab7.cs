using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs
{
    class FileLabLibrary7 
    {
        void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
        public void SelectionSort(int[] a, int l,int r)
        {
            for (int i = l; i < r; i++)
            {
                int min = i;
                for (int j = i + 1; j <= r; j++)
                {
                    if (a[j] < a[min])
                    {
                        min = j;
                    }
                }
                Swap(ref a[i], ref a[min]);
            }
            foreach (int k in a)
                Console.WriteLine(k);
        }

       


       
    }
    class Lab7Manager
    {
        public void Ex1()
        {
            FileLabLibrary7 FileLab = new FileLabLibrary7();
            TrashForEx1.Begin();

        }
    }

    class TrashForEx1 : File_lab6
    {
       static public void Begin()
        {
            FileLabLibrary7 NewLib7 = new FileLabLibrary7();
            
            Ex_1();
        }
    }


}
