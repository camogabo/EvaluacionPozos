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
    public class OperacionController : Controller
    {
        private PozosPemexEntities db = new PozosPemexEntities();

        // GET: Operacion
        public ActionResult Index()
        {
            var operacions = db.Operacions.Include(o => o.Campo).Include(o => o.Equipo).Include(o => o.Pozo);
            return View(db.Operacions.ToList());
        }

        // GET: Operacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operacion operacion = db.Operacions.Find(id);
            if (operacion == null)
            {
                return HttpNotFound();
            }
            return View(operacion);
        }

        // GET: Operacion/Create
        public ActionResult Create()
        {
            var pozoID=0;
            TempData["PozoId"] = pozoID;

            ViewBag.CampoId = new SelectList(db.Campoes, "CampoId", "Nombre");
            ViewBag.EquipoId = new SelectList(db.Equipoes, "EquipoId", "Nombre");
            ViewBag.PozoId = new SelectList(db.Pozoes, "PozoId", "Nombre");
            //db.sp_calcularOpex(2.3, 3.1, 3.0, 1.1, 1, 1, 1);
            return View();
        }

        // POST: Operacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OperacionId,CampoId,EquipoId,PozoId,Opex,GasAceite,Rga,tasaImpositiva,Paridad")] Operacion operacion)
        {
            if (ModelState.IsValid)
            {
                db.Operacions.Add(operacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CampoId = new SelectList(db.Campoes, "CampoId", "Nombre", operacion.CampoId);
            ViewBag.EquipoId = new SelectList(db.Equipoes, "EquipoId", "Nombre", operacion.EquipoId);
            ViewBag.PozoId = new SelectList(db.Pozoes, "PozoId", "Nombre", operacion.PozoId);

            return View(operacion);
        }

        // GET: Operacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operacion operacion = db.Operacions.Find(id);
            if (operacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CampoId = new SelectList(db.Campoes, "CampoId", "Nombre", operacion.CampoId);
            ViewBag.EquipoId = new SelectList(db.Equipoes, "EquipoId", "Nombre", operacion.EquipoId);
            ViewBag.PozoId = new SelectList(db.Pozoes, "PozoId", "Nombre", operacion.PozoId);
            return View(operacion);
        }

        // POST: Operacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OperacionId,CampoId,EquipoId,PozoId,Opex,GasAceite,Rga,tasaImpositiva,Paridad")] Operacion operacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CampoId = new SelectList(db.Campoes, "CampoId", "Nombre", operacion.CampoId);
            ViewBag.EquipoId = new SelectList(db.Equipoes, "EquipoId", "Nombre", operacion.EquipoId);
            ViewBag.PozoId = new SelectList(db.Pozoes, "PozoId", "Nombre", operacion.PozoId);
            return View(operacion);
        }

        // GET: Operacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operacion operacion = db.Operacions.Find(id);
            if (operacion == null)
            {
                return HttpNotFound();
            }
            return View(operacion);
        }

        // POST: Operacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Operacion operacion = db.Operacions.Find(id);
            db.Operacions.Remove(operacion);
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
