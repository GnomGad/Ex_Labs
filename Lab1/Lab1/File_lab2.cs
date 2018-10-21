using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs
{
    class lab2
    {
        public static void ex_1() // работает
        {
            double a, b, c;
            double Dis;
            Console.WriteLine("enter a,b,c and press Enter");//дальше будет ввод
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            c = int.Parse(Console.ReadLine());
            if (a == 0) return; //главное условие, если а = 0 то вылетаем
            Dis = (Math.Pow(b, 2) - 4 * a * c);//нахождение дискриминанта
            if (Dis > 0) //2 корня если дискриминант больше 0
            {
                var x1 = (((-b) + Math.Sqrt(Dis)) / (2 * a));
                var x2 = (((-b) - Math.Sqrt(Dis)) / (2 * a));
                Console.WriteLine(" x1: {0}  x2: {1}",x1,x2);

            }
            else if (Dis == 0) //1 корень если равен 0
            {
                var x1 = -((b) / (2 * a));
                Console.WriteLine(" x1: {0}",x1);
            }
            else // если вообще нет корней, ибо дис меньше 0, то будем искать 2 корня x+y*i  x-y*i
            {
                Dis = -Dis; //Очень важно наш дис надо обратить в положительный, дабы добыть корень
                var x1 = (((-b) / (2 * a)));  // находим х
                var y1 = ((Math.Sqrt(Dis)) / (2 * a)); // находим y

                var x2 = (((-b) / (2 * a)));
                var y2 = ((Math.Sqrt(Dis)) / (2 * a));

                Console.WriteLine("x1 = {0} + {1} * i",x1,y1);
                Console.WriteLine("x2 = {0} - {1} * i",x2,y2);
               
            }
           // Console.WriteLine($" {Dis}   {Math.Sqrt(Dis)}");
        }

        public static void ex_2() // работает
        {
            double pi = 0; //число пи
            double k = 1;
            Console.WriteLine("enter number");
            int num = int.Parse(Console.ReadLine());

            for(int i = 1; i < num; i+=2)
            {
                pi += 4 *k / i ;// первое умножение на +1 даст нам число 4, последующиее будут умножатся на k и делиться на i, которое должно каждый раз +2 делать по условию
                k *= -1; // смена знака, без него будут огромные числа
            }
             Console.WriteLine(pi);
        }
        public static void ex_3() // работает
        {
            int f0 = 1, f1 = 1, f2 = 1; 
            while (f1<10000)
            {
                Console.WriteLine($"{f1}");  
                f0 = f1; 
                f1 = f2; 
                f2 = f0 + f1;
                
            } 
        }

        public static void ex_4() // Не работае
        {

            Console.WriteLine("enter x,q");
            int x = int.Parse(Console.ReadLine());// градусы
            int q = int.Parse(Console.ReadLine()); //число
            double add = 0;
            sbyte sign = -1;
            int pow = 2;
            double cos = 1;
            while (true)
            {
                add = sign * (Math.Pow(x, pow) / factorial(pow));
                if (Math.Abs(add) < q)
                    break;
                else
                    cos = cos + add;
                Console.WriteLine(cos);
                pow += 2;
                sign *= -1;

            }
        }

        static int factorial(int x) //факториал для ex_4 
        {
            int res = 1;
            for (int i = x; i > 1; i--)
                res *= i;

            return res;
        }



        public static void ex_5() // вроде работает. много символов не стоит записывать, а то зависнет
        {
            Console.WriteLine("enter N ");
            int N = int.Parse(Console.ReadLine());
            int x = 1, y = 1, z = 1;
            bool q = false;

            for (x = 1; x <= y; x++)
            { 
                for (y = 1; y <= z; y++)
                { 
                    for (z = 1; z <= N; z++)
                    {
                        if ((x*x*x) + (y * y * y) + (z * z * z) == N)
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
            Console.WriteLine("enter 0<x<100 ");
            int year = int.Parse(Console.ReadLine());
            if (year>=100|| year <= 0) goto re;
                if (year % 10 == 1 && year != 11) Console.WriteLine("{0} год ", year);
                else if ((year % 10 >= 2 && year % 10 <= 4) && (year >= 22 || year <= 4)) Console.WriteLine("{0} года ", year);
                else Console.WriteLine("{0} лет ", year);
        }

        public static void Ex_a1_5() // дайте мне в лоб )))))) работает
        {

            Console.WriteLine("enter Day ");
            string day = Console.ReadLine();
            Console.WriteLine("enter Month ");
            string month = Console.ReadLine();
            Console.WriteLine("enter Year ");
            string year = Console.ReadLine();
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

            if (d > 31)
            day = "31";
            if (int.Parse(day) > 31) d = 31;
            //в любом случае будет 31 день

            if ((m == 2 || m == 4 || m == 9 || m == 11)&& d > 30) day = "30";
            if (day == "30") d = 30;
            //в этих случаях у нас будет 30, во всех других 31
            if (y % 4 == 0 && m == 6 && d > 28) day = "29";
            else if (m == 6 && d > 27) day = "28";

            //в первом случае 29 во втором 28
            if (int.Parse(month) < 10) month = "0" + month;

            Console.WriteLine("{0}/{1}/{2}", day,month,year);
        }

        public static void ex_a2_5() // работает
        {
            Console.WriteLine("enter a");
            int a =Math.Abs(int.Parse(Console.ReadLine()));
            Console.WriteLine("enter b");
            int b = Math.Abs(int.Parse(Console.ReadLine()));

            if (a > b) { a = a + b;b = a - b;a = a - b; }//a<b
            for(; a<=b;a++ )
            {
                Console.WriteLine("a = "+a);
            }

        }
    }
}
    