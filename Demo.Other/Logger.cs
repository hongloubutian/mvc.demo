using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Other
{
    public class Logger
    {
        //存放写日志的任务队列
       private  Queue<Action> _queue;

        //写日志的线程
        private Thread _threadWriteLog;

        //信号灯
        private ManualResetEvent _signal;

        //Ctor 初始化
        private Logger()
        {
            this._queue = new Queue<Action>();
            this._signal = new ManualResetEvent(false);
            _threadWriteLog = new Thread(HandlerTask);
            _threadWriteLog.IsBackground = true;
            this._threadWriteLog.Start();
        }

        //单例模式，保持一个日志对象
        private static readonly Logger _Logger = new Logger();

        private static Logger GetInstance()
        {
            return _Logger;
        }

        //处理队列中的任务
        private  void HandlerTask()
        {
            while (true)
            {
                _signal.WaitOne();//等待信号
                _signal.Reset();//接收到后重置

                Thread.Sleep(1000);

                Queue<Action> queueCopy;
                lock (_queue)
                {
                    queueCopy = new Queue<Action>(_queue);
                    _queue.Clear();
                }

                foreach (var action in queueCopy)
                {
                    action();
                }
            }
        }

        private void WriteLog(string content)
        {
            lock (_queue)
            {
                // 将任务加到队列
                _queue.Enqueue(() => File.AppendAllText("d:/log.txt", content));
            }

            // 打开“信号”
            _signal.Set();
        }

        // 公开一个Write方法供外部调用
        public static void Write(string content)
        {
            Task.Factory.StartNew(() => GetInstance().WriteLog(content));
        }
    }
}
