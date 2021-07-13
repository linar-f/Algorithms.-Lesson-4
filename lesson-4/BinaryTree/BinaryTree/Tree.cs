using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class Node
    {
        public int Value { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
        public Node Parent { get; set; }
    }

    class Tree
    {
        Node node = new Node() { Value = 1 };

        public void AddItem(int value)
        {
            var node1 = node;
            Queue<Node> bufer= new Queue<Node>();
            bufer.Enqueue(node1);
            bool stop = false;
            while (stop != true)
            {
                var element = bufer.Dequeue();
                if (element.LeftChild != null)
                {
                    bufer.Enqueue(element.LeftChild);
                }
                if (element.RightChild != null)
                {
                    bufer.Enqueue(element.RightChild);
                }
                if (element.LeftChild == null)
                {
                    node1 = element;
                    Node newNode = new Node { Value = value };
                    node1.LeftChild = newNode;
                    node1.LeftChild.Parent = node1;
                    stop = true;
                }
                else if (element.RightChild == null)
                {
                    node1 = element;
                    Node newNode = new Node { Value = value };
                    node1.RightChild = newNode;
                    node1.RightChild.Parent = node1;
                    stop = true;
                }
            }
        }

        public Node GetNodeByValue(int value)
        {
            var node1 = node;
            Queue<Node> bufer = new Queue<Node>();
            bufer.Enqueue(node1);
            bool stop = false;
            while (stop != true)
            {
                Node element = bufer.Dequeue();
                if (element.Value == value)
                {
                    node1 = element;
                    stop = true;
                }
                else
                {
                    if (element.LeftChild != null)
                    {
                        bufer.Enqueue(element.LeftChild);
                    }
                    if (element.RightChild != null)
                    {
                        bufer.Enqueue(element.RightChild);
                    }
                }
            }
            return (node1);
        }

        public void PreOrderTravers(Node root)
        {
            if (root != null)
            {
                Console.Write($"{root.Value}");
                if (root.LeftChild != null || root.RightChild != null)
                {
                    Console.Write('(');
                    if (root.LeftChild != null)
                    {
                        PreOrderTravers(root.LeftChild);
                    }
                    else
                    {
                        Console.Write("null");
                    }
                    Console.Write(',');
                    
                    if (root.RightChild != null)
                    {
                        PreOrderTravers(root.RightChild);
                    }
                    else
                    {
                        Console.Write("null");
                    }
                    Console.Write(')');
                }
            }
        }

        public void PrintTree()
        {
            PreOrderTravers(node);
        }

        public void RemoveItem(int value)
        {
            Node node1 = GetNodeByValue(value);
            if (node1.Parent != null)
            {
                if (node1.Parent.LeftChild.Value == value)
                {
                    node1.Parent.LeftChild = null;
                }
                if (node1.Parent.RightChild.Value == value)
                {
                    node1.Parent.RightChild = null;
                }
            }
        }
    }
}
