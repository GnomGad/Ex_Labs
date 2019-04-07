using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
                                               ,'Я','Ч','С','М','И','Т','Ь','Б','Ю','1','2','3','4','5','6','7','8','9','0','К','k'};

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
                            if (str_s[i + sleep] == ' ' || str_s[i + sleep] == ',' || str_s[i + sleep] == '.' || str_s[i + sleep] == '-')
                            {

                            }
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
                            if (str_s[i + sleep] == ' ' || str_s[i + sleep] == ',' || str_s[i + sleep] == '.' || str_s[i + sleep] == '-')
                            {

                            }
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


        private static bool is_symbol(int char_int, bool bol, bool bol_two=true)// для 5 задания проверочка
        {
            if (char_int >= 32 && char_int <= 47 && !bol && !bol_two)
                return true;
            if (char_int <= 90 && char_int>=65 && bol && bol_two)
                return true;
            if (char_int <= 57 && char_int >= 48 && !bol && bol_two)
                return true;
            if (char_int <= 122 && char_int >= 97 &&!bol_two)  
            return true;
            
            return false;
        }
        public static void Ex_5()
        {
            string str_s = Console.ReadLine();
            {
                int flag = 0;
                string str_not_s = "";
                str_s += " ";
                foreach (char char_for_str in str_s)// 65 и 90 это A-Z 48-57 числа 0-9  символы письма 32 @space@  
                {
                    if (is_symbol(char_for_str, true) && flag == 0) { flag = 1; str_not_s += char_for_str; }//вход большого символа
                    else if ((flag == 1) && is_symbol(char_for_str, true, false)) str_not_s += char_for_str;   //вход маленького символа
                    else if ((flag == 1) && is_symbol(char_for_str, false)) { flag = 2; str_not_s += char_for_str; }//вход цифры первой
                    else if ((flag == 2) && is_symbol(char_for_str, false)) { flag = 3; str_not_s += char_for_str; }//вход цифры второй
                    else if ((flag == 3) && is_symbol(char_for_str, false, false)) { flag = 0; Console.WriteLine(str_not_s); str_not_s = ""; }//сброс есть 
                    else { flag = 0; str_not_s = ""; }//если будет ничего
                }
            }// умертвим наши переменные не нужные
            Regex regex = new Regex(@"[A-ZА-Я]([a-zа-я]+)\d\d");// регулярочка
            foreach (Match match in regex.Matches(str_s))
                Console.WriteLine(match);
        }
        public static void Ex_6()
        {
            
            string str_s = Console.ReadLine();
            string part_reg = @"\s+";
            string target = "";
            string temp = "";
            Regex regex = new Regex(part_reg);
            str_s = regex.Replace(str_s, target);
            Console.WriteLine(str_s);
            // регулярочка(-?)\s*\d+\s*?[+-]\s*?\d+\s*?=\s*?(-?)\s*?\d+
            int[] int_array = new int[3];
            regex = new Regex(@"-?\d+");
            temp = regex.Match(str_s).ToString();
            int_array[0] = Int32.Parse(temp);
            Console.WriteLine(int_array[0]);


            regex = new Regex(@"[+-]\d+");
            string temp2 = regex.Match(str_s, temp.Length - 1).ToString();
            int_array[1] = Int32.Parse(temp2);
            Console.WriteLine(int_array[1]);


            regex = new Regex(@"-?\d+");
            string temp3 = regex.Match(str_s, temp.Length+temp2.Length).ToString();
            int_array[2] = Int32.Parse(temp3);
            Console.WriteLine(int_array[2]);

        }
        public static void Ex_7()//работает
        {//заполнение
            string[] music_list = new string[10];
            double[] music_double_time = new double[10];
            music_list[0] = "1. Gentle Giant – Free Hand [6:15]";
            music_list[1] = "2. Supertramp – Child Of Vision [07:27]";
            music_list[2] = "3. Camel – Lawrence [10:46]";
            music_list[3] = "4. Yes – Don’t Kill The Whale [3:55]";
            music_list[4] = "5. 10CC – Notell Hotel [04:58]";
            music_list[5] = "6. Nektar – King Of Twilight [4:16]";
            music_list[6] = "7. The Flower Kings – Monsters & Men [21:19]";
            music_list[7] = "8. Focus – Le Clochard [1:59]";
            music_list[8] = "9.Pendragon – Fallen Dream And Angel[5:23]";
            music_list[9] = "10. Kaipa – Remains Of The Day [08:02]";
            //for (int i = 0; i < 10; i++) music_list[i]=Console.ReadLine();//разблокировать для рукописного ввода

            //общая длина
            Int32 summ_list_time = 0;
            int summ_list_time_sec =0;
            double big_music = Double.MinValue;
            double small_music = Double.MaxValue;
            double min_inteval_first = Double.MaxValue;

            int[] kekster = { 0, 0, 0, 0 };
            int[] int_spec = { 0,0};//0 для макса 1 для мина
            {
                
                Regex regex = new Regex(@"(\[)\d+:\d+(\])");
                Regex regex_two = new Regex(@"[\[\]]");
                Regex regex_three = new Regex(@":");
                for (int i = 0; i < 10; i++)
                {
                    string temp = music_list[i];
                    temp = regex.Match(temp).ToString();
                    temp = regex_two.Replace(temp, "");
                    temp = regex_three.Replace(temp, ",");
                    double temp_d = Double.Parse(temp);
                    music_double_time[i] = temp_d;
                    summ_list_time += (int)(temp_d);//время
                    {//для секунд
                        double temp_for_sec = temp_d-(int)(temp_d);
                        temp_for_sec =temp_for_sec* 100;
                        summ_list_time_sec +=(int)(temp_for_sec) ;
                    }
                    
                    if (big_music < temp_d)   {big_music = temp_d;   int_spec[0] = i;}
                    if (small_music > temp_d) {small_music = temp_d; int_spec[1] = i;}
                }
                
                for(int i =0;i<10;i++)
                {
                    for(int j =0;j<10;j++)
                    {
                        if (i != j && (Math.Abs(music_double_time[i] - music_double_time[j]) < min_inteval_first))//j наименьшая получается
                        {
                            min_inteval_first = Math.Abs(music_double_time[i] - music_double_time[j]);
                            kekster[0] = i;
                            kekster[1] = j;
                        }
                    }
                }
                

            }
            double summ_double_time = 0;
            int int_item_time = 0;
            foreach (double doub in music_double_time)
            {
                double temp = doub;
                int_item_time += (int)(temp);
                summ_double_time+= ((doub-(int)(temp)));
            }
            int item_free = (int)(summ_double_time);
            summ_double_time = summ_double_time - item_free;
            summ_double_time += item_free + int_item_time;
            Console.WriteLine("Общее время всех песен "+ summ_double_time);
            Console.WriteLine("\nСамая длинная песня \n"+music_list[int_spec[0]]);
            Console.WriteLine("\nСамая короткая песня \n" + music_list[int_spec[1]]);
           Console.WriteLine("\nМинимальный интервал между \n{0} \n{1} ", music_list[kekster[0]],music_list[kekster[1]]);
        }
        public static void Ex_A1_5()// работает
        {
            /*                                                  хитрожопый план
            * переводим текст в ловер и записываем в посимвольный массив+
            * делаем отдельный массив от "а" до "я" символов и записать их номера, ибо ручками в падлу, пусть компилится
            * находим одинаковые символы и добавляем к ним число связанное с их номером, кодируем крч
            * неизвестные значения получают + 100, и потом декодируется вся эта каша
            * небольшая побочка, надо добавить 1071, шоб выйти в те же символы
             */

            /*                                      нормальный план пришедший после того, как я реализовал хитрожопый
             * тупо к символьным интам добавлять ключи по списку, на вывод чисел отнимать у них -1071,шоб была иллюзия работы
             * после чего в другой массив кидать уже с - ключами и получать все те же значения.........
             */
            // ввод текста
            Console.WriteLine("Введите текст");
            string normal_text =  Console.ReadLine();
            char[] array_char_for_normal_text = new char[normal_text.Length];
            normal_text = normal_text.ToLower();
            int[] keys = { 2, 5, 9 };// массив ключей
           


            // разбиение текста на массив символов
            for (int i = 0; i< array_char_for_normal_text.Length;i++)
                array_char_for_normal_text[i] = normal_text[i];


            int[] coding_normal_text = coding(array_char_for_normal_text, keys);// вывод
            foreach (int symbol in coding(array_char_for_normal_text, keys))
                Console.Write(symbol + " ");
            Console.WriteLine();


            encoding(keys,coding_normal_text);
            Console.WriteLine();
        }
        static int[] coding(char[] array_char_for_normal_text, int[] keys)
        {//массив который над изменить, символы нормали, числа, ключи
            // базовый массив и заполнение 
            
            char[] basic_array_chars = new char[1103 - 1072 + 2];//до я от а 
            int[] basic_array_int = new int[1103 - 1072 + 2];// порядковый номер начиная с нуля

            for (int i = 0, k = 1072; i < 1103 - 1072 + 1; i++, k++)
            {
                basic_array_int[i] = i + 1;
                basic_array_chars[i] = (char)(k);
            }
            basic_array_int[basic_array_int.Length - 1] = 33;
            basic_array_chars[basic_array_chars.Length - 1] = 'ё'; //1105 символ, аутируем вместе

            int[] exit_array = new int[array_char_for_normal_text.Length];

            for (int i = 0, k = 0; i < array_char_for_normal_text.Length; i++,k++)
            {
                int count = 0;
                if (k == 3) k = 0;
                for(int j =0;j< basic_array_chars.Length;j++)
                {
                    if(array_char_for_normal_text[i] == basic_array_chars[j])
                    {
                        count++;
                         exit_array[i] = basic_array_int[j] + keys[k];
                    }
                }
                if (count == 0) { exit_array[i] = array_char_for_normal_text[i] + 100; k--; }
            }
            return exit_array;
        }


        static void encoding(int[] keys, int[] array_coding_normal_text)
        {
            char[] basic_array_chars = new char[1103 - 1072 + 2];//до я от а 
            int[] basic_array_int = new int[1103 - 1072 + 2];// порядковый номер начиная с нуля

            for (int i = 0, k = 1072; i < 1103 - 1072 + 1; i++, k++)
            {
                basic_array_int[i] = i + 1;
                basic_array_chars[i] = (char)(k);
            }
            basic_array_int[basic_array_int.Length - 1] = 33;
            basic_array_chars[basic_array_chars.Length - 1] = 'ё'; //1105 символ, аутируем вместе
            
            int[] exit_array = new int[array_coding_normal_text.Length];
            //процедура энкодинга
            for (int i = 0, k = 0; i < array_coding_normal_text.Length; i++,k++)
            {
                if (k == 3) k = 0;
                if (array_coding_normal_text[i] >= 100) { exit_array[i] = array_coding_normal_text[i] - 100;k--; }
                else
                {
                        exit_array[i] = array_coding_normal_text[i] - keys[k]+1071;

                }
            }

            foreach (char kek in exit_array)
                Console.Write(kek);

        }


        public static void Ex_A2_5()// работает
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
                            if (str_s[i + sleep] == ' ' || str_s[i + sleep] == ',' || str_s[i + sleep] == '.' || str_s[i + sleep] == '-')
                            {

                            }
                            else break;
                        }
                        else break;// выход если улетели
                    }
                }
                else if (sleep == 0) array_str[count] += str_s[i];// когда слипы не 0 это значит, что мы идем по символам
                if (sleep != 0) { array_str_new[count] += str_s[i]; sleep--; }// на каждой итерации будет идти -- и так до нуля, что бы не запороть слова
            }

            for (int i = 0; i < array_str.Length; i++)
            {
                if (array_str[i] == null) break;
                string temp = array_str[i];
                if (temp.Length<6)
                {
                    string temp_for_array = null;
                  foreach(int k in temp)
                    {
                        if (k >= 65 && k <= 90)
                        {
                            temp_for_array += "\"_\"";
                        }
                        else temp_for_array +=(char) k;
                    }
                    array_str[i] = temp_for_array;
                } 
            }
            char[] big_cymbols = { 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L',  'Z', 'X', 'C', 'C', 'V', 'B', 'N', 'M' };
            
            for(int i =0;i< array_str.Length;i++)
            {
                if (array_str[i] != null)
                {
                    Console.Write(array_str[i]+array_str_new[i+1]);
                }
                else break;
            }
            Console.WriteLine();
            Console.WriteLine("Второй способ");//str_s

            string[] array_for_str_s = str_s.Split(char_any, StringSplitOptions.RemoveEmptyEntries);
            string[] array_for_str_s_tans = str_s.Split(char_any_cybol_for_word, StringSplitOptions.RemoveEmptyEntries);
            string[] new_array_str = new string[array_for_str_s.Length];


            for(int i =0;i<array_for_str_s.Length;i++)
            {
                string temp = array_for_str_s[i];
                if (temp.Length < 6)
                {
                    for (int j = 0; j < big_cymbols.Length; j++)
                        temp = temp.Replace(big_cymbols[j].ToString(), "\"_\"");
                }
                new_array_str[i] = temp;
            }


            for (int i = 0; i < new_array_str.Length; i++)
            {

                    Console.Write(new_array_str[i]);
                //if(i< array_for_str_s_tans.Length)
                    Console.Write(array_for_str_s_tans[i]);
            }
            Console.WriteLine();
        }
        public static void Ex_A3_5()// работает
        {
            string stroka_normalnaya = Console.ReadLine();
            Regex regex = new Regex(@"\(\d{3}\)\d{3}\-\d{2}\-\d{2}");
            foreach (Match kek in regex.Matches(stroka_normalnaya))
                Console.WriteLine(kek);
            regex = new Regex(@"\(\d{3}\)\d{3}\d{2}\d{2}");
            foreach (Match kek in regex.Matches(stroka_normalnaya))
                Console.WriteLine(kek);
        }
    }
}