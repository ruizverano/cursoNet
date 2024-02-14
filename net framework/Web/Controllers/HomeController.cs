using Negocio;
using Negocio.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Bienvenido a SIVICC PLUS";

            ViewBag.RESULTADO_SUMA = new FuncionalidadesRepositorio().SumarDosNumeros(90,50);

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Operaciones()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Operaciones(decimal _n1, decimal _n2)
        {
            ViewBag.RESULTADO = new FuncionalidadesRepositorio().SumarDosNumeros(_n1,_n2);
            return View();

        }

    }
}