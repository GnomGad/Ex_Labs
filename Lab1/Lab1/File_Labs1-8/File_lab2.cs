﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs
{
    class lab2
    {
        public static void ex_1() // работает дискриминант
        {
            double a, b, c;
            double Dis;
            Console.WriteLine("введите a,b,c");//дальше будет ввод
            int[] n = MainL.Normal_Enter_Parse(Console.ReadLine(), 1);
            a = n[0];
            b = n[1];
            c = n[2];
            if (a == 0) return; //главное условие, если а = 0 то вылетаем
            Dis = (Math.Pow(b, 2) - 4 * a * c);//нахождение дискриминанта
            if (Dis > 0) //2 корня если дискриминант больше 0
            {
                var x1 = (((-b) + Math.Sqrt(Dis)) / (2 * a));
                var x2 = (((-b) - Math.Sqrt(Dis)) / (2 * a));
                Console.WriteLine(" x1: {0}  x2: {1}", x1, x2);

            }
            else if (Dis == 0) //1 корень если равен 0
            {
                var x1 = -((b) / (2 * a));
                Console.WriteLine(" x1: {0}", x1);
            }
            else // если вообще нет корней, ибо дис меньше 0, то будем искать 2 корня x+y*i  x-y*i
            {
                Dis = -Dis; //Очень важно наш дис надо обратить в положительный, дабы добыть корень
                var x1 = (((-b) / (2 * a)));  // находим х
                var y1 = ((Math.Sqrt(Dis)) / (2 * a)); // находим y

                Console.WriteLine(" x1 = {0} + {1} * i\n x2 = {0} - {1} * i", x1, y1);


            }
            // Console.WriteLine($" {Dis}   {Math.Sqrt(Dis)}");
        }

        public static void ex_2() // работает число пи
        {
            double pi = 0; //число пи
            double k = 1;
            Console.WriteLine("введите большое число");
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i < num; i += 2, k *= -1)// смена знака, без него будут огромные числа
            {
                pi += 4 * k / i;// первое умножение на +1 даст нам число 4, последующиее будут умножатся на k и делиться на i, которое должно каждый раз +2 делать по условию
            }
            Console.WriteLine(pi);
        }
        public static void ex_3() //   работает   фибоначи
        {
            int count = 0;
            for (int f0 = 1, f1 = 1, f2 = 1; f1 < 10000; f0 = f1, f1 = f2, f2 = f0 + f1) if (f1 > 999 && f1 <= 9999) count++;
            Console.WriteLine("count= {0}", count);
        }

        public static void ex_4() // работает
        {

            Console.WriteLine("введите x,q через энтер");
            double n = int.Parse(Console.ReadLine());// градусы
            double q = double.Parse(Console.ReadLine()); //число
            double add = 0;
            double x = n * Math.PI / 180;
            sbyte sign = -1;
            int pow = 2, count = 0;
            double cos = 1;
            while (true)
            {
                add =(Math.Pow(x, pow) / factorial(pow));
                count++;
                if (add< q)
                    break;
                else
                {
                    cos = cos + (sign * add);
                    
                }
                pow += 2;
                sign *= -1;
            }
            Console.WriteLine("cos({2}) = {0}      слогаемых {1}",cos,count,x);
        }

        static int factorial(int x) //факториал для ex_4 
        {
            int res = 1;
            for (int i = x; i > 1; i--)
                res *= i;

            return res;
        }
       
       
            public static void ex_5() // вроде работает. много символов не стоит записывать, а то зависнет x^3+y^3+z^3=N
        {
            Console.WriteLine("введите N ");
            int N = int.Parse(Console.ReadLine());
            int x = 1, y = 1, z = 1;
            
            bool q = false;

            for (x = 1; x <= y; x++)
            { 
                for (y = 1; y <= z; y++ )
                { 
                    for (z = 1; z <= N; z++ )
                    {
                        if ((x*x*x) +(y*y*y)+(z*z*z) == N)
                        {
                            Console.WriteLine("x={0}  y={1}  z={2}", x, y, z);
                            q = true;
                        }
                        
                    }
                    //Console.Write("- ");
                }
               // Console.Write("+ ");
            }
            if (!q) Console.WriteLine("No such combinations!");
            
        }
        public static void ex_6() // работает
        {
            re:
            Console.WriteLine("введите 0< x <100 ");
            int year = int.Parse(Console.ReadLine());
            if (year>=100|| year <= 0) goto re;
                if (year % 10 == 1 && year != 11) Console.WriteLine("{0} год ", year);
                else if ((year % 10 >= 2 && year % 10 <= 4) && (year >= 22 || year <= 4)) Console.WriteLine("{0} года ", year);
                else Console.WriteLine("{0} лет ", year);
        }

        public static void ex_a1_5() // дайте мне в лоб )))))) работает dd/mm/yyyy 
        {

            Console.WriteLine("введите день месяц год ");
            string[] str = MainL.Normal_Enter_Parse(Console.ReadLine(), "s");
            string day = str[0];

            string month = str[1];

            string year = str[2];
            //если число меньше, то выход
            if (int.Parse(day) < 0 || int.Parse(month) < 0 || int.Parse(year) < 0)
            {
                return;
            }
            //если число больше, то подгоняем до dd/mm/yyyy
            if (int.Parse(day) > 99)
            {
                for (int i = 0; i < (int.Parse(day)); i += 100)
                {
                    day = Convert.ToString(int.Parse(day) / 10);
                }
            }
            if (int.Parse(month) > 99)
            {
                for (int i = 0; i < (int.Parse(month)); i += 100)
                {
                    month = Convert.ToString(int.Parse(month) / 10);
                }
            }
            if (int.Parse(year) > 9999)
            {
                for (int i = 9999; i < (int.Parse(year)); i += 1000)
                {
                    year = Convert.ToString(int.Parse(year) / 10);
                }
            }
            // список условий с нулями
            if (int.Parse(day) < 10) day = "0" + day;
            if (int.Parse(month) < 10) month = "0" + month;
            if (int.Parse(year) < 10) year = "000" + int.Parse(year);
            else if (int.Parse(year) < 100) year = "00" + int.Parse(year);
            else if (int.Parse(year) < 1000) year = "0" + int.Parse(year);
            // 1-31     2-30    3-31   4-30      5-31     6-28/29     7-31    8-31       9-30      10-31    11-30       12-31
            int d = int.Parse(day);
            int m = int.Parse(month);
            int y = int.Parse(year);

           month = Convert.ToString( Math.Min(int.Parse(month), 12));//месяц
            //================================ ветвление верного дня по месяцу
            if (d > 31)
            day = "31";
            if (int.Parse(day) > 31) d = 31;
            //в любом случае будет 31 день

            if ((m == 6 || m == 4 || m == 9 || m == 11)&& d > 30) day = "30";
            if (day == "30") d = 30;
            //в этих случаях у нас будет 30, во всех других 31
            if (y % 4 == 0 && m == 2 && d > 28) day = "29";
            else if (m == 2 && d > 27) day = "28";

            //в первом случае 29 во втором 28
            if (int.Parse(month) < 10) month = "0" + month;

            Console.WriteLine("{0}/{1}/{2}", day,month,year);
        }

        public static void ex_a2_5() // работает   вывести сумму нечетных чисел a,b
        {
            Console.WriteLine("введите a и b");
            int[] num = MainL.Normal_Enter_Parse(Console.ReadLine(), 1);
            int a =Math.Abs(num[0]);
            int b = Math.Abs(num[0]);
            int k = 0;
            if (a > b)
            {
                a = a + b;
                b = a - b;
                a = a - b;
            }//a<b 
            for(; a<=b;a++ )
            {
                if (a % 2 != 0) k += a;
                
            }
            Console.WriteLine("сумма = {0}",k);
        }
    }
}
    