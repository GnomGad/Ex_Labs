using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs
{
    class lab4
    {
        public static void Ex_1()// починил
        {
            int count = 0;
            
            string str_s = Console.ReadLine();
            
            //StringBuilder str_b = new StringBuilder();

             //str_s = "шла Cаша по шоссе и сосала сушку.";
            //str_s = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЫЪЭЮЯ"

            Console.WriteLine("Первый способ");// Обработка строки через массивы // суть примерно похоже на заполнение массива
            for (int i =0;i<str_s.Length;i++)// i юзается как тестируемый символ
            {
                for (int j = 0; j < str_s.Length; j++)//j это  всех символы  
                    if (i != j && str_s[i] == str_s[j]) count++;// наши требования - i !=j
                if(count==0)Console.Write(str_s[i]);
                count = 0;
            }

            Console.WriteLine("\nВторой способ");
            for (int i = 0; i< str_s.Length;i++)// проверка каждого символа
            {
                
               for(int j =0;str_s.IndexOf(str_s[i],j)!=-1;)// проверка вхождений как только вхождение не будет замечено, то индекс оф выведет -1
                {
                    if (str_s[str_s.IndexOf(str_s[i], j)] == str_s[i])
                    {// идет проверка, если элемент с индексом индекс оф будет равен нашему элементу i, то мы заходим и делаем счетчик
                        count++;
                        j = str_s.IndexOf(str_s[i], j) + 1;// это шо бы у нас в поиск уже не попадались элементы которые я нашел, и по этому +1
                    }
                }
                if (count == 1) Console.Write(str_s[i]);// при одинарном символе, индекс оф может только 1 раз закоунтиться
                count = 0;

            }
            
            Console.WriteLine();

        }
        public static void Ex_2()//доделать
        {
           
            string str_s = Console.ReadLine();
            int sleep = 0;// это счетчик пропусков, пока он не ноль, мы будем пропускать вывода номера слова при особых символах
            Console.WriteLine("Первый способ");

            for (int i = 0,count =1; i < str_s.Length; i++)//обработка основной каждого элемента
            {
                if ((str_s[i] == ' ' || str_s[i] == ',' || str_s[i] == '.' || str_s[i] == '-')&&sleep==0)// проверка на нужный символ, а так же слип
                {
                    Console.Write("({0})", count);// если уж зашли,то должны вывести число слова
                    Console.Write(str_s[i]); //ну и собственно символ
                    count++;// это счетчик слов
                    for(; ;sleep++)// божественный слип не делал условия выхода, что бы сделать потом
                    {
                        if (i + sleep < str_s.Length)// проверка, что бы не улетать за границы массива
                        {//собственно, если после конца слова будут идти еще такие символы, то мы их должны посчитать
                            // что бы потом, их даже не использовать
                            if (str_s[i + sleep] == ' ' || str_s[i + sleep] == ',' || str_s[i + sleep] == '.' || str_s[i + sleep] == '-');
                            else break;
                        }
                        else break;// выход если улетели
                    }
                }
                else Console.Write(str_s[i]);// если обычный символ то выводим
                if (sleep != 0) sleep--;// на каждой итерации будет идти -- и так до нуля, что бы не запороть слова
            }
            Console.WriteLine();
            Console.WriteLine("Второй способ");
            for (int i = 0; i < str_s.Length; i++)//
            {

            }

        }

    }
}
