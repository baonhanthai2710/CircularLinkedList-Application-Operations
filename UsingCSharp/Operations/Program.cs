using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectEx1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CircularLinkedList list = new CircularLinkedList();

            list.InsertAtEnd(new Book { Title = "Book A", Author = "Author 1", Price = 19.99 });
            list.InsertAtEnd(new Book { Title = "Book B", Author = "Author 2", Price = 9.99 });
            list.InsertAtBeginning(new Book { Title = "Book C", Author = "Author 3", Price = 14.99 });

            Console.WriteLine("Original List:");
            list.PrintList();

            list.SortSelection();
            Console.WriteLine("\nList after Selection Sort:");
            list.PrintList();

            list.RemoveByCriteria(b => b.Price > 15);
            Console.WriteLine("\nList after Removing Books with Price > $15:");
            list.PrintList();

            Console.WriteLine("\nReversing the list:");
            list.Reverse();
            list.PrintList();
        }
    }
}
