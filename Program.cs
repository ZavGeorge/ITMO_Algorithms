using System;

namespace Algorithms_lab_6
{
    class Program
    {
        static void Main(string[] args)
        {

            var tree = new Tree<int>();

            tree.Add(31);
            tree.Add(54);
            tree.Add(123);
            tree.Add(13);
            tree.Add(18);
            tree.Add(3);
            tree.Add(20);
            tree.Add(48);

            var tree1 = new Tree<String>();

            tree1.Add("a");
            tree1.Add("b");
            tree1.Add("c");
            tree1.Add("d");
            tree1.Add("e");
            tree1.Add("f");

            foreach (var item in tree.ForwardDirection())
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine();
            foreach (var item in tree.PostOrder())
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
            foreach (var item in tree.ReverseOrder())
            {
                Console.Write(item + ", ");
            }


            var tree2 = new Tree<String>();

            tree2.AddExp("*", "2");
            tree2.AddExp("-", "8");
            tree2.AddExp("/", "5");
            tree2.AddExp("*", "1");
            tree2.AddExp("2", "3");

            Console.WriteLine("");
            foreach (var item in tree2.ReverseOrder())
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine(tree2.ResultExpression());




        }
    }
}
