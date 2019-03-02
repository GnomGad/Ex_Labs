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


            
        }
        static  void Ex3()// работает
        {
            Lab6Manager Ex3F = new Lab6Manager();
            Console.WriteLine("Считать текстовый файл, сформировать новый файл, в котором удалить все цифры. Вывести на консоль количество удалений.");
            Console.WriteLine("Как назвать новый файл?");
            Ex3F.FileOutName = Console.ReadLine();
            Ex3F.Ex3();
        }
        static void Ex4()
        {
            Lab6Manager Ex4 = new Lab6Manager();
            Console.WriteLine("Написать программу, которая создает на одном из разделов жесткого диска директорию Lab6_Temp, автоматически копирует в эту директорию Ваш файл lab.dat из задания 1 и создает в ней копию этого файла lab_backup.dat путем побайтового копирования.Вывести на консоль информацию о файле lab.dat: размер, время последнего изменения, время последнего доступа.\r\n");
            Ex4.Ex4();
        }
        static void Ex5()
        {
            Lab6Manager Ex5F = new Lab6Manager();
            Console.WriteLine("Перенесите файл в папку и введите её название ( . для получения информации)");
            Ex5F.FileName  = Console.ReadLine();
            Ex5F.Ex5();
        }
    }

}
