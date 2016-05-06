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
    public class PozoController : Controller
    {
        private PozosPemexEntities db = new PozosPemexEntities();

        

        // GET: Pozo
        public ActionResult Index()
        {
            var pozoes = db.Pozoes.Include(p => p.Campo);
            return View(pozoes.ToList());
        }

        // GET: Pozo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pozo pozo = db.Pozoes.Find(id);
            if (pozo == null)
            {
                return HttpNotFound();
            }
            return View(pozo);
        }

        // GET: Pozo/Create
        public ActionResult Create()
        {
            ViewBag.CampoId = new SelectList(db.Campoes, "CampoId", "Nombre");
            return View();
        }

        // POST: Pozo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PozoId,Nombre,Barriles,Meses,CampoId")] Pozo pozo)
        {
            if (ModelState.IsValid)
            {
                db.Pozoes.Add(pozo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CampoId = new SelectList(db.Campoes, "CampoId", "Nombre", pozo.CampoId);
            return View(pozo);
        }

        // GET: Pozo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pozo pozo = db.Pozoes.Find(id);
            if (pozo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CampoId = new SelectList(db.Campoes, "CampoId", "Nombre", pozo.CampoId);
            return View(pozo);
        }

        // POST: Pozo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PozoId,Nombre,Barriles,Meses,CampoId")] Pozo pozo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pozo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CampoId = new SelectList(db.Campoes, "CampoId", "Nombre", pozo.CampoId);
            return View(pozo);
        }

        // GET: Pozo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pozo pozo = db.Pozoes.Find(id);
            if (pozo == null)
            {
                return HttpNotFound();
            }
            return View(pozo);
        }

        // POST: Pozo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pozo pozo = db.Pozoes.Find(id);
            db.Pozoes.Remove(pozo);
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
