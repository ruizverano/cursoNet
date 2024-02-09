using Comun.Apllicacion;
using Negocio.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {

            List<EmpleadoDTO> resultado=new EmpleadosRepositorio().ConsultarEmpleados();

            return View();
        }
    }
}