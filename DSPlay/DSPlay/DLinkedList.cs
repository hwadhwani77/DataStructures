using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPlay
{
    /// <summary>
    /// Doubly Linked List
    /// </summary>
    public class DLinkedList
    {
        public Node head { get; set; }

        public class Node
        {
            int data;
            Node next, prev;

            public Node(int data)
            {
                this.data = data;
                this.next = null;
                this.prev = null;
            }

            public void setNext(Node node)
            {
                this.next = node;
            }

            public void setPrev(Node node)
            {
                this.prev = node;
            }

            public Node getNext()
            {
                return this.next;
            }

            public Node getPrev()
            {
                return this.prev;
            }

            public int getData()
            {
                return this.data;
            }
        }

        public void InsertAtFront(int data)
        {
            DLinkedList list = this;
            Node node = new Node(data);

            //Set New Node's prev to null and Next to head
            node.setPrev(null);
            node.setNext(head);

            //If Head is not null, set head's prev to new node
            if (list.head != null)
                head.setPrev(node);

            head = node;
        }

        public void InsertAfterNode(Node prevNode, int data)
        {
            DLinkedList list = this;
            Node node = new Node(data);

            //Get Next Node
            Node nextNode = prevNode.getNext();

            //New Node Next and Prev
            node.setNext(nextNode);
            node.setPrev(prevNode);

            //Next Node's prev and Prev Node's next
            nextNode.setPrev(node);
            prevNode.setNext(node);            
        }

        public void InsertAtEnd(int data)
        {
            DLinkedList list = this;
            Node node = new Node(data);

            Node current = list.head;

            while(current != null && current.getNext() != null)
            {
                current = current.getNext();
            }

            //Loop will end when it find current.next = null which will be the last node.

            current.setNext(node);

            node.setPrev(current);
            node.setNext(null);
        }

        public void DeleteNode(Node delNode)
        {
            DLinkedList list = this;

            if (list.head == null || delNode == null)
                return;

            if (list.head == delNode)
            {
                list.head = delNode.getNext();
            }

            if (delNode != null)
            {
                Node prevNode = delNode.getPrev();
                Node nextNode = delNode.getNext();

                prevNode.setNext(nextNode);
                nextNode.setPrev(prevNode);
            }           
        }

        public void ReverseList()
        {
            DLinkedList list = this;
            Node temp = null, current;

            current = list.head;

            while (current != null)
            {
                temp = current.getPrev();
                current.setPrev(current.getNext());
                current.setNext(temp);
                current = current.getPrev();
            }

            if (temp != null)
                head = temp.getPrev();

        }
    }
}
