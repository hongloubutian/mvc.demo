using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace Demo.Other
{
    public class ThreadDemo
    {
        #region Ctor
        private ThreadDemo()
        {
        }
        #endregion

        #region 1

        private static bool done;
        private static object locker = new object();//锁

        private static void Go()
        {
            if (!done)
            {
                Thread.Sleep(500);
                Console.WriteLine("Done");
                done = true;
            }
        }

        #endregion

        #region 线程信号机制

        private static void SignalTest()
        {
            var signal = new ManualResetEvent(false);
            new Thread(() =>
            {
                Console.WriteLine("Waiting signal...");
                signal.WaitOne();
                signal.Dispose();
                Console.WriteLine("Get It");
            }
           ).Start();
              Thread.Sleep(2000);

            signal.Set();//打开信号

            Console.ReadKey();

        }

        #endregion
        public static void ToThread()
        {
            Thread t = new Thread(SignalTest);
            t.Start();
            Console.ReadKey();
        }

    }
}
