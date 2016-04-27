using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Demo;
using MVC.Model;

namespace MVC.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Create
        public ActionResult Create()
        {
            return View();
        }

        #endregion

        #region Edit
        public ActionResult Edit(Guid id)
        {
            var model = BookService.Instance().GetById(id);
            if (model == null) return HttpNotFound();
            return View(model);
        }

        #endregion

        #region Methods   
        [HttpPost]
        public ActionResult AddBook(BookMark model)
        {
            if (ModelState.IsValid)
            {
                model.BookMarkId = Guid.NewGuid();
                model.BookInsertTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                BookService.Instance().Add(model);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(BookMark model)
        {
            if (ModelState.IsValid)
            {
                if (model == null) return HttpNotFound();

                var oldModel = BookService.Instance().GetById(model.BookMarkId);
                BookService.Instance().Delete(oldModel);
                BookService.Instance().Add(model);
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Index
        public ActionResult Index()
        {
            return View(BookService.Instance().GetlistList().OrderBy(x=>x.BookNo));
        }
        #endregion

        #region Delete
        public ActionResult Delete(Guid id)
        {
            var model = BookService.Instance().GetById(id);
            BookService.Instance().Delete(model);
            return RedirectToAction("Index");
        }

        #endregion
    }
}
