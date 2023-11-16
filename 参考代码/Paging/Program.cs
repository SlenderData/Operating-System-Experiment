using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 页面调度算法实现范例
/// </summary>
namespace Paging
{
    /// <summary>
    /// 主控类
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            BlockList blockList = new BlockList(5);
            Random rand = new Random(); //定义随机数发生器

            List<Pagetable> plist = new List<Pagetable>();

            for (int i = 0; i < 20; i++)
            {
                Pagetable pt = new Pagetable(i + 1, i * 10 + 1, false, false, "Hd" + (i * 1000).ToString(), blockList);
                plist.Add(pt);
            }

            for (int i = 0; i < 50; i++)
            {
                int pn = rand.Next(1, 20);
                Boolean wr = (rand.Next(0, 1) == 1);

                if (wr)
                    plist[pn - 1].write();
                else
                    plist[pn - 1].read();

                blockList.Display();
                for (int k = 0; k < plist.Count; k++) plist[k].Display();

                Console.WriteLine("-------------------");
                Console.Read();
            }
        }
    }
}
