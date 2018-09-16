using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Array = new int[10];
            double sum=0;
            string s = "";
            Console.Write("please input 10 numbers");
            for (int i=0;i<10;i++)
            {
                s = Console.ReadLine();
                Array[i] = int.Parse(s);
                sum += Array[i];
            }
            double average = sum / 10;
            for (int j = 0; j < 10; j++)
            {
                for (int k = j + 1; k < 10; k++)
                {
                    if (Array[j] > Array[k])
                    {
                        int a = Array[j];
                        Array[j] = Array[k];
                        Array[k] = a;
                    }                   
                }
            }
            Console.WriteLine("最大值是" + Array[9]);
            Console.WriteLine("最小值是" + Array[0]);
            Console.WriteLine("平均值是" + average);
            Console.WriteLine("和是" + sum);
        }
    }
}
