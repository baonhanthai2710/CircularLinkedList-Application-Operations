using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectEx1
{
    internal class Node
    {
        public Book Data { get; set; }
        public Node Next { get; set; }

        public Node(Book data)
        {
            Data = data;
            Next = null;
        }
    }
}
