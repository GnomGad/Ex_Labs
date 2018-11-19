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




        public static void ex_3() // работает с вторым массивом
        {
            int[] nums = new int[4];
            int[] nums2 = new int[nums.Length];

            Console.WriteLine("Введите k");
            int k = int.Parse(Console.ReadLine());
       

            for (int i = 0; i < nums.Length; i++) // заполняю массив
                nums[i] = i;
            

            foreach (int i in nums) // вывожу массив обычный
            {
                Console.Write("{0} ", i);

            }
            Console.Write("\n\n");


           
            for (int i = 0; i < nums.Length; i++)// работающий читерский способ через второй массив
            {
                if (i - k >= 0)
                {

                    nums2[i - k] = nums[i];
                }
                else
                {
                    nums2[nums.Length - 1 - i] = nums[i];
                }


            }

            foreach (int i in nums2) // вывожу массив со сдвигом в лево
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
        public static void ex_6() // работает
        {
            Random  rand = new Random();
            int NumArray = 10;// длина массива
            int m1 = 0, m2 = 10; //их 
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Введите длину массива");
            Console.ForegroundColor = ConsoleColor.White;
            NumArray = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Введите минимальный мин и макс для рандома");
            Console.Write("минимум: ");
            Console.ForegroundColor = ConsoleColor.White;
            m1 =int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("максимум: ");
            Console.ForegroundColor = ConsoleColor.White;
            m2 = int.Parse(Console.ReadLine());

            int[] array = new int[NumArray];
            for (int i = 0; i < array.Length; i++) array[i] = rand.Next(m1,m2);
           
            foreach (int n in array)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(n + " ");
            }
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("sumIterative " + sumIterative(array));
            Console.WriteLine("sumRecursive " + sumRecursive(array));
            Console.WriteLine("minIterative " + minIterative(array));
            Console.WriteLine("minRecursive " + minRecursive(array));
        }

        static int sumIterative(int[] array) 
        {
            int sum = 0;
            foreach (int n in array)
            {
                sum += n;
            }
            return sum;
        }

        static int sumRecursive(int[] array,int n=0, int i = 0)
        {
            
            return array.Length>i?sumRecursive(array,n + array[i],++i) :n ; // проверка индекса? суммирование : вывод суммы
        }
        
        static int minIterative(int[] array)
        {
            int min = int.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min) min = array[i];    
            }
            return min;
        }

        static int minRecursive(int[] array, int min = int.MaxValue,int i = 0) 
        {
           
            return array.Length  > i ? array[i] < min ? minRecursive(array,min = array[i],++i) : minRecursive(array, min, ++i) : min ;// проверка индекса?проверка на минимум?запуск рекурсии с новым минимумо: запуск рекурсии со старым минимумом: вывод минимума

        }

        public static void ex_7() // робит 
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
