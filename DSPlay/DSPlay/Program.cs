using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPlay
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Data Structure Playground");
            Console.WriteLine("1. Linked List");
            Console.WriteLine("2. Doubly Linked List");
            Console.WriteLine("3. Stack");
            Console.WriteLine("4. Queue");
            Console.WriteLine("5. Binary Tree");
            Console.WriteLine("6. Binary Search Tree");
            Console.WriteLine("7. Graph");
            Console.WriteLine("8. Array");            
            Console.WriteLine("100. Sorts ");
            Console.WriteLine("1000. Dynamic Programming ");
            Console.WriteLine("Please select an option");
            string option = Console.ReadLine();
            int key = -1;

            if (Int32.TryParse(option, out key))
            {
                switch (key)
                {
                    case 1:
                        LinkedListFuntions();
                        break;

                    case 2:
                        DoubleLinkedListFunctions();
                        break;

                    case 3:
                        StackFunctions();
                        break;

                    case 4:
                        QueueFunctions();
                        break;

                    case 5:
                        BinaryTreeFunctions();
                        break;

                    case 6:
                        BinarySearchTreeFunctions();
                        break;

                    case 7:
                        GraphFunctions();
                        break;

                    case 8:
                        ArrayFunctions();
                        break;                   

                    case 100:
                        SortFunctions();
                        break;
                    case 1000:
                        DPFunctions();
                        break;
                }
            }
        }

        public static void LinkedListFuntions()
        {
            /*Linked List Implementation*/
            LinkedList list = new LinkedList();
            list.head = new LinkedList.Node(1);
            LinkedList.Node second = new LinkedList.Node(2);
            LinkedList.Node fourth = new LinkedList.Node(4);

            list.head.setNext(second);
            second.setNext(fourth);

            /* Linked List Insertion at first place */
            //Time complexity O(1)
            list.insertAtBeginning(0);

            /* Linked List Insertion after a specific position */
            //Time complexity O(1)
            list.insertAfter(second, 3);

            /* Linked List Insertion at end of list */
            //Time complexity O(N)
            list.insertAtEnd(5);

            /* Linked List Deletion via Key */
            //Time Complexity O(N)
            list.deleteKey(2);


            /* Linked List Deletion via position */
            //Time Complexity O(N)
            list.deletePosition(4);

            /* Iterative Length */
            Console.WriteLine("Iterative Linked List Length: " + list.iterativeLinkedListLength());

            /* Recursive Length */
            Console.WriteLine("Recursive Linked List Length: " + list.recursiveLinkedListLength(list.head));

            /*Swap Nodes 2 & 4 */
            list.swapNodes(0, 4);

            /*Reversee Linked List */
            list.reverseLinkedList();

            /*Merge two sorted list */
            LinkedList list1 = new LinkedList();
            LinkedList list2 = new LinkedList();
            list1.head = new LinkedList.Node(1);
            list2.head = new LinkedList.Node(2);

            LinkedList.Node three = new LinkedList.Node(3);
            LinkedList.Node four = new LinkedList.Node(4);
            LinkedList.Node five = new LinkedList.Node(5);
            LinkedList.Node six = new LinkedList.Node(6);

            list1.head.setNext(three);
            three.setNext(five);

            list2.head.setNext(four);
            four.setNext(six);

            LinkedList.Node mergedNode = list.SortedMergeList(list1.head, list2.head);

            LinkedList finalList = new LinkedList();
            finalList.head = new LinkedList.Node(0);
            finalList.head.setNext(mergedNode);

            /*Reverse Linked List in Group */
            LinkedList.Node returnNode = list.reverseLinkedListGroup(list.head, 4);

            /* Detect and Remove Loop in a linked List */
            list.head.getNext().getNext().getNext().getNext().getNext().setNext(list.head.getNext().getNext());
            list.DetectRemoveLoop();

            /* Add two linked list */
            LinkedList firstList = new LinkedList();
            firstList.head = new LinkedList.Node(7);
            firstList.head.setNext(new LinkedList.Node(5));
            firstList.head.getNext().setNext(new LinkedList.Node(9));
            firstList.head.getNext().getNext().setNext(new LinkedList.Node(4));
            firstList.head.getNext().getNext().getNext().setNext(new LinkedList.Node(6));

            LinkedList secondList = new LinkedList();
            secondList.head = new LinkedList.Node(8);
            secondList.head.setNext(new LinkedList.Node(4));

            LinkedList.Node result = list.addTwoLinkedList(firstList.head, secondList.head);

            /* Rotate Linked List by k nodes */
            list.RotateLinkedList(5);

        }

        public static void DoubleLinkedListFunctions()
        {
            DLinkedList list = new DLinkedList();
            list.head = new DLinkedList.Node(2);
            list.InsertAtFront(0);

            list.InsertAfterNode(list.head, 1);

            list.InsertAtEnd(3);

            //DLinkedList.Node delNode = list.head.getNext().getNext();
            //list.DeleteNode(delNode);

            list.ReverseList(); //O(N) complexity

        }

        public static void StackFunctions()
        {
            Stack<int> stack = new Stack<int>(4);
            stack.push(0);
            stack.push(1);
            stack.push(2);
            stack.push(3);

            Console.WriteLine("Peek at top: " + stack.peek());
            //Console.WriteLine(stack.pop());

            Console.WriteLine(stack.infixToPostFix("a+b*(c^d-e)^(f+g*h)-i"));

            Console.WriteLine(stack.postFixEvaluation("231*+9-"));

            Console.WriteLine(stack.reverseString("abc"));

            Console.WriteLine(stack.balancedParanthesis("{[({()})]}"));

            int[] array = { 11, 13, 21, 3 };
            stack.printNextGreaterElement(array);

            stack.reverseStackRecursively(stack);

            Stack<int> stack2 = new Stack<int>(4);
            stack2.push(20);
            stack2.push(3);
            stack2.push(44);
            stack2.push(-1);

            stack2.sortStackRecursively(stack2);
        }

        public static void QueueFunctions()
        {

            QueueAsArray<int> queue = new QueueAsArray<int>(4);
            queue.enqueue(10);
            queue.enqueue(20);
            queue.enqueue(30);
            queue.enqueue(40);

            Console.WriteLine("Front Item : " + queue.frontItem());
            Console.WriteLine("Last Item : " + queue.rearItem());

            Console.WriteLine("Dequeued item: " + queue.dequeue());


            QueueAsLinkedList queueList = new QueueAsLinkedList();
            queueList.enqueue(10);
            queueList.enqueue(20);
            queueList.enqueue(30);
            queueList.enqueue(40);

            Console.WriteLine("Dequeued Item: " + queueList.dequeue().key);

            queue.generateBinary(10);
        }

        public static void BinaryTreeFunctions()
        {
            BinaryTree tree = new BinaryTree();
            tree.root = new Binary.Node(1);

            tree.root.left = new Binary.Node(2);
            tree.root.right = new Binary.Node(3);

            tree.root.left.left = new Binary.Node(4);
            tree.root.left.right = new Binary.Node(5);

            tree.root.right.left = new Binary.Node(6);
            tree.root.right.right = new Binary.Node(7);

            Console.WriteLine("");
            tree.InOrderTraversal(tree.root);
            Console.WriteLine("");
            tree.PreOrderTraversal(tree.root);
            Console.WriteLine("");
            tree.PostOrderTraversal(tree.root);

            Console.WriteLine("");
            Console.WriteLine("");
            tree.LevelOrderTravesal();

            Console.WriteLine("The diameter of tree: " + tree.diameter());

            tree.InorderWithoutRecursion(tree.root);

            Console.WriteLine("");
            Console.WriteLine("The width of tree: " + tree.getMaxWidthOfTree(tree.root));
            Console.WriteLine("");

            tree.printKDistant(tree.root, 2);

            Console.WriteLine("");

            tree.printAncestors(tree.root, 7);
        }

        public static void BinarySearchTreeFunctions()
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.insert(50);
            tree.insert(30);
            tree.insert(20);
            tree.insert(40);
            tree.insert(70);
            tree.insert(60);
            tree.insert(80);

            tree.inorderPrint(tree.root);

            //tree.deleteKey(20);
            //tree.inorderPrint(tree.root);

            //tree.deleteKey(30);
            //tree.inorderPrint(tree.root);

            //tree.deleteKey(50);
            //tree.inorderPrint(tree.root);

            Binary.Node pre = null, suc = null;
            tree.FindPreSuc(tree.root, 30, ref pre, ref suc);

            Console.WriteLine("Predecessor: " + pre.key + ", Successor: " + suc.key + " of 30");

            Binary.Node temp = tree.FindLCA(tree.root, 20, 40);

            BinarySearchTree tree1 = new BinarySearchTree();
            tree1.root = new Binary.Node(50);
            tree1.root.left = new Binary.Node(30);
            tree1.root.left.left = new Binary.Node(10);
            tree1.root.left.right = new Binary.Node(20);
            tree1.root.right = new Binary.Node(80);
            tree1.root.right.left = new Binary.Node(60);
            tree1.root.right.right = new Binary.Node(90);

            tree1.inorderPrint(tree1.root);

            tree1.correctBSTUtil(tree1.root);

            tree.Ceil(tree.root, 10);

            tree.isPairPresent(tree.root, 100);


            BinarySearchTree btree1 = new BinarySearchTree();
            btree1.root = new Binary.Node(100);
            btree1.root.left = new Binary.Node(50);
            btree1.root.right = new Binary.Node(300);
            btree1.root.left.left = new Binary.Node(20);
            btree1.root.left.right = new Binary.Node(70);

            BinarySearchTree btree2 = new BinarySearchTree();
            btree2.root = new Binary.Node(80);
            btree2.root.left = new Binary.Node(40);
            btree2.root.right = new Binary.Node(120);

            BinarySearchTree finalMergedTree = new BinarySearchTree();
            finalMergedTree.root = tree.mergedTree(btree1.root, btree2.root);
            finalMergedTree.inorderPrint(finalMergedTree.root);

        }

        public static void GraphFunctions()
        {
            Graph graph = new Graph(5);
            graph.addEdge(graph, 0, 1);
            graph.addEdge(graph, 0, 4);
            graph.addEdge(graph, 1, 2);
            graph.addEdge(graph, 1, 3);
            graph.addEdge(graph, 1, 4);
            graph.addEdge(graph, 2, 3);
            graph.addEdge(graph, 3, 4);

            graph.printGraph(graph);

            Console.WriteLine("BFS");
            graph.BFS(2);

            Console.WriteLine("DFS");
            graph.DFS(2);


            int N = 30;
            int[] moves = new int[N];
            for (int i = 0; i < N; i++)
                moves[i] = -1;

            // Ladders
            moves[2] = 21;
            moves[4] = 7;
            moves[10] = 25;
            moves[19] = 28;

            // Snakes
            moves[26] = 0;
            moves[20] = 8;
            moves[16] = 3;
            moves[18] = 6;

            Console.WriteLine(graph.minSnakesAndLadders(moves, N));

            int[][] g = new int[3][]; // {{0, 1000, 2000}, {0, 0, 5000}, {0,0,0}};  
            g[0] = new int[3] { 0, 1000, 2000 };
            g[1] = new int[3] { 0, 0, 5000 };
            g[2] = new int[3] { 0, 0, 0 };
            graph.minCashFlowRec(g, 3);
        }

        public static void SortFunctions()
        {
            int[] inputArray = { 3, 34, 21, 15, 6 };

            //Sort.MergeSort(inputArray, 0, inputArray.Length - 1);

            Sort.QuickSort(inputArray, 0, inputArray.Length - 1);
        }

        public static void ArrayFunctions()
        {
            int[] a1 = new int[7];

            a1[0] = 12;
            a1[1] = 6;
            a1[2] = 20;
            a1[3] = 40;
            a1[4] = 30;
            a1[5] = 2;

            Console.WriteLine("Found at index: " + UnsortedArrayFns.Search(a1, 70));

            ArrayBase.PrintArray(a1);
            //int index = UnsortedArrayFns.Insert(a1, 80, 6);
            //ArrayBase.PrintArray(a1);

            //UnsortedArrayFns.Delete(a1, 20);
            //ArrayBase.PrintArray(a1);


            int[] a2 = new int[7];

            a2[0] = 12;
            a2[1] = 16;
            a2[2] = 20;
            a2[3] = 40;
            a2[4] = 50;
            a2[5] = 70;

            Console.WriteLine("Found at index: " + SortedArrayFns.Search(a2, 70, 0, 5));

            ArrayBase.PrintArray(a2);
            SortedArrayFns.Insert(a2, 30);
            ArrayBase.PrintArray(a2);

            SortedArrayFns.Delete(a2, 20);
            ArrayBase.PrintArray(a2);

            //ArrayBase.ReverseArray(a1, 0, a1.Length - 1);

            Console.Write("Leaders in Array: ");
            ArrayBase.Leaders(a1);

            Console.WriteLine("Finding Candidates for Sum of 18");
            ArrayBase.ArrayHasTwoCandidates(a1, a1.Length - 1, 18);

            int[] majority = { 1, 3, 3, 1, 2, 3, 3 };
            ArrayBase.MajorityElement(majority);

            int[] occurence = { 2, 3, 5, 4, 5, 2, 4, 3, 5, 2, 4, 4, 2 };
            Console.WriteLine("Odd Occurence Element: " + ArrayBase.OddOccurrence(occurence));

            int[] rotateArray = { 230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778, 887, 755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 168, 23, 677, 61, 400, 136, 874, 363, 394, 199, 863, 997, 794, 587, 124, 321, 212, 957, 764, 173, 314, 422, 927, 783, 930, 282, 306, 506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180, 414, 751, 28, 546, 60, 371, 493, 370, 527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430, 803, 59, 858, 538, 427, 583, 368, 375, 173, 809, 896, 370, 789, 542 };
            //ArrayBase.PrintArray(ArrayBase.ReverseArray(rotateArray, 2));

            ArrayBase.TwoSum(rotateArray, 5);
            ArrayBase.TwoSumHash(rotateArray, 5);
        }
        
        public static void DPFunctions()
        {
            DP dp = new DP();

            Console.WriteLine("Memoization (Top Down) Fibo of 10: " + dp.MemoFibo(10));

            Console.WriteLine("Tabulation (Bottom Up) Fibo of 10: " + dp.TabFibo(10));

            dp = new DP();
            Console.WriteLine("Memoization Facto of 5: " + dp.MemoFacto(5));

            Console.WriteLine("Tabulation Facto of 5: " + dp.TabFacto(5));
        }
    }
}
