using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DSPlay.Binary;
namespace DSPlay
{
    public class BinaryTree : Node
    {
        public Node root;

        //public class Node
        //{
        //    public int key;
        //    public Node left, right;

        //    public Node(int item)
        //    {
        //        this.key = item;
        //        this.left = this.right = null;
        //    }
        //}

        public BinaryTree()
        {
            root = null;
        }

        public BinaryTree(int key)
        {
            root = new Node(key);
        }

        public void InOrderTraversal(Node node)
        {
            if (node == null) return;

            InOrderTraversal(node.left);

            Console.WriteLine(node.key);

            InOrderTraversal(node.right);

        }

        public void PreOrderTraversal(Node node)
        {
            if (node == null) return;

            Console.WriteLine(node.key);

            PreOrderTraversal(node.left);

            PreOrderTraversal(node.right);

        }

        public void PostOrderTraversal(Node node)
        {
            if (node == null) return;

            PostOrderTraversal(node.left);

            PostOrderTraversal(node.right);

            Console.WriteLine(node.key);
        }

        public void LevelOrderTravesal()
        {
            BinaryTree tree = this;

            int h = heightOfTree(tree.root);
            for (int i = 1; i <= h; i++)
                printGivenLevel(tree.root, i);
        }

        public int diameter()
        {
            BinaryTree tree = this;
            return (diameter(tree.root));
        }

        public void InorderWithoutRecursion(Node root)
        {
            if (root == null)
                return;

            Stack<Node> stack = new Stack<Node>();
            Node node = root;

            while (node != null)
            {
                stack.push(node);
                node = node.left;
            }

            while (!stack.isEmpty())
            {
                node = stack.pop();
                Console.Write(node.key);
                if (node.right != null)
                {
                    node = node.right;

                    while (node != null)
                    {
                        stack.push(node);
                        node = node.left;
                    }
                }
            }
        }

        public int getMaxWidthOfTree(Node root)
        {
            int maxwidth = 0; int width;
            int height = heightOfTree(root);

            for (int i = 1; i <= height; i++)
            {
                width = getWidth(root, i);
                if (width > maxwidth)
                    maxwidth = width;
            }

            return maxwidth;
        }

        public void printKDistant(Node node, int k)
        {
            if (node == null)
                return;
            if (k == 0)
                Console.WriteLine(node.key);
            else
            {
                printKDistant(node.left, k - 1);
                printKDistant(node.right, k - 1);
            }
        }

        public bool printAncestors(Node node, int key)
        {
            if (node == null)
                return false;
            if (node.key == key)
                return true;
            if (printAncestors(node.left, key) || printAncestors(node.right, key))
            {
                Console.WriteLine(node.key);
                return true;
            }
            return false;
        }

        #region Private Methods

        private int heightOfTree(Node root)
        {
            if (root == null)
                return 0;
            else
            {
                int lHeight = heightOfTree(root.left);
                int rHeight = heightOfTree(root.right);

                if (lHeight > rHeight)
                    return lHeight + 1;
                else
                    return rHeight + 1;
            }
        }

        private void printGivenLevel(Node root, int level)
        {
            if (root == null)
                return;

            if (level == 1)
                Console.WriteLine(root.key);
            else if (level > 1)
            {
                printGivenLevel(root.left, level - 1);
                printGivenLevel(root.right, level - 1);
            }
        }

        private int diameter(Node root)
        {
            if (root == null)
                return 0;

            int lheight = heightOfTree(root.left);
            int rheight = heightOfTree(root.right);

            int ldiameter = diameter(root.left);
            int rdiameter = diameter(root.right);

            return Math.Max(lheight + rheight + 1, Math.Max(ldiameter, rdiameter));
        }

        private int getWidth(Node root, int index)
        {
            if (root == null)
                return 0;

            if (index == 1)
                return 1;
            else if (index > 1)
                return getWidth(root.left, index - 1) + getWidth(root.right, index - 1);
            return 0;
        }
        #endregion
    }

    public static class Codec
    {
        static Dictionary<int, string> urlDict = new Dictionary<int, string>();
        // Encodes a URL to a shortened URL
        public static string encode(string longUrl)
        {
            int key = longUrl.GetHashCode();
            if (!urlDict.ContainsKey(key))
                urlDict[key] = longUrl;
            return key.ToString();
        }

        // Decodes a shortened URL to its original URL.
        public static string decode(string shortUrl)
        {
            int key = Int32.Parse(shortUrl);
            if (urlDict.ContainsKey(key))
                return urlDict[key];
            else
                return string.Empty;
        }
    }
}
