﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Labs
{
    class LibraryFileLab6
    {
        ConsoleManager ConsoleManager = new ConsoleManager();
        string FilesPath = @"..\..\Files";
        string FileForRead = @"Input.txt";// ввод сюда
        string FileForWrite = @"Output.txt";// вывод отсюда
        string DirectoryName = @"Lab6_Temp";//
        string FileNameForLabDotDat = @"Lab.dat";
        string FileNameForBackUp = null;
        string FileBmpName = null;
        public LibraryFileLab6()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileForRead">Пример Input.txt</param>
        /// <param name="FileForWrite">Пример Output.txt</param>
        public LibraryFileLab6(string FileForRead, string FileForWrite)
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
        public LibraryFileLab6(string FileForRead, string FileForWrite, string FilesPath)
        {
            this.FileForRead = TestNamePath(FileForRead);
            this.FileForWrite = TestNamePath(FileForWrite);
            this.FilesPath = TestFilesPath(FilesPath);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FilesPath">Out.txt</param>
        public LibraryFileLab6(string FileForWrite)
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
        //2 задание
        /// <summary>
        /// Запишет пары
        /// </summary>
        public void WriteInBinaryFileSetOfPairs()
        {
            BinaryWriter BiWrite = null;
            try
            {
                
                BiWrite = new BinaryWriter(File.Open((FilesPath + "\\" + FileForWrite), FileMode.OpenOrCreate));
                for (byte i = 4; i <= 81; i++)
                {
                    BiWrite.Write(i);
                    BiWrite.Write((float)Math.Pow(i, 0.5));
                }

            }
            catch(Exception e)
            {
                ConsoleManager.RedSendToConsole("WriteInBinaryFileSetOfPairs\r\n" + e.Message);
            }
            finally
            {
                BiWrite.Close();
            }
        }
        /// <summary>
        /// Запишет второе число из пар
        /// </summary>
        public void ReadInBinaryFileSecondNumberAndWriteItinNewBinaryFile()
        {
            BinaryReader BiRead = null;
            BinaryWriter BiWrite = null;
            try
            {

                BiRead = new BinaryReader(File.Open((FilesPath + "\\" + FileForWrite), FileMode.Open));
                BiWrite = new BinaryWriter(File.Open((FilesPath + "\\" + FileForRead), FileMode.OpenOrCreate));
                for (byte i = 4; i <= 81; i++)
                {
                    BiRead.ReadByte();
                    BiWrite.Write(BiRead.ReadSingle());
                }

            }
            catch (Exception e)
            {
                ConsoleManager.RedSendToConsole("ReadInBinaryFileSecondNumberAndWriteItinNewBinaryFile\r\n" + e.Message);
            }
            finally
            {
                BiRead.Close();
                BiWrite.Close();
            }
        }

        //3 задание
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
                ConsoleManager.RedSendToConsole("ReadTextFromFileAndReturnIt \r\n" + e.Message);
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
                ConsoleManager.RedSendToConsole("WriteTextInFile \r\n" + e.Message);

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
                ConsoleManager.RedSendToConsole("WriteTextInFileAndCreateFile \r\n" + e.Message);

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
            char[] chars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            try
            {
                SplitArray = Text.Split(chars);
                foreach (string S in SplitArray)
                    TextWithoutNumber = TextWithoutNumber + S;

            }
            catch (Exception e)
            {
                ConsoleManager.RedSendToConsole("ReturnTextWithoutNumbers \r\n" + e.Message);
            }
            finally
            {

                ConsoleManager.GreenSendToConSole((Text.Length - TextWithoutNumber.Length).ToString() + ", именно столько цифр удалено из текста");
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
            this.FileForWrite = TestNamePath(FileForWrite);
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
            else ConsoleManager.GreenSendToConSole("Файл уже существует");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PathF">C:\Application\Dock</param>
        /// <param name="Name">Lab.dat</param>
        public void CreateOutFile(string PathF,string Name)
        {
            SetFileNameForBackUp(Name);
            string FullPath = Path.Combine(PathF, FileNameForBackUp);
            if (!File.Exists(FullPath))
            {
                File.Create(FullPath).Close();
                ConsoleManager.GreenSendToConSole("Файл успешно создан");
            }
            else ConsoleManager.GreenSendToConSole("Файл уже существует");
        }
        public void SetFileNameForBackUp(string FileNameForBackUp)
        {
            this.FileNameForBackUp = Path.GetFileNameWithoutExtension(FileNameForBackUp) + "_backup" + Path.GetExtension(FileNameForBackUp);
        }

        //4 задание
        /// <summary>
        /// Создание директории
        /// </summary>
        public void CreateDirectory()
        {
            if (!Directory.Exists(FilesPath + "\\" + DirectoryName))
            {
                Directory.CreateDirectory(FilesPath + "\\" + DirectoryName);
                ConsoleManager.GreenSendToConSole("Директория успешно создана");
            }
            else ConsoleManager.GreenSendToConSole("Директория уже существует");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DirectoryName">Name</param>
        public void SetDirectoryName(string DirectoryName)
        {
            if (DirectoryName.Trim().Length != 0)
                this.DirectoryName = DirectoryName;
            else
            {
                ConsoleManager.RedSendToConsole("Неверное имя директории");
                ConsoleManager.GreenSendToConSole("Имя директории остается по умолчаию");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileNameForLabDotDat">Lab.dot</param>
        public void SetFileNameForLabDotDat(string FileNameForLabDotDat)
        {
            this.FileNameForLabDotDat = TestNamePath(FileNameForLabDotDat);
        }
        /// <summary>
        /// Копирует файл FilesPath +"\\" +FileNameForLabDotDat   в  
        ///               FilesPath + "\\" + DirectoryName + "\\" + FileNameForLabDotDat
        ///               Файл копируется в другую директрию
        /// </summary>
        public void CopyFileInMyDirectory()
        {
            try
            {
                File.Copy((FilesPath +"\\" +FileNameForLabDotDat), FilesPath + "\\" + DirectoryName + "\\" + FileNameForLabDotDat, true);
                ConsoleManager.GreenSendToConSole("Файл успешно скопирован");
            }
            catch (Exception e)
            {
                ConsoleManager.RedSendToConsole("CopyFileInMyDirectory\r\n" + e.Message);
            }
        }
        /// <summary>
        /// в начале необходимо проинициализировать FileNameForBackUp через SetFileNameForBackUp
        /// </summary>
        public void ByteBackup()
        {
            BinaryReader BiRead = null;
            BinaryWriter BiWrite = null;
            if (File.Exists((FilesPath + "\\" + DirectoryName + "\\" + FileNameForBackUp)))
                ConsoleManager.RedSendToConsole("Файл для бэкапа уже существует, он будет перезаписан\r\n");

            try
            {
                 BiRead = new BinaryReader(File.Open((FilesPath + "\\" + DirectoryName + "\\" + FileNameForLabDotDat), FileMode.Open));
                 BiWrite = new BinaryWriter(File.Open((FilesPath + "\\" + DirectoryName + "\\" + FileNameForBackUp), FileMode.OpenOrCreate));

                for(long i=0; i< BiRead.BaseStream.Length;i++)
                {
                    BiWrite.Write(BiRead.ReadByte());
                }

                ConsoleManager.GreenSendToConSole("Бэкап успешно произошел\r\n");


            }
            catch(Exception e)
            {
                ConsoleManager.RedSendToConsole("ByteBackup\r\n" + e.Message);
            }
            finally
            {
                
                BiRead.Close();
                BiWrite.Flush();
                BiWrite.Close();
            }
        }
        public void InfoFile()
        {
            try
            {
                FileInfo Flinfo = new FileInfo(FilesPath + "\\"  + FileNameForLabDotDat);
                ConsoleManager.BlueSendToConSole("Информация о файле "+FileNameForLabDotDat);
                ConsoleManager.BlueSendToConSole("Размер файла: "+Flinfo.Length.ToString()+" Байт");
                ConsoleManager.BlueSendToConSole("Время последнего изменения: " + Flinfo.LastWriteTime);
                ConsoleManager.BlueSendToConSole("Время последнего доступа: " + Flinfo.LastAccessTime);
            }
            catch(Exception e)
            {
                ConsoleManager.RedSendToConsole("InfoFile\r\n" + e.Message);
            }
        }

        //5 задание
        public void SetStructForBMPFileAndShowIt(string FileBmpName)
        {
            this.FileBmpName = Path.ChangeExtension(FileBmpName, ".bmp");
            StuctForBMPFile BMP = new StuctForBMPFile();
            try
            {
                BinaryReader BiRead = new BinaryReader(File.Open((FilesPath + "\\" + this.FileBmpName), FileMode.Open));//0
                BiRead.ReadBytes(2);//2
                BMP.SetName(this.FileBmpName);
                BMP.SetSize(BiRead.ReadInt32());//6
                BiRead.ReadBytes(12);//18
                BMP.SetWidth(BiRead.ReadInt32());//22
                BMP.SetHeight(BiRead.ReadInt32());//26
                BiRead.ReadBytes(2);//28
                BMP.SetBitPerPixel(BiRead.ReadInt16());//30
                BMP.SetCompression(BiRead.ReadInt32());//34
                BiRead.Close();

                ConsoleManager.BlueSendToConSole("Имя файла: " + BMP.Name);
                ConsoleManager.BlueSendToConSole("Размер: " + BMP.Size + " байт");
                ConsoleManager.BlueSendToConSole("Ширина:  " + BMP.Width + " пикселей");
                ConsoleManager.BlueSendToConSole("Высота:  " + BMP.Height + " пикселей");
                ConsoleManager.BlueSendToConSole("Бит на пиксель: " + Math.Pow(2, BMP.BitsPerPixel));
                string Compression = BMP.Compression == 0 ? "без сжатия" : BMP.Compression == 1 ? "8 bit RLE сжатие" : BMP.Compression == 2 ? "4 bit RLE сжатие" : "Неизвестное сжатие";
                ConsoleManager.BlueSendToConSole("Cжатие: " + Compression);
            }
            catch(Exception e)
            {
                ConsoleManager.RedSendToConsole("SetStructForBMPFileAndShowIt\r\n" + e.Message);
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
        public void BlueSendToConSole(string text)
        {
            BlueFontConsole();
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
        private void BlueFontConsole() => Console.ForegroundColor = ConsoleColor.Blue;
    }
    public struct StuctForBMPFile
    {
        public string Name;
        public int Size;
        public int Width;
        public int Height;
        public short BitsPerPixel;
        public int Compression;

        public void SetName(string Name) => this.Name = Name;
        public void SetSize(int Size) => this.Size = Size;
        public void SetWidth(int Width) => this.Width = Width;
        public void SetHeight(int Height) => this.Height = Height;
        public void SetBitPerPixel(short BitsPerPixel) => this.BitsPerPixel = BitsPerPixel;
        public void SetCompression(int Compression) => this.Compression = Compression;
    }

    class Lab6Manager
    {

        public string FileOutName = "Output.txt";
        public string FileInName = "Input.txt";
        public string FilePathName = @"..\..\Files";
        public string DirectoryName = @"Lab6_Temp";
        public string FileName = @"Lab.dat";
        /// <summary>
        /// FileOutName имя файла куда метод запишет byte and float
        /// FileInName имя файла куда метод запишет только float из файла FileOutName
        /// </summary>
        public void Ex2()
        {
            LibraryFileLab6 FileLab = new LibraryFileLab6();
            FileLab.SetNameFileForWrite(FileOutName);
            FileLab.SetNameFileForRrite(FileInName);
            FileLab.WriteInBinaryFileSetOfPairs();
            FileLab.ReadInBinaryFileSecondNumberAndWriteItinNewBinaryFile();
        }
        public void Ex3()
        {
            LibraryFileLab6 FileLab = new LibraryFileLab6(FileInName, FileOutName, FilePathName);
            string Text = FileLab.ReadTextFromFileAndReturnIt();
            string TextWithoutNums = FileLab.ReturnTextWithoutNumbers(Text);
            FileLab.WriteTextInFileAndCreateFile(TextWithoutNums);
            Console.WriteLine();
            
        }
        public void Ex4()
        {
            LibraryFileLab6 FileLab = new LibraryFileLab6();
            FileLab.SetFileNameForLabDotDat(FileName);
            FileLab.CreateDirectory();
            FileLab.CopyFileInMyDirectory();
            FileLab.CreateOutFile(FilePathName +"\\"+ DirectoryName, FileName);
            FileLab.ByteBackup();
            FileLab.InfoFile();
            
        }
        public void Ex5()
        {
            LibraryFileLab6 FileLab = new LibraryFileLab6();
            if (FileName == ".")
                foreach(string files in Directory.GetFiles(FilePathName))
                    Console.WriteLine(Path.GetFileName(files));
            else
            FileLab.SetStructForBMPFileAndShowIt(FileName);
            

        }
    }

    

}
