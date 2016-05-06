using EvaluacionPozosPemex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvaluacionPozosPemex.Controllers
{
    public class VRegionesController : Controller
    {

        private PozosPemexEntities db = new PozosPemexEntities();

        // GET: VRegiones


        public ActionResult AguasSomeras()
        {
            var model = db.Database.SqlQuery<Campo>("SELECT * FROM Campo WHERE RegionId = 1 ").ToList();
            return View(model);
        }

        public ActionResult CamposTerrestres()
        {
            var model = db.Database.SqlQuery<Campo>("SELECT * FROM Campo WHERE RegionId = 2 ").ToList();
            return View(model);
        }

        public ActionResult Gas()
        {
            var model = db.Database.SqlQuery<Campo>("SELECT * FROM Campo WHERE RegionId = 3 ").ToList();
            return View(model);
        }

        public ActionResult NoConvencionales()
        {
            var model = db.Database.SqlQuery<Campo>("SELECT * FROM Campo WHERE RegionId = 4 ").ToList();
            return View(model);
        }

        public ActionResult DesarrolloCampos()
        {
            var model = db.Database.SqlQuery<Campo>("SELECT * FROM Campo WHERE RegionId = 5 ").ToList();
            return View(model);
        }
    }
}