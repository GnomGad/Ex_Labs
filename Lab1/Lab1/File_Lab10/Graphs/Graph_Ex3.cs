using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs.File_Lab10.Graphs
{
    partial class  Graphs
    {
        IncidenceArray incidence;
        IncidenceList incidence2;
        public void Start()
        {
            int ch1 =  default(int);
            int ch2 = default(int);
            try
            {
                Console.WriteLine("Введите X\r\n");
                 ch1= int.Parse(Console.ReadKey().KeyChar.ToString());
                Console.WriteLine("\r\nВведите Y\r\n");
                 ch2 = int.Parse(Console.ReadKey().KeyChar.ToString());
            }
            catch(FormatException)
            {
                Console.WriteLine("неверное число");
                return;
            }
            Console.WriteLine("\r\nМассив");
            incidenceArray(ch1, ch2);
            IncidenceList(ch1, ch2);

        }

        void incidenceArray(int X,int Y)
        {
            incidence = new IncidenceArray();
            incidence.Run(X,Y);
            incidence.Show();
        }

        void IncidenceList(int X,int Y)
        {
            incidence2 = new IncidenceList();
            incidence2.Run(X, Y);
            incidence2.Show();
        }
    }

    class IncidenceArray: Graph
    {

        public void Run(int X, int Y)
        {
            X--;
            Y--;

            SetGraphTable();

            Stack<int> paths = BFS(X, Y);
            Console.Write("\r\nBFS");

            while (paths.Count > 0)
            {
                int tmp = paths.Pop();
                Console.Write(" -> " +(tmp+1));
            }
            Console.WriteLine();
            Stack<int> paths1 = DFS(X, Y);
            Console.Write("\r\nDFS");
            while (paths1.Count > 0)
            {
                int tmp = paths1.Pop();
                Console.Write(" -> " + (tmp + 1));
            }
            Console.WriteLine();
        }
        public Stack<int> BFS(int startPos, int endPos)
        {
            Queue<int> q = new Queue<int>();

            int[] vPath = new int[V];
            int[] checkedv = new int[V];

            q.Enqueue(startPos);
            checkedv[startPos] = 1;

            while (q.Count > 0)
            {
                int i = q.Dequeue();

                for (int j = 0; j < V; j++)
                {
                    if (graph[i, j] == 1 && checkedv[j] == 0)
                    {
                        checkedv[j] = 1;
                        q.Enqueue(j);
                        vPath[j] = i;

                        if (j == endPos)
                            return backChain(vPath, startPos, endPos);
                    }
                }
            }
            return null;
        }
        public Stack<int> backChain(int[] p, int startPos, int endPos)
        {
            int pos = endPos;

            Stack<int> pathStack = new Stack<int>();
            pathStack.Push(pos);

            while (pos != startPos)
            {
                pos = p[pos];
                pathStack.Push(pos);
            }

            return pathStack;
        }
        public Stack<int> DFS(int startPos, int endPos)
        {
            Stack<int> st = new Stack<int>();

            int[] vPath = new int[V];
            int[] checkedv = new int[V];

            st.Push(startPos);
            checkedv[startPos] = 1;

            while (st.Count>0)
            {
                int i = st.Pop();

                for (int j = V - 1; j >= 0; j--)
                {
                    if (graph[i, j] == 1 && checkedv[j] == 0)
                    {
                        checkedv[j] = 1;
                        st.Push(j);
                        vPath[j] = i;

                        if (j == endPos)
                            return backChain(vPath, startPos, endPos);
                    }
                }
            }
            return null;
        }

    }
    class IncidenceList : Graph
    {
        public void Run(int X, int Y)
        {
            Console.WriteLine("\r\nЛист\r\n");
            X--;
            Y--;
            SetGraphTable();
            Stack<int> paths = BFS(X, Y);
            Console.Write("\r\nBFS");

            while (paths.Count > 0)
            {
                int tmp = paths.Pop();
                Console.Write(" -> " + (tmp + 1));
            }
            Console.WriteLine();
            Stack<int> paths1 = DFS(X, Y);
            Console.Write("\r\nDFS");
            while (paths1.Count > 0)
            {
                int tmp = paths1.Pop();
                Console.Write(" -> " + (tmp + 1));
            }
            Console.WriteLine();
        }

        public Stack<int> BFS(int startPos, int endPos)
        {
            Queue<int> q = new Queue<int>();

            int[] vPath = new int[V];
            int[] checkedv = new int[V];

            q.Enqueue(startPos);
            checkedv[startPos] = 1;

            while (q.Count > 0)
            {
                int i = q.Dequeue();

                for (int j = 0; j < V; j++)
                {
                    if (graphList[i].IndexOf(j)!=-1 && checkedv[j] == 0)
                    {
                        checkedv[j] = 1;
                        q.Enqueue(j);
                        vPath[j] = i;

                        if (j == endPos)
                            return backChain(vPath, startPos, endPos);
                    }
                }
            }
            return null;
        }
        public Stack<int> backChain(int[] p, int startPos, int endPos)
        {
            int pos = endPos;

            Stack<int> pathStack = new Stack<int>();
            pathStack.Push(pos);

            while (pos != startPos)
            {
                pos = p[pos];
                pathStack.Push(pos);
            }

            return pathStack;
        }
        public Stack<int> DFS(int startPos, int endPos)
        {
            Stack<int> st = new Stack<int>();

            int[] vPath = new int[V];
            int[] checkedv = new int[V];

            st.Push(startPos);
            checkedv[startPos] = 1;

            while (st.Count > 0)
            {
                int i = st.Pop();

                for (int j = V - 1; j >= 0; j--)
                {
                    if (graphList[i].IndexOf(j) != -1 && checkedv[j] == 0)
                    {
                        checkedv[j] = 1;
                        st.Push(j);
                        vPath[j] = i;

                        if (j == endPos)
                            return backChain(vPath, startPos, endPos);
                    }
                }
            }
            return null;
        }

        protected override void SetGraphTable()
        {
            graphList = new List<int>[8];
            setG(1, new int[] {2,3 });
            setG(2, new int[] {1,6,7});
            setG(3, new int[] {1,4,6,8 });
            setG(4, new int[] {3,5 });
            setG(5, new int[] {4,6 });
            setG(6, new int[] {2,3,5 });
            setG(7, new int[] {2,8 });
            setG(8, new int[] {3,7 });


        }
        protected  void setG(int x, int[] y)
        {
            x--;
            for (int i = 0; i < y.Length; i++)
                y[i] = y[i] - 1;

           graphList[x] = new List<int>(y);
        }

        public override void Show()
        {
            Console.WriteLine();
            for(int i =0;i<8;i++)
            {
                Console.Write("\r\n"+"["+(i+1)+"]");
                foreach (int k in graphList[i])
                    Console.Write(" -> "+(k + 1));
            }
            Console.WriteLine();
        }
    }
    class Graph
    {
        protected int V = 8;
        protected int[,] graph { get; set; }
        protected List<int>[] graphList { get; set; }
        public virtual void Show()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    Console.Write(graph[i, k] + "  ");
                }
                Console.WriteLine();
            }
        }

        protected virtual void SetGraphTable()
        {
            graph = new int[8, 8]{
                { 0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0}
                                };
            SetPaths(1, 2);
            SetPaths(1, 3);
            SetPaths(2, 6);
            SetPaths(2, 7);
            SetPaths(3, 4);
            SetPaths(3, 6);
            SetPaths(3, 8);
            SetPaths(4, 5);
            SetPaths(5, 6);
            SetPaths(7, 8);
        }
        protected virtual void SetPaths(int x, int y)
        {
            x--;
            y--;
            graph[x, y] = 1;
            graph[y, x] = 1;
        }

    }

}
