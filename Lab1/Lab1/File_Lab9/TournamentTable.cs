using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs
{
    class TournamentTable
    {
        TreeTable treeTable;
        public void Initialize()
        {
            treeTable = new TreeTable();
            treeTable.SetTable();
            treeTable.SetTeams();
            MessageTeams();
            treeTable.SetFirstPeriod();
            treeTable.SetSecondTeams();
            treeTable.SetSecondPeriod();
            treeTable.SetThirdTeams();
            treeTable.SetThirdPeriod();
            treeTable.Final();

            treeTable.PreOrderTraversal();
        }

        public void MessageTeams()
        {
            Console.WriteLine("Чемпионат по футболу\r\n");
            bool b = true;
            foreach (string strK in treeTable.ReturnTeams())
            {
                if (b)
                {
                    b = !b;
                    Console.Write($"{strK,15} VS ");
                }
                else
                {
                    b = !b;
                    Console.Write(strK+"\r\n");
                }
            }
        }
    }

    class TreeNode
    {
        /// <summary>
        /// true если игра закончена
        /// </summary>
        public bool IsGameOver = false;
        public string Country1 = default(string);
        public string Country2 = default(string);
        public byte Score1 = default(byte);
        public byte Score2 = default(byte);
        public int Value = default(int);

        public TreeNode Left = null;
        public TreeNode Right = null;

        public TreeNode(int value)
        {
            Value = value;
        }
        public TreeNode()
        {

        }

        public void SetCountry(string c1,string c2)
        {
            this.Country1 =  c1;
            this.Country2 =  c2;
        }

        public void FinishTheMatch()
        {
            //Score1 = b1;
            // Score2 = b2;
            // if (b1 == b2)
            // {
            //     Score1 =(byte)( Score1 + 1);
            //  }
            
            while(Score1 == Score2)
            {
                Score1 = Random();
                Score2 = Random();
            }

            IsGameOver = true;
        }

        public string CountryWinner()
        {
            
            if (Score1> Score2)
                return Country1;
            else
                return Country2;
        }
        byte Random()
        {
            Random r = new Random();
            int c1 = r.Next(0, 22) < 7 ? 1 :
                r.Next(0, 22) < 11 ? 2 :
                r.Next(0, 33) < 11 ? 3 :
                r.Next(0, 44) < 11 ? 4 :
                r.Next(0, 66) < 19 ? 5 : 6;
            return(byte) c1;
        }
        public string ReturnResult()
        {
            string retr = Country1 + " - " + Country2 + " : " + Score1.ToString() + " - " + Score2.ToString();
            return retr;
        }
    }

    class TreeTable
    {
        /*Устанавливаем корень, каждый узел это матч 1 на 1, в коде необходимо реализовать лишь всю таблицу
         *  если игры 2^n то можно у макс игр отнять -1 и получится количество таблиц, это мой случай
         * не-не-не, ну его нахрен, пусть кто-то за меня это сделать, мне лень думать, голова уже болит
         */
        TreeNode Root;
        string[] SixteenTeams = new string[16];

        public void SetTable()
        {
            int Num = 1;

            Root = new TreeNode(Num++); // 1
            Root.Left = new TreeNode(Num++);//2
            Root.Right = new TreeNode(Num++);//3

            Root.Left.Left = new TreeNode(Num++); // 4 in 2
            Root.Left.Right = new TreeNode(Num++); // 5 in 2

            Root.Left.Left.Left = new TreeNode(Num++); //6 in 4 in 2
            Root.Left.Left.Right = new TreeNode(Num++); //7 in 4 in 2

            Root.Left.Right.Left = new TreeNode(Num++); //8 in 5 in 2
            Root.Left.Right.Right = new TreeNode(Num++); //9 in 5 in 2


            Root.Right.Left = new TreeNode(Num++); // 10 in 3
            Root.Right.Right = new TreeNode(Num++); // 11 in 3

            Root.Right.Left.Left = new TreeNode(Num++); // 12 in 10 in 3
            Root.Right.Left.Right = new TreeNode(Num++); // 13 in 10 in 3

            Root.Right.Right.Left = new TreeNode(Num++); // 14 in 11 in 3
            Root.Right.Right.Right = new TreeNode(Num++); // 15 in 11 in 3


        }
        public void SetTeams()
        {
            /* 6 - Бразилия Уругвай 
             * 7 - Китай Япония
             * 8 - Россия Украина
             * 9 - Чехия Пакистан
             * 12 - Англия Шотландия
             * 13 - Алжир Зеландия
             * 14 - Таджикистан Армения
             * 15 - Грузия Молдавия
             */
            List<string> teams = new List<string>();
            teams.AddRange(new string[] { "Бразилия", "Уругвай","Китай", "Япония", "Россия", "Украина", "Чехия", "Пакистан", "Англия", "Франция", "Алжир",
                                         "Зеландия","Таджикистан","Армения","Грузия","Молдавия"});
            Random r = new Random();
            for (int i = 0;i<16;i++)
            {
                int RAND = r.Next(teams.Count);
                SixteenTeams[i] = teams[RAND];
                teams.RemoveAt(RAND);
                
            }

            Root.Left.Left.Left.SetCountry(SixteenTeams[0], SixteenTeams[1]);//6 in 4 in 2
            Root.Left.Left.Right.SetCountry(SixteenTeams[2], SixteenTeams[3]);//7 in 4 in 2

            Root.Left.Right.Left.SetCountry(SixteenTeams[4], SixteenTeams[5]); //8 in 5 in 2
            Root.Left.Right.Right.SetCountry(SixteenTeams[6], SixteenTeams[7]); //9 in 5 in 2

            Root.Right.Left.Left.SetCountry(SixteenTeams[8], SixteenTeams[9]);// 12 in 10 in 3
            Root.Right.Left.Right.SetCountry(SixteenTeams[10], SixteenTeams[11]); // 13 in 10 in 3

            Root.Right.Right.Left.SetCountry(SixteenTeams[12], SixteenTeams[13]); // 14 in 11 in 3
            Root.Right.Right.Right.SetCountry(SixteenTeams[14], SixteenTeams[15]); // 15 in 11 in 3
        }
        /// <summary>
        /// Юзать после заполнения списка
        /// </summary>
        /// <returns></returns>
        public string[] ReturnTeams()
        {
            return SixteenTeams;
        }
        public void SetFirstPeriod()
        {
            Random r1 = new Random();
            Random r2 = new Random();
            
            Root.Left.Left.Left.FinishTheMatch();//6 in 4 in 2
            Root.Left.Left.Right.FinishTheMatch();//7 in 4 in 2

            Root.Left.Right.Left.FinishTheMatch(); //8 in 5 in 2
            Root.Left.Right.Right.FinishTheMatch(); //9 in 5 in 2

            Root.Right.Left.Left.FinishTheMatch();// 12 in 10 in 3
            Root.Right.Left.Right.FinishTheMatch(); // 13 in 10 in 3

            Root.Right.Right.Left.FinishTheMatch(); // 14 in 11 in 3
            Root.Right.Right.Right.FinishTheMatch(); // 15 in 11 in 3
        }

        public void SetSecondTeams()
        {

            Root.Left.Left.SetCountry(Root.Left.Left.Left.CountryWinner(), Root.Left.Left.Right.CountryWinner());// 4 in 2
            Root.Left.Right.SetCountry(Root.Left.Right.Left.CountryWinner(), Root.Left.Right.Right.CountryWinner()); // 5 in 2

            Root.Right.Left.SetCountry(Root.Right.Left.Left.CountryWinner(), Root.Right.Left.Right.CountryWinner()); // 10 in 3
            Root.Right.Right.SetCountry(Root.Right.Right.Left.CountryWinner(), Root.Right.Right.Right.CountryWinner()); // 11 in 3
        }

        public void SetSecondPeriod()
        {
            Random r1 = new Random();
            Random r2 = new Random();

            Root.Left.Left.FinishTheMatch();// 4 in 2
            Root.Left.Right.FinishTheMatch(); // 5 in 2

            Root.Right.Left.FinishTheMatch(); // 10 in 3
            Root.Right.Right.FinishTheMatch(); // 11 in 3
        }

        public void SetThirdTeams()
        {
            Root.Left.SetCountry(Root.Left.Left.CountryWinner(), Root.Left.Right.CountryWinner()) ;//2
            Root.Right.SetCountry(Root.Right.Left.CountryWinner(), Root.Right.Right.CountryWinner()) ;//3
        }

        public void SetThirdPeriod()
        {
            Random r1 = new Random();
            Random r2 = new Random();
            Root.Left.FinishTheMatch();//2
            Root.Right.FinishTheMatch();//3
        }

        public void Final()
        {
            Random r1 = new Random();
            Random r2 = new Random();
            Root.SetCountry(Root.Left.CountryWinner(), Root.Right.CountryWinner());
            Root.FinishTheMatch();
        }

        public void PreOrderTraversal()
        {
            PreOrder(Root);
        }

        public void PreOrder(TreeNode node)
        {
            if (node != null)
            {
                if (node.Value == 1)
                    Console.Write(node.ReturnResult() + "\r\n");
                else if (node.Value == 3 || node.Value == 2)
                    Console.Write("\t" + node.ReturnResult() + "\r\n");
                else if (node.Value == 4 || node.Value == 5 || node.Value == 10 || node.Value == 11)
                    Console.Write("\t\t" + node.ReturnResult() + "\r\n");
                else 
                    Console.Write("\t\t\t" + node.ReturnResult() + "\r\n");
                PreOrder(node.Left);
                PreOrder(node.Right);
            }
        }



    }
}
