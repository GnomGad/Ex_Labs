using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs
{
    class lab2
    {
        public static void ex_1()
        {
            double a, b, c;
            double Dis;
            Console.WriteLine("enter a,b,c and press Enter");//дальше будет ввод
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            c = int.Parse(Console.ReadLine());
            if (a == 0) return; //главное условие, если а = 0 то вылетаем
            Dis = (Math.Pow(b, 2) - 4 * a * c);//дискриминант
            if (Dis > 0) //2 корня
            {
                var x1 = (((-b) + Math.Sqrt(Dis)) / (2 * a));
                var x2 = (((-b) - Math.Sqrt(Dis)) / (2 * a));
                Console.WriteLine(" x1: {0}  x2: {1}",x1,x2);

            }
            else if (Dis == 0) //1 корень
            {
                var x1 = -((b) / (2 * a));
                Console.WriteLine($" x1: {x1}");
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

        public static void ex_2()
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
             Console.WriteLine($"{pi}");
        }
        public static void ex_3()
        {
            int f0 = 1, f1 = 1, f2 = 1;
            while (f1<10000)
            {
               Console.WriteLine($"{f1}"); // хз как пояснить даж, первое значение будет равно второму, второе третьему, а третье сумме первого и второго
                f0 = f1;
                f1 = f2;
                f2 = f0 + f1;
                
            } 
        }

        public static void ex_4() // НЕ ГОТОВО
        {

            Console.WriteLine("will be later");
        }

        public static void ex_5() // НЕ ГОТОВО
        {

            Console.WriteLine("will be later");
        }
        public static void ex_6() // НЕ ГОТОВО
        {

            Console.WriteLine("will be later");
        }
    }
}
    