using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectEx1
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{Title} by {Author}, ${Price:F2}";
        }
    }
}
