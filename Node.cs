using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_lab_6
{
    class Node<T> 
        where T: IComparable, IComparable<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get;  set; }
        public Node<T> Right { get;  set; }
        public Node(T data)
        {
            Data = data;
        }

        public Node(T data, Node<T> left, Node<T> right) 
        {
            Data = data;
            Left = left;
            Right = right;
        }

        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }


        public void Add(T data)
        {
            var node = new Node<T>(data);

            if (node.CompareTo(Data) == -1) 
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Add(data);
                }
            }
            else
            {
                if ( Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Add(data);
                }
            }
        }

        public void AddExp(T data, T right)
        {
            var node = new Node<T>(data);

            if (node.Data.ToString() == "/" || node.Data.ToString() == "*" || node.Data.ToString() == "+" || node.Data.ToString() == "-")
            {
                if (Left == null)
                {
                    Left = node;
                    Left.Right = new Node<T>(right);
                }
                else
                {
                    Left.AddExp(data, right);
                }
                
            }
            else
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.AddExp(data, right);
                }
            }

        }

    }
}
