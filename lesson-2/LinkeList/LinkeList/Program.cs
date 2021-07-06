using System;

namespace LinkedList
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }


    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        public int GetCount(); // возвращает количество элементов в списке
        public void AddNode(int value);  // добавляет новый элемент списка
        public void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        public void RemoveNode(int index); // удаляет элемент по порядковому номеру
        public void RemoveNode(Node node); // удаляет указанный элемент
        public Node FindNode(int searchValue); // ищет элемент по его значению
    }

    class ListNode: ILinkedList
    {
        Node node = new Node { Value = 1};
                
        public int GetCount() // возвращает количество элементов в списке
        {
            var node1 = node;
            int count = 0;
            if (node.Value != 0)
            {
                count = 1;
                while (node1.NextNode != null)
                {
                    node1 = node1.NextNode;
                    count = count + 1;
                }
            }
            return (count);
        }
        public void AddNode(int value)  // добавляет новый элемент списка
        {
            var node1 = node;
            while (node1.NextNode != null)
            {
                node1 = node1.NextNode;
            }
            Node newNode = new Node { Value = value };
            node1.NextNode = newNode;
            newNode.PrevNode = node1;
        }
        public void AddNodeAfter(Node node, int value) // добавляет новый элемент списка после определённого элемента
        {
            var node1 = node;
            Node newNode = new Node { Value = value };
            if (node1.NextNode != null)
            {
                node1.NextNode.PrevNode = newNode;
                newNode.NextNode = node1.NextNode;
            }
                node1.NextNode = newNode;
                newNode.PrevNode = node1;
        }
        public void RemoveNode(int index) // удаляет элемент по порядковому номеру
        {
            var node1 = node;
            for (int i = 0; i < index-1; i++)
            {
                node1 = node1.NextNode;
            }
            node1.NextNode.PrevNode = node1.PrevNode;
            node1.PrevNode.NextNode = node1.NextNode;
        }
        public void RemoveNode(Node node) // удаляет указанный элемент
        {
            var node1 = node;
            node1.NextNode.PrevNode = node1.PrevNode;
            node1.PrevNode.NextNode = node1.NextNode;
        }
        public Node FindNode(int searchValue) // ищет элемент по его значению
        {
            int n = GetCount();
            var node1 = node;
            for (int i = 0; i < n-1; i++)
            {
                if (searchValue == node1.Value) break;
                node1 = node1.NextNode;
            }
            return (node1);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            ListNode node = new ListNode();
            node.AddNode(2);
            node.AddNode(11);
            node.AddNode(55);
            int n = node.GetCount();
            Console.WriteLine(n);
            var node1 = node;
            var afterNode = node.FindNode(11);
            node.AddNodeAfter(afterNode, 133);
            n = node.GetCount();
            Console.WriteLine(n);
            var delNode = node.FindNode(2);
            node.RemoveNode(delNode);
            n = node.GetCount();
            Console.WriteLine(n);
            node.RemoveNode(3);
            n = node.GetCount();
            Console.WriteLine(n);
        }
    }
}
