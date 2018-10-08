using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    //声明参数类型
    public class ClockEventArgs : EventArgs
    {
    }
    //声明委托类型
    public delegate void ClockEventHandler(object sender,ClockEventArgs e);
    //定义事件源
    public class Clock
    {
        //声明事件
        public event ClockEventHandler Clocker;

        public void timing()
        {
            string s = "";
            Console.WriteLine("please set time,for example 19:45:21");
            s = Console.ReadLine();    
            while (DateTime.Now.ToLongTimeString().ToString() != s)
            {
            }
            ClockEventArgs args = new ClockEventArgs();
                Clocker(this, args);
        }
    }
    class Program
    {
        //回调函数
        static void showTiming(object sender,ClockEventArgs e)
        {
            Console.WriteLine("闹钟响了");
        }
        static void Main(string[] args)
        {            
            Clock clock = new Clock();
            //注册事件
            clock.Clocker += showTiming;
            clock.timing();
        }       
    }
}
