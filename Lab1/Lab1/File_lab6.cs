using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Labs
{
    class File_lab6 
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
        // имя файла playlist
        const string FILES_PATH_FOR_PLAYLIST = FILES_PATH + PLAYLIST_DAT; 
        // путь к файлу playlist.dat
        const byte MAX_STRING_TABLE = lab5_1.MaxStrinTable; 
        // константа макс числа строк таблицы
        const byte MAX_BUILD_CONST= lab5_1.MaxBuildConst;
        // МАКСИМАЛЬНОЕ количесво числа логов


        static LogActions[] BuildLogs = new LogActions[MAX_BUILD_CONST];
        // массив логов
        static GetTvshow[] TvShows = new GetTvshow[MAX_STRING_TABLE];
        // массив тв шоу
        static BigSpan LongPeriodOfSpan = new BigSpan();
        // самый долгий период
        static DateTime TimeIsNow = DateTime.Now;
        // время в сей момент   






        public static void Ex_1()
        {
            
            ReadFilePlaylist();
            //WriteFilePlaylist();
            

            Console.ReadKey();

        }





        
        private static void ReadFilePlaylist()
        {
            StreamReader ReadPlayList = new StreamReader(FILES_PATH_FOR_PLAYLIST);


            string[] ArrayStringPlaList = new string[MAX_STRING_TABLE];
            
            // проверка на пустую строку и комментарий
            while (!ReadPlayList.EndOfStream)
            { 
                string tmp = ReadPlayList.ReadLine();

                if (tmp.Length == 0)
                    continue;
                else if (tmp[0] == 47 && tmp[1] == 47)
                    continue;
                string[] ReturnArrayForTests = ReturValueForTvShows(tmp);
                if (ReturnArrayForTests != null) // проверка на числовой элемент -1 если его нет
                foreach(string s in ReturnArrayForTests) // тестовый стенд
                {
                        Console.Write(s+" ");
                }
                Console.WriteLine();
            }

           


            ReadPlayList.Close();
            Console.WriteLine();
        }



        
        private static string[] ReturValueForTvShows(string str)// возврат 4 элементов массива
        {
            char[] chars = { ' ', Convert.ToChar(9) };
            string[] ArrayValue = str.Split('\\');
            byte count = 0;
            foreach (string StrFromArray in ArrayValue)
                ArrayValue[count++] = StrFromArray.TrimStart(chars).TrimEnd(chars);

            
            if (ArrayValue.Length == 4)  
                return ArrayValue;
            else
                return null; // система сляжет)
            

        }



       


        private static void WriteFilePlaylist()
        {
            StreamWriter WritePlatList = new StreamWriter(FILES_PATH_FOR_PLAYLIST);
            
            WritePlatList.Close();
        }
    }
}
