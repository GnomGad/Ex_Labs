using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs
{
    class Lab1
    {


        //<========================================================== LABA ===================================================================>
        public static void  Ex_0()// лабба 1
        {
            Console.WriteLine("введи любое значение");
            double d = Convert.ToDouble(Console.ReadLine());// любое значение с запятой
            d *= 10;
            d %= 10;
            Console.WriteLine(((int)(d)));
            
        }
        public static void Ex_1()
        {
            Console.WriteLine("введи секунды");
            int hour,minut,idk,sec = Convert.ToInt32(Console.ReadLine()); ; 
            hour = sec / 3600; // получаем час
            idk = hour * 60; // час в минутах
            minut = sec / 60 - idk ; // минуты
            Console.WriteLine("Часы {0} минуты {1}", hour, minut);
            
        }
        public static void Ex_2()
        {
            Console.WriteLine("введите время: h,m,s ");
            
            int h = Convert.ToInt32(Console.ReadLine()), m = Convert.ToInt32(Console.ReadLine()), s = Convert.ToInt32(Console.ReadLine());
            double idk;
            idk = (h * 30 + m * 0.5 + s * (0.5 / 60.0));// вроде робит 1 час = 360/12 = 30градусов, 1 минута  = 30 градусов /60 = 0.5 градусов, 1 секунда = 0.5 градусов на 60
            Console.WriteLine(idk);
            
        }
        public static void Ex_3()
        {
            int first = 1,second = 2; 
            Console.WriteLine(first + " " + second);
            first = second + first; // складываем в первый
            second = first - second; // от первого отнимаем второй
            first = first - second;//  от первого отнимаем второй, но уже для первого
            Console.WriteLine(first+" "+ second);
            

        }
        public static void Ex_4()
        {

            int  a, b;
            double S,P,D;
           // string a, b;
            Console.WriteLine("введите первый катет");
            a =(Convert.ToInt32 (Console.ReadLine()));// ввод и сразу конвертация
            Console.WriteLine("введите второй катет");
            b = (Convert.ToInt32 (Console.ReadLine()));
            S = (a * b) / 2; //площадь равна половине произведения катета
            D = (Math.Sqrt(((a * a) + (b * b))));
            P = (a + b + D); // а+б+с = площадь 
            Console.WriteLine("S = {0}, P {1}",S,P);    
            
        }



        public static void Ex_5()
        {
            Console.WriteLine("введите 4х значние число");
            int a,i,p=1;
            a = (Convert.ToInt32(Console.ReadLine()));

            i = a / 1000; // делим число на 1к, получаем то, сколько в числе раз 1к, умножаем полученное число и отнимаем его от оригинала и получаем уже 3х значное число, продолжаем.
            a -= i * 1000;
            p *= i;

            i = a / 100;
            a -= i * 100;
            p *= i;

            i = a / 10;
            a -= i * 10;
            p *= i;

            p *= a;
            Console.WriteLine(p);
            
        }
        public static void Ex_6()
        {
            Console.WriteLine("введите 3х значние число");
            int a_b,i,b_a=0; //a_b правильная. b_a реверс 3x знаков
            a_b = (Convert.ToInt32(Console.ReadLine()));
            i = a_b / 100;
            a_b -= i * 100;
            b_a += i;

            i = a_b / 10;
            a_b -= i * 10;
            b_a += i * 10;

            b_a += a_b * 100;

            Console.WriteLine(b_a);
            
        }
        public static void Ex_7()// 
        {
            double x;
            Console.WriteLine("введите x");
            x = (Convert.ToDouble(Console.ReadLine()));
            double a = x * (x * (x * (3 * x - 5) + 2) - 1) + 7;
            Console.WriteLine(a);
           

        }
        public static void Ex_8()
        {
             int a1, a2, a3, b1, b2, b3, c1, c2, c3, d1, d2, d3,de, de1, de2, de3;
            //int a1 = 2, a2 = 1, a3 = 2, b1 = 5, b2 = 3, b3 = 10, c1 = 4, c2 = 2, c3 = 9, d1 = 30, d2 = 150, d3 = 110, de, de1, de2, de3;
            Console.WriteLine("введите первый ряд по формуле  a,b,c,d каждое значение через энтер");
            a1 = Convert.ToInt32(Console.ReadLine());
            b1 = Convert.ToInt32(Console.ReadLine());
            c1 = Convert.ToInt32(Console.ReadLine());
            d1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("введите второй ряд по формуле  a,b,c,d каждое значение через энтер");
            a2 = Convert.ToInt32(Console.ReadLine());
            b2 = Convert.ToInt32(Console.ReadLine());
            c2 = Convert.ToInt32(Console.ReadLine());
            d2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("введите третий ряд по формуле  a,b,c,d каждое значение через энтер");
            a3 = Convert.ToInt32(Console.ReadLine());
            b3 = Convert.ToInt32(Console.ReadLine());
            c3 = Convert.ToInt32(Console.ReadLine());
            d3 = Convert.ToInt32(Console.ReadLine());

            de = a1 * b2 * c3 - a1 * b3 * c2 - b1 * a2 * c3 + b1 * a3 * c2 + c1 * a2 * b3 - c1 * a3 * b2; // nu
            
            
            if (de != 0  )
            {
                de1 = d1 * b2 * c3 - d1 * b3 * c2 - b1 * d2 * c3 + b1 * d3 * c2 + c1 * d2 * b3 - c1 * d3 * b2;// первый
                de2 = a1 * d2 * c3 - a1 * d3 * c2 - d1 * a2 * c3 + d1 * a3 * c2 + c1 * a2 * d3 - c1 * a3 * d2;// второй
                de3 = a1 * b2 * d3 - a1 * b3 * d2 - b1 * a2 * d3 + b1 * a3 * d2 + d1 * a2 * b3 - d1 * a3 * b2;// третий
                    
                double x1 = (de1 / de);
                double x2 = (de2 / de);
                double x3 = (de3 / de);
                Console.WriteLine("x1 = {0}     x2 = {1}     x3 = {2}",x1,x2,x3);
            }
            else
            {
                Console.WriteLine("determinant = 0");
            }
            

        }
        public static void Ex_A1_5() // 5 вариант
        {

            string
                title = "Телепередачи",
                bot = "Перечисляемый тип: И - игровая; А - аналитическая; Т – ток-шоу",
                tv = "Передача",
                lead = "Ведущий",
                mmr = "Рейтинг",
                type = "Тип";
            sbyte mmr1, mmr2, mmr3;

            string tv1,tv2,tv3,lead1,lead2,lead3,type1,type2,type3;
            tv1 = "Своя игра";
            tv2 = "Воскресный вечер";
            tv3 = "Пусть говорят";

            lead1 = "П. Кулешов";
            lead2 = "В. Соловьев";
            lead3 = "А. Малахов";
            mmr1 = 5;
            mmr2 = 5; 
            mmr3 = 4;

            type1 = "И";
            type2 = "А";
            type3 = "Т";
            var x0 = "-------------------------------------------------------------------------";
            Console.WriteLine("{0}",x0);
            Console.WriteLine("I {0,-70}I", title);
            Console.WriteLine("{0}", x0);
            Console.WriteLine("I {0,-24}I {1,-14} I {2,-10} I {3,-13} I",tv,lead,mmr,type);
            Console.WriteLine("{0}", x0);
            Console.WriteLine("I {0,-24}I {1,-14} I {2,-10} I {3,-13} I", tv1, lead1, mmr1, type1);
            Console.WriteLine("{0}", x0);
            Console.WriteLine("I {0,-24}I {1,-14} I {2,-10} I {3,-13} I", tv2, lead2, mmr2, type2);
            Console.WriteLine("{0}", x0);
            Console.WriteLine("I {0,-24}I {1,-14} I {2,-10} I {3,-13} I", tv3, lead3, mmr3, type3);
            Console.WriteLine("{0}", x0);
            Console.WriteLine("I {0}\tI",bot);
            Console.WriteLine("{0}", x0);
        }

        public static void Ex_A2_5()
        {
            
            double a,b,t,y,s;
            Console.WriteLine("введите значение  a,b,t каждое через энтер");
          
            a = (Convert.ToDouble(Console.ReadLine()));
            b = (Convert.ToDouble(Console.ReadLine()));
            t = (Convert.ToDouble(Console.ReadLine()));
            y =(Math.Pow(Math.E,-b*t) * Math.Sin(a*t+b)-Math.Sqrt(Math.Abs(b*t+a)));
            s = (b * Math.Sin(a * Math.Pow(t, 2) * Math.Cos(2 * t) - 1));
            Console.WriteLine("y= {0}",y);
            Console.WriteLine("s= {0}", s);
        }





    }
}
