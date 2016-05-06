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
    public class ActivoController : Controller
    {
        private PozosPemexEntities db = new PozosPemexEntities();

        // GET: Activo
        public ActionResult Index()
        {
            var activoes = db.Activoes.Include(a => a.Region);
            return View(activoes.ToList());
        }

        // GET: Activo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activo activo = db.Activoes.Find(id);
            if (activo == null)
            {
                return HttpNotFound();
            }
            return View(activo);
        }

        // GET: Activo/Create
        public ActionResult Create()
        {
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "Nombre");
            return View();
        }

        // POST: Activo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActivoId,Nombre,RegionId")] Activo activo)
        {
            if (ModelState.IsValid)
            {
                db.Activoes.Add(activo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "Nombre", activo.RegionId);
            return View(activo);
        }

        // GET: Activo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activo activo = db.Activoes.Find(id);
            if (activo == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "Nombre", activo.RegionId);
            return View(activo);
        }

        // POST: Activo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActivoId,Nombre,RegionId")] Activo activo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "Nombre", activo.RegionId);
            return View(activo);
        }

        // GET: Activo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activo activo = db.Activoes.Find(id);
            if (activo == null)
            {
                return HttpNotFound();
            }
            return View(activo);
        }

        // POST: Activo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activo activo = db.Activoes.Find(id);
            db.Activoes.Remove(activo);
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
