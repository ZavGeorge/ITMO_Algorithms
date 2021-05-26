using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_lab_7
{
    public class DoubleConnectedList<T>: IEnumerable
    {
        public DoubleConnected<T> Head { get; set; }
        public DoubleConnected<T> Tail { get; set; }
        public int Count { get; set; }
        public DoubleConnectedList()
        {

        }

        public DoubleConnectedList(T data)
        {
            var item = new DoubleConnected<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }

        public void Add(T data)
        {
            var item = new DoubleConnected<T>(data);

            if (Count == 0)
            {
                Head = item;
                Tail = item;
                Count = 1;
            }

            Tail.Next = item;
            item.Previous = Tail;
            Tail = item;
            Count++;
        }
        public void Delete(T data)
        {

            var current = Head;
            while(current != null)
            {
                if (current.Data.Equals(data))
                {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                    Count--;
                    return;
                }
                current = current.Next;
            }
        }

        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }



    }
}
