using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;

using CSharp_Shell;

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
    }



    
}



