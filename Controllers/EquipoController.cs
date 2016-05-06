using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EvaluacionPozosPemex.Models;

namespace EvaluacionPozosPemex.Controllers
{
    public class EquipoController : Controller
    {
        private PozosPemexEntities db = new PozosPemexEntities();

        // GET: Equipo
        public ActionResult Index()
        {
            var equipoes = db.Equipoes.Include(e => e.Region);
            return View(equipoes.ToList());
        }

        // GET: Equipo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipoes.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        // GET: Equipo/Create
        public ActionResult Create()
        {
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "Nombre");
            return View();
        }

        // POST: Equipo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EquipoId,Nombre,Compania,Renta,RegionId")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                db.Equipoes.Add(equipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "Nombre", equipo.RegionId);
            return View(equipo);
        }

        // GET: Equipo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipoes.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "Nombre", equipo.RegionId);
            return View(equipo);
        }

        // POST: Equipo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EquipoId,Nombre,Compania,Renta,RegionId")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "Nombre", equipo.RegionId);
            return View(equipo);
        }

        // GET: Equipo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipoes.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        // POST: Equipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipo equipo = db.Equipoes.Find(id);
            db.Equipoes.Remove(equipo);
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
