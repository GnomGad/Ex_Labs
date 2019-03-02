using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Labs
{
    class File_lab6 :lab5_1
    {
        //
        // UTF8Encoding используется как текущая
        //\n = 10 ; \r = 13 ; int(9) табуляция или магия которую мне сделал нотпад
        //


        const string FILES_FULL_PATH = @"D:\Application\Git\Ex_Labs\Lab1\Lab1\Files";
        //фулл путь к файлам
        const string FILES_PATH = @"..\..\Files"; 
        // работает прям из Lab1 
        const string PLAYLIST_DAT = @"\Lab.dat"; 
        // имя файла 
        const string FILES_PATH_FOR_PLAYLIST = FILES_PATH + PLAYLIST_DAT; 
        // путь к файлу playlist.dat
        const byte MAX_STRING_TABLE = lab5_1.MaxStrinTable; 
        // константа макс числа строк таблицы
        const byte MAX_BUILD_CONST= lab5_1.MaxBuildConst;
        // МАКСИМАЛЬНОЕ количесво числа логов
        private static int CountForLines = 1;

        static GetTvshow TvShows = new GetTvshow();


        

        public static void Ex_1()
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


        
        private static void ReadAndSetTvShowsFilePlaylist()
        {
            
            StreamReader ReadPlayList = new StreamReader(FILES_PATH_FOR_PLAYLIST);
            string[] ArrayStringPlaList = new string[MAX_STRING_TABLE];
            
            
            while (!ReadPlayList.EndOfStream)
            {
                string tmp = ReadPlayList.ReadLine();
                // проверка на пустую строку и комментарий
                if (tmp.Length == 0)
                    continue;
                else if (tmp[0] == 47 && tmp[1] == 47)
                    continue;

                try
                {
                    string[] ReturnArrayForTests = ReturValueForTvShows(tmp);
                        SetTvShows(ReturnArrayForTests);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("строка номер {0} проигнорирована", CountForLines);
                    Console.WriteLine(tmp);
                }
                
                catch (Exception e) 
                {
                    // стартер пак
                    Console.WriteLine(e.Data);
                    Console.WriteLine(e.HelpLink);
                    Console.WriteLine(e.InnerException);
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.Source);
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine(e.TargetSite);
                    Console.WriteLine(e.GetBaseException());
                    Console.WriteLine(e.GetHashCode());
                    Console.WriteLine(e.GetType());
                }
                CountForLines++;

            }
            ReadPlayList.Close();
            
   
        }


        private static string[] ReturValueForTvShows(string str)// возврат 4 элементов массива
        {
            char[] chars = { ' ', Convert.ToChar(9) };
            string[] ArrayValue = str.Split('\\');
            byte count = 0;
            foreach (string StrFromArray in ArrayValue)
                ArrayValue[count++] = StrFromArray.TrimStart(chars).TrimEnd(chars);

           
            if (ArrayValue.Length == 4)
            {
                try
                {
                    string err = ArrayValue[2].ToString(), err2 = "";
                    char err1 = Char.Parse(ArrayValue[3]);

                    TvShows.check_for_value_non_set_value(err, out err);
                    TvShows.check_for_tyoe_non_set_type(err1, out err2);

                    if (err == "error")
                    {
                        Console.WriteLine("Ошибка: В строке {0} неверная оценка {1}", CountForLines, ArrayValue[2]);
                        return null;
                    }
                    else if (err2 == "error")
                    {
                        Console.WriteLine("Ошибка: В строке {0} неверный тип ток шоу {1}", CountForLines, ArrayValue[3]);
                        return null;
                    }
                    else
                        return ArrayValue;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Ошибка: строка номер {0} проигнорирована ", CountForLines);
                    return null;
                }

            }
            else
                return null; // система сляжет)
            

        }


        private static void SetTvShows(string[] array) // заполнение в tvshows
        {
            for (int i = 0; i < MAX_STRING_TABLE; i++)
            {

                if (Tv_Shows[i].NameArtist == null)
                {
                    string er1 = null;
                    string er2 = null;
                    Tv_Shows[i].NameTV = array[0];
                    Tv_Shows[i].NameArtist = array[1];
                    Tv_Shows[i].check_for_value(array[2], out er1);
                    Tv_Shows[i].check_for_tyoe(Char.Parse(array[3]), out er2);
                    Tv_Shows[i].n = i + 1;
                    i = MAX_STRING_TABLE;
                }
            } 
        }
       
        

        private static void GetFromTvShowsAndWriteFilePlaylist()
        {
            StreamWriter WritePlatList = new StreamWriter(FILES_PATH_FOR_PLAYLIST);
            for (int i = 0; i < MAX_STRING_TABLE; i++)
            {
                if (Tv_Shows[i].NameArtist != null)
                {
                    WritePlatList.WriteLine(Tv_Shows[i].NameTV+" \\ "+ Tv_Shows[i].NameArtist+" \\ "+ (int)(Tv_Shows[i].Value)+" \\ "+ Tv_Shows[i].Type);
                    Tv_Shows[i].NameArtist = null;
                    Tv_Shows[i].NameTV = null;
                    WritePlatList.Flush();

                }
            }
            
            WritePlatList.Close();
        }

       
    }
}
