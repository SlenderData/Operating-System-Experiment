using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/// <summary>
/// 处理器调度演示程序
/// </summary>
namespace ProcessScheduling
{
    class Program
    {
        private static ReadyList readyList = new ReadyList();
        static Random rand = new Random(); //定义随机数发生器
        /// <summary>
        /// FIFO调度
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            PCB pcb = new PCB("PCB1", rand.Next(1, 10), rand.Next(1, 10));
            readyList.Push(pcb);
            pcb = new PCB("PCB2", rand.Next(1, 10), rand.Next(1, 10));
            readyList.Push(pcb);
            pcb = new PCB("PCB3", rand.Next(1, 10), rand.Next(1, 10));
            readyList.Push(pcb);
            pcb = new PCB("PCB4", rand.Next(1, 10), rand.Next(1, 10));
            readyList.Push(pcb);
            pcb = new PCB("PCB5", rand.Next(1, 10), rand.Next(1, 10));
            readyList.Push(pcb);
            pcb = null;

            while (!((readyList.IsEmpty == true) && ((pcb == null) || (pcb.Status == ProcessStatus.Finish))))
            {
                Console.WriteLine("================================");
                if ((pcb != null) && (pcb.Status == ProcessStatus.Ready))
                {
                    readyList.Push(pcb);
                    pcb = null;
                }

                if ((pcb == null) || (pcb.Status == ProcessStatus.Finish))
                {
                    if ((pcb != null) && (pcb.Status == ProcessStatus.Finish)) pcb.Display();
                    pcb = readyList.Pop();
                }

                if (pcb != null)
                {
                    if (pcb.Status != ProcessStatus.Running) pcb.Run();

                    pcb.Display();
                    readyList.Display();
                }
                Console.WriteLine("********************************");
                Thread.Sleep(100);
            }

            if (pcb != null) pcb.Display();

            Console.Read();

        }

        /// <summary>
        /// FIFO+时间片轮转调度
        /// </summary>
        /// <param name="args"></param>
        /*static void Main(string[] args)
        {

            PCB pcb = new PCB("PCB1", rand.Next(1,10), rand.Next(1, 10));
            readyList.Push(pcb);
            pcb = new PCB("PCB2", rand.Next(1, 10), rand.Next(1, 10));
            readyList.Push(pcb);
            pcb = new PCB("PCB3", rand.Next(1, 10), rand.Next(1, 10));
            readyList.Push(pcb);
            pcb = new PCB("PCB4", rand.Next(1, 10), rand.Next(1, 10));
            readyList.Push(pcb);
            pcb = new PCB("PCB5", rand.Next(1, 10), rand.Next(1, 10));
            readyList.Push(pcb);
            pcb = null;

            while (readyList.IsEmpty == false) {
                Console.WriteLine("================================");
                if ((pcb != null) && (pcb.Status == ProcessStatus.Ready))
                {
                    readyList.Push(pcb);
                    pcb = null;
                }

                if ((pcb == null) || (pcb.Status == ProcessStatus.Finish))
                {              
                    if ((pcb != null) && (pcb.Status == ProcessStatus.Finish)) pcb.Display();
                    pcb = readyList.Pop();
                }

                if (pcb != null)
                {
                    if (pcb.Status != ProcessStatus.Running) pcb.RunByTimeSlice();
                 
                    pcb.Display();
                    readyList.Display();
                }
                Console.WriteLine("********************************");
                Thread.Sleep(100);
            }

            while (pcb != null)
            {
                Console.WriteLine("================================");
                if (pcb != null)
                {
                    if (pcb.Status != ProcessStatus.Running) pcb.RunByTimeSlice();

                    pcb.Display();
                }
                Console.WriteLine("********************************");
                if (pcb.Status == ProcessStatus.Finish) break;
                Thread.Sleep(100);
            }

            Console.Read();

        }*/
    }
}
