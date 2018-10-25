using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs
{
    class lab3
    {
        public static void ex_1() 
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
        public static void ex_2() // не работае так как надо
        {
            int[,] nums = new int[7,7];
            Random r = new Random();
            
            for (int i = 0; i < 7; i++)// заполняю массив
                for(int j =0; j<7;j++)
                    nums[i,j] = r.Next(-30, 45);
            Console.Write("\n\n");
            for (int i = 0; i < 7; i++)// вывожу массив
                for (int j = 0; j < 7; j++)
                {
                    Console.Write("{0,5}",nums[i,j] );
                    if (j == 6) Console.Write("\n");
                }
            Console.Write("\n\n");
            for (int i = 0; i < 7; i++)// вывожу массив
                for (int j = 0; j < 7; j++)
                {
                    Console.Write("{0,5}", nums[j, i]);
                    if (j == 6) Console.Write("\n");
                }
            Console.Write("\n\n");

        }
        public static void ex_3()
        {
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
        public static void ex_7() 
        {
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
