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
    public class PrecioController : Controller
    {
        private PozosPemexEntities db = new PozosPemexEntities();

        // GET: Precio
        public ActionResult Index()
        {
            var precios = db.Precios.Include(p => p.Campo);
            return View(precios.ToList());
        }

        // GET: Precio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Precio precio = db.Precios.Find(id);
            if (precio == null)
            {
                return HttpNotFound();
            }
            return View(precio);
        }

        // GET: Precio/Create
        public ActionResult Create()
        {
            ViewBag.CampoId = new SelectList(db.Campoes, "CampoId", "Nombre");
            return View();
        }

        // POST: Precio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrecioId,PrecioCrudo,PrecioGas,Ano,CampoId")] Precio precio)
        {
            if (ModelState.IsValid)
            {
                db.Precios.Add(precio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CampoId = new SelectList(db.Campoes, "CampoId", "Nombre", precio.CampoId);
            return View(precio);
        }

        // GET: Precio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Precio precio = db.Precios.Find(id);
            if (precio == null)
            {
                return HttpNotFound();
            }
            ViewBag.CampoId = new SelectList(db.Campoes, "CampoId", "Nombre", precio.CampoId);
            return View(precio);
        }

        // POST: Precio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrecioId,PrecioCrudo,PrecioGas,Ano,CampoId")] Precio precio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(precio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CampoId = new SelectList(db.Campoes, "CampoId", "Nombre", precio.CampoId);
            return View(precio);
        }

        // GET: Precio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Precio precio = db.Precios.Find(id);
            if (precio == null)
            {
                return HttpNotFound();
            }
            return View(precio);
        }

        // POST: Precio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Precio precio = db.Precios.Find(id);
            db.Precios.Remove(precio);
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
