using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Labs
{

    class FileLabLibrary8 : Search
    {
        //0.5
        public void SearchManager(int element)
        {
            char key = 'h';
            while(key!='0')
            {
                Console.WriteLine("1 - Линейный поиск\r\n2 - Бинарный поиск\r\n3 - Интерполяционный поиск\r\n0-выход");
                key = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (key)
                {
                    case '0':
                        break;
                    case '1':
                        СhoiceSearch(SearchType.LINEAR, element);
                        break;
                    case '2':
                        СhoiceSearch(SearchType.BINARY, element);
                        break;
                    case '3':
                        СhoiceSearch(SearchType.INTERPOLATION, element);
                        break;
                    default:
                        Console.WriteLine("Неверный симмвол");
                        break;
                }
            }


        }
        public void SearchManager(SearchString text)
        {
            char key = 'h';
            while (key != '0')
            {
                Console.WriteLine("1 - простой поиск\r\n2 - КМП поиск\r\n3 - БМ поиск\r\n0-выход");
                key = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (key)
                {
                    case '0':
                        break;
                    case '1':
                        СhoiceSearch(SearchType.SIMPLE, text);
                        break;
                    case '2':
                        СhoiceSearch(SearchType.KMP, text);
                        break;
                    case '3':
                        СhoiceSearch(SearchType.BM, text);
                        break;
                    default:
                        Console.WriteLine("Неверный симмвол");
                        break;
                }
            }


        }
        public void СhoiceSearch(SearchType Search,int element)
        {
            switch(Search)
            {
                case SearchType.LINEAR:
                    Console.WriteLine("Линейка");
                    SetStart();
                    LinearSearch(arrayint, element);
                    SetEnd();
                    SetInterval();
                    WriteInConsoleInfo();
                    break;
                case SearchType.BINARY:
                    Console.WriteLine("Бинарка");
                    SetStart();
                    BinarySearch(arrayint, element);
                    SetEnd();
                    SetInterval();
                    WriteInConsoleInfo();
                    break;
                case SearchType.INTERPOLATION:
                    Console.WriteLine("Интерполяционный");
                    SetStart();
                    InterpolationSearch(arrayint, element);
                    SetEnd();
                    SetInterval();
                    WriteInConsoleInfo();
                    break;
                default:
                    break;
            }
        }
        public void СhoiceSearch(SearchType Search, SearchString text)
        {
            switch (Search)
            {
                case SearchType.SIMPLE:
                    Console.WriteLine("простой");
                    SetStart();
                    SimpleSearch(text);
                    SetEnd();
                    SetInterval();
                    WriteInConsoleInfo();
                    break;
                case SearchType.KMP:
                    Console.WriteLine("КМП");
                    SetStart();
                    KMPSearch(text);
                    SetEnd();
                    SetInterval();
                    WriteInConsoleInfo();
                    break;
                case SearchType.BM:
                    Console.WriteLine("БМ");
                    SetStart();
                    BMSearch(text);
                    SetEnd();
                    SetInterval();
                    WriteInConsoleInfo();
                    break;
                default:
                    break;
            }
        }

    }
    class Search : ISearch , IArray, IReadFile, ITime, ISearchString
    {
        protected ConsoleManager consoleManager = new ConsoleManager();

        protected long position;
        protected int[] arrayint = { };
        protected string pathFile = @"..\..\Files\sorted.dat";
        protected DateTime start;
        protected DateTime end;
        protected TimeSpan interval;
        protected SearchString searchText;

        public int[] ArrayInt
        {
            get
            {
                
                if(arrayint.Length ==0)
                    consoleManager.RedSendToConsole("Длина массива равна 0");
                return arrayint;
            }
            set
            {
                if (value.Length > 0)
                    arrayint = value;
                else consoleManager.RedSendToConsole("Длина массива равна 0");
            }
        }
        public long Position
        {
            get
            {
                return position;
            }
        }
        public string PathFile
        {
            get
            {
                return pathFile;
            }
            
        }
        public DateTime Start { get { return start; } }
        public DateTime End { get {return end; } }
        public TimeSpan Interval { get { return interval; } }
        public SearchString SearchString { get { return searchText; } }

        public void SetStart() => start = DateTime.Now;
        public void SetEnd() => end = DateTime.Now;
        public void SetInterval() => interval = End - Start;
        public void WriteInConsoleInfo()
        {
            string tmpPosition = (position != -1 ? position.ToString() : "Не найдено");
            Console.WriteLine("Позиция элемента {0}, выполнено за {1}:{2}\r\n{3} ", tmpPosition, Interval.Seconds, Interval.Milliseconds,Interval);
        }

        public void LinearSearch(int[] array,int element)
        {
            position = -1;
            for (int i =0;i<array.Length;i++)
            {
                if (array[i] == element)
                {
                    position = i;
                    break;
                }
            }
            
        }
        public void BinarySearch(int[] array,int element)
        {
            position = -1;

            int right = array.Length;
            int left = 0;
            while (Math.Abs(right-left)!=1)
            {
                int mid = (right+left)/2;
                
                if (array[mid] == element)
                {
                    position = mid;
                    break;
                }
                if (array[mid] < element)
                    right = mid;
                else
                    left = mid;
            }
        }
        /// <summary>
        /// пойдет
        /// </summary>
        /// <param name="array"></param>
        /// <param name="element"></param>
        public void InterpolationSearch(int[] array, int element)
        {
            position = -1;
            long right = ArrayInt.Length - 1;
            long left = 0;
            {
                while (right >= left)
                {
                    long mid = left + (((element - array[left]) * (right - left)) / (array[right] - array[left]));

                    if (array[mid] < element)
                        left = mid + 1;
                    else if (array[mid] > element)
                        right = mid - 1;
                    else
                    {
                        position = (int)mid;
                        break;
                    }

                }
            }
        }

        public void ReadBinaryFile()
        {
            
            BinaryReader BiRead = null;
            if (File.Exists(pathFile))
            {
                try
                {
                    BiRead = new BinaryReader(File.Open(pathFile, FileMode.Open));
                    long tmpLength = ((BiRead.BaseStream.Length - 1) / 4);
                    int[] tmpArray = new int[tmpLength];
                    SortName tmpSortName = (SortName)BiRead.ReadByte();
                    consoleManager.SpecifiedColorSendToConsole(tmpSortName.ToString(), ConsoleColor.Yellow);
                    for(int i =0;i< tmpLength;i++)
                    {
                        tmpArray[i] = BiRead.ReadInt32();
                    }
                    InitializationArray(tmpArray);
                }
                catch (Exception e)
                {
                    consoleManager.RedSendToConsole(e.Message);
                }
                finally
                {
                    BiRead.Close();
                }
            }
            else
                consoleManager.RedSendToConsole("Файла по пути "+pathFile+" нет");
        }
        public void InitializationArray(int[] array)
        {
            ArrayInt = array;
            consoleManager.GreenSendToConSole("Массив был инициализирован");
        }

        public void InitializationSearchString(SearchString Str)
        {
            searchText.Text = Str.Text;
            searchText.SubText = Str.SubText;
        }

        public void SimpleSearch(SearchString str)
        {
            position = -1;
            long itoe = 0;
            for(int i = 0;i<str.Text.Length;i++)
            {
                if(str.Text[i] == str.SubText[0])
                {
                    for(int K = 0;K<str.SubText.Length && str.SubText[K]==str.Text[K+i];K++)
                    {
                        itoe++;

                    }
                    if(itoe == str.SubText.Length)
                    {
                        position = i;
                        return;
                    }
                    itoe = 0;
                }
            }
        }
        public void KMPSearch(SearchString str)
        {
            position = -1;
            string pattern = str.SubText;
            string text = str.Text;
            int n = text.Length;
            int m = pattern.Length;

            int[] prefix = computePrefixFunction(pattern);

            int j = 0;

            for (int i = 1; i <= n; i++)
            {
                while (j > 0 && pattern[j] != text[i - 1])
                {
                    j = prefix[j - 1];
                }
                if (pattern[j] == text[i - 1])
                {
                    j++;
                }
                if (j == m)
                {
                    position = i - m;
                    return;// Найдено в позиции i - m 
                }
            }
            position = -1;		 // Не найдено

        }
        public void BMSearch(SearchString str)
        {

        }
        int[] computePrefixFunction(string s)
        {
            int m = s.Length;

            int[] pi = new int[m];
            int j = 0;
            pi[0] = 0;

            for (int i = 1; i < m; i++)
            {
                while (j > 0 && s[j] != s[i])
                {
                    j = pi[j];
                }
                if (s[j] == s[i])
                {
                    j++;
                }
                pi[i] = j;
            }
            return pi;

        }

    }
    struct SearchString
    {
        public string Text;
        public string SubText;
    }
    enum SearchType
    {
        LINEAR,
        BINARY,
        INTERPOLATION,
        KMP,
        BM,
        SIMPLE
    }
}
