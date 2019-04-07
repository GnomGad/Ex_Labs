using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;



namespace Labs
{
    class FileLabLibrary9
    {

    }
    /// <summary>
    /// много писанины, прям ппц(
    /// </summary>
    class TrashContent : File_lab6
    {
        List<GetTvshow> tvshows;

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

        /// <summary>
        /// Обязательно к применению
        /// Инициализируем лист, получим данные из файла и запусним их в наш лист
        /// </summary>
        public void InittList()
        {
            tvshows = new List<GetTvshow>();
            ReadAndSetTvShowsFilePlaylist();//получаем список твшоу
            tvshows.AddRange(Tv_Shows);// устанавливаем его

        }

        

    }

    class Lab9Manager
    {
        
        public void Ex1F()
        {
            TrashContent trashContent = new TrashContent();
            trashContent.InittList();
        }
    }
}



