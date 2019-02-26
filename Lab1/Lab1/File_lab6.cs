using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Labs
{
    class File_lab6 : lab5_1
    {
        //
        // UTF8Encoding используется как текущая
        //\n = 10 ; \r = 13
        //


        const string FILES_FULL_PATH = @"D:\Application\Git\Ex_Labs\Lab1\Lab1\Files";
        //фулл путь к файлам
        const string FILES_PATH = @"..\..\Files"; 
        // работает прям из Lab1 
        const string PLAYLIST_DAT = @"\Lab.dat"; 
        // имя файла playlist
        const string FILES_PATH_FOR_PLAYLIST = FILES_PATH + PLAYLIST_DAT; 
        // путь к файлу playlist.dat
        const byte MAX_STRING_TABLE = MaxStrinTable; 
        // константа макс числа строк таблицы
        const byte MAX_BUILD_CONST= MaxBuildConst;
        // МАКСИМАЛЬНОЕ количесво числа логов


        static LogActions[] BuildLogs = new LogActions[MaxBuildConst];
        // массив логов
        static GetTvshow[] TvShows = new GetTvshow[MaxStrinTable];
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
            
            while(!ReadPlayList.EndOfStream)
            {
                Console.WriteLine(ReadPlayList.ReadLine());
            }
            ReadPlayList.Close();
            
            Console.WriteLine();
        }




        private static void WriteFilePlaylist()
        {
            StreamWriter WritePlatList = new StreamWriter(FILES_PATH_FOR_PLAYLIST);
            
            WritePlatList.Close();
        }
    }
}
