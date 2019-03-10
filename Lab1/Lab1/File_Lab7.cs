using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    class Sort
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
         
        protected int arrayLength;
        protected int[] array;

        public Sort(int arrayLength)
        {
            this.arrayLength = arrayLength;
        }

        public int Compare { get; protected set; }
        public int Transposition { get; protected set; }

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

        }
        void FillDecrement()
        {

        }
        void FillRandom()
        {
            Random Rand = new Random();
            array = new int[arrayLength];
            for(int i = 0;i<arrayLength;i++)
            {
                array[i] = Rand.Next(0, 100);
            }
            
        }
        public void arrayShow()
        {
            foreach(int k in array)
            {
                Console.WriteLine(k);
            }
        }
        void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
        int[] SelectionSort(int[] a, int l, int r)
        {
            for (int i = l; i < r; i++)
            {
                int min = i;
                for (int j = i + 1; j <= r; j++)
                    if (a[j] < a[min])
                        min = j;

                Swap(ref a[i], ref a[min]);
            }
            return a;
        }
        int[] InsertionSort(int[] a, int l, int r)
        {
            for (int i = l + 1; i <= r; i++)
                for (int j = i; j > l; j--)
                    if (a[j - 1] > a[j])
                        Swap(ref a[j - 1], ref a[j]);
            return a;
        }
        int[] BubbleSort(int[] a, int l, int r)
        {
            for (int i = l; i < r; i++)
                for (int j = r; j > i; j--)
                    if (a[j - 1] > a[j])
                        Swap(ref a[j - 1], ref a[j]);
            return a;
        }
        int[] ShakerSort(int[] a, int l, int r)
        {
            do
            {
                //Сдвигаем к концу массива "тяжелые элементы"
                for (int i = l; i < r; i++)
                {
                    if (a[i] > a[i + 1])
                    {
                        Swap(ref a[i], ref a[i + 1]);
                    }
                }

                r--;

                //Сдвигаем к началу массива "легкие элементы"
                for (int i = r; i > l; i--)
                {
                    if (a[i] < a[i - 1])
                    {
                        Swap(ref a[i], ref a[i - 1]);
                    }
                }

                l++;
            }
            while (l <= r);
            return a;
        }
        int[] ShellSort(int[] a, int l, int r)
        {
            int[] H = { 57, 23, 10, 4, 1 };
            int HN = H.Length;

            foreach (int step in H)
            {
                for (int i = l + step; i <= r; i++)
                {
                    int j = i;
                    int tmp = a[i];

                    while (j >= l + step && tmp < a[j - step])
                    {
                        a[j] = a[j - step];
                        j -= step;
                    }
                    a[j] = tmp;
                }
            }
            return a;

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
            int arrayLength = 10;
            Sort SortLab = new Sort(arrayLength);
            SortLab.Fill(FillType.RANDOM);
            SortLab.arrayShow();
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
