using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.DataStructures
{
    class Graph
    {
        public Node[] Nodes;
        
        public class Node
        {
            public string Name;
            public Node[] Children;
            public bool Visited = false;
        }

        public void DepthFirstSearch(Node root)
        {
            if (root == null)
                return;
            Visit(root);
            root.Visited = true;
            foreach (Node n in root.Children)
            {
                if (n.Visited == false)
                    DepthFirstSearch(n);
            }
        }

        public void BreadthFirstSearch(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            root.Visited = true;
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                Node r = queue.Dequeue();
                Visit(r);
                foreach (Node n in r.Children)
                {
                    if (n.Visited == false)
                    {
                        n.Visited = true;
                        queue.Enqueue(n);
                    }
                }
            }
        }

        public void Visit(Node node)
        {
            Console.WriteLine("At node " + node.Name);
        }
    }
}
