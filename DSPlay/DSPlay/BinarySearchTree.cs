using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DSPlay.Binary;
namespace DSPlay
{
    public class BinarySearchTree
    {
        public Node root;

        private Node first, middle, last, prev = null;

        public BinarySearchTree()
        {
            root = null;
        }

        public BinarySearchTree(int key)
        {
            root = new Node(key);
        }

        public Node SearchNode(Node root, int key)
        {
            if (root == null || root.key == key)
                return root;

            if (root.key > key)
                return SearchNode(root.left, key);
            else
                return SearchNode(root.right, key);
        }

        public void insert(int key)
        {
            root = insertRecord(root, key);
        }

        public void inorderPrint(Node root)
        {
            if (root != null)
            {
                inorderPrint(root.left);
                Console.WriteLine(root.key);
                inorderPrint(root.right);
            }
        }

        public void deleteKey(int key)
        {
            root = deleteRecord(root, key);
        }

        public void FindPreSuc(Node root, int key, ref Node pre, ref Node suc)
        {
            if (root == null)
                return;

            if (root.key == key)
            {
                if (root.left != null)
                {
                    Node temp = root.left;
                    while (temp.right != null)
                    {
                        temp = temp.right;
                    }
                    pre = temp;
                }

                if (root.right != null)
                {
                    Node temp = root.right;
                    while (temp.left != null)
                        temp = temp.left;

                    suc = temp;
                }
                return;
            }

            if (root.key > key)
            {
                suc = root;
                FindPreSuc(root.left, key, ref pre, ref suc);
            }
            else
            {
                pre = root;
                FindPreSuc(root.right, key, ref pre, ref suc);
            }
        }

        public Node FindLCA(Node node, int n1, int n2)
        {
            if (node == null)
                return null;

            if (node.key > n1 && node.key > n2)
                return FindLCA(node.left, n1, n2);

            if (node.key < n1 && node.key < n2)
                return FindLCA(node.right, n1, n2);

            return node;

        }

        public void correctBSTUtil(Node root)
        {
            first = middle = last = prev = null;

            correctBST(root);

            if (first != null && last != null)
            {
                int temp = first.key;
                first.key = last.key;
                last.key = temp;
            }
            else if (first != null && middle != null)
            {
                int temp = first.key;
                first.key = middle.key;
                middle.key = temp;
            }
        }

        public int Ceil(Node node, int input)
        {
            if (node == null)
                return -1;

            if (node.key == input)
                return node.key;

            if (node.key < input)
            {
                return Ceil(node.right, input);
            }

            int ceil = Ceil(node.left, input);
            return (ceil >= input) ? ceil : node.key;
        }

        public bool isPairPresent(Node node, int input)
        {
            if (node == null)
                return false;

            int[] array = NodeToList(node, new List<int>()).ToArray();
            int start = 0, end = array.Length - 1;

            while (start < end)
            {
                if (array[start] + array[end] == input)
                {
                    Console.WriteLine("Found Pair: " + array[start] + ", " + array[end]);
                    return true;
                }
                else if (array[start] + array[end] < input)
                {
                    start++;
                }
                else
                {
                    end--;
                }
            }
            Console.WriteLine("No pairs found");
            return false;
        }


        public Node mergedTree(Node node1, Node node2)
        {
            Node mergedNode = null;

            List<int> firstList = NodeToList(node1, new List<int>());
            List<int> secondList = NodeToList(node2, new List<int>());
            List<int> mergedList = sortedMergedList(firstList, secondList, firstList.Count, secondList.Count);
            mergedNode = ALtoBST(mergedList, 0, mergedList.Count - 1);

            return mergedNode;
        }

        #region Private Methods

        private Node ALtoBST(List<int> inputList, int start, int end)
        {
            if (start > end)
                return null;

            int mid = (start + end) / 2;
            Node node = new Node(inputList[mid]);

            node.left = ALtoBST(inputList, start, mid - 1);
            node.right = ALtoBST(inputList, mid + 1, end);

            return node;
        }

        private List<int> sortedMergedList(List<int> firstList, List<int> secondList, int m, int n)
        {
            List<int> finalList = new List<int>();
            int i = 0, j = 0;

            while (i < m && j < n)
            {
                if (firstList[i] < secondList[j])
                { finalList.Add(firstList[i]); i++; }
                else
                { finalList.Add(secondList[j]); j++; }
            }
            while (i < m)
            { finalList.Add(firstList[i]); i++; }
            while (j < n)
            { finalList.Add(secondList[j]); j++; }

            return finalList;
        }

        private List<int> NodeToList(Node node, List<int> inputList)
        {
            if (node == null)
                return inputList;

            NodeToList(node.left, inputList);
            inputList.Add(node.key);
            NodeToList(node.right, inputList);

            return inputList;

        }

        private void correctBST(Node root)
        {
            if (root != null)
            {
                //In-order
                correctBST(root.left);

                if (prev != null && root.key < prev.key)
                {
                    if (first == null)
                    {
                        first = prev;
                        middle = root;
                    }
                    else
                        last = root;
                }

                prev = root;

                correctBST(root.right);
            }
        }

        private Node deleteRecord(Node root, int key)
        {
            if (root == null)
                return root;

            if (root.key > key)
                root.left = deleteRecord(root.left, key);
            else if (root.key < key)
                root.right = deleteRecord(root.right, key);
            else
            {
                if (root.left == null)
                    return root.right;
                else if (root.right == null)
                    return root.left;

                root.key = minValue(root.right);

                root.right = deleteRecord(root.right, root.key);
            }

            return root;

        }

        private int minValue(Node root)
        {
            int min = root.key;
            while (root.left != null)
            {
                min = root.left.key;
                root = root.left;
            }

            return min;
        }

        private Node insertRecord(Node root, int key)
        {
            if (root == null)
            {
                root = new Node(key);
                return root;
            }

            if (root.key > key)
                root.left = insertRecord(root.left, key);
            else
                root.right = insertRecord(root.right, key);

            return root;
        }

        #endregion
    }
}
