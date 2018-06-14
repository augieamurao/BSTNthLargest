using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTNthLargest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting BSTNthLargest.Main()");

            // Build the BST
            //                      30
            //                 20         40
            //              10    25    35   50
            //
            Node n = null;
            NodeUtil.InsertNode(ref n, 30);
            NodeUtil.InsertNode(ref n, 20);
            NodeUtil.InsertNode(ref n, 10);
            NodeUtil.InsertNode(ref n, 25);
            NodeUtil.InsertNode(ref n, 40);
            NodeUtil.InsertNode(ref n, 35);
            NodeUtil.InsertNode(ref n, 50);
            
            int c = 0;
            
            NodeUtil.NthLargest(n, 5, ref c );
            //NodeUtil.NthLargest_NoRecur(n, 5, c);
        }

    }

    class Node
    {
        public Node(int k)
        {
            Key = k;
            left = null;
            right = null;
        }
        public int Key { get; set; }
        public Node left;
        public Node right;
    }

    class NodeUtil
    {
        public static void InsertNode(ref Node node, int key)
        {
            if (node == null)
            {
                node = new Node(key);
            }

            if (key > node.Key)
            {
                InsertNode(ref node.right, key);
            }
            else if (key < node.Key)
            {
                InsertNode(ref node.left, key);
            }
        }
        //TODO: Make it stop after count == n
        public static void NthLargest(Node node, int n, ref int count)
        {
            if ((node == null) || (count == n))
                return;

            NthLargest(node.right, n, ref count);

            // process this node
            ++count;
            if (count == n)
            {
                Console.WriteLine("Nth ({0}) node key is: {1}", n, node.Key);
                return;
            }
            
            NthLargest(node.left, n, ref count);
        }

        public static void NthLargest_NoRecur(Node node, int n, int count)
        {
            Stack<Node> stack = new Stack<Node>();

            if (node == null)
            {
                return;
            }

            Node curNode = node;
            while (true)
            {
                if ((stack.Count() == 0) && (curNode == null))
                {
                    return;
                }

                // find the largest node in this subtree
                while (curNode != null)
                {
                    stack.Push(curNode);
                    curNode = curNode.right;
                }

                curNode = stack.Pop();
                Console.WriteLine("Node: {0}", curNode.Key);


                curNode = curNode.left;
            }
 
        }
    }
}
