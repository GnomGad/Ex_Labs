using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs
{
    class FileLabLibrary7 
    {
        

        public void InsertionSort(ref GetTvshow[] Tv, int l, int r)
        {
            for (int i = l + 1; i <= r; i++)
                for (int j = i; j > l; j--)
                    if ((int)Tv[j - 1].Value > (int)Tv[j].Value)
                    {
                        // Swap((int)Tv[j - 1].Value, (int)Tv[j].Value, j);
                        //присвоение tmp элементы j-1
                        int tmpValue =(int) Tv[j - 1].Value;
                        string tmpNameTv = Tv[j - 1].NameTV;
                        string tmpNameArtist = Tv[j - 1].NameArtist;
                        char tmpType = Tv[j - 1].Type;
                        int tmpN = Tv[j - 1].n;

                        //присвоение j-1 элементы из j
                        Tv[j - 1].Value = Tv[j].Value;
                        Tv[j - 1].NameTV = Tv[j].NameTV;
                        Tv[j - 1].NameArtist = Tv[j].NameArtist;
                        Tv[j - 1].Type = Tv[j].Type;
                        Tv[j - 1].n = Tv[j].n;

                        //присвоение j из tmp
                        Tv[j].check_for_value(tmpValue.ToString(), out string er);
                        Tv[j].check_for_tyoe(tmpType, out string er1);
                        Tv[j].NameArtist = tmpNameArtist;
                        Tv[j].NameTV = tmpNameTv;
                        Tv[j].n = tmpN;
                    }
        }






    }
    class Lab7Manager
    {
        public void Ex1()
        {
            FileLabLibrary7 FileLab = new FileLabLibrary7();
            TrashForEx1.Begin();

        }
    }

    class TrashForEx1 : File_lab6
    {
       static public void Begin()
        {
            File_lab6.ReadAndSetTvShowsFilePlaylist();// инициализация TV_Shows[]
            int i = 0;
            for (i = 0; i < MaxStrinTable && Tv_Shows[i].NameTV != null; i++);// узнаем сколько не пустых элементов
            FileLabLibrary7 fl7 = new FileLabLibrary7();
            fl7.InsertionSort(ref Tv_Shows, 0, i-1);
            File_lab6.main();

        }
    }


}
