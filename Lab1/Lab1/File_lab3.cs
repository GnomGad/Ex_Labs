using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs
{
    class lab3
    {
        public static void ex_1() // работает
        {
            Console.WriteLine("Введите количество элементов");
            int n = int.Parse(Console.ReadLine());
            int[] nums = new int[n];
            Random r = new Random();

            for (int i = 0; i < n; i++) // заполняю массив
                nums[i] = r.Next(-30, 45); 
            int count=0;

            Console.Write("\n\n");

            foreach (int i in nums) // выводим массив
            {
                Console.Write("{0,5}",i);
                count++;
                if (count % 10 == 0) Console.Write("\n");
            }
            Console.Write("\n======================================================\n");
            count = -1;

            for (int i = nums.Length - 1; i >= 0; i--)// выводим массив с конца и по условию
            {
                if (nums[i] >= 0)
                {
                    count++;
                    if (count % 10 == 0) Console.Write("\n");
                    Console.Write("{0,5}", nums[i]);
                    
                }
            }
            Console.Write("\n\n");
        }
        public static void ex_2() // работает
        {
            int[,] nums = new int[7,7];
            Random r = new Random();
            for (int i = 0; i < nums.GetLength(0); i++)// заполняю массив
               for(int j =0; j< nums.GetLength(1); j++)
                    nums[i,j] = r.Next(-30, 45);

            Console.Write("\n\n");
            for (int i = 0; i < nums.GetLength(0); i++)// вывожу массив
                for (int j = 0; j < nums.GetLength(1); j++)
                {
                    Console.Write("{0,5}",nums[i,j] );
                    if (j == 6) Console.Write("\n");
                }

            Console.Write("\n\n");
            for (int i = 0; i <nums.GetLength(1) ; i++)// вывожу массив
                for (int j = nums.GetLength(0)-1; j >= 0; j--)
                {
                    Console.Write("{0,5}", nums[i, j]);
                    if (j == 0) Console.Write("\n");
                }
            Console.Write("\n\n");
        }




        public static void ex_3() // работает с читом
        {
            int[] nums = new int[4];
            int[] nums2 = new int[nums.Length];

            Console.WriteLine("Введите k");
            int k = int.Parse(Console.ReadLine());
       

            for (int i = 0; i < nums.Length; i++) // заполняю массив
                nums[i] = i;
            // последний символ

            foreach (int i in nums) // вывожу массив
            {
                Console.Write("{0} ", i);

            }
            Console.Write("\n\n");


            //=========================================== // работающий читерский способ через второй массив
            //for (int i = 0; i<nums.Length;i++) 
            //{
            //    if(i-k>=0)
            //    {

            //        nums2[i-k] = nums[i];
            //    }
            //    else
            //    {
            //        nums2[nums.Length-1-i] = nums[i];
            //    }


            //}
            //=========================================== // работает только при массиве в 4 при остальных размерах магия
            // int t = nums.Length-1,temp,lel;
            //for (int i = 0; i < k; i++) 
            //{
            //    temp = t;
            //    t = t - k < 0 ?t= nums.Length  - k : t = t - k;
            //    lel = nums[t];
            //    nums[t] = nums[temp];
            //    nums[temp] = lel;
            //    t = t - 1 < 0 ? t =nums.Length - 2 : t=t-1;
            //=========================================== 

            //}

            foreach (int i in nums) // вывожу массив
            {
                Console.Write("{0} ", i);

            }
            Console.Write("\n\n");


        }
        public static void ex_4() 
        {
        }
        public static void ex_5() 
        {
        }
        public static void ex_6()
        {
        }
        public static void ex_7() // робит но хз насчет количества членов
        {
            Console.WriteLine("Введите n членов");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(for_ex_7(n:n));
        }
        public static int for_ex_7(int f0 = 1,int f1 = 1,int f2 = 1,int n=1) 
        {

            f0 = f1;
            f1 = f2;
            f2 = f0 + f1;
            n--;
            if (n > 0) return for_ex_7(f0, f1, f2, n);
            else return f1;
        }
        public static void ex_8()
        {
        }
        public static void ex_a1_5()
        {
        }
        public static void ex_a2_5() 
        {
        }

    }
}
