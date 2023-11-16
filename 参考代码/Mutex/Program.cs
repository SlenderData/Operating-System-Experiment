using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/// <summary>
/// 互斥信号量的使用实例
/// </summary>
namespace MutexEx
{
    class Program
    {
        //创建互斥信号量对象
        static Mutex mutex = new Mutex();
        static Random rand = new Random(); //定义随机数发生器

        static void Main(string[] args)
        {
            // 创建线程并启动
            new Thread(new ThreadStart(Producer)).Start();
            new Thread(new ThreadStart(Customer)).Start();
            Console.Read();
        }

        /// <summary>
        /// 生产者线程
        /// </summary>
        private static void Producer()
        {
            while (true)
            {
                mutex.WaitOne();
                Console.WriteLine("----------------------");
                Console.WriteLine("Producer is working!");
                Thread.Sleep(500);
                Console.WriteLine("Producer is finish!");
                Console.WriteLine("----------------------");
                mutex.ReleaseMutex();
                Thread.Sleep(rand.Next(200, 400));
            }
        }

        /// <summary>
        /// 消费者线程
        /// </summary>
        private static void Customer()
        {
            while (true)
            {
                mutex.WaitOne();
                Console.WriteLine("----------------------");
                Console.WriteLine("customer is working");
                Thread.Sleep(500);
                Console.WriteLine("customer is finish!");
                Console.WriteLine("----------------------");
                mutex.ReleaseMutex();
                Thread.Sleep(rand.Next(200, 400));
            }
        }
    }
}
