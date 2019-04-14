using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Labs.Collections
{
    /// <summary>
    /// Узел
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DoubleLinkedNode<T>
    {
        public DoubleLinkedNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public DoubleLinkedNode<T> Previous { get; set; }
        public DoubleLinkedNode<T> Next { get; set; }
    }

    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        DoubleLinkedNode<T> Head;
        DoubleLinkedNode<T> Tail;
        int count;

        public void Add(T data)//работает
        {
            /*Создать узел и передать ему значение
             * Обозначить голову для первого элемента
             * Задать ссылку на Next прошлому элементу
             * Задать ссылку на Previous этому элементу
             * Установить текущий узел как Хвост
             */
            DoubleLinkedNode<T> node = new DoubleLinkedNode<T>(data);
            if (Head == null)
                Head = node;
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }
            Tail = node;
            count++;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num">Начинать с 0</param>
        public void Remove(int num)
        {
            /* получаемый индекс увеличиваем на 1, что бы было удобно считать
             * Создаем объект головы, curriet
             * проходимся по ссылкам next в цикле, пока не найдем нужный
             * при нахождении элемента необходимо прошлому элементу дать next элемент
             * а следующему элементу дать previous элемент
             */
            num++;//самый первый элемент будет 1
            int currietnum = 1;
            DoubleLinkedNode<T> currietDel = Head;

            while (currietDel!= null && num<=count)
            {

                if (num == currietnum)
                {
                    break;
                }
                currietDel = currietDel.Next;
                currietnum++;
            }

            if (currietDel == null||num >count)// если случился худший случай, то выходим
                return;

            if (num == 1)// отмечены 2 базовых ситуации
            {
                /* В голове установим новую ссылку, Head.Next будет батей
                 */
                currietDel = currietDel.Next;
                currietDel.Previous = null;

                Head = currietDel;
            }
            else if (num == count)
            {
                currietDel = Tail.Previous;
                currietDel.Next = null;
                Tail = currietDel;
            }
            else
            {
                currietDel.Next.Previous = currietDel.Previous;
                currietDel.Previous.Next = currietDel.Next;
            }


            count--;
        }
        /// <summary>
        /// Замена по элементу
        /// </summary>
        /// <param name="num"></param>
        /// <param name="data"></param>
        public void Substitution(int num,T data)
        {
            /*
             * скопировать Remove и вместо удаления сделать замену Data
             */
            num++;//самый первый элемент будет 1
            int currietnum = 1;
            DoubleLinkedNode<T> currietDel = Head;

            while (currietDel != null && num <= count)
            {

                if (num == currietnum)
                {
                    break;
                }
                currietDel = currietDel.Next;
                currietnum++;
            }

            if (currietDel == null || num > count)// если случился худший случай, то выходим
                return;

            if (num == 1)
            {
                currietDel.Data = data;

                Head = currietDel;
            }
            else if (num == count)
            {
                currietDel.Data = data;
                Tail = currietDel;
            }
            else
            {
                currietDel.Data = data;
            }
        }
        public T[] ReturnElements()
        {
            T[] kek = new T[count];
            DoubleLinkedNode<T> currietDel = Head;
            for (int i =0; currietDel!=null;i++)
            {
                kek[i] = currietDel.Data;
                currietDel = currietDel.Next;
            }
            return kek;
        }
        
        public int Count()
        {
            return count;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoubleLinkedNode<T> current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public bool Contains(T data)
        {
            DoubleLinkedNode<T> current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

    }


}
