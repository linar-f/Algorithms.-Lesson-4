using System;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree(); // При объявлении дерева, вершина создается сразу со значением 1
            tree.AddItem(2);
            tree.AddItem(3);
            tree.AddItem(4);
            tree.AddItem(5);
            tree.AddItem(6);
            tree.AddItem(7);
            tree.AddItem(8);
            tree.AddItem(9);
            tree.AddItem(10);
            tree.GetNodeByValue(3);
            tree.RemoveItem(5);
            tree.PrintTree();
            Console.ReadLine();
        }
    }
}
