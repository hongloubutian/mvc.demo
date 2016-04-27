using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Demo;
using MVC.Model;

namespace MVC.Web.Controllers
{
    public class UserController : Controller
    {
        #region Get
        //
        // GET: /User/
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region POST

        [HttpPost]
        public ActionResult Add(PersonModel model)
        {
            if (model != null)
                PersonService.Instance().Add(model);
            return View("Index");
        }

        [HttpPost]
        public ActionResult LoginUrl(string userName, string userPwd)
        {
            string personId = "";
            int result = PersonService.Instance().LoginSuccess(userName, userPwd, out personId);
            Session["userinfo"] = personId;
            if (result > 0)
                return View("Index");
            else
            {
                return View("Login");
            }
        }

        #endregion
    }
}
