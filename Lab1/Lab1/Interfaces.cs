using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs
{
    interface Interfaces
    {
    }
    /// <summary>
    /// Интерфейс для поиска
    /// </summary>
    interface ISearch
    {
        
        void LinearSearch(int[] array,int element);
        void BinarySearch(int[] array,int element);
        void InterpolationSearch(int[] array,int element);
        
    }
    /// <summary>
    /// Интерфейс для массива
    /// </summary>
    interface IArray 
    {
        int Position { get;  }
        int[] ArrayInt { get; set; }
        void InitializationArray(int[] array);


    }
    /// <summary>
    /// Интерфейс для чтения и записи
    /// </summary>
    interface IReadFile
    {
        string PathFile{ get; }
        void ReadBinaryFile();
    }
    interface ITime
    {
        DateTime Start { get;  }
        DateTime End { get;  }
        TimeSpan Interval { get;  }

        void SetStart();
        void SetEnd();
        void SetInterval();
        void WriteInConsoleInfo();
    }
    
}
