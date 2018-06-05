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

        public static void NthLargest(Node node, int n, ref int count)
        {
            if (node == null)
                return;

            // process larger nodes on the right
            if (node.right != null)
                NthLargest(node.right, n, ref count);

            // process this node
            if (count < n)
            {
                ++count;
                if (count == n)
                {
                    Console.WriteLine("Nth ({0}) node key is: {1}", n, node.Key);
                    return;
                }
            }
            else
            {
                return;
            }

            // Process nodes on the left if necessary
            if (node.left != null)
                NthLargest(node.left, n, ref count);
        }

    }

}
