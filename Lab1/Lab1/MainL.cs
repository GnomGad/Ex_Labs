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

            string[] nums_str = stroka.Split(',', ' ', '.', '/', '\\','\'',';');

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

            for (int i = 0,d = 1; i < full_s; i++)
            {
                if (i-1 == (79*d-1) )
                {
                    if (fullstring[i] != ' ')
                    {
                        Sexit += "-";
                    }
                    d++;
                }
                
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
                Console_message(Glob_Menu,"Введите номер лабораторной работы 1-3");
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
                    case "help": { help(1); break; }
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
    }
}
