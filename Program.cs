using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees2
{
    /*
     * Tasks:
     * 1) Complete the implementation of the Node methods
     * 2) Print out the tree using the different tree traversal metods
     * 3) Test findNote() and deleteNode()
     *
     *
     */
    class Node
    {
        // Attributes
        private Node left;
        private Node right;
        private string item;

        //Methods
        public Node(string item)
        {
            this.left = null;
            this.right = null;
            this.item = item;
        }
        public void addNode(string item, Node current)
        {
            int compOut = string.Compare(item, current.item);          // Comparison Outcome
            // -1 means string1 is less than string2
            // 0 means string 1 is the same as string2
            // 1 means string 1 is greater than string2

            if (compOut == -1 || compOut == 0)
            {
                if (current.left != null) addNode(item, current.left);
                else current.left = new Node(item);
            }
            else if (compOut == 1)
            {
                if (current.right != null) addNode(item, current.right);
                else current.right = new Node(item);
            }
        }
        public Boolean findNode(string item, Node current)
        {
            int compOut = string.Compare(item, current.item);          // Comparison Outcome
            // -1 means string1 is less than string2
            // 0 means string 1 is the same as string2
            // 1 means string 1 is greater than string2

            if (compOut == 0) return true;
            else if (compOut == -1 && current.left != null) return findNode(item, current.left);
            else if (compOut == 1 && current.right != null) return findNode(item, current.right);
            return false;
        }
        public Boolean deleteNode(string item, Node current)
        {
            int compOut = string.Compare(item, current.item);          // Comparison Outcome
            if (compOut == 0) return true;
            else if (compOut == -1 && current.left != null)
            {
                if (deleteNode(item, current.left))
                {
                    current.left = null;
                    Console.WriteLine("Successfully Deleted {0}", item);
                }
            }
            else if (compOut == 1 && current.right != null)
            {
                if (deleteNode(item, current.right))
                {
                    current.right = null;
                    Console.WriteLine("Successfully Deleted {0}", item);
                }
            }
            return false;
        }
        public void printTree(string input)
        {
            switch (input.ToLower())
            {
                case "preorder":
                    preorder(this);
                    break;
                case "inorder":
                    inorder(this);
                    break;
                case "postorder":
                    postorder(this);
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
        private void preorder(Node current)
        {
            if (current != null)
            {
                Console.WriteLine(current.item);
                preorder(current.left);
                preorder(current.right);
            }
        }
        private void inorder(Node current)
        {
            if (current != null)
            {
                inorder(current.left);
                Console.WriteLine(current.item);
                inorder(current.right);
            }
        }
        private void postorder(Node current)
        {
            if (current != null)
            {
                postorder(current.left);
                postorder(current.right);
                Console.WriteLine(current.item);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Node root = null;

            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };


            // process all the nodes on the array
            //
            foreach (var mon in months)
            {
                if (root == null)
                    root = new Node(mon);
                else
                    root.addNode(mon, root);
            }

            // print out the tree using different traversal methods
            //

            root.printTree("");
            Console.Write("\n");
            root.printTree("preorder");
            Console.Write("\n");
            root.printTree("inorder");
            Console.Write("\n");
            root.printTree("postorder");
            Console.Write("\n");

            // Test the findNote() and deleteNode()

            foreach (var mon in months)
                if (root.findNode(mon, root)) Console.WriteLine("Found {0}", mon);

            Console.Write("\n");

            foreach (var mon in months)
                root.deleteNode(mon, root);
            //Can't delete January since it is the root
            //After deleting Febuary and March, only January will be left, since all the other nodes are connected to Febuary and March

            Console.ReadKey();
        }
    }
}