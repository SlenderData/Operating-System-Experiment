using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveScheduling
{
    /// <summary>
    /// 运动方向
    /// </summary>
    enum DriveDir
    {
        Up, // 从小到大
        Down  //从大到小
    }

    /// <summary>
    /// 驱动调度类
    /// </summary>
    class Driver
    {
        private List<int> m_Tracks = null; //要访问的磁道列表
        private int maxTrack = 49; //最大磁道，最小为0
        private int curPos = 0; //当前位置
        private DriveDir driveDir = DriveDir.Up; //磁头当前运动方向

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="curpos"></param>
        /// <param name="maxtrack"></param>
        /// <param name="tracks"></param>
        /// <param name="dir"></param>
        public Driver(int curpos, int maxtrack, List<int> tracks, DriveDir dir)
        {
            curPos = curpos;
            maxTrack = maxtrack;
            m_Tracks = tracks;
            driveDir = dir;
        }

        /// <summary>
        /// 最短距离优先调度
        /// </summary>
        public void shortestFirst()
        {
            int trip = 0;
            int curp = curPos;
            DriveDir cdir = driveDir;

            List<int> buf = new List<int>();
            if (m_Tracks != null) {
                for (int i = 0; i < m_Tracks.Count; i++) buf.Add(m_Tracks[i]);
            }

            Console.WriteLine("Start...");
            while ((buf != null) && (buf.Count > 0)) {
                int t = getShortestP(buf, curp);
                if (t >= 0)
                {
                    trip += Math.Abs(curp - buf[t]);

                    if (curp > buf[t])
                    {
                        if (cdir == DriveDir.Down)
                        {
                            Console.WriteLine("From {0} move to {1} and trip is {2}", curp, buf[t], trip);
                            curp = buf[t];
                            buf.RemoveAt(t);
                        }
                        else
                        {
                            Console.WriteLine("From {0} turn around to {1} and trip is {2}", curp, buf[t], trip);
                            curp = buf[t];
                            cdir = DriveDir.Down;
                            buf.RemoveAt(t);
                        }
                    }
                    else if (curp < buf[t])
                    {
                        if (cdir == DriveDir.Up)
                        {
                            Console.WriteLine("From {0} move to {1} and trip is {2}", curp, buf[t], trip);
                            curp = buf[t];
                            buf.RemoveAt(t);
                        }
                        else
                        {
                            Console.WriteLine("From {0} turn around to {1} and trip is {2}", curp, buf[t], trip);
                            curp = buf[t];
                            cdir = DriveDir.Up;
                            buf.RemoveAt(t);
                        }
                    }
                    else {
                        Console.WriteLine("Keep in {0} and trip is {1}", buf[t], trip);
                        buf.RemoveAt(t);
                    }
                }
            }
            Console.WriteLine("------Finish");
        }

        /// <summary>
        /// 获取到当前位置的最近磁道
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        private int getShortestP(List<int> buf, int pos) {
            int rt = -1;
            int dis = maxTrack+1;

            if (buf != null) {
                for (int i = 0; i < buf.Count; i++)
                {
                    int temp = Math.Abs(buf[i] - pos);
                    if (temp < dis) {
                        dis = temp;
                        rt = i;
                    }
                }
            }

            return rt;
        }

    }
}
