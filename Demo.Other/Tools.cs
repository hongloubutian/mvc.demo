using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Demo.Other
{
    public  class Tools
    {
        private Tools()
        {
        }

        #region 1
        /// <summary>
        /// 定义一个委托
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private delegate int Calculate(int x, int y);

        //定义一个和委托有相同参数的方法
        private static int CalcFunction(int x, int y)
        {
            return x + y;
        }

        private static int TimesFunction(int x, int y)
        {
            return x * y;
        }


        public static void ToCalc()
        {
            Calculate calc = CalcFunction;
            Console.WriteLine("1+2={0}", calc(1, 2));

            calc += TimesFunction;
            Console.WriteLine("1*2={0}", calc(1, 2));

            Console.ReadLine();
        }
        #endregion    

        #region 2

        private delegate void ProgressBar(int percentNumber);

        private  static void Match(ProgressBar bar)
        {
            for (int i=0;i<=10;i++)
            {
                bar(i*10);
                System.Threading.Thread.Sleep(100);
            }
        }

        private static  void ShowProgressBar(int number)
        {
            Console.WriteLine("进度:{0}%",number);
        }

        public static void ToProgressBar()
        {
            ProgressBar progressBar=ShowProgressBar;
            Match(progressBar);
            Console.WriteLine("Done..");
            Console.ReadLine();
        }

        #endregion

        #region 泛型委托
        private  delegate T Calculator<T>(T args);

        private static void Calc<T>(T[] values)
        {
            Calculate calc = TimesFunction;
            for (int i=0;i<values.Length;i++)
            {
                Console.WriteLine(calc(Convert.ToInt32(values[i]),i));
            }
            Console.ReadLine();
        }

        public static void ToCalcT()
        {
            int[] values = {1,4,9,14,25,56,7,58,9};
            Calc(values);
        }

        #endregion
    }

}
