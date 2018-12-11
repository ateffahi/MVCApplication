using MVC_Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Application.Controllers
{
    public class AttendanceController : Controller
    {
        /// <summary>
        /// GET : Add a Student
        /// </summary>
        /// <returns></returns>
        public ActionResult AddStudentAttendance()
        {
            ViewBag.Message = "Attendance page";
            return View();
        }
        /// <summary>
        /// Display student details
        /// </summary>
        /// <returns></returns>
        [HandleError(View="CustomErrors")] 
        public ActionResult DetailStudentAttendance(int id)
        {
          
            StudentAttendanceViewModel studentAttendances = new StudentAttendanceViewModel()
            {
                Id = id,
                Date = DateTime.Now,
                IsPresent = true,
                Student = new StudentViewModel() { Id = 1, Name = "jonathan"},
                IdClassRoom = 5,
                ClassRoomName = "toto"
            };

            ViewBag.Message = "Detail Student Attendance";
            
            return View();
        }
    }
}