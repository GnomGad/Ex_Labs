using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs.File_Lab10.Graphs
{
    class MinPathGame : Properties
    {
        public void Start()
        {
            SetCities();
            RandomL();
            Show();
            Choice();
        }

       
    }

    class Properties 
    {
        protected int[,] Cities { get; set; }
        int V = default(int);
        protected virtual void SetCities()
        {
            int d = V;
            while (d == V)
            {
                Console.WriteLine("Количество городов");
                try
                {
                    int k = int.Parse(Console.ReadLine());
                    V = k;
                    Cities = new int[k, k];
                }
                catch (FormatException)
                {
                    Console.WriteLine("Плохое значение");
                }
            }

        }

        protected void RandomL()
        {
            Random rand = new Random();
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    if (i == j)
                        Cities[i, j] = -1;
                    else
                    {
                        if (rand.Next(0, 100) > 55)
                            Cities[i, j] = rand.Next(40, 100);
                        else
                            Cities[i, j] = -1;
                    }
                    Cities[j, i] = Cities[i, j];
                }
            }
        }

        protected void Show()
        {
            for (int i = 0; i < V; i++)
            {
                for (int k = 0; k < V; k++)
                    Console.Write(Cities[i, k] + "  ");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public int ShortestPath(int s, int v)
        {
            List<int> distances = new List<int>();
            List<int> q = new List<int>();
            for (int i = 0; i < V; i++)
            {
                distances.Add(int.MaxValue);
                q.Add(i);
            }
            distances[s] = 0;

            while (q.Count > 0)
            {
                int u = -1, min = int.MaxValue;

                for (int i = 0; i < q.Count; i++)
                {
                    if (distances[q[i]] <= min)
                    {
                        min = distances[q[i]];
                        u = q[i];
                    }
                }
                q.Remove(u);
                for (int i = 0; i < V; i++)
                    if (Cities[u, i] > 0)
                        if (distances[i] > Cities[u, i] + distances[u])
                            distances[i] = Cities[u, i] + distances[u];
            }

            return distances[v];

        }
        public void Choice()
        {
            for (int i = 0; i < V; i++)
            {
                for (int k = 0; k < V; k++)
                {
                    if (i != k)
                    {
                        int Norm = ShortestPath(i, k);
                        if(Norm<=200 && Norm >=0)
                        Console.WriteLine($"Путь от {i + 1} и до {k + 1} длина {Norm}");
                    }
                        
                }
            }

        }
    }
}
