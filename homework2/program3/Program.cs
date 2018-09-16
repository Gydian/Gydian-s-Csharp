using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[102];
            bool[] mark = new bool[102];
            for(int i=0;i<=100;i++)
            {
                a[i] = i;
                mark[i] = true;
            }
            for(int i=2;i<=Math.Sqrt(100);i++)
            {
               if(mark[i]==true)
                {
                    for(int j=i;j*i<=99;j++)
                    {
                        mark[j * i] = false;
                    }
                }
            }            
            Console.WriteLine("素数有：");
            for(int i=2;i<=99;i++)
            {
                if(mark[i]==true)
                {
                    Console.Write(a[i] + " ");
                }
             }
        }
    }
}
