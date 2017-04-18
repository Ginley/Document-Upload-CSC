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

        public ActionResult GetDoc(DocModel model)
        {
            var document = docDao.GetDoc(model);
            return File(System.IO.File.ReadAllBytes(document.ToString()), ".pdf", "Test File");
        }

        public ActionResult Student(DocModel model)
        {

            return View("Student");
        }

        public ActionResult AddDoc(DocModel model)
        {
            if (model.Document == null || model.Document.ContentLength == 0)
            {
                ModelState.AddModelError(string.Empty, "This field is required.");
            }
            if (string.IsNullOrEmpty(model.FirstName) || string.IsNullOrEmpty(model.LastName))
            {
                ModelState.AddModelError(string.Empty, "Both name fields are required.");
            }

            if (ModelState.IsValid)
            {
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
                {
                    fileData = binaryReader.ReadBytes(Request.Files[0].ContentLength);
                }

                bool result = docDao.AddDoc(model.FirstName, model.LastName, fileData);

                if (result == true)
                {
                    return View("Success");
                }
            }

            return View("Student");
        }
    }
}