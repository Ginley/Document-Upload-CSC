using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Document_Upload.Models;

namespace Document_Upload.Controllers
{
    public class DocController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admin(DocModel model)
        {
            if (model.IsAdmin)
            {
                return View("Admin");
            }

            return View("Index");
        }

        public ActionResult Student(DocModel model)
        {

            return View("Student");
        }
    }
}