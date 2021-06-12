using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class BinaryTree
    {
        public class BinaryTreeNode
        {
            public int Data;

            public BinaryTreeNode Left;
            public BinaryTreeNode Right;

            public BinaryTreeNode(int key)
            {
                Data = key;
                Left = null;
                Right = null;
            }
        }

        public BinaryTreeNode Node;

        public BinaryTree(int[] array)
        {
            Node = new BinaryTreeNode(array[0]);

            for (int i = 1; i < array.Length; i++)
            {
                Insert(array[i]);
            }
        }

        public void PreOrder(BinaryTreeNode root)
        {
            if(root != null)
            {
                Console.Write($"{root.Data} ");
                PreOrder(root.Left);
                PreOrder(root.Right);
            }
        }

        public void PostOrder(BinaryTreeNode root)
        {
            if(root != null)
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                Console.Write($"{root.Data} ");
            }
        }

        public void InOrder(BinaryTreeNode root)
        {
            if (root != null)
            {
                InOrder(root.Left);
                Console.Write($"{root.Data} ");
                InOrder(root.Right);
            }
        }

public BinaryTreeNode Search(int key, out BinaryTreeNode father)
        {
            var root = Node;
            father = root;
            while (true)
            {
                if(root == null || key == root.Data)
                {
                    break;
                }
                father = root;

                if (key < root.Data)
                {
                    root = root.Left;
                }
                else
                {
                    root = root.Right;
                }
            }
            return root;
        }

        public void Insert(int key)
        {
            Search(key, out BinaryTreeNode father);
            
            if (father == null)
            {
                Node.Data = key;
            }
            else if (key < father.Data)
            {
                father.Left = new BinaryTreeNode(key);
            }
            else
            {
                father.Right = new BinaryTreeNode(key);
            }
        }

        public bool Remove(int key)
        {
            var key_root = Search(key, out BinaryTreeNode father);

            if (key_root == null)
            {
                return false;
            }

            if (key_root.Right == null)
            {
                father.Left = key_root.Left;
                key_root = null;
            }
            else
            {
                var curr_root = key_root.Right;
                while(curr_root.Left != null)
                {
                    father = curr_root;
                    curr_root = curr_root.Left;
                }
                key_root.Data = curr_root.Data;
                father.Left = curr_root.Right;
            }
            return true;
        }

        public void Delete()
        {
            Node = null;
        }

        public void Depth(BinaryTreeNode Node, int depth)
        {
            if (depth == 0)
            {
                Console.Write($"{Node.Data} ");
            }
            else if (depth > 0)
            {
                depth -= 1;
                if (Node.Left != null)
                {
                    Depth(Node.Left, depth);
                }
                if (Node.Right != null)
                {
                    Depth(Node.Right, depth);
                }
            }
        }
    }
}
