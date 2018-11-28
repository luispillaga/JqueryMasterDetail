using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JQuery;

namespace JQuery.Controllers
{
    public class AutosController : Controller
    {
        private TallerJQueryEntities db = new TallerJQueryEntities();

        // GET: Autos
        public ActionResult Index()
        {
            var autoes = db.Autoes.Include(a => a.Persona);
            return View(autoes.ToList());
        }

        // GET: Autos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = db.Autoes.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // GET: Autos/Create
        public ActionResult Create()
        {
            ViewBag.per_id = new SelectList(db.Personas, "per_id", "per_nombre");
            return View();
        }

        // POST: Autos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "aut_id,aut_placa,aut_modelo,aut_color,per_id")] Auto auto)
        {
            if (ModelState.IsValid)
            {
                db.Autoes.Add(auto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.per_id = new SelectList(db.Personas, "per_id", "per_nombre", auto.per_id);
            return View(auto);
        }
        //Child
        [ChildActionOnly]
        public ActionResult crearParcial()
        {
            var auto = new Auto();
            return PartialView("Create", auto);
        }

        // GET: Autos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = db.Autoes.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            ViewBag.per_id = new SelectList(db.Personas, "per_id", "per_nombre", auto.per_id);
            return View(auto);
        }

        // POST: Autos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "aut_id,aut_placa,aut_modelo,aut_color,per_id")] Auto auto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.per_id = new SelectList(db.Personas, "per_id", "per_nombre", auto.per_id);
            return View(auto);
        }

        // GET: Autos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = db.Autoes.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // POST: Autos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auto auto = db.Autoes.Find(id);
            db.Autoes.Remove(auto);
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
