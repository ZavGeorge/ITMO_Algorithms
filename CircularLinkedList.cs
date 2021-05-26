using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_lab_7
{
    public class CircularLinkedList<T> : IEnumerable
    {
        public DoubleConnected<T> Head { get; set; }
        public int Count { get; set; }

        public CircularLinkedList() { }
        public CircularLinkedList(T data)
        {
            Head = new DoubleConnected<T>(data);
            Head.Next = Head;
            Head.Previous = Head;
            Count = 1;
        }
        public void Add(T data)
        {
            if(Count == 0)
            {
                Head = new DoubleConnected<T>(data);
                Head.Next = Head;
                Head.Previous = Head;
                Count = 1;
                return;
            }
            var item = new DoubleConnected<T>(data);
            item.Next = Head;
            item.Previous = Head.Previous;
            Head.Previous.Next = item;
            Head.Previous = item;
            Count++;

        } 

        public void Delete(T data)
        {
            if (Head.Data.Equals(data))
            {
                Head.Previous = Head.Previous;
                Head.Previous.Next = Head.Next;
                Count--;
                Head = Head.Next;
                return;
            }

            var current = Head;
            for(int i = Count; i>0; i--)
            {
                if (current != null && current.Data.Equals(data))
                {
                    current.Next.Previous = current.Previous;
                    current.Previous.Next = current.Next;
                    Count--;
                    return;
                }
                current = current.Next;
            }
        }
        public IEnumerator GetEnumerator()
        {
            var current = Head;
            for(int i=0; i< Count; i++)
            {
                yield return current.Data;
                current = current.Next;
            }
        }





    }
}
