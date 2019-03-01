using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Labs
{
    class LibraryFileLab6_3
    {
        ConsoleManager ConsoleManager = new ConsoleManager();
        string FilesPath = @"..\..\Files";
        string FileForRead = @"Input.txt";// ввод сюда
        string FileForWrite = @"Output.txt";// вывод отсюда

        public LibraryFileLab6_3()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileForRead">Пример Input.txt</param>
        /// <param name="FileForWrite">Пример Output.txt</param>
        public LibraryFileLab6_3(string FileForRead, string FileForWrite)
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
        public LibraryFileLab6_3(string FileForRead, string FileForWrite, string FilesPath)
        {
            this.FileForRead = TestNamePath(FileForRead);
            this.FileForWrite = TestNamePath(FileForWrite);
            this.FilesPath = TestFilesPath(FilesPath);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FilesPath">Out.txt</param>
        public LibraryFileLab6_3(string FileForWrite)
        {
            this.FileForWrite = TestNamePath(FileForWrite);
        }

        string TestNamePath(string Head)
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
        string TestFilesPath(string Body)
        {
            if (Path.GetPathRoot(Body) == @"\")
            {
                ConsoleManager.RedSendToConsole("Не указана корневая папка");
                ConsoleManager.GreenSendToConSole("Вернется значение по умолчанию  " + FilesPath);
                return FilesPath;
            }
            return Body;
        }

        /// <summary>
        /// Берет значения из файла и возвращает их
        /// </summary>
        /// <returns></returns>
        public string ReadTextFromFileAndReturnIt()
        {
            StreamReader StreamRead = null;
            string OutForRerurn = null;
            try
            {
                StreamRead = new StreamReader(FilesPath + "\\" + FileForRead);
                OutForRerurn = StreamRead.ReadToEnd();

            }
            catch (Exception e)
            {
                ConsoleManager.RedSendToConsole("Ошибка в блоке чтения файла \r\n" + e.Message);
            }
            finally
            {
                StreamRead.Close();

            }
            return OutForRerurn;
        }
        /// <summary>
        /// Получает текст, который нужно записать в файл
        /// </summary>
        /// <param name="Text"></param>
        public void WriteTextInFile(string Text)
        {
            StreamWriter StreamWrite = null;
            try
            {
                StreamWrite = new StreamWriter(FilesPath + "\\" + FileForWrite);
                StreamWrite.WriteLine(Text);
            }
            catch (Exception e)
            {
                ConsoleManager.RedSendToConsole("Ошибка в блоке записи в файл \r\n" + e.Message);

            }
            finally
            {
                StreamWrite.Flush();
                StreamWrite.Close();
            }
        }
        /// <summary>
        /// Получает текст, который нужно записать в файл, если нет файла то создать
        /// </summary>
        /// <param name="Text"></param>
        public void WriteTextInFileAndCreateFile(string Text)
        {
            StreamWriter StreamWrite = null;
            try
            {
                CreateOutFile();
                StreamWrite = new StreamWriter(FilesPath + "\\" + FileForWrite);
                StreamWrite.WriteLine(Text);
            }
            catch (Exception e)
            {
                ConsoleManager.RedSendToConsole("Ошибка в блоке записи в файл \r\n" + e.Message);

            }
            finally
            {
               // StreamWrite.Flush();
                StreamWrite.Close();
            }
        }
        /// <summary>
        /// Возвращает строку без цифр
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public string ReturnTextWithoutNumbers(string Text)
        {
            string[] SplitArray = null;
            string TextWithoutNumber = "";
            char[] chars = { '0', '1', '2','3','4','5','6','7','8','9' };
            try
            {
                SplitArray = Text.Split(chars);
                foreach(string S in SplitArray)
                    TextWithoutNumber = TextWithoutNumber+ S;
                
            }
            catch(Exception e)
            {
                ConsoleManager.RedSendToConsole("Ошибка в блоке удаления чисел \r\n" + e.Message);
            }
            finally
            {
                
                ConsoleManager.GreenSendToConSole((Text.Length - TextWithoutNumber.Length).ToString()+" именно столько цифр удалено из текста");
            }
            return TextWithoutNumber;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileForWrite">Name.txt</param>
        /// 
        public void SetNameFileForWrite(string FileForWrite) 
        {
            this.FileForWrite =  TestNamePath(FileForWrite);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileForRead">Name.txt</param>
        public void SetNameFileForRrite(string FileForRead)
        {
            this.FileForRead = TestNamePath(FileForRead);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FilesPath">C:\Application\Dock</param>
        public void SetPath(string FilesPath)
        {
            this.FilesPath = TestFilesPath(FilesPath);
        }
        /// <summary>
        /// создание файла
        /// </summary>
        public void CreateOutFile()
        {
            if (!File.Exists(FilesPath + "\\" + FileForWrite))
            {
            
                File.CreateText(FilesPath + "\\" + FileForWrite).Close();
                ConsoleManager.GreenSendToConSole("Файл успешно создан");
              
            }
        }

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

    class Lab6Manager
    {
        
        public string FileOutName = "Output.txt";
        public string FileInName = "Input.txt";
        public string FilePathName = @"..\..\Files";

        public void Ex3()
        {
            LibraryFileLab6_3 FileLab = new LibraryFileLab6_3(FileInName,FileOutName,FilePathName);
            string Text = FileLab.ReadTextFromFileAndReturnIt();
            string TextWithoutNums = FileLab.ReturnTextWithoutNumbers(Text);
            FileLab.WriteTextInFileAndCreateFile(TextWithoutNums);
            Console.WriteLine();
        }
    }
        
}
