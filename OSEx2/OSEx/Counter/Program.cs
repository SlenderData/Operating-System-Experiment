using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/// <summary>
/// 计时器程序，演示不同线程执行相同代码时的时间。
/// </summary>
namespace Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建10个线程
            Thread td1 = new Thread(new ThreadStart(Counter1));
            Thread td2 = new Thread(new ThreadStart(Counter2));
            Thread td3 = new Thread(new ThreadStart(Counter3));
            Thread td4 = new Thread(new ThreadStart(Counter4));
            Thread td5 = new Thread(new ThreadStart(Counter5));
            Thread td6 = new Thread(new ThreadStart(Counter6));
            Thread td7 = new Thread(new ThreadStart(Counter7));
            Thread td8 = new Thread(new ThreadStart(Counter8));
            Thread td9 = new Thread(new ThreadStart(Counter9));
            Thread td10 = new Thread(new ThreadStart(Counter10));
            
            //启动10个线程
            td1.Start();
            td2.Start();
            td3.Start();
            td4.Start();
            td5.Start();
            td6.Start();
            td7.Start();
            td8.Start();
            td9.Start();
            td10.Start();

            Console.Read();
        }

        private static void Counter1()
        {
            DateTime dt = DateTime.Now;
            for(int i=0;i<900000000;i++)
            {
                int x = 1;
                int y = x + 1;
                x = y + x;
            }
            double off = (DateTime.Now - dt).TotalMilliseconds;

            Console.WriteLine("Counter1 is {0}", off);
        }

        private static void Counter2()
        {
            DateTime dt = DateTime.Now;
            for (int i = 0; i < 900000000; i++)
            {
                int x = 1;
                int y = x + 1;
                x = y + x;
            }
            double off = (DateTime.Now - dt).TotalMilliseconds;

            Console.WriteLine("Counter2 is {0}", off);
        }

        private static void Counter3()
        {
            DateTime dt = DateTime.Now;
            for (int i = 0; i < 900000000; i++)
            {
                int x = 1;
                int y = x + 1;
                x = y + x;
            }
            double off = (DateTime.Now - dt).TotalMilliseconds;

            Console.WriteLine("Counter3 is {0}", off);
        }

        private static void Counter4()
        {
            DateTime dt = DateTime.Now;
            for (int i = 0; i < 900000000; i++)
            {
                int x = 1;
                int y = x + 1;
                x = y + x;
            }
            double off = (DateTime.Now - dt).TotalMilliseconds;

            Console.WriteLine("Counter4 is {0}", off);
        }

        private static void Counter5()
        {
            DateTime dt = DateTime.Now;
            for (int i = 0; i < 900000000; i++)
            {
                int x = 1;
                int y = x + 1;
                x = y + x;
            }
            double off = (DateTime.Now - dt).TotalMilliseconds;

            Console.WriteLine("Counter5 is {0}", off);
        }

        private static void Counter6()
        {
            DateTime dt = DateTime.Now;
            for (int i = 0; i < 900000000; i++)
            {
                int x = 1;
                int y = x + 1;
                x = y + x;
            }
            double off = (DateTime.Now - dt).TotalMilliseconds;

            Console.WriteLine("Counter6 is {0}", off);
        }

        private static void Counter7()
        {
            DateTime dt = DateTime.Now;
            for (int i = 0; i < 900000000; i++)
            {
                int x = 1;
                int y = x + 1;
                x = y + x;
            }
            double off = (DateTime.Now - dt).TotalMilliseconds;

            Console.WriteLine("Counter7 is {0}", off);
        }

        private static void Counter8()
        {
            DateTime dt = DateTime.Now;
            for (int i = 0; i < 900000000; i++)
            {
                int x = 1;
                int y = x + 1;
                x = y + x;
            }
            double off = (DateTime.Now - dt).TotalMilliseconds;

            Console.WriteLine("Counter8 is {0}", off);
        }

        private static void Counter9()
        {
            DateTime dt = DateTime.Now;
            for (int i = 0; i < 900000000; i++)
            {
                int x = 1;
                int y = x + 1;
                x = y + x;
            }
            double off = (DateTime.Now - dt).TotalMilliseconds;

            Console.WriteLine("Counter9 is {0}", off);
        }

        private static void Counter10()
        {
            DateTime dt = DateTime.Now;
            for (int i = 0; i < 900000000; i++)
            {
                int x = 1;
                int y = x + 1;
                x = y + x;
            }
            double off = (DateTime.Now - dt).TotalMilliseconds;

            Console.WriteLine("Counter10 is {0}", off);
        }
    }
}
