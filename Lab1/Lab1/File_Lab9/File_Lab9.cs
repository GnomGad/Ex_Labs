using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

using Labs.Game;
using Labs.Collections;
namespace Labs
{
    class FileLabLibrary9
    {
        // это вот 4 задание
        Dictionary<int, int> combine = new Dictionary<int, int>();
        public void SetCombine(int N)
        {
            for (int i = 1; i <= N; i++)
                combine[i] = 0;
        }
        public void Combinations(int N)
        {
            for( int x =1; Math.Pow(x, 3)<N; x++)
                for(int y = 1; Math.Pow(y, 3) <N; y++)
                    for(int z=1;Math.Pow(z,3)<N;z++)
                    {
                        if ((x * x * x) + (y * y * y) + (z * z * z) <= N)
                            combine[(x * x * x) + (y * y * y) + (z * z * z)] = combine[(x * x * x) + (y * y * y) + (z * z * z)] + 1;
                        else
                            break;
                    }
            
        }
        public void ShowCombine()
        {
            foreach(KeyValuePair<int,int>comb in combine)
            {
                if (comb.Value > 1)
                    Console.WriteLine("Число "+comb.Key);
            }
        }
    }
    
    class Lab9Manager
    {  
        public void Ex1F()
        {
            TrashContent trashContent = new TrashContent();
            trashContent.Main();
        }
        public void Ex1S()
        {
            TrachContentTwo trachContentTwo = new TrachContentTwo();
            trachContentTwo.Main();
            
        }

        public void Ex2(string text)
        {
            CSharp_Shell.Test test = new CSharp_Shell.Test(text);
        }

        public void Ex3()
        {
            try
            {
                Console.WriteLine("Сколько игроков? 5<= N <=10");
                int n = Int32.Parse(Console.ReadLine());
                if (n < 5 || n > 10)
                    throw new Exception("Надурить меня хочешь?");
                Console.WriteLine("Текст считалочки");
                LoopGame Game = new LoopGame(n, Console.ReadLine());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            
            
        }

        public void Ex4()
        {
            int N = 100000;
            FileLabLibrary9 fileLabLibrary9 = new FileLabLibrary9();
            try
            {
                fileLabLibrary9.SetCombine(N);
                fileLabLibrary9.Combinations(N);
                fileLabLibrary9.ShowCombine();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Ex5()
        {
            TournamentTable kek = new TournamentTable();
            kek.Initialize();
        }
        /// <summary>
        /// Первый массив на проверку, второй где откуда проверять
        /// </summary>
        /// <param name="Ar"></param>
        /// <param name="Ar2"></param>
        public void Ex6(string[] Ar, string[] Ar2)
        {
            if(Ar.Length > Ar2.Length)
            {
                Console.WriteLine("В списке на проверку больше элементов, чем необходимо");
                return;
            }
            DoubleLinkedList<string> linkedList2 = new DoubleLinkedList<string>();
            DoubleLinkedList<string> linkedList1 = new DoubleLinkedList<string>();

            foreach (string k in Ar2)
                linkedList2.Add(k);
            foreach (string k in Ar)
            {
                linkedList1.Add(k);
                if (!linkedList2.Contains(k))
                {
                    Console.WriteLine("Первый лист содержит элементы которых нет во втором списке");
                    return;
                }
            }
            Console.WriteLine("Все элементы первого содержатся во втором");

        }

        
        
    }

    public class ContList<T>
    {
        public void Compare(List<T> p1,List<T> p2)
        {
            foreach(T cont in p1)
            {
                if (!p2.Contains(cont))
                {
                    Console.WriteLine("Содержит не все элементы");
                    return;
                }
            }
            Console.WriteLine("Содержит все элементы");
        }
    }


    
}



