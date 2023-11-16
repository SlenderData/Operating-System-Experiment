using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/// <summary>
/// 演示不同优先级线程的执行进度
/// </summary>
namespace PrioEx
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

            //设置各线程的优先级
            td1.Priority = ThreadPriority.Highest;
            td2.Priority = ThreadPriority.Highest;
            td3.Priority = ThreadPriority.Highest;
            td4.Priority = ThreadPriority.Highest;
            td5.Priority = ThreadPriority.Highest;
            td6.Priority = ThreadPriority.Highest;
            td7.Priority = ThreadPriority.Highest;
            td8.Priority = ThreadPriority.Normal;
            td9.Priority = ThreadPriority.Highest;
            td10.Priority = ThreadPriority.Lowest;

            //启动10各线程
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
            for (int i = 0; i <= 500000000; i++)
            {
                if (i % 1000000 == 0)
                {
                    Console.Write('1');
                }
            }
        }

        private static void Counter2()
        {
            for (int i = 0; i <= 500000000; i++)
            {
                if (i % 1000000 == 0)
                {
                    Console.Write('2');
                }
            }
        }

        private static void Counter3()
        {
            for (int i = 0; i <= 500000000; i++)
            {
                if (i % 1000000 == 0)
                {
                    Console.Write('3');
                }
            }
        }

        private static void Counter4()
        {
            for (int i = 0; i <= 500000000; i++)
            {
                if (i % 1000000 == 0)
                {
                    Console.Write('4');
                }
            }
        }

        private static void Counter5()
        {
            for (int i = 0; i <= 500000000; i++)
            {
                if (i % 1000000 == 0)
                {
                    Console.Write('5');
                }
            }
        }

        private static void Counter6()
        {
            for (int i = 0; i <= 500000000; i++)
            {
                if (i % 1000000 == 0)
                {
                    Console.Write('6');
                }
            }
        }

        private static void Counter7()
        {
            for (int i = 0; i <= 500000000; i++)
            {
                if (i % 1000000 == 0)
                {
                    Console.Write('7');
                }
            }
        }

        private static void Counter8()
        {
            for (int i = 0; i <= 500000000; i++)
            {
                if (i % 1000000 == 0)
                {
                    Console.Write('8');
                }
            }
        }

        private static void Counter9()
        {
            for (int i = 0; i <= 500000000; i++)
            {
                if (i % 1000000 == 0)
                {
                    Console.Write('9');
                }
            }
        }

        private static void Counter10()
        {
            for (int i = 0; i <= 500000000; i++)
            {
                if (i % 1000000 == 0)
                {
                    Console.Write('A');
                }
            }        
        }
    }
}
