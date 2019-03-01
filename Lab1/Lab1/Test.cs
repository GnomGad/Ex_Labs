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

            Ex3();
        }
        static  void Ex3()
        {
            Lab6Manager Ex3 = new Lab6Manager();
            Ex3.FileOutName = "OutThere.txt";
            Ex3.Ex3();
        }
    }

}
