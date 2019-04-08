using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs
{
    class MainL
    {

        public static ConsoleColor Color_Green = ConsoleColor.Green;// задания 
        public static ConsoleColor Color_Red = ConsoleColor.Red; // ошибки
        public static ConsoleColor Color_Yellow = ConsoleColor.Yellow; // помощь
        public static ConsoleColor Color_DarkGreen = ConsoleColor.DarkGreen;// название тем
        public static ConsoleColor Color_Cyan = ConsoleColor.Cyan; // не помню где юзаю)
        public static ConsoleColor Color_Magnetta = ConsoleColor.Magenta;
        public static string Ex = "Задание:", bug = "Ошибка:", topic = "Тема:", Glob_Menu = "Меню:", help_mes = "Помощь:", help_mesR = "Помощь по разделу:", space = "    ", test_questions = "Контрольные вопросы";// tipics

        public static int[] Normal_Enter_Parse(string stroka, int n = 1)
        {

            string[] nums_str = stroka.Split(',', ' ', '.', '/', '\\','\'',';','ю', 'б', 'э', 'ж', 'д', 'ъ', 'х', 'з', 'щ', 'm', 'l', '[', ']', '|', 'p', 'o', '?');

                int[] nums_int = new int[nums_str.Length];
                for (int i = 0; i < nums_int.Length; i++)
                    nums_int[i] = int.Parse(nums_str[i]);
                return nums_int;
        }
        public static string[] Normal_Enter_Parse(string stroka,string s="string")
        {
            string[] nums_str = stroka.Split(',', ' ', '.', '/', '\\', '\'', ';');
            return nums_str;
        }
        static string  stroka_normal(string fullstring)
        {

            string Sexit = ""; //то, что нужно вернуть
            int sum_space = fullstring.Length / 80;
            int full_s = fullstring.Length;

            for (int i = 0; i < full_s; i++)
            { 
                Sexit += fullstring[i];
            }
            return Sexit;
        }
        //------------------------------------
        static void Console_message(string theme , string stroka, ConsoleColor color = ConsoleColor.White)
        {
            
            Console.ForegroundColor = color;
            Console.WriteLine(stroka_normal(theme +" " +stroka));
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Console_message(string stroka = "", ConsoleColor color = ConsoleColor.White)
        {

            Console.ForegroundColor = color;
            Console.WriteLine(stroka_normal(" " + stroka));
            Console.ForegroundColor = ConsoleColor.White;
        }
        //--------------------------------------
        static void help(byte t = 0) // обработано
        {
            Console_message(help_mes, "0 - Выход из текущего каталога", Color_Yellow);
            Console_message(help_mes, "cl - Очистка экрана", Color_Yellow);
            Console_message(help_mes, "help - помощь", Color_Yellow);
            if (t == 1)
            {
                Console.WriteLine();
                Console_message(help_mesR+" 1", "Базовые типы данных языка C#. Работа с консолью", Color_Yellow);
                Console_message(help_mesR + " 2","Программирование ветвления и циклов на языке C#", Color_Yellow);
                Console_message(help_mesR + " 3","Массивы. Пользовательские функции", Color_Yellow);
            }
            if (t == 2)
            {
                Console_message(help_mes, "q - Контрольные вопросы", Color_Yellow);
            }
        }


        static void Main(string[] args)// 80*
        {
            // for(int i = 1;i<=80; i++)
            //stroka_normal("Реализовать программно присвоение целочисленной переменной d первой цифры из дробной части положительного вещественного числа х.Например,для х = 27.3198 значение d будет равно 3");

            while (true)
            {
                Console_message(Glob_Menu,"Введите номер лабораторной работы 1-5");
                string key = Console.ReadLine();
                //string[] nums = key.Split(',', ' ', '.','/','\\');
                string[] nums = Normal_Enter_Parse(key," ");
                string key_second = "-1";
                if (nums.Length == 2)
                {
                    key = nums[0];
                      key_second = nums[1];
                }
                switch (key)
                {
                    case "cl": { Console.Clear(); break; }
                    case "0": { return; }
                    case "1": { Console_message(topic,"Базовые типы данных языка C#. Работа с консолью", Color_DarkGreen) ; Ex_lab1(key_second); break; }
                    case "2": { Console_message(topic,"Программирование ветвления и циклов на языке C#", Color_DarkGreen); Ex_lab2(key_second); break; }
                    case "3": { Console_message(topic,"Массивы. Пользовательские функции", Color_DarkGreen); Ex_lab3(key_second); break; }
                    case "4": { Console_message(topic, "Работа со строками в C#. Знакомство с регулярными выражениями", Color_DarkGreen);Ex_Lab4(key_second);break; }
                    case "5": { Console_message(topic, "Перечисления и структуры в C#", Color_DarkGreen); Ex_Lab5(key_second); break; }
                    case "6": { Console_message(topic, "Работа с файлами", Color_DarkGreen); Ex_Lab6(key_second); break; }
                    case "7": { Console_message(topic, "Простые алгоритмы сортировки. Анализ алгоритмов", Color_DarkGreen); Ex_Lab7(key_second); break; }
                    case "8": { Console_message(topic, "Алгоритмы поиска", Color_DarkGreen); Ex_Lab8(key_second); break; }
                    case "9": { Console_message(topic, "Абстрактные типы данных (АТД). Коллекции в .NET.", Color_DarkGreen); Ex_Lab9(key_second); break; }
                    case "10": { Console_message(topic, "Продвинутые алгоритмы сортировки. Динамическое программирование. Алгоритмы на графах.", Color_DarkGreen); Ex_Lab10(key_second); break; }
                    case "help": { help(1); break; }
                    case "": { Labs.Test.test(); break; }
                    default: { Console_message(bug,"Неверное значение, команда help для помощи",Color_Red) ; break; }

                }
            }

        }

        static void Ex_lab1(string d ) //<======================================================== LAB1
        {
            
            string k = d;
            
            while (true)
            {
                if(k!="0")Console_message(Glob_Menu, "Введите номер задания  1-11");
                if(k == "-1") k = Console.ReadLine();

                switch (k)
                {
                    
                    case "help": { help(2); break; }
                    case "cl": { Console.Clear(); break; }
                    case "0": { return; }
                    case "1": { Console_message(Ex, "Реализовать программно присвоение целочисленной переменной d первой цифры из дробной части положительного вещественного числа х.Например,для х = 27.3198 значение d будет равно 3",Color_Green); Lab1.Ex_0(); break; }
                    case "2": { Console_message(Ex, "Написать программу, которая определяет полное количество часов и минут суток, которые прошли к моменту текущей секунды суток.Например, если секунд прошло 11111, то часов прошло 3, а минут – 5 (11111 = 3 * 3600 + 5 * 60 + 11)", Color_Green); Lab1.Ex_1(); break; }
                    case "3": { Console_message(Ex, "Написать программу, которая определяет угол в градусах между положением часовой стрелки в начале суток и ее положением в h часов, m минут и s секунд (0 ≤ h ≤ 11; 0 ≤ m, s ≤ 59)", Color_Green); Lab1.Ex_2(); break; }
                    case "4": { Console_message(Ex, "Реализовать программно обмен значениями для двух целых переменных без использования дополнительных переменных.", Color_Green); Lab1.Ex_3(); break; }
                    case "5": { Console_message(Ex, "Написать программу, которая предлагает пользователю ввести длины 2 катетов прямоугольного треугольника и затем по этим данным вычисляет и выводит на экран площадь и периметр треугольника", Color_Green); Lab1.Ex_4(); break; }
                    case "6": { Console_message(Ex, "Написать программу, которая находит произведение цифр заданного четырехзначного числа.Например, для числа «1234» ответ будет 1 * 2 * 3 * 4 = 24.", Color_Green); Lab1.Ex_5(); break; }
                    case "7": { Console_message(Ex, "Написать программу, которая записывает введенное трехзначное число в обратном порядке в переменную reversed и выводит ее на экран.Например, при вводе числа «362» будет выведено строкой ниже число «263».", Color_Green); Lab1.Ex_6(); break; }
                    case "8": { Console_message(Ex, "Ввести с клавиатуры действительное число х. Пользуясь только операциями умножения, сложения и вычитания, вычислить: 3x^4 – 5х^3 + 2х^2 – x + 7",Color_Green); Lab1.Ex_7(); break; }
                    case "9": { Console_message(Ex, "Написать программу для решения системы уравнений (коэффициенты a, b, c ввести с клавиатуры, определитель системы не должен быть равен 0)", Color_Green); Lab1.Ex_8(); break; }
                    case "10": { Console_message(Ex, "Разработать программу, которая позволяет ввести по отдельности данные из таблицы, представленной в приложении А, и выводит форматированную таблицу на экран(включая заголовок и примечания).Целочисленные и вещественные значения хранить в переменных соответствующих типов.", Color_Green); Lab1.Ex_A1_5(); break; }
                    case "11": { Console_message(Ex, "Разработать программу, которая вычисляет и выводит на экран значения, в соответствии с формулами, приведенными в приложении А.Определить области допустимых значений параметров формул(действительные числа). При демонстрации программы задать произвольные значения из этих областей.", Color_Green); Lab1.Ex_A2_5(); break; }
                    case "q":
                        {
                            Console_message(test_questions, Color_Cyan);
                            Console_message( "1. Что такое алгоритм? Укажите свойства и виды представления алгоритма. ", Color_Cyan);
                            Console_message( "2.В чем заключается суть компиляции и компоновки(линковки) кода ? ", Color_Cyan);
                            Console_message( "3.Перечислите и кратко опишите основные парадигмы современного программирования.", Color_Cyan);
                            Console_message( "4.Работа в среде MS Visual Studio: как создать проект консольного приложения на C#? Что делают комбинации клавиш Ctrl+F5 и Shift+F6? ", Color_Cyan);
                            Console_message( "5.Работа в среде MS Visual Studio: как производится отладка программ ? ", Color_Cyan);
                            Console_message( "6.Кратко опишите два главных элемента фреймворка.NET.", Color_Cyan);
                            Console_message("7.Перечислите базовые типы данных C# с указанием объема занимаемой памяти для каждого типа.", Color_Cyan);
                            Console_message( "8.Что такое переменная ? Как объявляются и инициализируются переменные и константы на языке C#?", Color_Cyan);
                            Console_message( "9.Каково назначение ключевого слова var в C#? 10.Укажите особенности преобразования и приведения типов на C#.", Color_Cyan);
                            Console_message( "11.Чем отличаются префиксный и постфиксный инкременты(декременты) ?", Color_Cyan); 
                            Console_message( "12.Как можно форматировать вывод данных на консоль в.NET ?", Color_Cyan); 
                            break;
                        }
                    default: { Console_message(bug, "Неверное значение, команда help для помощи", Color_Red); break; }

                }
                Console_message(Glob_Menu, "space если хотите повторить или номер нужного задания", Color_Magnetta);
                string tmp = Console.ReadLine();
                if (tmp != " ") k = tmp;
            }
        }

        static void Ex_lab2(string d ) //<======================================================== LAB2
        {
            string k=d;
            while (true)
            {
                if (k != "0") Console_message(Glob_Menu, "Введите номер задания  1-8");
                if (k == "-1") k = Console.ReadLine();
                switch (k)
                {
                    case "help": { help(2); break; }
                    case "cl": { Console.Clear(); break; }
                    case "0": { return; }
                    case "1": { Console_message(Ex, "Написать программу для решения квадратного уравнения ax2 + bx + c = 0.Числа a, b и c вводятся с клавиатуры.Если уравнение имеет два действительных корня, программа должна вывести оба корня на экран; если один корень – вывести только один; если уравнение не имеет действительных корней, то вывести результат в виде записи двух комплексных чисел: x + iy и x–iy.",Color_Green); lab2.ex_1(); break; }
                    case "2": { Console_message(Ex, "Написать программу для приближенного вычисления числа π на основе следующей формулы (количество слагаемых ввести с клавиатуры):", Color_Green); lab2.ex_2(); break; }
                    case "3": { Console_message(Ex, "Написать программу, которая определяет количество четырехзначных чисел в ряде Фибоначчи. Ряд Фибоначчи (1, 1, 2, 3, 5, 8, 13, 21, …) – это такая последовательность натуральных чисел, каждый член которой является суммой предыдущих двух (первые два члены равны 1):f0 = f1 = 1; fi = fi-1 + fi-2 , i = 2,3,4... ", Color_Green); lab2.ex_3(); break; }
                    case "4": { Console_message(Ex, "Написать программу для вычисления приближенного значения cos(x) на основе формулы ряда Тейлора (необходимо ввести с клавиатуры числа х и q; если значение по модулю очередного слагаемого окажется меньше q, то расчет суммы нужно остановить, на экран надо вывести также количество учтенных слагаемых)", Color_Green); lab2.ex_4(); break; }
                    case "5": { Console_message(Ex, "Написать программу, которая позволяет ввести с клавиатуры натуральное число N и вывести на экран все комбинации натуральных чисел x, y, z, таких что x^3+y^3 +z^3 =N. Если число N невозможно разложить по кубам x, y, z, программа должна выводить сообщение «No such combinations!». ", Color_Green); lab2.ex_5(); break; }
                    case "6": { Console_message(Ex, "Написать программу, которая позволяет ввести с клавиатуры число N от 1 до 100 и вывести на экран грамматически верную фразу вида «N [лет|год | года]». Например: «21 год», «32 года», «57 лет» и т.д.", Color_Green); lab2.ex_6(); break; }
                    case "7": { Console_message(Ex, "Ввести с экрана день, месяц и год (3 целых неотрицательных числа). Вывести на экран дату в формате dd / mm / yyyy(если одно из чисел однозначное, то слева дополнить одним нулем).Ситуацию с вводом отрицательного числа, в программном коде не проверять", Color_Green); lab2.ex_a1_5(); break; }
                    case "8": { Console_message(Ex, "Ввести числа a, b (a<b). Вывести на экран сумму нечетных чисел из диапазона [a, b].", Color_Green); lab2.ex_a2_5(); break; }
                    case "q": {
                            Console_message(test_questions, Color_Cyan);
                            Console_message("1. Приведите по три примера задач, которые нужно решать с помощью операторов ветвления и с помощью операторов цикла. ", Color_Cyan);
                            Console_message("2. Чем отличаются составные логические выражения от простых? Приведите по два примера простых и составных выражений на языке C#. ", Color_Cyan);
                            Console_message("3. Замените строку кода int x = n%3 == 0 ? n/3 : n*3; кодом с оператором if. ", Color_Cyan);
                            Console_message("4. Переменные каких типов можно использовать в качестве селекторов switch?", Color_Cyan);
                            Console_message("5. Что делают операторы break и continue?", Color_Cyan);
                            Console_message("6. Запишите цикл, который считает сумму всех четных чисел в диапазоне от 0 до 20, в виде оператора for с пустым телом.", Color_Cyan);
                            Console_message("7. В чем отличие оператора do while от оператора while?", Color_Cyan);
                            break; }
                    default: { Console_message(bug, "Неверное значение, команда help для помощи", Color_Red); break; }
                }
                Console_message(Glob_Menu, "space если хотите повторить или номер нужного задания", Color_Magnetta);
                string tmp = Console.ReadLine();
                if (tmp != " ") k = tmp;
            }
        }

        static void Ex_lab3(string d)
        {
            string k=d;
            while (true)
            {
                if (k != "0") Console_message(Glob_Menu, "Введите номер задания  1-10");
                if (k == "-1") k = Console.ReadLine();
                switch (k)
                {
                    case "help": { help(2); break; }
                    case "cl": { Console.Clear(); break; }
                    case "0": { return; }
                    case "1": { Console_message(Ex, "Написать программу, которая запрашивает число элементов массива, после чего создает массив, заполняет его случайными целыми числами в диапазоне от -30 до 45 и выводит на экран строками по 10 элементов.Программа должна после этого вывести элементы массива в обратном направлении, начиная с последнего, игнорируя отрицательные элементы.", Color_Green); lab3.ex_1(); break; }
                    case "2": { Console_message(Ex, "Написать программу поворота двумерного массива размерности 7х7 на 90 градусов вправо (без использования дополнительных массивов).", Color_Green); lab3.ex_2(); break; }
                    case "3": { Console_message(Ex, "Написать программу циклического сдвига массива на k позиций влево.", Color_Green); lab3.ex_3(); break; }
                    case "4": { Console_message(Ex, "Написать функции для поэлементного сложения и вычитания двумерных массивов 3х3. Функции должны принимать массивы в качестве параметров и выдавать результирующий массив в качестве возвращаемого значения. В третьем параметре функции необходимо вернуть среднее значение всех элементов входных массивов.", Color_Green); lab3.ex_4(); break; }
                    case "5": { Console_message(Ex, "Написать программу перемножения двух матриц 5х5.", Color_Green); lab3.ex_5(); break; }
                    case "6": {
                            Console_message( "Написать и продемонстрировать работу следующих функций:", Color_Green);
                            Console_message("\tsumIterative – итерационно вычисляет сумму элементов массива", Color_Green);
                            Console_message("\tsumRecursive – рекурсивно вычисляет сумму элементов массива", Color_Green);
                            Console_message("\tminIterative – итерационно вычисляет минимальный элемент в массиве", Color_Green);
                            Console_message("\tminRecursive – рекурсивно вычисляет минимальный элемент в массиве", Color_Green);
                            lab3.ex_6();
                            break; }
                    case "7": { Console_message(Ex, "Написать рекурсивную функцию для нахождения n-ого члена ряда Фибоначчи по формулам, приведенным в лабораторной работе №2.", Color_Green); lab3.ex_7(); break; }
                    case "8": { Console_message(Ex, "Написать программу, позволяющую рекурсивно вычислить определитель матрицы NxN по формуле: где Mij – это дополнительный минор (определитель матрицы, получаемой изисходной вычеркиванием i-й строки и j-го столбца).", Color_Green); lab3.ex_8(); break; }
                    case "9": { Console_message(Ex, ". Написать программу, заполняющую и отображающую на экране двумерный массив 9х9, в соответствии с вариантом(приложение А).", Color_Green); lab3.ex_a1_5(); break; }
                    case "10": { Console_message(Ex, "Написать программу, работающую с одномерным массивом, в соответствии с вариантом.", Color_Green); lab3.ex_a2_5(); break; }
                    case "q": { Console_message(test_questions, Color_Cyan);
                            Console_message( "1. Какими способами можно на языке C# объявить и проинициализировать одномерный массив?", Color_Cyan);
                            Console_message( "2. Можно ли в C# узнать размер (количество элементов) массива?", Color_Cyan);
                            Console_message( "3. Как работает оператор foreach?", Color_Cyan);
                            Console_message( "4. Какими способами можно на языке C# объявить и проинициализировать двумерный массив? Какие есть типы двумерных массивов?", Color_Cyan);
                            Console_message( "5. Синтаксис пользовательской функции. Параметры по умолчанию.", Color_Cyan);
                            Console_message( "6. Передача параметров в функцию. Ключевые слова params, ref и out.", Color_Cyan);
                            Console_message( "7. то такое рекурсия? Особенности написания рекурсивных функций", Color_Cyan);
                            break; }
                    default: { Console_message(bug, "Неверное значение, команда help для помощи", Color_Red); break; }
                }
                Console_message(Glob_Menu, "space если хотите повторить или номер нужного задания", Color_Magnetta);
                string tmp = Console.ReadLine();
                if (tmp != " ") k = tmp;
            }
        }

        static void Ex_Lab4(string d)
        {
            string k = d;
            while(true)
            {
                if (k != "0") Console_message(Glob_Menu, "Введите номер задания  1-10");
                if (k == "-1") k = Console.ReadLine();
                switch (k)
                {
                    case "help": { help(2); break; }
                    case "cl": { Console.Clear(); break; }
                    case "0": { return; }
                    case "1": { Console_message(Ex, "1. Ввести с клавиатуры текст предложения, завершить точкой. Вывести на консоль все символы, которые входят в этот текст ровно по одному разу. Решить задачу 2 способами: через обработку строки как массива символов и с помощью методов класса string", Color_Green);Labs.lab4.Ex_1() ;break; }
                    case "2": { Console_message(Ex, "2. Ввести с клавиатуры текст предложения, завершить точкой. Сформировать новую строку на основе исходной, в которой после каждого слова в скобках указать номер слова в предложении(слова разделяются запятыми, пробелами или тире).Например, если введено «Донецк – прекрасный город», результирующая строка должна выглядеть так: «Донецк(1) – прекрасный(2) город(3)». Решить задачу 2 способами: через обработку строки как массива символов и с помощью методов класса string.", Color_Green); lab4.Ex_2() ; break; }
                    case "3": { Console_message(Ex, "3. Ввести текст из нескольких слов, завершить точкой. Сформировать новую строку на основе исходной путем перестановки слов в обратной последовательности.Решить задачу 2 способами: через обработку строки как массива символов и с помощью методов классов string и StringBuilder", Color_Green);Labs.lab4.Ex_3() ;break; };
                    case "4": { Console_message(Ex, "4. Ввести с клавиатуры 7 строк, занести их в массив. Вывести все строки, в которых содержится хотя бы одно слово, оканчивающееся на “.com” (регистр символов не важен; слова разделяются пробелами, запятыми или точками). Также вывести номер строки, содержащей наименьшее число пробелов.Решить 2 способами: через обработку строки как массива символов и с помощью методов класса string", Color_Green); Labs.lab4.Ex_4(); break; };
                    case "5": { Console_message(Ex, "5. Ввести с клавиатуры текст. Программно найти в нем и вывести отдельно все слова, которые начинаются с большого латинского символа(от A до Z) и заканчиваются 2 цифрами, например «Petr93», «Johnny70», «Service02». Решить 2 способами: через обработку строки как массива и с помощью регулярных выражений.", Color_Green); Labs.lab4.Ex_5(); break; };
                    case "6": { Console_message(Ex, "6. Ввести строку вида « 15 + 36 = 51 » (количество пробелов может быть разным, числа – целые и могут быть отрицательны).С помощью регулярных выражений разобрать эту строку и занести в переменные типа int оба операнда и сумму.Вывести все переменные на консоль.", Color_Green);Labs.lab4.Ex_6() ; break; };
                    case "7": {
                            Console_message(Ex, "7. Дан треклист – массив из 10 строк следующего вида:", Color_Green);
                            Console_message("1. Gentle Giant – Free Hand [6:15]", Color_Green);
                            Console_message("2. Supertramp – Child Of Vision [07:27]", Color_Green);
                            Console_message("3. Camel – Lawrence [10:46]", Color_Green);
                            Console_message("4. Yes – Don’t Kill The Whale [3:55]", Color_Green);
                            Console_message("5. 10CC – Notell Hotel [04:58]", Color_Green);
                            Console_message("6. Nektar – King Of Twilight [4:16]", Color_Green);
                            Console_message("7. The Flower Kings – Monsters & Men [21:19]", Color_Green);
                            Console_message("8. Focus – Le Clochard [1:59]", Color_Green);
                            Console_message("9. Pendragon – Fallen Dream And Angel [5:23]", Color_Green);
                            Console_message("10. Kaipa – Remains Of The Day [08:02]", Color_Green);
                            Console_message(Ex, "Написать программу, которая обрабатывает весь треклист, суммирует время звучания песен и выводит результат на экран, а также отображает самую длинную и самую короткую песню в списке и пару песен с минимальной разницей во времени звучания.", Color_Green);
                            Labs.lab4.Ex_7(); break; };
                    case "8": { Console_message(Ex, "8.Написать программу, позволяющую шифровать и расшифровывать строки символов на основе 3 симметричных алгоритмов шифрования(прилож.А) Шифр Гронсфельда  ", Color_Green);lab4.Ex_A1_5(); break; };
                    case "9": { Console_message(Ex, "9.Написать программу обработки текста, в соответствии с вариантом. Решить задачу 2 способами: через обработку строки как массива символов и с помощью методов классов string и / или StringBuilder", Color_Green);
                            Console_message("Ввести с клавиатуры латинский текст. Сформировать новую строку из исходной путем замены всех больших букв в коротких словах(менее 6 букв) на символ «_»).", Color_Green); Labs.lab4.Ex_A2_5(); break; };
                    case "10": { Console_message(Ex, "10.Написать регулярные выражения для поиска подстроки в строке по правилу или шаблону, в соответствии с вариантом.", Color_Green);
                            Console_message("Найти в тексте все номера телефонов – подстроки вида «(000)1112233» или «(000)111-22-33»", Color_Green); Labs.lab4.Ex_A3_5() ; break; };
                    case "q":
                        {
                            Console_message(test_questions, Color_Cyan);
                            Console_message("1. Как в C# .NET может быть представлена строка символов?", Color_Cyan);
                            Console_message("2. Кратко опишите особенности и основные методы класса String", Color_Cyan);
                            Console_message("3. Что делают методы split() и join()?", Color_Cyan);
                            Console_message("4. Укажите особенности сравнения строк в C# .NET", Color_Cyan);
                            Console_message("5. Что такое абстрактное синтаксическое дерево? Дерево разбора?", Color_Cyan);
                            Console_message("6. Приведите определение и пример РБНФ-выражения.", Color_Cyan);
                            Console_message("7. Что такое регулярные выражения? Для чего они используются?", Color_Cyan);
                            Console_message("8. Опишите основные синтакические элементы регулярных выражений", Color_Cyan);
                            Console_message("9. Укажите разницу между «жадными», «ленивыми» и «собственническими» квантификаторами в регулярных выражениях", Color_Cyan);
                            break;
                        }
                    default: { Console_message(bug, "Неверное значение, команда help для помощи", Color_Red); break; }
                }
                Console_message(Glob_Menu, "space если хотите повторить или номер нужного задания", Color_Magnetta);
                string tmp = Console.ReadLine();
                if (tmp != " ") k = tmp;
            }
        }

        static void Ex_Lab5(string d)
        {
            string k = d;
            while (true)
            {
                if (k != "0") Console_message(Glob_Menu, "Введите номер задания  1-2");
                if (k == "-1") k = Console.ReadLine();
                switch (k)
                {
                    case "help": { help(2); break; }
                    case "cl": { Console.Clear(); break; }
                    case "0": { return; }
                    case "1": { Console_message(Ex, "1. Модифицировать код индивидуального задания 1 лабораторной работы №1. Организовать хранение данных в виде массива структур с полями, которые соответствуют столбцам таблицы.Консольное приложение должно быть интерактивным и постоянно предлагать на выбор одно из следующих действий, пока пользователь не введет 7, т.е.выберет пункт «7 – Выход»:", Color_Green);
                            Console_message("1 – Просмотр таблицы 2 – Добавить запись 3 – Удалить запись 4 – Обновить запись 5 – Поиск записей 6 – Просмотреть лог 7 - Выход", Color_Green);
                            Console_message("При выборе пункта «Просмотр таблицы» программа должна отобразить таблицу со всеми записями, по аналогии с лабораторной работой №1.", Color_Green);
                            Console_message("При выборе пункта «Добавить запись» программа должна последовательно предложить заполнить все поля новой записи и добавить ее в конец набора.", Color_Green);
                            Console_message("При выборе пункта «Удалить запись» программа должна предложить пользователю ввести номер записи, которую необходимо удалить.Удаление из массива подразумевает уменьшение числа элементов на 1 и смещение всех записей, находящихся после удаляемой, на 1 влево в массиве. ", Color_Green);
                            Console_message("При выборе пункта «Обновить запись» программа должна предложить пользователю ввести номер записи, которую необходимо обновить; затем предложить ввести новые значения всех полей этой записи и обновить ее.", Color_Green);
                            Console_message("При выборе пункта «Поиск записей» программа должна предложить ввести пользователю фильтр для поиска(выберите любой фильтр или спросите у проработчика.Например, найти всех сотрудников с годом рождения больше 1985) и вывести результаты, соответствующие фильтру внутри таблицы того же вида. ", Color_Green);
                            Console_message("При выборе пункта «Просмотреть лог» должен быть отображен лог действий пользователя(см.следующий пункт).", Color_Green);
                            Console_message("У меня 5 вариант",Color_Green);
                            lab5_1.main();
                            break; }
                    case "2": { Console_message(Ex, "2. Все действия пользователя (добавление / удаление / обновление записей) должны фиксироваться в специальном логе.Лог представляет собой тоже массив структур - записей(максимум 50 последних действий) с информацией о перечисляемом типе операции(ADD, DELETE, UPDATE), точном времени операции и сведениями о записи, с которой было произведено действие.Вывод на консоль должен иметь вид:", Color_Green);
                            Console_message("\n12:45:02 – Добавлена запись “Иванов” \n12:46:25 – Добавлена запись “Петров”\n12:46:58 – Удалена запись “Иванов” ", Color_Green);
                            Console_message("Ниже через одну пустую строку нужно также вывести время самого долгого «простоя» в текущем сеансе:", Color_Green);
                            Console_message("\n00:01:23 – Самый долгий период бездействия пользователя ", Color_Green); lab5_1.main();
                            break; }


                    case "q":
                        {
                            Console_message(test_questions, Color_Cyan);
                            Console_message("1. Какие возможности предоставляет C# .NET для работы с датой и временем? ", Color_Cyan);
                            Console_message("2. Опишите особенности перечисляемого типа enum в C#.NET.", Color_Cyan);
                            Console_message("3. Чем удобны структуры? Особенности типа struct ", Color_Cyan);
                            Console_message("4. Создание и доступ к членам структуры.", Color_Cyan);

                            break;
                        }
                    default: { Console_message(bug, "Неверное значение, команда help для помощи", Color_Red); break; }
                }
                Console_message(Glob_Menu, "space если хотите повторить или номер нужного задания", Color_Magnetta);
                string tmp = Console.ReadLine();
                if (tmp != " ") k = tmp;
            }
        }

        static void Ex_Lab6(string d)//в сей момент работа происходит здесь
        {
            string k = d;

            while (true)
            {
                if (k != "0") Console_message(Glob_Menu, "Введите номер задания  1-");
                if (k == "-1") k = Console.ReadLine();

                switch (k)
                {

                    case "help": { help(2); break; }
                    case "cl": { Console.Clear(); break; }
                    case "0": { return; }
                    case "1": { Console_message(Ex, "Дополнить код лабораторной работы №5, организовав хранение данных предметной области в бинарном(четные варианты) или текстовом(нечетные варианты) файле lab.dat.Данные должны считываться из файла при запуске программы и записываться в файл при закрытии программы.", Color_Green);
                            Labs.File_lab6.Ex_1();
                            break; }
                    case "2": { Console_message(Ex, ". Написать программу для работы с бинарными файлами, в соответствии с вариантом(приложение А).", Color_Green);
                            break; }
                    case "3": { Console_message(Ex, "Написать программу для работы с текстовыми файлами, в соответствии с вариантом(приложение Б).", Color_Green);
                            Console_message("",Color_Green);
                            break; }
                    case "4": { Console_message(Ex, "Написать программу, которая создает на одном из разделов жесткого диска директорию Lab6_Temp, автоматически копирует в эту директорию Ваш файл lab.dat из задания 1 и создает в ней копию этого файла lab_backup.dat путем побайтового копирования.Вывести на консоль информацию о файле lab.dat: размер, время последнего изменения, время последнего доступа.", Color_Green);
                            break; }
                    case "5": { Console_message(Ex, "Написать программу, которая позволяет ввести имя bmp-файла, считать его заголовки и вывести на консоль информацию о размере файла, ширине и высоте в пикселях, количестве бит на пиксель, разрешении горизонтальном и вертикальном(количестве пикселей на метр), типе сжатия(без сжатия / 4бит RLE / 8бит RLE).Подготовьте несколько файлов изображений и проверьте на них Вашу программу.Структура bmp - файла приведена в приложении В", Color_Green);
                            break; }
                    case "q":
                        {
                            Console_message(test_questions, Color_Cyan);
                            Console_message("Мне лень их заполнять)  ", Color_Cyan);

                            break;
                        }
                    default: { Console_message(bug, "Неверное значение, команда help для помощи", Color_Red); break; }

                }
                Console_message(Glob_Menu, "space если хотите повторить или номер нужного задания", Color_Magnetta);
                string tmp = Console.ReadLine();
                if (tmp != " ") k = tmp;
            }
        }
        static void Ex_Lab7(string d)
        {
            string k = d;

            while (true)
            {
                if (k != "0") Console_message(Glob_Menu, "Введите номер задания  1-");
                if (k == "-1") k = Console.ReadLine();

                switch (k)
                {

                    case "help": { help(2); break; }
                    case "cl": { Console.Clear(); break; }
                    case "0": { return; }
                    case "1": { Console_message(Ex, "", Color_Green); Lab1.Ex_0(); break; }
                    case "q":
                        {
                            Console_message(test_questions, Color_Cyan);
                            Console_message("1.  ", Color_Cyan);

                            break;
                        }
                    default: { Console_message(bug, "Неверное значение, команда help для помощи", Color_Red); break; }

                }
                Console_message(Glob_Menu, "space если хотите повторить или номер нужного задания", Color_Magnetta);
                string tmp = Console.ReadLine();
                if (tmp != " ") k = tmp;
            }
        }

        static void Ex_Lab8(string d)
        {
            string k = d;

            while (true)
            {
                if (k != "0") Console_message(Glob_Menu, "Введите номер задания  1-");
                if (k == "-1") k = Console.ReadLine();

                switch (k)
                {

                    case "help": { help(2); break; }
                    case "cl": { Console.Clear(); break; }
                    case "0": { return; }
                    case "1": { Console_message(Ex, "", Color_Green); Lab1.Ex_0(); break; }
                    case "q":
                        {
                            Console_message(test_questions, Color_Cyan);
                            Console_message("1.  ", Color_Cyan);

                            break;
                        }
                    default: { Console_message(bug, "Неверное значение, команда help для помощи", Color_Red); break; }

                }
                Console_message(Glob_Menu, "space если хотите повторить или номер нужного задания", Color_Magnetta);
                string tmp = Console.ReadLine();
                if (tmp != " ") k = tmp;
            }
        }

        static void Ex_Lab9(string d)
        {
            string k = d;

            while (true)
            {
                if (k != "0") Console_message(Glob_Menu, "Введите номер задания  1-");
                if (k == "-1") k = Console.ReadLine();

                switch (k)
                {

                    case "help": { help(2); break; }
                    case "cl": { Console.Clear(); break; }
                    case "0": { return; }
                    case "1": { Console_message(Ex, "", Color_Green); Lab1.Ex_0(); break; }
                    case "q":
                        {
                            Console_message(test_questions, Color_Cyan);
                            Console_message("1.  ", Color_Cyan);

                            break;
                        }
                    default: { Console_message(bug, "Неверное значение, команда help для помощи", Color_Red); break; }

                }
                Console_message(Glob_Menu, "space если хотите повторить или номер нужного задания", Color_Magnetta);
                string tmp = Console.ReadLine();
                if (tmp != " ") k = tmp;
            }
        }

        static void Ex_Lab10(string d)
        {
            string k = d;

            while (true)
            {
                if (k != "0") Console_message(Glob_Menu, "Введите номер задания  1-");
                if (k == "-1") k = Console.ReadLine();

                switch (k)
                {

                    case "help": { help(2); break; }
                    case "cl": { Console.Clear(); break; }
                    case "0": { return; }
                    case "1": { Console_message(Ex, "", Color_Green); Lab1.Ex_0(); break; }
                    case "q":
                        {
                            Console_message(test_questions, Color_Cyan);
                            Console_message("1.  ", Color_Cyan);

                            break;
                        }
                    default: { Console_message(bug, "Неверное значение, команда help для помощи", Color_Red); break; }

                }
                Console_message(Glob_Menu, "space если хотите повторить или номер нужного задания", Color_Magnetta);
                string tmp = Console.ReadLine();
                if (tmp != " ") k = tmp;
            }
        }

    }
}
