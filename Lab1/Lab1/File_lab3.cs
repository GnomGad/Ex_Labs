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




        public static void ex_3() // НЕ РАБОТАЕТ, БАГ С НУЛЕМ КОТОРЫЙ НЕ ХОЧЕТ ДВИГАТЬСЯ БОЛЬШЕ ЧЕМ НАДО
        {
            Console.WriteLine("Введите длинну массива и K");
            string n = Console.ReadLine();
            int[] array_n = MainL.Normal_Enter_Parse(n, 1);

            int[] nums = new int[array_n[0]];
            int[] nums2 = new int[array_n[0]];


            for (int i = 0; i < array_n[0]; i++) // заполняю массив
                nums[i] = i;
            

            foreach (int i in nums) // вывожу массив обычный
            {
                Console.Write("{0} ", i);

            }
            Console.Write("\n\n");


           
            for (int i = 0; i < array_n[0]; i++)
            {
                if (i - array_n[1] >= 0)
                {

                    nums2[i - array_n[1]] = nums[i];
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
        public static void ex_4() // работает 
        {
            Console.WriteLine("Массив A");
            int[,] First_array = new int[3, 3];
            int[,] Second_array = new int[3, 3];
            Random rand = new Random();
            for (int i = 0; i < First_array.GetLength(0); i++)
            {
                for (int j = 0, count = 0; j < Second_array.GetLength(0); j++, count++)
                {
                    First_array[i, j] = rand.Next(0, 10);
                    Console.Write("{0,-5}", First_array[i, j]);//  заполнение 1 и 2 массива вывод 1
                    Second_array[i, j] = rand.Next(0, 10);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Массив B");
            for (int i = 0; i < Second_array.GetLength(0); i++) // вывод второго  массива
            {
                for (int j = 0; j < Second_array.GetLength(0); j++)
                    Console.Write("{0,-5}", Second_array[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine("Массив A+B");
            int[,] Third_array = new int[3, 3];
            Third_array = sum(First_array, Second_array, out float summ);

            for (int i = 0; i < Third_array.GetLength(0); i++) // вывод третьего  массива
            {
                for (int j = 0; j < Third_array.GetLength(0); j++)
                    Console.Write("{0,-5}", Third_array[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine("Среднее значение A+B: " + summ);

            int[,] Fourth_array = new int[3, 3];
            Fourth_array = diff(First_array, Second_array, out float summ_2);
            Console.WriteLine("Массив A-B");
            for (int i = 0; i < Fourth_array.GetLength(0); i++) // вывод четвертого  массива
            {
                for (int j = 0; j < Fourth_array.GetLength(0); j++)
                    Console.Write("{0,-5}", Fourth_array[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine("Среднее значение A-B: " + summ_2);
        }



        public static int[,] sum(int[,] First_array, int[,] Second_array, out float summ) //сумма
        {
            summ = 0;
            int[,] Third_array = new int[3,3];
            int count = 0;
            for (int i = 0; i < First_array.GetLength(0); i++) 
                for (int j = 0; j < Second_array.GetLength(0); j++,count++)
                {
                    Third_array[i,j] = First_array[i, j] + Second_array[i, j];
                    summ += Third_array[i, j];

                }
            summ =summ/(count*2);
            return Third_array;
        }
        public static int[,] diff(int[,] First_array, int[,] Second_array, out float summ_2)
        {
            int count = 0;
            summ_2 = 0;
            int[,] Third_array = new int[3, 3];
            for (int i = 0; i < First_array.GetLength(0); i++)
                for (int j = 0; j < Second_array.GetLength(0); j++, count++)
                {
                    Third_array[i, j] = First_array[i, j] - Second_array[i, j];
                    summ_2 += Third_array[i, j];
            }
            summ_2 = summ_2 / (count * 2);
            return Third_array;
        }






        public static void ex_5() // работает для любых  x == y значений [2,2] [100,100]
        {
           

            int[,] First_Array =  new int[5,5];
            int[,] Second_Array = new int[5,5];
            int[,] Third_Array = new int[5,5];
            Random rand = new Random();
            for (int i = 0; i < First_Array.GetLength(0); i++)// заполнение первого и второго массива, вывод первого
            {
                for (int j = 0; j < First_Array.GetLength(0); j++)
                {
                    First_Array[i, j] = rand.Next(0, 100);
                    Console.Write("{0,-5}",First_Array[i, j]);// 
                    Second_Array[i, j] = rand.Next(0, 100);
                }
                Console.WriteLine();
            }

            Console.WriteLine('+');

            for (int i = 0; i < First_Array.GetLength(0); i++) // вывод второго  массива
            {
                for (int j = 0; j < First_Array.GetLength(0); j++)
                    Console.Write("{0,-5}",Second_Array[i, j]);
                Console.WriteLine();
            }
            for (int i = 0; i < First_Array.GetLength(0); i++) // заполняем третий массив через уже существующий метод
                for (int j = 0; j < First_Array.GetLength(0); j++)
                    Third_Array[i,j]=proizv(First_Array, Second_Array,i,j);
            Console.WriteLine();
            for (int i = 0; i < Third_Array.GetLength(0); i++)// вывод 3 массива
            {
                for (int j = 0; j < Third_Array.GetLength(0); j++)
                    Console.Write("{0,-7}",Third_Array[i, j]);
                Console.WriteLine();
            }
        }
        static int proizv(int[,] First_Array,int[,] Second_Array,int x,int y)//тот самый метод
        {
            int summ = 0;
            int First_x = x,Second_y = y;
            // фича в том, что мы получаем координаты x и y, у первого массива x статична, она постоянная, а y увеличивается на +1
            // у второго массива первая +1, а вторая статичная Y
            // зная эту зависимость массивов можно сделать вот такую форму для подсчета
            
                for (int i = 0; i < First_Array.GetLength(1)|| i < Second_Array.GetLength(0); i++)

                {
                    summ += (First_Array[First_x, i] * Second_Array[i, Second_y]);
                }
           
            return summ;
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
