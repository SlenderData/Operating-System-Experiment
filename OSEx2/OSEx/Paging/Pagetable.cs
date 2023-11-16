using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paging
{
    /// <summary>
    /// 页表类
    /// </summary>
    class Pagetable
    {
        private int pageNo; //页号
        private int blockNo; //块号
        private Boolean isIn; //在内存标志
        private Boolean isModified; //修改标志
        private String hdAddr;  //硬盘地址

        private BlockList blockList = null; //在内存页面列表

        public int PageNo {
            get { return pageNo; }
            set { pageNo = value; }
        }

        public int BlockNo
        {
            get { return blockNo; }
            set { blockNo = value; }
        }

        public Boolean IsIn
        {
            get { return isIn; }
            set { isIn = value; }
        }

        public Boolean IsModified
        {
            get { return isModified; }
            set { isModified = value; }
        }

        public String HdAddr
        {
            get { return hdAddr; }
            set { hdAddr = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pageno"></param>
        /// <param name="blockno"></param>
        /// <param name="isin"></param>
        /// <param name="ismodified"></param>
        /// <param name="hdaddr"></param>
        public Pagetable(int pageno, int blockno, Boolean isin, Boolean ismodified, String hdaddr, BlockList blocklist) {
            pageNo = pageno;
            blockNo = blockno;
            isIn = isin;
            isModified = ismodified;
            hdAddr = hdaddr;
            blockList = blocklist;
        }

        /// <summary>
        /// 读页面
        /// </summary>
        public void read()
        {
            if (isIn == false) {
                Console.WriteLine("Missing Page Interruption");
                
                Pagetable pt = blockList.Push(this);
                if (pt != null) pt.IsIn = false;
                isIn = true;
            }

            Console.WriteLine("Page {0} in {1} block is read", pageNo, blockNo);          
        }

        /// <summary>
        /// 写页面
        /// </summary>
        public void write()
        {
            if (isIn == false)
            {
                Console.WriteLine("Missing Page Interruption");

                Pagetable pt = blockList.Push(this);
                if (pt != null) pt.IsIn = false;
                isIn = true;
            }

            isModified = true;

            Console.WriteLine("Page {0} in {1} block is write", pageNo, blockNo);
        }


        /// <summary>
        /// 显示进程状态
        /// </summary>
        public void Display()
        {
            Console.WriteLine("Page {0}, isIn {1}, isModified {2}, BlockNo {3}, HdAddr {4}", pageNo, isIn, isModified, blockNo, hdAddr);
        }
    }
}
