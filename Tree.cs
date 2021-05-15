using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_lab_6
{
    class Tree<T> 
        where T: IComparable, IComparable<T>
    {
        public Node<T> Root { get; private set; }
        public double result { get; private set; }
        public int Count { get; private set; }

        public void Add(T data)
        { 

            if ( Root == null)
            {
                Root = new Node<T>(data);
                Count = 1;
                return;
            }
            Root.Add(data);
            Count++;

        }

        public List<T> ForwardDirection()
        {
            var list = new List<T>();

            if (Root == null)
            {
                return list;
            }
            return ForwardDirection(Root);
        }
        private List<T> ForwardDirection(Node<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                list.Add(node.Data);
                if (node.Left != null)
                {
                    list.AddRange(ForwardDirection(node.Left));
                }
                if (node.Right != null)
                {
                    list.AddRange(ForwardDirection(node.Right));
                }
            }
            return list;
        }


        public List<T> PostOrder()
        {
            var list = new List<T>();

            if (Root == null)
            {
                return list;
            }
            return PostOrder(Root);
        }
        private List<T> PostOrder(Node<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(PostOrder(node.Left));
                }
                if (node.Right != null)
                {
                    list.AddRange(PostOrder(node.Right));
                }
                list.Add(node.Data);
            }
            return list;
        }


        public List<T> ReverseOrder()
        {
            var list = new List<T>();

            if (Root == null)
            {
                return list;
            }
            return ReverseOrder(Root);
        }
        private List<T> ReverseOrder(Node<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(ReverseOrder(node.Left));
                }
                list.Add(node.Data);
                if (node.Right != null)
                {
                    list.AddRange(ReverseOrder(node.Right));
                }
            }
            return list;
        }

        public void AddExp(T data,  T right)
        {

            if (Root == null)
            {
                Root = new Node<T>(data);
                Root.Right = new Node<T>(right);
                Count = 1;
                return;
            }
            Root.AddExp(data, right);
            Count++;
        }
        
        public double ResultExpression()
        {
            result = 0;
            if (Root == null)
            {
                return result;
            }
            ResultExpression(Root);
            return result;
        }

        private void ResultExpression(Node<T> node)
        {
            if (node != null)
            {
                if (node.Data.ToString() == "/" || node.Data.ToString() == "*" || node.Data.ToString() == "+" || node.Data.ToString() == "-")
                {
                    if (node.Left.Data.ToString() == "/" || node.Left.Data.ToString() == "*" || node.Left.Data.ToString() == "+" || node.Left.Data.ToString() == "-")
                    {
                        ResultExpression(node.Left);

                        if (node.Data.ToString() == "/")
                        {
                            result = result / Convert.ToDouble(node.Right.Data);
                        }
                        if (node.Data.ToString() == "-")
                        {
                            result = result - Convert.ToDouble(node.Right.Data);
                        }
                        if (node.Data.ToString() == "+")
                        {
                            result = result + Convert.ToDouble(node.Right.Data);
                        }
                        if (node.Data.ToString() == "*")
                        {
                            result = result * Convert.ToDouble(node.Right.Data);
                        }
                    }
                    else
                    {
                        if (node.Data.ToString() == "/")
                        {
                            result = Convert.ToDouble(node.Left.Data) / Convert.ToDouble(node.Right.Data);
                        }
                        if (node.Data.ToString() == "-")
                        {
                            result = Convert.ToDouble(node.Left.Data) - Convert.ToDouble(node.Right.Data);
                        }
                        if (node.Data.ToString() == "+")
                        {
                            result = Convert.ToDouble(node.Left.Data) + Convert.ToDouble(node.Right.Data);
                        }
                        if (node.Data.ToString() == "*")
                        {
                            result = Convert.ToDouble(node.Left.Data) * Convert.ToDouble(node.Right.Data);
                        }
                    }
                }
                else
                {
                    result = Convert.ToDouble(node.Data);
                }
            
            }
        }




    }
}
