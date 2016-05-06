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
    public class CampoController : Controller
    {
        private PozosPemexEntities db = new PozosPemexEntities();

        // GET: Campo
        public ActionResult Index()
        {
            var campoes = db.Campoes.Include(c => c.Activo).Include(c => c.Region);
            return View(campoes.ToList());
        }

        // GET: Campo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campo campo = db.Campoes.Find(id);
            if (campo == null)
            {
                return HttpNotFound();
            }
            return View(campo);
        }

        // GET: Campo/Create
        public ActionResult Create()
        {
            ViewBag.ActivoId = new SelectList(db.Activoes, "ActivoId", "Nombre");
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "Nombre");
            return View();
        }

        // POST: Campo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CampoId,Nombre,ActivoId,RegionId,Declinacion,GastoFijo,GastoVariable,GastoTotal")] Campo campo)
        {
            if (ModelState.IsValid)
            {
                db.Campoes.Add(campo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivoId = new SelectList(db.Activoes, "ActivoId", "Nombre", campo.ActivoId);
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "Nombre", campo.RegionId);
            return View(campo);
        }

        // GET: Campo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campo campo = db.Campoes.Find(id);
            if (campo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivoId = new SelectList(db.Activoes, "ActivoId", "Nombre", campo.ActivoId);
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "Nombre", campo.RegionId);
            return View(campo);
        }

        // POST: Campo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CampoId,Nombre,ActivoId,RegionId,Declinacion,GastoFijo,GastoVariable,GastoTotal")] Campo campo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivoId = new SelectList(db.Activoes, "ActivoId", "Nombre", campo.ActivoId);
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "Nombre", campo.RegionId);
            return View(campo);
        }

        // GET: Campo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campo campo = db.Campoes.Find(id);
            if (campo == null)
            {
                return HttpNotFound();
            }
            return View(campo);
        }

        // POST: Campo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Campo campo = db.Campoes.Find(id);
            db.Campoes.Remove(campo);
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
