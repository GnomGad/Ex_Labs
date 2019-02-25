using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Labs
{
    public class lab5_1
    {/// <summary>
     ///  если над поменять количество максимальное строк в таблице
     /// </summary>
        public const byte MaxStrinTable = 2; // максимальное число таблицы
        public const byte MaxBuildConst = 50; // максимальное число логов
         static LogActions[] Builds = new LogActions[MaxBuildConst];
         static GetTvshow[] Tv_Shows = new GetTvshow[MaxStrinTable];
         static BigSpan BigSpan = new BigSpan();
         static DateTime tim = DateTime.Now;
         static byte COUNT = 0;

        /// <summary>
        /// свой майн с блэк джеком и таблицами
        /// </summary>
        public static void main()
        {
            TimeS.timelast = DateTime.Now;
            while (true)
            {
                Console.WriteLine("\n1 – Просмотр таблицы\n2 – Добавить запись\n3 – Удалить запись\n4 – Обновить запись\n5 – Поиск записей\n6 – Просмотреть лог\n7 - Выход\n");
                string key = Console.ReadLine();
                switch (key)
                {
                    case "1": show(); break;
                    case "2": build(); break;
                    case "3": delete(); break;
                    case "4": update(); break;
                    case "5": search(); break;
                    case "6": check_log(); break;
                    case "7": return;
                }
            }
        }

        public static void show()// показ
        {
            Tv_Shows[1].ShowTheme();
            for (int i = 0; i < MaxStrinTable; i++)
            {
                if (Tv_Shows[i].NameArtist != null)// что бы не показывалась таблица без значений
                    Tv_Shows[i].ShowThis();

            }
            Tv_Shows[1].ShowStatement();
            build_log();

        }

       public static void build()// построение
        {
            for (int i = 0; i < MaxStrinTable; i++)
            {

                if (Tv_Shows[i].NameArtist == null)
                {

                    Console.WriteLine("Название передачи");
                    Tv_Shows[i].NameTV = Console.ReadLine();

                    Console.WriteLine("Фамилия ведущего");
                    Tv_Shows[i].NameArtist = Console.ReadLine();

                    Console.WriteLine("оценка 1-5");
                    error_1:
                    string er;
                    Tv_Shows[i].check_for_value(Console.ReadLine(), out er);
                    if (er == "good") goto good_1;
                    else Console.WriteLine("Ошибка! Введите от 1 до 5");
                    goto error_1;
                    good_1:

                    Console.WriteLine("Тип передачи");
                    error_2:
                    Tv_Shows[i].check_for_tyoe(Char.Parse(Console.ReadLine()), out er);
                    if (er == "good") goto good_2;
                    else Console.WriteLine("Ошибка! Введите А, И или Т");
                    goto error_2;
                    good_2:
                    build_log(Tv_Shows[i].NameTV, ForLogAction.Add, DateTime.Now);
                    Tv_Shows[i].n = i + 1;
                    break;
                }
                
            }
        }


        public static void delete()// удаление
        {
            Console.WriteLine("Введи порядковый номер записи из списка");
            byte i = Byte.Parse(Console.ReadLine());
            if (i > MaxStrinTable || i < 0) { Console.WriteLine("Нет таких значений"); return; }
            i--;
            if (Tv_Shows[i].NameArtist == null) { Console.WriteLine("Нет таких значений"); return; }
            Tv_Shows[i].ShowThis();
            Console.WriteLine("Выбранная таблица \n1(да)\t2(нет)");
            byte KeyC = Byte.Parse(Console.ReadLine());
            if (KeyC == 1)
            {
                build_log(Tv_Shows[i].NameTV, ForLogAction.Delete, DateTime.Now);
                int count = 0;
                for (int j = i, k = j + 1; k < MaxStrinTable; j++, k++, count++)
                {
                    Tv_Shows[j].NameArtist = Tv_Shows[k].NameArtist;
                    Tv_Shows[j].NameTV = Tv_Shows[k].NameTV;
                    Tv_Shows[j].n = Tv_Shows[k].n - 1;
                    Tv_Shows[j].Type = Tv_Shows[k].Type;
                    Tv_Shows[j].Value = Tv_Shows[k].Value;
                }
                Tv_Shows[MaxStrinTable - 1].NameArtist = null;
                Tv_Shows[MaxStrinTable - 1].NameTV = null;
                Tv_Shows[MaxStrinTable - 1].n = 0;
                Tv_Shows[MaxStrinTable - 1].Type = '0';
                Tv_Shows[MaxStrinTable - 1].Value = ValueOfTV.one;

            }
        }

        public static void update()//ап
        {
            Console.WriteLine("Введи порядковый номер записи из списка");
            byte i = Byte.Parse(Console.ReadLine());
            if (i > MaxStrinTable||i<0) { Console.WriteLine("Нет таких значений"); return; }
            i--;
           
            if (Tv_Shows[i].NameArtist == null) { Console.WriteLine("Нет таких значений"); return; }
            Tv_Shows[i].ShowThis();
            Console.WriteLine("Выбранная таблица \n1(да)\t2(нет)");
            byte KeyC = Byte.Parse(Console.ReadLine());
            if (KeyC == 1)
            {
                build_log(Tv_Shows[i].NameTV, ForLogAction.Update, DateTime.Now);
                Console.WriteLine("Название передачи");
                Tv_Shows[i].NameTV = Console.ReadLine();


                Console.WriteLine("Фамилия ведущего");
                Tv_Shows[i].NameArtist = Console.ReadLine();

                Console.WriteLine("оценка 1-5");
                error_1:
                string er;
                Tv_Shows[i].check_for_value(Console.ReadLine(), out er);
                if (er == "good") goto good_1;
                else Console.WriteLine("Ошибка! Введите от 1 до 5");
                goto error_1;
                good_1:

                Console.WriteLine("Тип передачи");
                error_2:
                Tv_Shows[i].check_for_tyoe(Char.Parse(Console.ReadLine()), out er);
                if (er == "good") goto good_2;
                else Console.WriteLine("Ошибка! Введите А, И или Т");
                goto error_2;
                good_2:
                Console.WriteLine();

            }


        }


        public static void search()//поиск   организовать тип по значениям
        {
            Console.WriteLine("Выбери тип поиска\n1-Поиск по типу\n2-Поиск по оценке");
            string KeyFirst = Console.ReadLine();
            if (KeyFirst == "1") serach_for_type();
            else if (KeyFirst == "2") serach_for_value();
            build_log();
        }


        public static void serach_for_value()// работает
        {
            Console.WriteLine("Через пробел введите нумера |Все нумеры .");
            string TypeKeyFirst = Console.ReadLine();
            byte count = 0;
            byte count1 = 0;
            char[] array_nums = { '0', '0', '0', '0', '0' };

            if (TypeKeyFirst == ".") count++;
            if (count == 0)
            {
                Regex regex = new Regex(@"\d");
                foreach (Match ch in regex.Matches(TypeKeyFirst))
                {
                    array_nums[count1] = Char.Parse(ch.ToString());
                    count1++;
                    if (count1 != 5) count1++;
                    else count1 = 0;
                }
            }
            else
                for (byte i = 1; i < 6; i++)
                    array_nums[i - 1] = Char.Parse(i.ToString());

            Tv_Shows[1].ShowTheme();
            for (int i = 0; i < MaxStrinTable; i++)
            {
                if (Tv_Shows[i].NameArtist != null)// что бы не показывалась таблица без значений
                    for (int j = 0; j < 5; j++)
                    {
                        int b = (int)(Tv_Shows[i].Value);
                        if (b.ToString() == array_nums[j].ToString())
                            Tv_Shows[i].ShowThis();
                    }
            }
            Tv_Shows[1].ShowStatement();
        }


        public static void serach_for_type()// найс
        {
            Console.WriteLine("Через пробел введите символы |Все символы просто .|Все символы кроме одного .символ");
            string TypeKeyFirst = Console.ReadLine().ToUpper();
            byte count = 0;
            char[] array_chars = { 'А', 'И', 'Т' };

            foreach (char ch_of_type in TypeKeyFirst)
                if (ch_of_type == '.') count = 5;// если 5 то ничего не меняем либо 1 символ при 5
                else if (count == 5)
                    for (int i = 0; i < 3; i++)
                        if (array_chars[i] == ch_of_type) array_chars[i] = '0';

            if (count != 5)// если нету 5 то над найти те символы, которые там будут юзатся
            {
                for (int i = 0; i < 3; i++)
                    array_chars[i] = '0';
                Regex regex = new Regex(@"\w");
                byte count1 = 0;

                foreach (Match ch in regex.Matches(TypeKeyFirst))
                {
                    array_chars[count1] = Char.Parse(ch.ToString());

                    if (count1 != 3) count1++;
                    else count1 = 0;
                }
            }

            Tv_Shows[1].ShowTheme();
            for (int i = 0; i < MaxStrinTable; i++)
            {
                if (Tv_Shows[i].NameArtist != null)// что бы не показывалась таблица без значений
                    for (int j = 0; j < 3; j++)
                        if (Tv_Shows[i].Type == array_chars[j])
                            Tv_Shows[i].ShowThis();

            }
            Tv_Shows[1].ShowStatement();
        }


        static void check_log()//лог
        {

            for (int i = 0; i < MaxBuildConst; i++)
                if (Builds[i].Telepered != null)
                    Builds[i].showlog();

            TimeS.showtime();
            build_log();


        }
        static void build_log(string txet, ForLogAction act, DateTime dt)
        {
            if (COUNT == MaxBuildConst) COUNT = 0;
            Builds[COUNT++].addlog(txet, act, dt);
            TimeS.timebigtest(DateTime.Now);
        }
        static void build_log()
        {
            TimeS.timebigtest(DateTime.Now);
        }
    }
}
