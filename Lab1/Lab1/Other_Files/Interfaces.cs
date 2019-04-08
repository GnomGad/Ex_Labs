using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs.Interfaces
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
    interface ISearchString
    {
        SearchString SearchString { get; }
        void InitializationSearchString(SearchString SearchString);
        void SimpleSearch(SearchString searchString);
        void KMPSearch(SearchString searchString);
        void BMSearch(SearchString searchString);
    }
    /// <summary>
    /// Интерфейс для массива
    /// </summary>
    interface IArray 
    {
        long Position { get;  }
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
    /// <summary>
    /// интерфейс для времени
    /// </summary>
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
    /// <summary>
    /// Шоб не завтыкать с тем, что мне нужно
    /// </summary>
    interface IMenu
    {
        /// <summary>
        /// Логика кейсов
        /// </summary>
        void Main();
        /// <summary>
        /// Волшебный метод инита стартовых значений в лист
        /// </summary>
        void Initialize();
        /// <summary>
        /// Показать меню
        /// </summary>
        void Show();
        /// <summary>
        /// Добавить элемент
        /// </summary>
        void Add();
        /// <summary>
        /// Удалить элемент
        /// </summary>
        void Delete();
        /// <summary>
        /// Обновление элемента
        /// </summary>
        void Update();
        /// <summary>
        /// Поиск элемента
        /// </summary>
        void Search();
        /// <summary>
        /// Показать лог
        /// </summary>
        void Log();
    }
    /// <summary>
    /// Доболнительный интерфейс  к логу
    /// что бы не засирать логику интерфейса ,menu
    /// </summary>
    interface IMenuLog
    {
        /// <summary>
        /// Для особых действий, что бы их отметить
        /// </summary>
        /// <param name="txet"></param>
        /// <param name="act"></param>
        /// <param name="dt"></param>
        void BuildLog(string txet, ForLogAction act, DateTime dt);
        /// <summary>
        /// Для действий,которые не важные, но важен переход времени
        /// </summary>
        void BuildLog();
    }
    
}
