using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 驱动调度范例
/// </summary>
namespace DriveScheduling
{
    /// <summary>
    /// 主控类
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            List<int> m_Tracks = new List<int>();
            m_Tracks.Add(2);
            m_Tracks.Add(34);
            m_Tracks.Add(5);
            m_Tracks.Add(8);
            m_Tracks.Add(3);
            m_Tracks.Add(24);
            m_Tracks.Add(12);
            m_Tracks.Add(18);

            Driver driver = new Driver(15, 49, m_Tracks, DriveDir.Down);

            driver.shortestFirst();

            Console.Read();
        }
    }
}
