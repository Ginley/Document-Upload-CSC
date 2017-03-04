using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Document_Upload.Models;
using System.IO;

namespace Document_Upload.Controllers
{
    public class DocController : Controller
    {
        private readonly DocDao docDao;

        public DocController()
        {
            docDao = new DocDao();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admin(DocModel model)
        {
            return View("Admin");
        }

        public FileResult GetDoc(DocModel model)
        {
            return File(docDao.GetDoc(model), ".pdf", "Test File");
        }

        public ActionResult Student(DocModel model)
        {

            return View("Student");
        }

        public void AddDoc(DocModel model)
        {
            docDao.AddDoc(model.FirstName, model.LastName, model.Document);
        }
    }
}