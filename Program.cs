using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
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
        private Node root;

        //Methods
        public Node(string item)
        {
            this.left = null;
            this.right = null;
            this.item = item;
        }
        public void addNode(string item)
        {
            if (root == null) root = this;

            Node current = root;
            bool added = false;
            while (!added)
            {
                int compOut = string.Compare(item, this.item);          // Comparison Outcome
                // -1 means string1 is less than string2
                // 0 means string 1 is the same as string2
                // 1 means string 1 is greater than string2

                if (compOut == -1 || compOut == 0)
                {
                    if (this.left != null) current = current.left;
                    else
                    {
                        this.left = new Node(item);
                        added = true;
                    }
                }
                else if (compOut == 1)
                {
                    if (this.right != null) current = current.right;
                    else
                    {
                        this.right = new Node(item);
                        added = true;
                    }
                }
            }
        }
        public Boolean findNode(string item)
        {
            if (root == null) root = this;

            Node current = root;
            bool found = false;
            int compOut;
            while (!found)
            {
                compOut = string.Compare(item, this.item);          // Comparison Outcome
                // -1 means string1 is less than string2
                // 0 means string 1 is the same as string2
                // 1 means string 1 is greater than string2

                if (compOut == 0) found = true;
                if (compOut == -1)
                {
                    if (this.left != null) current = current.left;
                    else break;
                }
                else if (compOut == 1)
                {
                    if (this.right != null) current = current.right;
                    else break;
                }
            }
            return found;
        }
        public void deleteNote(string item)
        {
            if (root == null) root = this;

            Node current = root;
            Node previous = null;
            bool found = false;
            int compOut = -2;
            int prevCompOut = -2;
            while (!found)
            {
                prevCompOut = compOut;
                compOut = string.Compare(item, this.item);          // Comparison Outcome
                // -1 means string1 is less than string2
                // 0 means string 1 is the same as string2
                // 1 means string 1 is greater than string2

                if (compOut == 0) found = true;
                if (compOut == -1)
                {
                    if (this.left != null)
                    {
                        previous = current;
                        current = current.left;
                    }
                    else break;
                }
                else if (compOut == 1)
                {
                    if (this.right != null)
                    {
                        previous = current;
                        current = current.right;
                    }
                    else break;
                }
            }

            if (found && prevCompOut == -1) previous.left = null;
            else if (found && prevCompOut == 1) previous.right = null;
            else Console.WriteLine("Item not found!");
        }
        void printTree() { }
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
                    root.addNode(mon);
            }

            // print out the tree using different traversal methods
            //

            // Test the findNote() and deleteNode()
        }
    }
}