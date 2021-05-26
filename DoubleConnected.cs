using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_lab_7
{
    public class DoubleConnected<T> 
    {
        public T Data { get; set; }
        public DoubleConnected<T> Next { get; set; }

        public DoubleConnected<T> Previous { get; set; }

        public DoubleConnected(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }

       

    }
}
