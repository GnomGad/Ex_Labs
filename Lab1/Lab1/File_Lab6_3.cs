using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Labs
{
    class FileLab6_3
    {
        ConsoleManager ConsoleManager = new ConsoleManager();
        string FullPath = "";
        string FilesPath = @"..\..\Files";
        string FileForRead = @"\TextEx3.txt";
        string FileForWrite = "";

        
        public FileLab6_3()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileForRead">Пример Input.txt</param>
        /// <param name="FileForWrite">Пример Output.txt</param>
        public FileLab6_3(string FileForRead, string FileForWrite)
        {
            this.FileForRead = TestNamePath(FileForRead);
            this.FileForWrite = TestNamePath(FileForWrite);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileForRead">Input.txt</param>
        /// <param name="FileForWrite">Output.txt</param>
        /// <param name="FilesPath">C:\Application\Dock</param>
        public FileLab6_3(string FileForRead, string FileForWrite, string FilesPath)
        {
            this.FileForRead = TestNamePath(FileForRead);
            this.FileForWrite = TestNamePath(FileForWrite);
            this.FilesPath = TestFilesPath(FilesPath);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FilesPath">:\Application\Dock</param>
        public FileLab6_3(string FilesPath)
        {
            this.FilesPath = TestFilesPath(FilesPath);
        }
        public string TestNamePath(string Head)
        {
            Head = Path.GetFileName(Head);
            if (Path.GetExtension(Head) == "")
            {
                ConsoleManager.RedSendToConsole("Ошибка: у имени нет расширения");
                Head = Path.ChangeExtension(Head, ".txt");
                ConsoleManager.GreenSendToConSole("Расширение изменено на .txt");
            }
            return Head;
        }
        public string TestFilesPath(string Body)
        {
            if(Path.GetPathRoot(Body) == @"\")
            {
                ConsoleManager.RedSendToConsole("Не указана корневая папка");
                ConsoleManager.GreenSendToConSole("Вернется значение по умолчанию  "+FilesPath);
                return FilesPath;
            }
            return Body;
        }
        /*
        public string ReadTextFromFileAndReturnIt(string FullPathForReadFile)
        {
            StreamReader StreamRead = null;
            string ArrayForStream = null;
            try
            {
                StreamRead = new StreamReader(FilesPath+"\\"+FileForRead);
                ArrayForStream = StreamRead.ReadToEnd();

            }
            catch (Exception e)
            {
                ConsoleManager.RedSendToConsole("Ошибка в блоке чтения файла \r\n" + e.Message);
            }
            finally
            {
                StreamRead.Close();     
            }
            return ArrayForStream;
        }*/









    }
    class ConsoleManager
    {
        public void RedSendToConsole(string text)
        {
            RedFontConsole();
            Console.WriteLine(text);
            WhiteFontConsole();
        }
        public void GreenSendToConSole(string text)
        {
            GreenFontConsole();
            Console.WriteLine(text);
            WhiteFontConsole();
        }
        public void SpecifiedColorSendToConsole(string text,ConsoleColor c1)
        {
            Console.ForegroundColor = c1;
            Console.WriteLine(text);
            WhiteFontConsole();
        }
        private void RedFontConsole() => Console.ForegroundColor = ConsoleColor.Red;
        private void WhiteFontConsole() => Console.ForegroundColor = ConsoleColor.White;
        private void GreenFontConsole() => Console.ForegroundColor = ConsoleColor.Green;
    }
        
}
