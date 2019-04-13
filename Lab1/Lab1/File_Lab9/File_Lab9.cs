using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;

using Labs.Game;

namespace Labs
{
    class FileLabLibrary9
    {

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
    }



    
}



