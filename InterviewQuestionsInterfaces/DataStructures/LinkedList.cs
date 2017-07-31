using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.DataStructures
{
    class LinkedList
    {
        private Node Head = null;
        private Node Tail = null;

        LinkedList()
        {

        }

        public void InsertFirst(object value)
        {
            Node newNode = new Node { Next = Head, Value = value };
            Head = newNode;
            if (Tail == null)
                Tail = newNode;
        }

        public void AddLast(object value)
        {
            Node newNode = new Node { Value = value };
            if (Head != null && Tail != null)
                Tail.Next = newNode;
            else
            {
                Head = newNode;
                Tail = newNode;
            }
        }

        public object RemoveFirst()
        {
            if (Head == null)
                return null;
            Node ret = Head;
            Head = Head.Next;
            return ret;
        }

        public object RemoveLast()
        {
            if (Tail == null)
                return null;
            Node ret = Tail;
            Tail = null;
            return ret;
        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        class Node
        {
            public Node Next;
            public object Value;
        }
    }
}
