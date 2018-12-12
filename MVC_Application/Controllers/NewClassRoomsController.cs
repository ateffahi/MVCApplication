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
    public class NewClassRoomsController : Controller
    {
        private AttendanceContext db = new AttendanceContext();

        // GET: NewClassRooms
        public ActionResult Index()
        {
            return View(db.ClassRoom.ToList());
        }

        // GET: NewClassRooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassRoom classRoom = db.ClassRoom.Find(id);
            if (classRoom == null)
            {
                return HttpNotFound();
            }
            return View(classRoom);
        }

        // GET: NewClassRooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewClassRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,Name")] ClassRoom classRoom)
        {
            if (ModelState.IsValid)
            {
                db.ClassRoom.Add(classRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classRoom);
        }

        // GET: NewClassRooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassRoom classRoom = db.ClassRoom.Find(id);
            if (classRoom == null)
            {
                return HttpNotFound();
            }
            return View(classRoom);
        }

        // POST: NewClassRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,Name")] ClassRoom classRoom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classRoom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classRoom);
        }

        // GET: NewClassRooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassRoom classRoom = db.ClassRoom.Find(id);
            if (classRoom == null)
            {
                return HttpNotFound();
            }
            return View(classRoom);
        }

        // POST: NewClassRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassRoom classRoom = db.ClassRoom.Find(id);
            db.ClassRoom.Remove(classRoom);
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
