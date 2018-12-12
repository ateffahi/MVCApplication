using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Application.Entities;
using MVC_Application.Filtres;

namespace MVC_Application.Controllers
{
    [CustomLogFilter]
    public class NewAttendancesController : Controller
    {
        private AttendanceContext db = new AttendanceContext();

        // GET: NewAttendances
        
        public ActionResult Index()
        {
            var attendance = db.Attendance.Include(a => a.ClassRoom).Include(a => a.Student);
            return View(attendance.ToList());
        }

        // GET: NewAttendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendance.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // GET: NewAttendances/Create
        public ActionResult Create()
        {
            ViewBag.IdClassRoom = new SelectList(db.ClassRoom, "Id", "Name");
            ViewBag.IdStudent = new SelectList(db.Student, "Id", "Name");
            return View();
        }

        // POST: NewAttendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,IsPresent,IdStudent,IdClassRoom")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Attendance.Add(attendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdClassRoom = new SelectList(db.ClassRoom, "Id", "Name", attendance.IdClassRoom);
            ViewBag.IdStudent = new SelectList(db.Student, "Id", "Name", attendance.IdStudent);
            return View(attendance);
        }

        // GET: NewAttendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendance.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClassRoom = new SelectList(db.ClassRoom, "Id", "Name", attendance.IdClassRoom);
            ViewBag.IdStudent = new SelectList(db.Student, "Id", "Name", attendance.IdStudent);
            return View(attendance);
        }

        // POST: NewAttendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,IsPresent,IdStudent,IdClassRoom")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdClassRoom = new SelectList(db.ClassRoom, "Id", "Name", attendance.IdClassRoom);
            ViewBag.IdStudent = new SelectList(db.Student, "Id", "Name", attendance.IdStudent);
            return View(attendance);
        }

        // GET: NewAttendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendance.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // POST: NewAttendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendance attendance = db.Attendance.Find(id);
            db.Attendance.Remove(attendance);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
