using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_lab_7
{
    public class DoubleConnectedStack<T>
    {

        public DoubleConnected<T> Head { get; set; }
        public int Count { get; set; }

        public DoubleConnectedStack()
        {
            Head = null;
            Count = 0;
        }

        public DoubleConnectedStack(T data)
        {
            var item = new DoubleConnected<T>(data);
            Head = item;
            Count = 1;
        }

        public void Push(T data)
        {
            var item = new DoubleConnected<T>(data);
            item.Previous = Head;
            Head = item;
            Count++;
        }
        public T Pop()
        {
            var item = Head;
            Head = Head.Previous;
            Count--;
            return item.Data;
        }

        public T Peek()
        {
            return Head.Data;
        }


    }
}
