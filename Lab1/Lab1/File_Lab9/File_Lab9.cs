using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;

using Labs.AddForm;
using Labs.Interfaces;

namespace Labs
{
    class FileLabLibrary9
    {

    }

    /// <summary>
    /// 1 задание сторона list
    /// </summary>
    class TrashContent : File_lab6, IMenu, IMenuLog
    {
        public static GetTvshow ADD = new GetTvshow();
        public static GetTvshow UP = new GetTvshow();
        List<GetTvshow> tvshows;
        List<LogActions> logActions;
        
        public Thread myThread;
        ulong iii = 0;
        private int K;
        /// <summary>
        /// Потом разобраться что я тут написал и лучше переписать, а то уже задница с чтением
        /// </summary>
        public void Ex1()
        {
            TimeS.timelast = DateTime.Now;
            FileInfo FileInfoForFile = new FileInfo(FILES_PATH_FOR_PLAYLIST);
            if (FileInfoForFile.Exists)
            {
                ReadAndSetTvShowsFilePlaylist();
                main();
                Console.WriteLine("Работа с таблицей закончилась, сохранить прогресс?\n\rВнимание, файл перезапишется и в нем будут все данные, которые есть в табличке!\r\n\r\n1(сохранить) 2(не сохранять) 3(таблица)");
                while (true)
                {
                    CountForLines = 1;
                    char Key = Console.ReadKey().KeyChar;
                    if (Key == '1')
                    {

                        Console.WriteLine("\r\nПрогресс сохранен");
                        GetFromTvShowsAndWriteFilePlaylist();
                        break;
                    }
                    else if (Key == '2')
                    {
                        Console.WriteLine("\r\nПрогресс не сохранен");
                        break;
                    }
                    else if (Key == '3')
                    {
                        Console.WriteLine("");
                        lab5_1.show();
                    }
                    else
                        Console.WriteLine("\r\nНеверная клавиша");
                    Console.WriteLine("\r\n1(сохранить) 2(не сохранять) 3(таблица)");
                }

            }
            else
            {
                Console.WriteLine("По пути {0} не найдено файла", FileInfoForFile.FullName);
                Console.WriteLine("Создать файл?\r\n");
                while (true)
                {
                    Console.WriteLine("\r\n1(Создать) 2(Не создавать) ");
                    CountForLines = 1;
                    char Key = Console.ReadKey().KeyChar;
                    if (Key == '1')
                    {

                        Console.WriteLine("\r\nФайл создан по пути");
                        FileInfoForFile.Create().Close();
                        Ex_1();

                        break;
                    }
                    else if (Key == '2')
                    {
                        Console.WriteLine("\r\nВыход");

                        break;

                    }

                    else
                        Console.WriteLine("\r\nНеверная клавиша");

                }

            }
        }

        //работает
        public void Main()
        {
            logActions = new List<LogActions>();
            TimeS.timelast = DateTime.Now;
            Initialize();
            while (true)
            {
                
                Console.WriteLine("\n1 – Просмотр таблицы\n2 – Добавить запись\n3 – Удалить запись\n4 – Обновить запись\n5 – Поиск записей\n6 – Просмотреть лог\n7 - Выход\n");
                char key = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (key)
                {
                    case '1': BuildLog(); Show(); break;
                    case '2': BuildLog(); Add(); break;
                    case '3': BuildLog(); Delete(); break;
                    case '4': BuildLog(); Update(); break;
                    case '5': BuildLog(); Search(); break;
                    case '6': BuildLog(); Log(); break;
                    case '7': return;
                }
                ResizeN();
            }
        }

        /// <summary>
        /// Я тут инициализирую мой лист из файла, это так, что бы не завтыкать
        /// </summary>
        public void Initialize()
        {
            tvshows = new List<GetTvshow>();
            ReadAndSetTvShowsFilePlaylist();//получаем список твшоу
            tvshows.AddRange(Tv_Shows);// устанавливаем его
            for(int i =0;i<tvshows.Count;i++)
            {
                if (tvshows[i].NameArtist == null)
                {
                    tvshows.RemoveAt(i);
                }

            }
            ResizeN();

        }

        /// <summary>
        /// Работает
        /// </summary>
        public void Show()
        {
            tvshows[0].ShowTheme();
            foreach (GetTvshow tv in tvshows)
                //if (tv.NameArtist != null && tv.NameTV != null)
                    tv.ShowThis();
            tvshows[0].ShowStatement();
        }

        public void Add()//работает
        {
            myThread =  new Thread(new ThreadStart(StartAdd));
            myThread.Name = iii++.ToString();
            myThread.Start();

        }
        public void Delete()// работает
        {
            Console.WriteLine("Введи порядковый номер записи из списка");
            try
            {
                int i = Int32.Parse(Console.ReadLine());
                if (i > 0 && i <= tvshows.Count)
                { 
                    tvshows[0].ShowTheme();
                    tvshows[i-1].ShowThis();
                    tvshows[0].ShowStatement();
                    Console.WriteLine("Это?\r\n 1 - (yes) any key - (no)");
                    if (Console.ReadKey().Key == ConsoleKey.D1)
                    {
                        BuildLog(tvshows[i-1].NameTV, ForLogAction.Delete, DateTime.Now);
                        tvshows.RemoveAt(i-1);
                        ResizeN();
                    }
                    else Console.WriteLine("Ну нет так нет");
                        
  
                }
                else
                    Console.WriteLine("элементов {0}",tvshows.Count);
            }
            catch(Exception e)
            {
                Console.WriteLine("Ошибка!\r\n{0}",e.Message);
            }
        }

        public void Update()//работает
        {
            
            Console.WriteLine("Введи порядковый номер записи из списка");
            try
            {
                int i = Int32.Parse(Console.ReadLine());
                if (i > 0 && i <= tvshows.Count)
                {
                    tvshows[0].ShowTheme();
                    tvshows[i - 1].ShowThis();
                    tvshows[0].ShowStatement();
                    Console.WriteLine("Это?\r\n 1 - (yes) any key - (no)");
                    if (Console.ReadKey().Key == ConsoleKey.D1)
                    {
                        K = i - 1;
                        myThread = new Thread(new ThreadStart(StartUp));
                        myThread.Name = iii++.ToString();
                        myThread.Start();
                        
                        ResizeN();

                        
                    }
                    else Console.WriteLine("Ну нет так нет");


                }
                else
                    Console.WriteLine("элементов {0}", tvshows.Count );
            }
            catch(Exception e)
            {
                Console.WriteLine("Ошибка!\r\n{0}", e.Message);
            }
        }

        public void Search()//работает
        {
            Console.WriteLine("Поиск по оценке от 1 до 5");
            ConsoleKey key = Console.ReadKey().Key;
            Console.WriteLine();
            if (key == ConsoleKey.D1 || key == ConsoleKey.D2 || key == ConsoleKey.D3 || key == ConsoleKey.D4 || key == ConsoleKey.D5)
            {
                int i = 5;
                if (key == ConsoleKey.D1) i = 1;
                else if (key == ConsoleKey.D2) i = 2;
                else if (key == ConsoleKey.D3) i = 3;
                else if (key == ConsoleKey.D4) i = 4;
                tvshows[0].ShowTheme();
                foreach (GetTvshow tv in tvshows)
                    if((int)tv.Value == i)
                        tv.ShowThis();
                tvshows[0].ShowStatement();
                    
            }
            else
            {
                Console.WriteLine("Неверное значение");
            }

        }

        public void StartAdd()//работает
        {
            Console.WriteLine("Поток {0} ожил", myThread.Name);
            Application.Run(new Form1());
            Console.WriteLine("Поток {0} умер", myThread.Name);
            ADD.n = tvshows.Count;
            if (ADD.NameArtist != null)
            {
                tvshows.Add(ADD);
                BuildLog(ADD.NameTV, ForLogAction.Add, DateTime.Now);
                Console.WriteLine("Шоу \"{0}\" уже в листе", ADD.NameTV);
                ResizeN();
            }
            else
                Console.WriteLine("По идее мы не добавим этот элемент");


        }

        public void StartUp()//работает
        {
            Console.WriteLine("Поток {0} ожил", myThread.Name);
            Application.Run(new Form1(tvshows[K]));
            Console.WriteLine("Поток {0} умер", myThread.Name);
            if (UP.NameArtist != null)
            {
                for(int i =0;i< tvshows.Count;i++)
                {
                    if (tvshows[i].n == UP.n)
                    {
                        tvshows[i] = UP;
                        Console.WriteLine("Шоу \"{0}\" уже изменен", UP.NameTV);
                        BuildLog(tvshows[i - 1].NameTV, ForLogAction.Update, DateTime.Now);
                        ResizeN();
                        
                        break;
                    }

                }
            }
            else
                Console.WriteLine("По идее мы не изменим этот элемент");
        }

        public void ResizeN()// работает
        {
            for (int i = 0; i < tvshows.Count; i++)
                tvshows[i] = new GetTvshow(tvshows[i].NameTV, tvshows[i].NameArtist, tvshows[i].Value, tvshows[i].Type,i+1);
        }

        /// <summary>
        /// Работает
        /// </summary>
        public void Log()//работает
        {
            if(logActions!=null)
                foreach (LogActions act in logActions)
                    if( act.Telepered !=null)
                        act.showlog();
            BuildLog();
            TimeS.showtime();
        }
        /// <summary>
        /// Вызвать, для особых действий
        /// </summary>
        /// <param name="txet"></param>
        /// <param name="act"></param>
        /// <param name="dt"></param>
        public void BuildLog(string txet, ForLogAction act, DateTime dt)//работает
        { 
            BuildLog();
            logActions.Add(new LogActions(txet, act, dt));
        }
        /// <summary>
        /// Вызывать, что бы отметку сделать по времени
        /// </summary>
        public void BuildLog()//работает
        {
            TimeS.timebigtest(DateTime.Now);
        }

    }

    class Lab9Manager
    {  
        public void Ex1F()
        {
            TrashContent trashContent = new TrashContent();
            trashContent.Main();
        }
    }


}



