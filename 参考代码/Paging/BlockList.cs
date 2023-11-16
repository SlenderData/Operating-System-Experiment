using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paging
{
    /// <summary>
    /// 进程在内存页面列表
    /// </summary>
    class BlockList
    {
        //定义队列
        private List<Pagetable> plist = null;
        private int m_capacity = 4; // 队列容量

        public List<Pagetable> PList
        {
            get { return plist; }
        }

        /// <summary>
        /// 队列空标志
        /// </summary>
        public Boolean IsEmpty
        {
            get { return (plist == null) || (plist.Count == 0); }
        }

        /// <summary>
        /// 队列满标志
        /// </summary>
        public Boolean IsFull
        {
            get { return (plist != null) && (plist.Count == m_capacity); }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public BlockList(int capacity)
        {
            m_capacity = capacity;
            plist = new List<Pagetable>(m_capacity);
        }

        /// <summary>
        /// 按FIFO策略在追加页面到列表中
        /// </summary>
        /// <param name="value"></param>
        public Pagetable Push(Pagetable value)
        {
            Pagetable rt = null;

            if (plist == null) plist = new List<Pagetable>(m_capacity);
            if (plist.Count == m_capacity)
            {
                rt = plist[0];
                plist.RemoveAt(0);
                rt.IsIn = false;
            }
            plist.Add(value);

            return rt;
        }

        /// <summary>
        /// 显示队列进程状态
        /// </summary>
        public void Display()
        {
            if (IsEmpty == false)
            {
                Console.Write("在内存的页面为: ");
                for (int i = 0; i < plist.Count; i++) Console.Write("PageNo: {0} | ", plist[i].PageNo);
                Console.WriteLine();
            }
            else {
                Console.WriteLine("没有页面在内存");
            }
        }
    }
}
