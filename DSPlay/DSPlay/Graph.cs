using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPlay
{
    public class QEntry
    {
        public int v { get; set; }
        public int dist { get; set; }
    }

    public class Graph
    {
        public int V;
        public LinkedList<int>[] adjLinkedList;

        public Graph(int V)
        {
            this.V = V;
            adjLinkedList = new LinkedList<int>[V];

            for (int i = 0; i < V; i++)
            {
                adjLinkedList[i] = new LinkedList<int>();
            }
        }

        public void addEdge(Graph graph, int src, int dest)
        {
            graph.adjLinkedList[src].AddFirst(dest);
            graph.adjLinkedList[dest].AddFirst(src);
        }

        public void printGraph(Graph graph)
        {
            for (int i = 0; i < graph.V; i++)
            {
                Console.WriteLine("Adjacency list of vertex: " + i);
                Console.Write("head");
                foreach (int h in adjLinkedList[i])
                {
                    Console.Write("-> " + h);
                }
                Console.WriteLine();

            }
        }

        public void BFS(int s)
        {
            bool[] visited = new bool[this.V];
            LinkedList<int> list = new LinkedList<int>();

            visited[s] = true;
            list.AddFirst(s);

            while (list.Count() > 0)
            {
                s = list.First();
                Console.WriteLine(s);

                foreach (int h in adjLinkedList[s])
                {
                    if (!visited[h])
                    {
                        visited[h] = true;
                        list.AddFirst(h);
                    }
                }
                list.Remove(s);
            }

        }

        public void DFS(int s)
        {
            bool[] visited = new bool[this.V];

            DFSUtil(s, visited);
        }

        public int minSnakesAndLadders(int[] move, int n)
        {
            int[] visited = new int[n];
            for (int i = 0; i < n; i++)
            { visited[i] = 0; }

            Queue<QEntry> queue = new Queue<QEntry>();
            QEntry qe = new QEntry();
            qe.v = 0; qe.dist = 0;

            visited[0] = 1;
            queue.Enqueue(qe);

            while (queue.Count > 0)
            {
                qe = queue.Dequeue();
                int v = qe.v;

                if (v == n - 1)
                    break;

                for (int j = v + 1; j <= (v + 6) && j < n; j++)
                {
                    if (visited[j] == 0)
                    {
                        QEntry a = new QEntry();
                        a.dist = (qe.dist + 1);
                        visited[j] = 1;

                        if (move[j] != -1)
                            a.v = move[j];
                        else
                            a.v = j;

                        queue.Enqueue(a);
                    }
                }
            }

            return qe.dist;
        }


        public void minCashFlowRec(int[][] g, int n)
        {
            int N = n;
            int[] amount = new int[N];            

            for (int p = 0; p < N; p++)
            {
                for (int i = 0; i < N; i++)
                { 
                    amount[p] += (g[i][p] - g[p][i]);
                }
            }
            minCashFlowRec(amount, n);
        }


        #region Private Functions

        private void DFSUtil(int s, bool[] visited)
        {
            visited[s] = true;
            Console.WriteLine(s);

            LinkedList<int> list = new LinkedList<int>();

            foreach (int h in adjLinkedList[s])
            {
                if (!visited[h])
                    DFSUtil(h, visited);
            }
        }

        private void minCashFlowRec(int[] amount, int n)
        {
            int mxCredit = getMaxIndex(amount, n); int mxDebit = getMinIndex(amount, n);

            if (amount[mxCredit] == 0 && amount[mxDebit] == 0)
                return;

            int min = minOf2(-amount[mxDebit], amount[mxCredit]);

            amount[mxCredit] -= min;
            amount[mxDebit] += min;

            Console.WriteLine("Person " + mxDebit + " pays " + min + " to Person " + mxCredit);

            minCashFlowRec(amount, n);

        }

        private int getMinIndex(int[] arr, int n)
        {
            int minInd = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] < arr[minInd])
                    minInd = i;
            }
            return minInd;
        }

        private int getMaxIndex(int[] arr, int n)
        {
            int maxInd = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] > arr[maxInd])
                    maxInd = i;
            }
            return maxInd;
        }

        private int minOf2(int x, int y)
        {
            return (x < y) ? x : y;
        }
        #endregion
    }
}
