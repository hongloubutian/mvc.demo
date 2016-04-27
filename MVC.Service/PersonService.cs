using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using MVC.DataLib;
namespace MVC.Demo
{
   public  class PersonService
   {
       private PersonService()
       {
       }

       private   static readonly PersonDao Dao = new PersonDao();

       public static PersonDao Instance()
       {
           return Dao;
       }
   }
}
