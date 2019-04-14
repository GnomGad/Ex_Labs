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
        }
    }

    class TreeNode
    {
        /// <summary>
        /// true если игра закончена
        /// </summary>
        public bool IsGameOver = false;
        public string Country1 = null;
        public string Country2 = null;
        public byte Score1 = 0;
        public byte Score2 =0;
        public int Element = 0;

        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }

    class TreeTable
    {
        /*Устанавливаем корень, каждый узел это матч 1 на 1, в коде необходимо реализовать лишь всю таблицу
         *  если игры 2^n то можно у макс игр отнять -1 и получится количество таблиц, это мой случай
         * не-не-не, ну его нахрен, пусть кто-то за меня это сделать, мне лень думать, голова уже болит
         */
        TreeNode Root;

        public void SetTable()
        {
            int teams = 16;
            int Tables = (int)Math.Log(16, 2);
            if (Root == null)
                Root = new TreeNode();
            for(int i =0;i<Tables;i++)// глубина т.е. этот цикл сделает сток итераций, скок надо вниз спуститься
            {

            }


        }
    }
}
