using System;

namespace Algorithms_lab_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Реализовать средствами ООП списки посредством массивов и с помощью указателей.Выполнить пример списка.");
            var list = new LinkedList<int>();
            list.Add(12);
            list.Add(32);
            list.Add(65);
            list.Add(234);
            list.Add(6);
            list.Delete(12);
            foreach(var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();



            Console.WriteLine("Реализовать средствами ООП двусвязные списки. Реализовать списки в виде класса.");
            var doublelist = new DoubleConnectedList<int>();
            doublelist.Add(1);
            doublelist.Add(3);
            doublelist.Add(6);
            doublelist.Add(-3);
            doublelist.Add(43);
            doublelist.Delete(1);
            foreach(var item in doublelist)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();



            Console.WriteLine("Реализовать средствами ООП кольцевые списки.");
            var circularlist = new CircularLinkedList<int>();
            circularlist.Add(1);
            circularlist.Add(-32);
            circularlist.Add(43);
            circularlist.Add(54);
            circularlist.Add(-5);
            circularlist.Add(0);
            circularlist.Delete(1);
            foreach(var item in circularlist)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();



            Console.WriteLine("Реализовать средствами ООП ограниченную очередь в виде массива.");
            var arrayqueue = new ArrayQueue<int>(5);
            arrayqueue.Enqueue(1);
            arrayqueue.Enqueue(2);
            arrayqueue.Enqueue(4);
            arrayqueue.Enqueue(5);
            arrayqueue.Enqueue(9);
            Console.Write(arrayqueue.Dequeue() + " ");
            Console.Write(arrayqueue.Dequeue() + " ");
            Console.Write(arrayqueue.Dequeue() + " ");
            Console.WriteLine();
            Console.WriteLine();



            Console.WriteLine("Реализовать средствами ООП ограниченный стек в виде массива");
            var arraystack = new ArrayStack<int>(5);
            arraystack.Push(21);
            arraystack.Push(12);
            arraystack.Push(1);
            arraystack.Push(3);
            arraystack.Push(4);
            Console.Write(arraystack.Pop() + " ");
            Console.Write(arraystack.Pop() + " ");
            Console.Write(arraystack.Pop() + " ");
            Console.WriteLine();
            Console.WriteLine();



            Console.WriteLine("Реализовать средствами ООП стек в виде связного списка");
            var doubleconnectedstack = new DoubleConnectedStack<int>();
            doubleconnectedstack.Push(12);
            doubleconnectedstack.Push(16);
            doubleconnectedstack.Push(-32);
            doubleconnectedstack.Push(0);
            Console.Write(doubleconnectedstack.Pop() + " ");
            Console.Write(doubleconnectedstack.Pop() + " ");
            Console.Write(doubleconnectedstack.Pop() + " ");
            Console.WriteLine();
            Console.WriteLine();



            Console.WriteLine("Реализовать средствами ООП с помощью стека вычисление постфиксных выражений.Вычислить пример: 2 * (3 + 2) * ((5 * 2 - 8) + (6 - 2 * 2))");
            var example = new PostfixExpressions();     
            Console.Write("Введите выражение: ");
            Console.WriteLine(example.Calculate(Console.ReadLine()));
           



        }
    }
}
