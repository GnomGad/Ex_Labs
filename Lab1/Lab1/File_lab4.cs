using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs
{
    class lab4
    {
        private static char[] char_any = { ' ', ',', '.', '-' };
        private static char[] char_any_whitout_dot = { ' ', ',', '-' };
        private static char[] char_any_cybol_for_word = { 'й', 'ц', 'у', 'к', 'е', 'н', 'г', 'ш', 'щ', 'з', 'х', 'ъ', 'ф', 'ы', 'в', 'а', 'п', 'р', 'о', 'л'
                                               ,'д', 'ж', 'э', 'я', 'ч', 'с', 'м', 'и', 'т', 'ь', 'б', 'ю','q','w','e','r','t','y','u','i','o','p','a','s','d'
                                               ,'z','x','c','v','b','n','m','Q','W','E','R','T','Y','U','I','O','P','A','S','D','F','G','H','J','K','L','Z','X'
                                               ,'C','V','B','N','M','M','Й','Ц','У','Е','Н','Г','Ш','Щ','З','Х','Ъ','Ф','Ы','В','А','П','Р','О','Л','Д','Ж','Э'
                                               ,'Я','Ч','С','М','И','Т','Ь','Б','Ю','1','2','3','4','5','6','7','8','9','0','К'};

        private static char[] char_any_symbol_withou_space = { 'й', 'ц', 'у', 'к', 'е', 'н', 'г', 'ш', 'щ', 'з', 'х', 'ъ', 'ф', 'ы', 'в', 'а', 'п', 'р', 'о', 'л'
                                               ,'д', 'ж', 'э', 'я', 'ч', 'с', 'м', 'и', 'т', 'ь', 'б', 'ю','q','w','e','r','t','y','u','i','o','p','a','s','d'
                                               ,'z','x','c','v','b','n','m','Q','W','E','R','T','Y','U','I','O','P','A','S','D','F','G','H','J','K','L','Z','X'
                                               ,'C','V','B','N','M','M','Й','Ц','У','Е','Н','Г','Ш','Щ','З','Х','Ъ','Ф','Ы','В','А','П','Р','О','Л','Д','Ж','Э'
                                               ,'Я','Ч','С','М','И','Т','Ь','Б','Ю','1','2','3','4','5','6','7','8','9','0','К','\\','/','\"','\'',',', '.', '-' };

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

        public static void Ex_2()//доделал
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
            char[] char_any = { ' ', ',', '.', '-' };//прямым вводом не работает
            int n = 0;
            for (int i = 0,index=0,count =1; i < str_s.Length; i++)//
            {
                index =str_s.IndexOfAny(char_any,n);// получение шоб попасть на след особых знаков
                
                if(index == i)// как ток индекс будет равен индексу массива заходи сюда
                {
                    n = index + 1; // это наше значение от которого мы начинаем поиск +1, что бы не зацикливался на 1 символе
                    Console.Write("({0})",count);
                    count++;//счетчик наших слов
                    while (true)
                    {
                        int temp = str_s.IndexOfAny(char_any, n);// темб это временная переменная для удобного дебага, ибо хрен знает
                        if (temp - n < 1)// разница между индексом и текущим положением, должна быть меньше 1, ибо боль это значит, что следующий пробел долеко и идет слово
                        {
                            Console.Write("{0}", str_s[i]);// выводим символ
                            index = str_s.IndexOfAny(char_any, n);//узнаем когда есть ли дальше символ слова
                            n = index + 1;// тот же n
                            i++;// мы же тут проходы тоже делаем, вот ток в основном цикле они не считаются
                        }
                        else if(i<str_s.Length) { Console.Write("{0}", str_s[i]); break; } // делаем условие, что бы i не было больше длины массиво, а то баг
                    }        
                }
                else
                Console.Write("{0}",str_s[i]);//вывод все равно будет постоянным   
            }
            Console.WriteLine();
        }

        public static void Ex_3()//Работает
        {
            int sleep = 0;// это счетчик пропусков, пока он не ноль, мы будем пропускать вывода номера слова при особых символах
            string str_s = Console.ReadLine();
            string[] array_str = new string[(int)(str_s.Length / 2)];
            string[] array_str_new = new string[array_str.Length];
            Console.WriteLine("Первый способ");
            for (int i = 0, count = 0; i < str_s.Length; i++)//обработка основной каждого элемента
            {
                if ((str_s[i] == ' ' || str_s[i] == ',' || str_s[i] == '.' || str_s[i] == '-') && sleep == 0)// проверка на нужный символ, а так же слип
                {
                    count++;// это счетчик слов
                    for (; ; sleep++)// божественный слип не делал условия выхода, что бы сделать потом
                    {
                        if (i + sleep < str_s.Length)// проверка, что бы не улетать за границы массива
                        {//собственно, если после конца слова будут идти еще такие символы, то мы их должны посчитать
                            // что бы потом, их даже не использовать
                            if (str_s[i + sleep] == ' ' || str_s[i + sleep] == ',' || str_s[i + sleep] == '.' || str_s[i + sleep] == '-') ;
                            else break;
                        }
                        else break;// выход если улетели
                    }
                }
                else if (sleep == 0) array_str[count] += str_s[i];// когда слипы не 0 это значит, что мы идем по символам
                if (sleep != 0) { array_str_new[count] += str_s[i]; sleep--; }// на каждой итерации будет идти -- и так до нуля, что бы не запороть слова
            }
            int count_for_null = -1;// если будет хоть 1 заход то будет 0
            for (int i = 0; i < array_str.Length; i++)// счетчик входлений без нулей for words
                if (array_str[i] != null) count_for_null++;
            
            int count_for_null_two = -1;
            for (int i = 0; i < array_str.Length; i++)// счетчик входлений без нулей for symbols
                if (array_str_new[i] != null) count_for_null_two++;

            if (count_for_null_two - count_for_null == 0)// если 0 то строки равны,если 1 то символов больше,если -1 то слов// у символов порог вхождения 1, а услов 0
                for (int i = 1, j = count_for_null; i <= count_for_null_two + 1; i++, j--)
                    Console.Write(array_str[j] + array_str_new[i]);
            else if (count_for_null_two - count_for_null == 1)// меньше слов // первый символ       
                for (int i = 1, j = count_for_null + 1; i <= count_for_null_two + 1; i++, j--)
                {
                    Console.Write(array_str_new[i]);
                    if (j > 0) Console.Write(array_str[j]);
                }
            else
                for (int i = 1, j = count_for_null; j>-1; i++, j--)
                {
                    Console.Write(array_str[j]);
                    if (i <= count_for_null_two+1) Console.Write(array_str_new[i]);
                }
            Console.WriteLine();
            //---------------------------------------------------------------------------------
            
            string[] array2_str = new string[str_s.Length];
            string[] array2_str_new = new string[str_s.Length];
            
            Console.WriteLine("Второй способ");
           
            
            int n = 0;

             array2_str = str_s.Split(char_any);
             array2_str_new =  str_s.Split(char_any_cybol_for_word);



            if (str_s.IndexOfAny(char_any_cybol_for_word) == 0) // если начало со слова, то строка 0 а спец 1
            {
                for (int i = 0, j = array2_str.Length - 1; ;)
                {
                    for (; j != -1;)
                        if (array2_str[j] != "")
                        {
                            Console.Write(array2_str[j]);
                            j--;
                            break;
                        }
                        else j--;
                    for (; i < array2_str_new.Length;)
                        if (array2_str_new[i] != "")
                        {
                            Console.Write(array2_str_new[i]);
                            i++;
                            break;
                        }
                        else i++;
                    if (j < 0 && i >= array2_str_new.Length) break;

                }
            }
            else if (str_s.IndexOfAny(char_any) == 0)//наоборот с символа начинается
            {
                for (int i = 0, j = array2_str.Length - 1; ;)
                {

                    for (; i < array2_str_new.Length;)
                        if (array2_str_new[i] != "")
                        {
                            Console.Write(array2_str_new[i]);
                            i++;
                            break;
                        }
                        else i++;
                    for (; j != -1;)
                        if (array2_str[j] != "")
                        {
                            Console.Write(array2_str[j]);
                            j--;
                            break;
                        }
                        else j--;
                    if (j < 0 && i >= array2_str_new.Length) break;

                }
            }
            else Console.WriteLine("Неизвестная мне ошибка");
            Console.WriteLine();

        }
        public static void Ex_4()//робит
        {//блок заполнения
            string[][] array_str = new string[8][];
            string[][] array_str_new = new string[8][];
            string[] array_str_first = new string[8];
            for (int i = 0; i < 8; i++)
            {
                string temp = Console.ReadLine();
                string[] temp_array = temp.Split(char_any_whitout_dot, StringSplitOptions.RemoveEmptyEntries);
                string[] temp_array_two = temp.Split(char_any_cybol_for_word, StringSplitOptions.RemoveEmptyEntries);
                array_str[i] = temp_array;
                array_str_new[i] = temp_array_two;
                array_str_first[i] = temp;
            }
            Console.WriteLine("Первый способ");
            Console.WriteLine();

            //блок нахождения и вывода в словах .com методами стринга
            foreach (string s in array_str_first)
            {
                string lower = s.ToLowerInvariant();
                if (lower.Contains(".com"))
                    Console.WriteLine(s);
            }

            //блок поиска пробелов для 
            string[] array_str_space = new string[8];
            int[] int_array =  { 0,Int32.MaxValue,0};//0 каунт 1 результат 2 номер строки
            char[] ch = { ' ' };
            foreach (string s in array_str_first)
            {
                string[] s_two = s.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                string s_string=null;
                foreach (string s_three in s_two)
                    s_string += s_three;
                if (s.Length - s_string.Length < int_array[1])
                {
                    int_array[1] = s.Length - s_string.Length;
                    int_array[2] = int_array[0];
                }
                int_array[0]++;
            }
            Console.WriteLine();
            Console.WriteLine(" Строка номер {0}",int_array[2]+1);// счет с 1
            Console.WriteLine("Второй способ");
            // блок поиска .com ручками 
            foreach(string[] string_for_array in array_str)
            {
                foreach(string string_not_array_for_string_for_array in string_for_array)
                {
                    int int_temp = -1;
                    foreach(char char_for_string in string_not_array_for_string_for_array)
                    {
                        string temp_char = char_for_string.ToString();
                        if (temp_char.ToLower() == "." && int_temp == -1) int_temp = 0;
                        else if (temp_char.ToLower() == "c" && int_temp == 0) int_temp = 1;
                        else if (temp_char.ToLower() == "o" && int_temp == 1) int_temp = 2;
                        else if (temp_char.ToLower() == "m" && int_temp == 2) 
                        { Console.WriteLine(string_not_array_for_string_for_array); int_temp = -1; break; }
                        else int_temp = -1;
                    }
                }
            }
            //блок поиска пробелов так же ручками
            int[] int_array_two = { 0, Int32.MaxValue, 0,0 };//0 каунт// 1 количество пробелов // 2 количество пробелов в строке // 3 номер строки
            foreach (string strint_for_array in array_str_first)
            {
                foreach(char char_for_strint_for_array in strint_for_array)
                    if (char_for_strint_for_array == ' ') int_array_two[2]++;
                if (int_array_two[1] > int_array_two[2]) { int_array_two[1] = int_array_two[2]; int_array_two[3] = int_array_two[0]; }
                int_array_two[0]++;
                int_array_two[2]=0;
            }
            int temp1 = int_array_two[3];
                Console.WriteLine("Строка номер {0}",temp1+1);
            
        }
        public static void Ex_5()
        {

        }
    }
}
