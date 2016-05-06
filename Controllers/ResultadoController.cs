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
    public class ResultadoController : Controller
    {
        private PozosPemexEntities db = new PozosPemexEntities();

        // GET: Resultado
        public ActionResult Index()
        {

            //var model = db.Database.SqlQuery<Resultado>("EXEC sp_calcularResultados {0},{1},{2},{3} ", , ).ToList();
            return View();
        }

    }
}
