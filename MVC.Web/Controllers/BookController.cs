using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Demo;
using MVC.Model;

namespace MVC.Web.Controllers
{
    public class BookController : Controller
    {
        //
        // GET: /Book/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BookList()
        {
            var list = BookService.Instance().GetlistList().OrderBy(x=>x.BookNo);
            return Json(list,JsonRequestBehavior.AllowGet);
        }
    }
}
