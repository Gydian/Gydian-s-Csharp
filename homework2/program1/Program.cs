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
            bool isPrime = true;
            string s = "";
            int n = 0;
            Console.Write("please input a positive int");
            s = Console.ReadLine();
            n = int.Parse(s);
            for (int j = 2; j <= n; j++)
            {
                for (int i = 2; i <= Math.Sqrt(j); i++)
                {
                    if (j % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime && n % j == 0)
                {
                    Console.WriteLine(j);
                }
                isPrime = true;
            }
    }
    }
}
