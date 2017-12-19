using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPlay
{
    public class QueueAsArray<T>
    {
        int capacity, front, rear, size;
        T[] array;

        public QueueAsArray(int capacity)
        {
            this.capacity = capacity;
            front = size = 0;
            rear = capacity - 1;
            array = new T[this.capacity];
        }

        public bool isFull()
        {
            return (this.size == this.capacity);
        }

        public bool isEmpty()
        {
            return (this.size == 0);
        }

        public void enqueue(T item)
        {
            if (isFull())
                return;

            this.rear = (this.rear + 1) % this.capacity;
            this.array[this.rear] = item;
            this.size += 1;
        }

        public T dequeue()
        {
            if (isEmpty())
                return default(T);

            T item = this.array[this.front];
            this.front = (this.front + 1) % this.capacity;
            this.size -= 1;
            return item;
        }

        public T frontItem()
        {
            if (isEmpty())
                return default(T);

            return this.array[this.front];
        }

        public T rearItem()
        {
            if (isEmpty())
                return default(T);

            return this.array[this.rear];
        }

        public void generateBinary(int n)
        {
            QueueAsArray<string> queue = new QueueAsArray<string>(n);
            queue.enqueue("1");

            while (n-- > 0)
            {
                string s1 = queue.frontItem();
                
                Console.WriteLine(queue.dequeue());
                string s2 = s1;
                queue.enqueue(s1 + "0");
                queue.enqueue(s2 + "1");
            }
        }
    }

    public class QueueAsLinkedList
    {
        public class Node
        {
            public int key;
            public Node next;

            public Node(int key)
            {
                this.key = key;
                this.next = null;
            }
        }

        Node rear, front;

        public QueueAsLinkedList()
        {
            this.front = this.rear = null;
        }

        public void enqueue(int key)
        {
            Node node = new Node(key);

            if (this.rear == null)
            {
                this.front = this.rear = node;
                return;
            }

            this.rear.next = node;
            this.rear = node;
        }

        public Node dequeue()
        {
            if (this.front == null)
                return null;


            Node node = this.front;
            this.front = this.front.next;

            if (this.front == null)
                this.rear = null;

            return node;
        }
    }

}
