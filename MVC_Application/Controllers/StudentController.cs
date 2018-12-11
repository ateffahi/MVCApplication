using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Application.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student/
        public ActionResult AddStudent()
        {
            return View();
        }
    }
}