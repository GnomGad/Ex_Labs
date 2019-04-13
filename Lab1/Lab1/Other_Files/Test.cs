using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;

namespace Labs
{
    class Test
    {
        //public static void test() => Labs.File_lab6.Ex_1();
        public static void test()
        {
            LabManager9();
        }
        
        public static void LabManager6()//работает
        {
            char k = 'j';
            while (k != 0)
            {
                Console.WriteLine("\r\nНомер задания, 0 - выход");
                k = Console.ReadKey().KeyChar;
                if (k == '1') File_lab6.Ex_1();
                else if (k == '2') Ex2();
                else if (k == '3') Ex3();
                else if (k == '4') Ex4();
                else if (k == '5') Ex5();
            }
        }
        static void Ex2()//работает
        {
            Console.WriteLine("Программно записать в бинарный файл набор пар «N – N^1/2» для N от 4 до 81.Написать функцию, которая считывает из этого файла все вторые числа из каждой пары и записывает во второй файл");
            Lab6Manager Ex2F = new Lab6Manager();
            Ex2F.FileOutName = "OutFile.txt";
            Ex2F.FileInName = "InputFile.txt";
            Ex2F.Ex2();
        }
        static void Ex3()// работает
        {
            Lab6Manager Ex3F = new Lab6Manager();
            Console.WriteLine("Считать текстовый файл, сформировать новый файл, в котором удалить все цифры. Вывести на консоль количество удалений.");
            Console.WriteLine("Как назвать новый файл?");
            Ex3F.FileInName = "Ex3";
            Ex3F.FileOutName = Console.ReadLine();
            Ex3F.Ex3();
        }
        static void Ex4()// работает
        {
            Lab6Manager Ex4 = new Lab6Manager();
            Console.WriteLine("Написать программу, которая создает на одном из разделов жесткого диска директорию Lab6_Temp, автоматически копирует в эту директорию Ваш файл lab.dat из задания 1 и создает в ней копию этого файла lab_backup.dat путем побайтового копирования.Вывести на консоль информацию о файле lab.dat: размер, время последнего изменения, время последнего доступа.\r\n");
            Ex4.Ex4();
        }
        static void Ex5()// работает
        {
            Lab6Manager Ex5F = new Lab6Manager();
            Console.WriteLine("Перенесите файл в папку и введите её название ( . для получения информации)");
            Ex5F.FileName = Console.ReadLine();
            Ex5F.Ex5();
        }


        public static void LabManager7()
        {
            Ex1Lab7();
           // Ex2Lab7();
        }
        static void Ex1Lab7()//работает
        {
        Lab7Manager Lab7Managers = new Lab7Manager();
        Lab7Managers.Ex1();
        }
        static void Ex2Lab7()//работает
        {
            Lab7Manager Lab7Managers = new Lab7Manager();
            Lab7Managers.Ex2();
        }

        public static void LabManager8()
        {
            //Ex1Lab8();
            Ex2Lab8();
        }
        static void Ex1Lab8()
        {
            FileLabLibrary8 Fl8 = new FileLabLibrary8();
           

            Fl8.ReadBinaryFile();
            /*
            foreach(int i in Fl8.ArrayInt)
            {
                Console.Write("{0}  ", i);
            }
            */
            Console.WriteLine("Введи число");
            Fl8.SearchManager(int.Parse(Console.ReadLine()));
            
        }
        static void Ex2Lab8()
        {
            SearchString SS = new SearchString();
            SS.Text = "sukosuka";
            SS.SubText = "suka";
            FileLabLibrary8 Fl8 = new FileLabLibrary8();
            Fl8.InitializationSearchString(SS);
            Fl8.SearchManager(SS);
        }

        public static void LabManager9()
        {
            char k = 'j';
            while (k != '0')
            {
                Console.WriteLine("\r\nНомер задания\r\n1,  2,  3,  4,   0 - выход");
                k = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (k == '1') Ex1Lab9();
                else if (k == '2') Ex2Lab9();
                else if (k == '3') Ex3Lab9();
                else if (k == '4') Ex4Lab9();
                else if (k == '5') Ex5();
            }
        }
        static void Ex1Lab9()
        {
            Lab9Manager lab9Manager = new Lab9Manager();
            char k = 'j';
            while (k != '0')
            {
                Console.WriteLine("\r\n1 - первая часть  2 - вторая часть, 0 - выход");
                k = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (k == '1') lab9Manager.Ex1F();
                else if (k == '2') lab9Manager.Ex1S();
            } 
        }
        static void Ex2Lab9()
        {
            Console.WriteLine("\r\nВведите цифровое выражение");
            string text = Console.ReadLine();
            if (text.ToLower() == "true")
            {
                text = "(2+3)(1+6)(((2-3)(5+1)))2(3)(1 + 6(7 + 2))((2 - 3)(5 + 1))2(3 + 5(((6))))";
                Console.WriteLine(text);
            }
            else if (text.ToLower() == "false")
            {
                text = "((2+3)(4-1)))2(3 + 5(((6))";
                Console.WriteLine(text);
            }
                Lab9Manager lab9Manager = new Lab9Manager();
            lab9Manager.Ex2(text);
        }
        static void Ex3Lab9()
        {
            Lab9Manager lab9Manager = new Lab9Manager();
            lab9Manager.Ex3();
                
        }
        static void Ex4Lab9()
        {

        }

    }

}
