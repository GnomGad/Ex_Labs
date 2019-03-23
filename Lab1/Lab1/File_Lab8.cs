using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Labs
{

    class FileLabLibrary8 : Search
    {
        
        public void SearchManager(int element)
        {
            Console.WriteLine("Linear");
            SetStart();
            LinearSearch(arrayint, element);
            SetEnd();
            SetInterval();
            WriteInConsoleInfo();
            Console.WriteLine("InterpolationSearch");
            SetStart();
            InterpolationSearch(arrayint, element);
            SetEnd();
            SetInterval();
            WriteInConsoleInfo();

        }

    }
    class Search : ISearch , IArray, IReadFile, ITime
    {
        protected ConsoleManager consoleManager = new ConsoleManager();

        protected int position;
        protected int[] arrayint = { };
        protected string pathFile = @"..\..\Files\sorted.dat";
        protected DateTime start;
        protected DateTime end;
        protected TimeSpan interval;

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
        public int Position
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
        /// ЧИНИ 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="element"></param>
        public void InterpolationSearch(int[] array, int element)
        {
            position = -1;
            long right = ArrayInt.Length-1;
            long left = 0;
            {
                while (right >= left)
                {
                    long mid = left + (((element-array[left])*(right-left))/(array[right]-array[left]));

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

    }
}
