using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;

namespace Labs
{
    class Test
    {
        //public static void test() => Labs.File_lab6.Ex_1();
        public static void test()
        {
            FileLab6_3 FileL = new FileLab6_3();
          string kek = FileL.ReadTextFromFileAndReturnIt(@"..\..\Files\TextEx3.txt");

            
                Console.Write(kek+" ");

            
            //Console.WriteLine(dom);

        }
    }

}
