﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using S2G5_SISAPPLICATION.Models;

namespace S2G5_SISAPPLICATION.Controllers
{
    public class RegistrationsController : Controller
    {
        private Entities db = new Entities();

        // GET: Registrations
        public ActionResult Index()
        {
            var registrations = db.Registrations.Include(r => r.Courses).Include(r => r.Students).Include(r => r.StudyTerms);
            return View(registrations.ToList());
        }

        // GET: Registrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registrations registrations = db.Registrations.Find(id);
            if (registrations == null)
            {
                return HttpNotFound();
            }
            return View(registrations);
        }

        // GET: Registrations/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentFname");
            ViewBag.TermID = new SelectList(db.StudyTerms, "TermID", "TermName");
            return View();
        }

        // POST: Registrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,CourseID,TermID,ID")] Registrations registrations)
        {
            if (ModelState.IsValid)
            {
                db.Registrations.Add(registrations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", registrations.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentFname", registrations.StudentID);
            ViewBag.TermID = new SelectList(db.StudyTerms, "TermID", "TermName", registrations.TermID);
            return View(registrations);
        }

        // GET: Registrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registrations registrations = db.Registrations.Find(id);
            if (registrations == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", registrations.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentFname", registrations.StudentID);
            ViewBag.TermID = new SelectList(db.StudyTerms, "TermID", "TermName", registrations.TermID);
            return View(registrations);
        }

        // POST: Registrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,CourseID,TermID,ID")] Registrations registrations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registrations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", registrations.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentFname", registrations.StudentID);
            ViewBag.TermID = new SelectList(db.StudyTerms, "TermID", "TermName", registrations.TermID);
            return View(registrations);
        }

        // GET: Registrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registrations registrations = db.Registrations.Find(id);
            if (registrations == null)
            {
                return HttpNotFound();
            }
            return View(registrations);
        }

        // POST: Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registrations registrations = db.Registrations.Find(id);
            db.Registrations.Remove(registrations);
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
