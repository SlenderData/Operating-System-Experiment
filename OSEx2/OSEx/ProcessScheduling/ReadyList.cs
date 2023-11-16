using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessScheduling
{
    /// <summary>
    /// 就绪队列管理类
    /// </summary>
    class ReadyList
    {
        //定义队列
        private List<PCB> plist = null;

        public List<PCB> PList {
            get { return plist; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ReadyList()
        {
            plist = new List<PCB>();
        }

        /// <summary>
        /// 判断队列是否为空
        /// </summary>
        public Boolean IsEmpty {
            get {
                return (plist == null) || (plist.Count == 0);
            }
        }

        /// <summary>
        /// 取出队首 PCB
        /// </summary>
        public PCB Pop()
        {
            if ((plist != null) && (plist.Count > 0))
            {
                PCB pcb = plist[0];
                plist.RemoveAt(0);
                return pcb;
            }
            else return null;
        }

        /// <summary>
        /// 在队尾追加进程PCB
        /// </summary>
        /// <param name="value"></param>
        public void Push(PCB value) {
            if (plist == null) plist = new List<PCB>();
            plist.Add(value);
        }

        /// <summary>
        /// 显示队列进程状态
        /// </summary>
        public void Display()
        {
            if (IsEmpty == false) {
                for (int i = 0; i < plist.Count; i++) plist[i].Display();
            }
        }
    }
}
