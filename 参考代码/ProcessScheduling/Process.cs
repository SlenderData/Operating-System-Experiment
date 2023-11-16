using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProcessScheduling
{
    /// <summary>
    /// 进程状态
    /// </summary>
    enum ProcessStatus
    {
        Ready,
        Running,
        Waiting,
        Finish
    }

    /// <summary>
    /// 进程类
    /// </summary>
    class PCB
    {
        //定义属性和访问函数
        private String name;
        private DateTime createTime;
        private int runDuration;
        private int prio;
        private ProcessStatus status;

        private System.Threading.Timer timer = null; //定时器
        private int timeSlice;  //时间片长度

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime CreateTime
        {
            get { return createTime; }
        }

        public int RunDuration
        {
            get { return runDuration; }
            set { runDuration = value; }
        }

        public int Prio
        {
            get { return prio; }
            set { prio = value; }
        }

        public ProcessStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// 获取当前状态名称
        /// </summary>
        public String StatusName
        {
            get
            {
                if (status == ProcessStatus.Ready)
                    return "就绪";
                else if (status == ProcessStatus.Running)
                    return "运行";
                else if (status == ProcessStatus.Waiting)
                    return "等待";
                else
                    return "完成";
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pname"></param>
        public PCB(String pname,int rd,int pr)
        {
            name = pname;
            createTime = DateTime.Now;
            runDuration = rd;
            prio = pr;
            status = ProcessStatus.Ready;        
        }

        /// <summary>
        /// 定时器回调函数
        /// </summary>
        /// <param name="state"></param>
        void TimerCallBack(object state)
        {
            runDuration = runDuration - timeSlice;
            if (runDuration <= 0)
                status = ProcessStatus.Finish;
            else
            {
                status = ProcessStatus.Ready;
            }
        }

        /// <summary>
        /// 每个进程一次运行完成
        /// </summary>
        public void Run() {
            if (runDuration > 0)
            {
                status = ProcessStatus.Running;
                timeSlice = runDuration;
                timer = new Timer(TimerCallBack);
                timer.Change(timeSlice * 100, 0);
            }
        }

        /// <summary>
        /// 按时间片轮转法运行
        /// </summary>
        public void RunByTimeSlice()
        {
            if (runDuration > 0)
            {
                status = ProcessStatus.Running;
                timeSlice = 1;
                timer = new Timer(TimerCallBack);
                timer.Change(timeSlice * 100, 0);
            }
        }

        /// <summary>
        /// 显示进程状态
        /// </summary>
        public void Display(){
            Console.WriteLine("Process {0} is {1} and prio is {2}, RunDuration is {3}", name, StatusName, prio, runDuration);
        }
        
    }
}
