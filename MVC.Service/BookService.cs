using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVC.DataLib;
namespace MVC.Demo
{
    public  class BookService
    {
        //单例模式 禁止new，支持多线程
       private BookService()
        {
        }

        private  static readonly BookDao Dao = new BookDao();

        public static BookDao Instance()
        {
            return Dao;
        }

    }
}
