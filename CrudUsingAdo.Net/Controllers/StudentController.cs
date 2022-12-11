using CrudUsingAdo.Net.Business_Layer;
using CrudUsingAdo.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudUsingAdo.Net.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int? rollnumber)
        {
            StudentBL bl = new StudentBL();
            Student student = bl.GetStudentDetailsByRollNumber(rollnumber ?? 0);
            return View(student);
        }
    }
}