using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            double n = 0;
            double d = 0;
            Console.Write("Please input a double:");
            s = Console.ReadLine();
            n = double.Parse(s);
            Console.Write("Please input another double:");
            s = Console.ReadLine();
            d = double.Parse(s);
            Console.WriteLine("the multiply of them is:" + (n * d));
        }
    }
}
