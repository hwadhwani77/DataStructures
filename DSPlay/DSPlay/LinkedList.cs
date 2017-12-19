using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPlay
{
    public class LinkedList
    {
        public Node head { get; set; }

        public class Node
        {
            int data;
            Node next;

            public Node(int data)
            {
                this.data = data;
                this.next = null;
            }

            public void setNext(Node node)
            {
                this.next = node;
            }

            public Node getNext()
            {
                return this.next;
            }

            public int getData()
            {
                return this.data;
            }
        }

        public void insertAtBeginning(int data)
        {
            LinkedList list = this;
            if (list == null)
                return;

            if (list.head == null)
            {
                list.head = new Node(data);
                list.head.setNext(null);
            }
            else
            {
                Node new_node = new Node(data);
                new_node.setNext(list.head);
                list.head = new_node;
            }

        }
        public void insertAfter(Node prev_node, int data)
        {
            if (prev_node == null)
                return;

            Node new_node = new Node(data);
            new_node.setNext(prev_node.getNext());
            prev_node.setNext(new_node);
        }
        public void insertAtEnd(int data)
        {
            LinkedList list = this;
            Node new_node = new Node(data);

            if (list == null)
                return;

            if (list.head == null)
            {
                list.head = new_node;
                //list.head.setNext(null);
            }
            else
            {
                Node last_node = list.head;
                while (last_node.getNext() != null)
                {
                    last_node = last_node.getNext();
                }

                last_node.setNext(new_node);
                // new_node.setNext(null);

            }
        }

        public void deleteKey(int key)
        {
            LinkedList list = this;

            Node temp, prev = null;

            temp = list.head;

            //If the key is same as head node
            if (temp != null && temp.getData() == key)
            {
                list.head = temp.getNext();
                return;
            }

            while (temp != null && temp.getData() != key)
            {
                prev = temp;
                temp = temp.getNext();
            }

            if (temp == null)
                return;

            prev.setNext(temp.getNext());
        }

        public void deletePosition(int position)
        {
            LinkedList list = this;
            Node temp, prev = null;

            temp = list.head;

            //If Position = 0 then remove Head
            if (position == 0)
            {
                list.head = temp.getNext();
                return;
            }

            //Go upto position - 1 bcoz we want to set next node to next.next of previous node
            for (int i = 0; temp != null && i < position - 1; i++)
            {
                temp = temp.getNext();
            }

            if (temp == null || temp.getNext() == null)
                return;

            Node next = temp.getNext().getNext();
            temp.setNext(next);
        }

        public int iterativeLinkedListLength()
        {
            LinkedList list = this;

            int count = 0;
            Node temp = list.head;
            while (temp != null)
            {
                count++;
                temp = temp.getNext();
            }
            return count;
        }

        public int recursiveLinkedListLength(Node node)
        {
            if (node == null)
                return 0;
            else
                return 1 + recursiveLinkedListLength(node.getNext());
        }

        public void swapNodes(int key1, int key2)
        {
            LinkedList list = this;
            Node prevKey1Node = null, prevKey2Node = null;
            Node orgKey1Node = null, orgKey2Node = null;
            Node temp = list.head;

            if (temp.getData() == key1 || temp.getData() == key2)
            {
                if (temp.getData() == key1)
                { prevKey1Node = null; orgKey1Node = temp; }
                else
                { prevKey2Node = null; orgKey2Node = temp; }
            }

            while (temp != null)
            {
                Node prev = temp;
                temp = temp.getNext();
                if (temp != null && (temp.getData() == key1 || temp.getData() == key2))
                {
                    if (temp.getData() == key1)
                    { prevKey1Node = prev; orgKey1Node = temp; }
                    else
                    { prevKey2Node = prev; orgKey2Node = temp; }
                }
            }

            if (orgKey1Node == null || orgKey2Node == null)
                return;

            if (prevKey1Node != null)
                prevKey1Node.setNext(orgKey2Node);
            else
                list.head = orgKey2Node;

            if (prevKey2Node != null)
                prevKey2Node.setNext(orgKey1Node);
            else
                list.head = orgKey1Node;

            Node temp1 = orgKey1Node.getNext();
            orgKey1Node.setNext(orgKey2Node.getNext());
            orgKey2Node.setNext(temp1);
        }

        public void reverseLinkedList()
        {
            LinkedList list = this;

            Node prev = null, current = list.head, next = null;

            while (current != null)
            {
                next = current.getNext();
                current.setNext(prev);
                prev = current;
                current = next;
            }
            list.head = prev;
        }

        public Node reverseLinkedListGroup(Node node, int k)
        {
            Node current = node, next = null, prev = null;

            int count = 0;

            while (count < k && current != null)
            {
                next = current.getNext();
                current.setNext(prev);
                prev = current;
                current = next;
                count++;
            }

            if (next != null)
                node.setNext(reverseLinkedListGroup(next, k));

            return prev;

        }

        public Node SortedMergeList(Node headA, Node headB)
        {
            if (headA == null)
                return headB;
            if (headB == null)
                return headA;

            if (headA.getData() < headB.getData())
            {
                headA.setNext(SortedMergeList(headA.getNext(), headB));
                Console.WriteLine("HEAD A");
                Print(headA);
                return headA;
            }
            else
            {
                headB.setNext(SortedMergeList(headA, headB.getNext()));
                Console.WriteLine("HEAD B");
                Print(headB);
                return headB;
            }
        }

        public void DetectRemoveLoop()
        {
            LinkedList list = this;
            Node node = list.head;
            if (node == null || node.getNext() == null)
                return;

            Node slow = list.head, fast = list.head;

            slow = slow.getNext();
            fast = fast.getNext().getNext();

            while (fast != null && fast.getNext() != null)
            {
                if (slow == fast)
                    break;

                slow = slow.getNext();
                fast = fast.getNext().getNext();
            }

            //If Loop detected
            if (slow == fast)
            {
                slow = node;
                while (slow.getNext() != fast.getNext())
                {
                    slow = slow.getNext(); fast = fast.getNext();
                }

                fast.setNext(null);
            }
        }

        public Node addTwoLinkedList(Node first, Node second)
        {
            Node result = null, prev = null, temp = null;
            int carry = 0, sum;

            while (first != null || second != null)
            {
                sum = carry + (first != null ? first.getData() : 0) + (second != null ? second.getData() : 0);

                carry = (sum >= 10) ? 1 : 0;
                sum = sum % 10;

                temp = new Node(sum);

                if (result == null)
                    result = temp;
                else {
                    prev.setNext(temp);
                }

                prev = temp;

                if (first != null)
                    first = first.getNext();

                if (second != null)
                    second = second.getNext();
            }

            if (carry > 0)
                temp.setNext(new Node(carry));

            return result;
        }

        public void RotateLinkedList(int k)
        {
            if (k == 0)
                return;

            LinkedList list = this;
            Node current = list.head;
            int count = 1;
            while (count < k && current != null)
            {
                current = current.getNext();
                count++;
            }

            if (current == null)
                return;

            Node kthNode = current;
            while (current.getNext() != null)
                current = current.getNext();
            //Bcoz current is pointing to last node
            current.setNext(list.head);
            list.head = kthNode.getNext();
            kthNode.setNext(null);

        }

        private void Print(Node node)
        {
            while (node != null)
            {
                Console.WriteLine(node.getData());
                node = node.getNext();
            }
        }
    }
}
