using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs
{
    class lab4
    {
        public static void Ex_1()// не верно робит, над починить
        {
            int count = 0;
            
            string str_s = Console.ReadLine();
            
            //StringBuilder str_b = new StringBuilder();

             //str_s = "шла саша по шоссе и сосала сушку.";
            //str_s = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЫЪЭЮЯ"

            Console.WriteLine("Первый способ");
            for(int i =0;i<str_s.Length;i++)// i юзается как тестируемый символ
            {
                for (int j = 0; j < str_s.Length; j++)//j это  всех символы
                    if (i != j && str_s[i] == str_s[j]) count++;// наши требования - i !=j
                if(count==0)Console.Write(str_s[i]);
                count = 0;
            }
            int n = 0;
            Console.WriteLine("\nВторой способ");// чинить-------------------------------------------------
            for(int i = 0;i<str_s.Length;i++)// главный символ
            {
                for (int j = 0; n != -1||n<str_s.Length;j++)// здесь количество повторо будет
                {
                    if (i != str_s.IndexOf(str_s[i], n)&& str_s.IndexOf(str_s[i],n)==str_s[j])
                        count++;
                    n++;
                }
                if (count == 0) Console.Write(str_s[i]);
                count = 0;
                
            }

        }
        public static void Ex_2()//херня
        {
            string skob = "()";
            string str_s = Console.ReadLine();
            Console.WriteLine("Первый способ");
            int n = -2;
            for (int i = 0, count = 1; n != -1; i = n + 1, count++ )
            {
                n = str_s.IndexOf(' ',i);
                if (n == -1) break;
                for(int j = 0;j<3;j++)
                str_s = str_s.Insert(n, "(" + count + ")");
                Console.WriteLine(n);
            }
            Console.WriteLine(str_s);
        }

    }
}
