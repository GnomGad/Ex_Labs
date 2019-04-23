using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Labs.File_Lab10.Sortings;
namespace Labs.File_Lab10
{
    class File_Lab10
    {
        /// <summary>
        /// Вернет массив купюр
        /// </summary>
        /// <returns></returns>
        public int[] RandomMoney()
        {
            int leng = 100;
            int[] arr = new int[leng];
            Random Rand = new Random();
            for(int i =0;i< leng;i++)
            {
                int tmpRand = Rand.Next(0, 100);
                if (tmpRand <= 9)
                    arr[i] = 1;
                else if (tmpRand <= 17)
                    arr[i] = 2;
                else if (tmpRand <= 30)
                    arr[i] = 5;
                else if (tmpRand <= 50)
                    arr[i] = 10;
                else if (tmpRand <= 70)
                    arr[i] = 20;
                else if (tmpRand <= 85)
                    arr[i] = 50;
                else
                    arr[i] = 100;
            }
            return arr;
        }
    }

    class ManagerLab10
    {
        public void main()
        {
            char k = 'j';
            while (k != 0)
            {
                Console.WriteLine("\r\nНомер задания  1,  2,  3,  4,  5,  0 - выход");
                k = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (k == '1') Ex1();
                else if (k == '2') Ex2();
                else if (k == '3') Ex3();
                else if (k == '4') Ex1();
                else if (k == '5') Ex1();
            }
        }
        public void Ex1()
        {
            Lab7Manager k1 = new Lab7Manager();
            k1.Ex2();
        }

        public void Ex2()
        {
            File_Lab10 file_Lab10 = new File_Lab10();

            CountingSort counting = new CountingSort(file_Lab10.RandomMoney());
            counting.Sort(0, 0);
            foreach (int i in counting.a)
                Console.WriteLine(i + " ");
        }

        public void Ex3()
        {

        }
    }
}
