using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs.File_Lab10
{
    class File_Lab10
    {
    }

    class ManagerLab10
    {
        public void main()
        {
            char k = 'j';
            while (k != 0)
            {
                Console.WriteLine("\r\nНомер задания  1,  2,  3,  4,  5,  0 - выход");
                k = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (k == '1') Ex1();
                else if (k == '2') Ex1();
                else if (k == '3') Ex1();
                else if (k == '4') Ex1();
                else if (k == '5') Ex1();
            }
        }
        public void Ex1()
        {
            Lab7Manager k1 = new Lab7Manager();
            //k.Ex2();
            Sorts k = new Sorts(1000);
             k.StartSort();
        }
    }
}
