using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectEx1
{
    internal class CircularLinkedList
    {
        private Node tail;

        // Initialize the list
        public CircularLinkedList()
        {
            tail = null;
        }

        // Check if the list is empty
        public bool IsEmpty()
        {
            return tail == null;
        }

        // Insert a new node at the beginning
        public void InsertAtBeginning(Book data)
        {
            Node newNode = new Node(data);
            if (IsEmpty())
            {
                tail = newNode;
                tail.Next = tail;
            }
            else
            {
                newNode.Next = tail.Next;
                tail.Next = newNode;
            }
        }

        // Insert a new node at the end
        public void InsertAtEnd(Book data)
        {
            Node newNode = new Node(data);
            if (IsEmpty())
            {
                tail = newNode;
                tail.Next = tail;
            }
            else
            {
                newNode.Next = tail.Next;
                tail.Next = newNode;
                tail = newNode;
            }
        }

        // Insert a new node after a specific node
        public void InsertAfter(Book target, Book data)
        {
            if (IsEmpty()) return;

            Node current = tail.Next;
            do
            {
                if (current.Data.Equals(target))
                {
                    Node newNode = new Node(data);
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    if (current == tail)
                    {
                        tail = newNode;
                    }
                    return;
                }
                current = current.Next;
            } while (current != tail.Next);
        }

        // Remove the first node
        public void RemoveFirst()
        {
            if (IsEmpty()) return;

            if (tail.Next == tail)
            {
                tail = null;
            }
            else
            {
                tail.Next = tail.Next.Next;
            }
        }

        // Remove the last node
        public void RemoveLast()
        {
            if (IsEmpty()) return;

            if (tail.Next == tail)
            {
                tail = null;
            }
            else
            {
                Node current = tail.Next;
                while (current.Next != tail)
                {
                    current = current.Next;
                }
                current.Next = tail.Next;
                tail = current;
            }
        }

        // Remove a node after a specific node
        public void RemoveAfter(Book target)
        {
            if (IsEmpty()) return;

            Node current = tail.Next;
            do
            {
                if (current.Data.Equals(target))
                {
                    if (current.Next == tail)
                    {
                        tail = current;
                    }
                    current.Next = current.Next.Next;
                    return;
                }
                current = current.Next;
            } while (current != tail.Next);
        }

        // Search a node
        public Node Search(Book target)
        {
            if (IsEmpty()) return null;

            Node current = tail.Next;
            do
            {
                if (current.Data.Equals(target)) return current;
                current = current.Next;
            } while (current != tail.Next);
            return null;
        }

        // Search nodes satisfying a specific criteria
        public void SearchByCriteria(Func<Book, bool> criteria)
        {
            if (IsEmpty()) return;

            Node current = tail.Next;
            do
            {
                if (criteria(current.Data))
                {
                    Console.WriteLine(current.Data);
                }
                current = current.Next;
            } while (current != tail.Next);
        }

        // Print the list
        public void PrintList()
        {
            if (IsEmpty())
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            Node current = tail.Next;
            do
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            } while (current != tail.Next);
        }

        // Sort the list (Selection Sort)
        public void SortSelection()
        {
            if (IsEmpty() || tail.Next == tail) return;

            Node current = tail.Next;
            do
            {
                Node min = current;
                Node temp = current.Next;
                while (temp != tail.Next)
                {
                    if (temp.Data.Price < min.Data.Price)
                    {
                        min = temp;
                    }
                    temp = temp.Next;
                }

                if (min != current)
                {
                    Book tempData = current.Data;
                    current.Data = min.Data;
                    min.Data = tempData;
                }
                current = current.Next;
            } while (current != tail.Next);
        }

        // Propose at least 3 operations
        // 1. Merge two lists
        public void Merge(CircularLinkedList other)
        {
            if (IsEmpty())
            {
                tail = other.tail;
            }
            else if (!other.IsEmpty())
            {
                Node first = tail.Next;
                Node otherFirst = other.tail.Next;

                tail.Next = otherFirst;
                other.tail.Next = first;
                tail = other.tail;
            }
        }

        // 2. Remove all nodes satisfying a specific criteria
        public void RemoveByCriteria(Func<Book, bool> criteria)
        {
            if (IsEmpty()) return;

            Node current = tail.Next;
            Node previous = tail;
            do
            {
                if (criteria(current.Data))
                {
                    if (current == tail)
                    {
                        tail = previous;
                    }
                    previous.Next = current.Next;
                    current = previous.Next;
                    if (previous == tail) break;
                }
                else
                {
                    previous = current;
                    current = current.Next;
                }
            } while (current != tail.Next);

            if (tail != null && criteria(tail.Data))
            {
                RemoveLast();
            }
        }

        // 3. Reverse the list
        public void Reverse()
        {
            if (IsEmpty() || tail.Next == tail) return;

            Node prev = tail;
            Node current = tail.Next;
            Node next;

            do
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            } while (current != tail.Next);

            tail.Next = prev;
            tail = current;
        }
    }
}
