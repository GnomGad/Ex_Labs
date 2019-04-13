using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Labs.Game
{  
    /// <summary>
    /// Главный класс игры
    /// </summary>
    class LoopGame
    {
        
        public LoopList<string> NamesOfParticiant = new LoopList<string>();
        int participant;
        public string Name { get; set; }
        public string Text { get; set; }
        int Cycle;
        /// <summary>
        /// Будет использован минимум т.е есть 5
        /// </summary>
        public LoopGame(int participant,string Text)
        {
            //Установка количества участников и текста
            this.participant = participant;
            this.Text = Text;

            //установка базовых имен
            SetLoopList();

            //выбор имени для старта
            SetName();

            // результат игры
            Console.WriteLine("Выбор пал на тебя "+NamesOfParticiant.ReturnName(Text,Name));
            
        }
        void SetLoopList()
        {
            NamesOfParticiant.Add("Игорь");
            NamesOfParticiant.Add("Влад");
            NamesOfParticiant.Add("Аня");
            NamesOfParticiant.Add("Женя");
            NamesOfParticiant.Add("Дима");
            if(participant >= 6)
                NamesOfParticiant.Add("Катя");
            if(participant >= 7)
                NamesOfParticiant.Add("Юля");
            if(participant >= 8)
                NamesOfParticiant.Add("Миша");
            if(participant >= 9)
                NamesOfParticiant.Add("Коля");
            if(participant == 10)
                NamesOfParticiant.Add("Андрей");
        }
        void SetName()
        {
            foreach (string k in NamesOfParticiant)
                Console.WriteLine("   "+k);

            while (true)
            {
                Console.WriteLine("Введите имя");
                this.Name = Console.ReadLine();
                foreach (string k in NamesOfParticiant)
                    if (k == Name)
                        return;
            }
            
        }
        string ReturnName(string text)
        {
           return NamesOfParticiant.ReturnName(text, Name);
        }
    }

    class LoopNode<T>
    {
        public LoopNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public LoopNode<T> Next { get; set; }
    }

    class LoopList<T> : IEnumerable<T>
    {
        LoopNode<T> Head;
        LoopNode<T> Tail;
        int count;
        public void Add(T data)
        {
            LoopNode<T> node = new LoopNode<T>(data);
            // если список пуст
            if (Head == null)
            {
                Head = node;
                Tail = node;
                Tail.Next = Head;
            }
            else
            {
                node.Next = Head;
                Tail.Next = node;
                Tail = node;
            }
            count++;
        }

        public string ReturnName(string txt,string name)
        {
            int CountWords;
            //Цикл-проверка на корявость строки
            while (true)
            {
                CountWords = ReturnCount(txt);//число слов
                if (CountWords == 0)
                {
                    Console.WriteLine("Введите нормальный текст");
                    txt = Console.ReadLine();
                }
                else
                    break;
            }
            LoopNode<T> current = Head;
            while (true)
            {
                //Отсюда стартуем
                if(current.Data.ToString() == name)
                {
                    //тут уже считаем считалочкой
                    for(int i =0;i<CountWords;i++)
                    {
                        current = current.Next;
                    }
                    return current.Data.ToString();
                }
                current = current.Next;

            }
            
        }

        int ReturnCount(string txt)
        {
            txt =txt.TrimStart().TrimEnd();

            int count1 = 0;
            for(int i =0;i<txt.Length;i++)
            {
                if (txt[i] == ' ')
                {
                    count1++;
                    if (i + 1 < txt.Length && txt[i + 1] == ' ')
                        count1--;
                }
                
            }
            if (count1 > 0|| txt.Length > 0)
                return count1 + 1;
            return count1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            LoopNode<T> current = Head;
            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            while (current != Head);
        }
    }
}
