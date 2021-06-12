using System;
using System.Collections.Generic;

namespace Algorithms
{
    class Start
    {
        static void Main(string[] args)
        {
            var array = new int[] { 9, 44, 50, 0, -7, 52, 6, 10, 45, -12, 48 };
            //var array = new int[] { 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35 };
            BinaryTree tree = new BinaryTree(array);

            tree.PreOrder(tree.Node);
            Console.WriteLine();
            tree.PostOrder(tree.Node);
            Console.WriteLine();
            tree.InOrder(tree.Node);
            Console.WriteLine();

            Console.Write($"depth: ");
            int depth = Int32.Parse(Console.ReadLine());
            tree.Depth(tree.Node, depth);

            Console.WriteLine();
            Console.WriteLine($"Seaerched num: {tree.Search(50, out var asd).Data}");
            Console.WriteLine();

            tree.Insert(5);

            tree.PreOrder(tree.Node);
            Console.WriteLine();
            tree.PostOrder(tree.Node);
            Console.WriteLine();
            tree.InOrder(tree.Node);
            Console.WriteLine();

            tree.Remove(44);

            tree.PreOrder(tree.Node);
            Console.WriteLine();
            tree.PostOrder(tree.Node);
            Console.WriteLine();
            tree.InOrder(tree.Node);
            Console.WriteLine();

            tree.Delete();

            tree.PreOrder(tree.Node);
            Console.WriteLine();
            tree.PostOrder(tree.Node);
            Console.WriteLine();
            tree.InOrder(tree.Node);
            Console.WriteLine();
        }
    }
}
