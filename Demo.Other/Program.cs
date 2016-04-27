using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Other
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tools.ToCalc();
            //Tools.ToProgressBar();
            //Tools.ToCalcT();
            //ThreadDemo.ToThread();
            for (int i = 0; i <= 3000; i++)
            {
                Logger.Write(string.Format("时间:{0},编号:{1}",DateTime.Now,i.ToString()));
            }
        }
    }
}
