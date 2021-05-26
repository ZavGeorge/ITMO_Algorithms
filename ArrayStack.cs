using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_lab_7
{
    public class ArrayStack<T>
    {
        private T[] items;
        private T head => items[0];
        private T Tail => items[Count > 0 ? Count - 1 : 0];
        private int MaxCount => items.Length;
        public int Count { get; private set; }

        public ArrayStack(int size)
        {
            items = new T[size];
            Count = 0;
        }

        public ArrayStack(int size, T data)
        {
            items = new T[size];
            items[0] = data;
            Count = 1;
        }

        public void Push(T data)
        {
            if (Count < MaxCount)
            {
                var result = new T[MaxCount];
                for (int i = 0; i < Count; i++)
                {
                    result[i] = items[i];
                }
                result[Count] = data;

                items = result;
                Count++;
            }
            
        }

        public T Pop()
        {
            var item = Tail;
            Count--;
            return item;
        }
    }
}
