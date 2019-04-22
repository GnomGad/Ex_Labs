using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Labs.File_Lab10.Sortings;
using Labs.Interfaces;

namespace Labs
{
    class FileLabLibrary7 
    {
       
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Tv">массив</param>
        /// <param name="l">0</param>
        /// <param name="r">количество элементом -1</param>
        public void InsertionSortForGetTvShow(ref GetTvshow[] Tv, int l, int r)
        {
            for (int i = l + 1; i <= r; i++)
                for (int j = i; j > l; j--)
                    if ((int)Tv[j - 1].Value > (int)Tv[j].Value)
                    {
                        // Swap((int)Tv[j - 1].Value, (int)Tv[j].Value, j);
                        //присвоение tmp элементы j-1
                        int tmpValue =(int) Tv[j - 1].Value;
                        string tmpNameTv = Tv[j - 1].NameTV;
                        string tmpNameArtist = Tv[j - 1].NameArtist;
                        char tmpType = Tv[j - 1].Type;
                        int tmpN = Tv[j - 1].n;

                        //присвоение j-1 элементы из j
                        Tv[j - 1].Value = Tv[j].Value;
                        Tv[j - 1].NameTV = Tv[j].NameTV;
                        Tv[j - 1].NameArtist = Tv[j].NameArtist;
                        Tv[j - 1].Type = Tv[j].Type;
                        Tv[j - 1].n = Tv[j].n;

                        //присвоение j из tmp
                        Tv[j].check_for_value(tmpValue.ToString(), out string er);
                        Tv[j].check_for_tyoe(tmpType, out string er1);
                        Tv[j].NameArtist = tmpNameArtist;
                        Tv[j].NameTV = tmpNameTv;
                        Tv[j].n = tmpN;
                    }
        }

        
    }
    public enum FillType
    {
        INCREMENT,
        DECREMENT,
        RANDOM,
    }
    public enum SortName
    {
        SELECTIONSORT,
        INSERTIONSORT,
        BUBBLESORT,
        SHAKERSORT,
        SHELLSORT,
        MERGESORT,
        QUICKSORT,
        HEAPSORT
    }

    public partial class Sort
    {
        /*
         * каждую функцию выполнить 3 раза
         * 1 - для 100 000 int элементов рандлмных
         * 2 - тот же массив для отсортированый в порядке возрастания
         * 3 - тот же массив в порядке убывания
         * Вывести секунды : миллисекунды
         * вывести количество сравнений и перестановок для каждого метода сортировки во всех 3х случаях
         * Результаты сортировки программно записать в sorted.dat 
         * написать код, который будет считывать sorted.dat и проверять на действительно ли сортированы данные
         */

        ConsoleManager ConsoleManager = new ConsoleManager();
        protected string PathFile = @"..\..\Files\sorted.dat";
        protected int arrayLength = 100000;
        protected int[] array;
        protected int RandMax = int.MaxValue;
        protected int RandMin = int.MinValue;
        public ulong Compare;
        public ulong Transposition;
        public DateTime Start;
        public DateTime End;
        public TimeSpan Interval;

        ISorts<int> MySorts;

        /* Конструкторы класса, инициализация массива
         */
        public Sort(int arrayLength)
        {
            this.arrayLength = arrayLength;
            arrayInitialization();
        }
        public Sort()
        {
            //array = new int[arrayLength];
            arrayInitialization();
        }
        protected void arrayInitialization()
        {
            array = new int[arrayLength];
        }


        /*Блок для заполнения массивa
         * 
         */
        public void Fill(FillType type)
        {
            switch(type)
            {
                case FillType.DECREMENT:
                    FillDecrement();
                    break;
                case FillType.INCREMENT:
                    FillIncrement();
                    break;
                case FillType.RANDOM:
                    FillRandom();
                    break;
                default:
                    break;
            }
        }
        void FillIncrement()
        {
            if (array.Length > 1 && (array[0]>array[arrayLength-1])) // то есть, если сейчас уменьшение идет, декримент, тогда реверсним
            {
                ConsoleManager.BlueSendToConSole("Сработало условие 654321");
                arrayReverse();
                
            }  

        }
        void FillDecrement()
        {
            if (array.Length > 1 && (array[0] < array[arrayLength-1]))// если сейчас инкремент то версаем
            {
                ConsoleManager.BlueSendToConSole("Сработало условие 123456");
                arrayReverse();
                
            }
        }
        void arrayReverse()
        {
            int[] tmparray = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                tmparray[i] = array[i];
            }
            for (int i = 0; i < arrayLength; i++)
            {

                array[i] = tmparray[arrayLength - 1 - i];
            }
        }
        void FillRandom()
        {
            Random Rand = new Random();
            
            for(int i = 0;i<arrayLength;i++)
            {
                array[i] = Rand.Next(RandMin, RandMax);
            }
            
        }
        public void SetRandMax(int RandMax)
        {
            this.RandMax = RandMax;
        }
        public void SetRandMin(int RandMin)
        {
            this.RandMin = RandMin;
        }


        /*Блок для работы со всем остальным
        */
        public void arrayShow()
        {
            foreach(int k in array)
            {
                Console.WriteLine(k);
            }
        }
        public void ChoiceSort(SortName sort)
        {
            switch (sort)
            {
                case SortName.SELECTIONSORT:
                    ConsoleManager.GreenSendToConSole("Сортировка Выбором");
                    SetNullForCompareAndTransposition();
                    SetStart();
                    SelectionSort(0, arrayLength - 1);
                    SetEnd();
                    SetInterval();
                    break;
                case SortName.INSERTIONSORT:
                    ConsoleManager.GreenSendToConSole("Сортировка Вставками");
                    SetNullForCompareAndTransposition();
                    SetStart();
                    InsertionSort(0, arrayLength-1);
                    SetEnd();
                    SetInterval();
                    break;
                case SortName.BUBBLESORT:
                    ConsoleManager.GreenSendToConSole("Сортировка Пузырьком");
                    SetNullForCompareAndTransposition();
                    SetStart();
                    BubbleSort(0, arrayLength - 1);
                    SetEnd();
                    SetInterval();
                    break;
                case SortName.SHAKERSORT:
                    ConsoleManager.GreenSendToConSole("Сортировка Шейкерная");
                    SetNullForCompareAndTransposition();
                    SetStart();
                    ShakerSort(0, arrayLength - 1);
                    SetEnd();
                    SetInterval();
                    break;
                case SortName.SHELLSORT:
                    ConsoleManager.GreenSendToConSole("Сортировка Шелла");
                    SetNullForCompareAndTransposition();
                    SetStart();
                    ShellSort(0, arrayLength - 1);
                    SetEnd();
                    SetInterval();
                    break;
                case SortName.MERGESORT:
                    MySorts = new MergeSort(array);
                    ConsoleManager.GreenSendToConSole("Сортировка Слиянием");
                    SetNullForCompareAndTransposition();
                    SetStart();
                    MySorts.Sort(0, arrayLength - 1);
                    SetEnd();
                    SetInterval();
                    array = MySorts.a;
                    break;
                case SortName.QUICKSORT:
                    MySorts = new QuickSort(array);
                    ConsoleManager.GreenSendToConSole("Быстрая сортировка");
                    SetNullForCompareAndTransposition();
                    SetStart();
                    MySorts.Sort(0, arrayLength - 1);
                    SetEnd();
                    SetInterval();
                    array = MySorts.a;
                    break;
                case SortName.HEAPSORT:
                    MySorts = new HeapSorter(array);
                    ConsoleManager.GreenSendToConSole("Сортировка Кучей");
                    SetNullForCompareAndTransposition();
                    SetStart();
                    MySorts.Sort(0, arrayLength - 1);
                    SetEnd();
                    SetInterval();
                    array = MySorts.a;
                    break;
                default:
                    break;
            }
        }
        public void SetStart() => Start = DateTime.Now;
        public void SetEnd() => End = DateTime.Now;
        public void SetInterval() => Interval = End - Start;
        public void WriteInConsoleInfo() => Console.WriteLine("Сортировка выполнилась за {0}:{1}\r\nперестановок {3} сравнений {4} \r\n{2}", Interval.Seconds, Interval.Milliseconds, Interval, Transposition, Compare);
        public void TranspositionIncrement() => Transposition++;
        public void CompareIncrement() => Compare++;
        public void SetNullForCompareAndTransposition() => Compare = Transposition = 0;

        /*Блок алгоритмов сортировки
         */
        void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
            TranspositionIncrement();
        }
        public void SelectionSort(int l, int r)
        {
            for (int i = l; i < r; i++)
            {
                int min = i;
                for (int j = i + 1; j <= r; j++,CompareIncrement())
                if (array[j] > array[min])
                    min = j;

                Swap(ref array[i], ref array[min]);
            }
           
        }
        public void InsertionSort(int l, int r)
        {

            for (int i = l + 1; i <= r; i++)
                for (int j = i; j > l; j--, CompareIncrement())
                    if (array[j - 1] < array[j])
                    { 
                        Swap(ref array[j - 1], ref array[j]);
                    }
            
            
        }
        public void BubbleSort(int l, int r)
        {
            for (int i = l; i < r; i++)
                for (int j = r; j > i; j--,CompareIncrement())
                    if (array[j - 1] < array[j])
                        Swap(ref array[j - 1], ref array[j]);
            
        }
        public void ShakerSort( int l, int r)
        {
            do
            {
                //Сдвигаем к концу массива "лёгкие элементы"
                for (int i = l; i < r; i++, CompareIncrement())
                {
                    if (array[i] < array[i + 1])
                    {
                        Swap(ref array[i], ref array[i + 1]);
                    }
                }

                r--;

                //Сдвигаем к началу массива "тяжелые элементы"
                for (int i = r; i > l; i--, CompareIncrement())
                {
                    if (array[i] > array[i - 1])
                    {
                        Swap(ref array[i], ref array[i - 1]);
                    }
                }

                l++;
            }
            while (l <= r);
            
        }
        public void ShellSort( int l, int r)
        {
            int[] H = { 57, 23, 10, 4, 1 };
            int HN = H.Length;

            foreach (int step in H)
            {
                for (int i = l + step; i <= r; i++)
                {
                    int j = i;
                    int tmp = array[i];

                    while (j >= l + step && tmp > array[j - step])
                    {
                        CompareIncrement();
                           array[j] = array[j - step];
                        j -= step;
                    }
                    array[j] = tmp;
                }
            }
           

        }
        
        /* Блок записи и чтения sorted.dat
         * первый байт под тип сортировки, все остальное в инты под значения
         */
        public void WriteFile(byte type)
        {
            BinaryWriter BiWrite = null;
            try
            {
                BiWrite = new BinaryWriter(File.Open(PathFile, FileMode.Create));
                BiWrite.Write(type);
                foreach(int tmp in array)
                {
                    BiWrite.Write(tmp);
                }

                ConsoleManager.GreenSendToConSole("Файл записан");
            }
            catch(Exception e)
            {
                ConsoleManager.RedSendToConsole(e.Message);
            }
            finally
            {
                BiWrite.Close();
            }
        }
        public void ReadFile()
        {
           
            int[] arraytmp = new int[arrayLength];
            BinaryReader BiRead = null;
            try
            {
                
                BiRead = new BinaryReader(File.Open(PathFile, FileMode.Open));
                SortName tmpSortName = (SortName) BiRead.ReadByte();
                ConsoleManager.SpecifiedColorSendToConsole(tmpSortName.ToString(), ConsoleColor.Yellow);
                
                for(int i =0;i<arrayLength;i++)
                {
                    arraytmp[i] = BiRead.ReadInt32();
                }
                if (TestSort(arraytmp)) ConsoleManager.GreenSendToConSole("Массив отсортирован правильно");
                else ConsoleManager.RedSendToConsole("Массив отсортирован не правильно");

            }
            catch (Exception e)
            {
                ConsoleManager.RedSendToConsole(e.Message);
            }
            finally
            {
                BiRead.Close();
            }

        }
        public bool TestSort(int[] arraytmp)
        {
            for (int i = 1; i < arrayLength; i++)
                if (arraytmp[i - 1] < arraytmp[i])
                    return false;

            return true;
        }

    }
    class Lab7Manager
    {
        public void Ex1()
        {
            FileLabLibrary7 FileLab = new FileLabLibrary7();
            TrashForEx1.Begin();
        }    
        public void Ex2()
        {
            int arrayLength = 100000;
            int Max = int.MaxValue;
            int Min = int.MinValue;
            char key = 'h';
            while(key!='0')
            {
                Console.WriteLine("1 - Сортировка вставками\r\n2 - Сортировка выбором\r\n3 - Сортировка Пузырьком\r\n4 - Сортировка Шейкером\r\n5 - Сортировка Шелла\r\n0-выход");
                key = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (key)
                {
                    case '0':
                        break;
                    case '1':
                        ManagerSort(arrayLength, Max, Min,SortName.INSERTIONSORT);
                        break;
                    case '2':
                        ManagerSort(arrayLength, Max, Min, SortName.SELECTIONSORT);
                        break;
                    case '3':
                        ManagerSort(arrayLength, Max, Min, SortName.BUBBLESORT);
                        break;
                    case '4':
                        ManagerSort(arrayLength, Max, Min, SortName.SHAKERSORT);
                        break;
                    case '5':
                        ManagerSort(arrayLength, Max, Min, SortName.SHELLSORT);
                        break;
                    default:
                        Console.WriteLine("СПЕЦ РЕЖИМ ДЛЯ 10 ЛАБЫ\r\n 1 - Сортировка слиянием 2 - Сортировка Быстрая, 3 - Сортировка Кучей ");
                        switch (Console.ReadKey().KeyChar)
                        {
                            case '1':
                                ManagerSort(arrayLength, Max, Min, SortName.MERGESORT);
                                break;
                            case '2':
                                ManagerSort(arrayLength, Max, Min, SortName.QUICKSORT);
                                break;
                            case '3':
                                ManagerSort(arrayLength, Max, Min, SortName.HEAPSORT);
                                break;
                            default:
                                break;
                        }
                        break;
                }
            }
        }
        public void ManagerSort(int len,int max,int min,SortName sort)
        {
            Sort Lab = new Sort(len);
            Lab.SetRandMax(max);
            Lab.SetRandMin(min);

            Console.WriteLine("Зарандомил");
            Lab.Fill(FillType.RANDOM);

            Console.WriteLine("Сортонул");
            Lab.ChoiceSort(sort);
            Lab.WriteInConsoleInfo();

            Console.WriteLine("Инкрементнул");
            Lab.Fill(FillType.INCREMENT);
            Lab.ChoiceSort(sort);
            Lab.WriteInConsoleInfo();

            Console.WriteLine("Декрементнул");
            Lab.Fill(FillType.DECREMENT);
            Lab.ChoiceSort(sort);
            Lab.WriteInConsoleInfo();

            Lab.WriteFile((byte)sort);
            Lab.ReadFile();
        }

    }

    class TrashForEx1 : File_lab6
    {
       static public void Begin()
        {
            File_lab6.ReadAndSetTvShowsFilePlaylist();// инициализация TV_Shows[]
            int i = 0;
            for (i = 0; i < MaxStrinTable && Tv_Shows[i].NameTV != null; i++);// узнаем сколько не пустых элементов
            FileLabLibrary7 fl7 = new FileLabLibrary7();
            fl7.InsertionSortForGetTvShow(ref Tv_Shows, 0, i-1);
            File_lab6.main();

        }
    }

    
}
