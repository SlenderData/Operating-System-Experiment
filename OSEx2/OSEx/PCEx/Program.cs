using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/// <summary>
/// 生产者消费者的实例
/// </summary>
namespace PCEx
{
    class Program
    {
        //定义信号量
        static Mutex mutex = new Mutex();

        static Semaphore empty = new Semaphore(10, 10);
        static Semaphore full = new Semaphore(0, 10);
        static int[] buffer = new int[10]; //定义缓冲区

        static Semaphore empty2 = new Semaphore(5, 5);
        static Semaphore full2 = new Semaphore(0, 5);
        static int[] buffer2 = new int[5]; //定义缓冲区

        static Random rand = new Random(); //定义随机数发生器

        static void Main(string[] args)
        {
            new Thread(new ThreadStart(Producer)).Start();
            new Thread(new ThreadStart(Customer)).Start();
            Console.Read();
        }

        /// <summary>
        /// 生产者函数
        /// </summary>
        private static void Producer()
        {
            uint ppointer = 0;
            int temp;
            while (true)
            {
                //同步-》互斥
                empty.WaitOne();
                //mutex.WaitOne();

                temp = rand.Next(1, 100);
                buffer[ppointer] = temp;
                Console.WriteLine("Producer works at {0} with {1}", ppointer, temp);
                ppointer = (ppointer + 1) % 10;

                //mutex.ReleaseMutex();
                full.Release();
                
                Thread.Sleep(rand.Next(200, 400));
            }
        }

        /// <summary>
        /// 消费者函数
        /// </summary>
        private static void Customer()
        {
            uint cpointer = 0;
            int temp;
            while (true)
            {
                //同步-》互斥
                full.WaitOne();
                //mutex.WaitOne();
                       
                temp = rand.Next(1, 100);
                temp = buffer[cpointer];
                Console.WriteLine("Customer gains at {0} with {1}", cpointer, temp);
                cpointer = (cpointer + 1) % 10;
                
                //mutex.ReleaseMutex();
                empty.Release();

                Thread.Sleep(rand.Next(200, 400));
            }
        }
    }
}
