using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalSyntax
{
    partial class MyPartialClass
    {
        public void Print()
        {
            Console.WriteLine($"{a}, {b}");
        }
    }
}
