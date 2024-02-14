using Comun.Aplicacion;
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
        // GET: EMPLEADO
        public ActionResult Index()
        {

            List<EmpleadoDTO> resultado=new EmpleadosRepositorio().ConsultarEmpleados();

            return View(resultado);
        }

        public ActionResult Detalle(decimal _id) {
            EmpleadoDTO resultado = new EmpleadosRepositorio().ConsultarEmpleadoPorId(_id);

            return View(resultado);
        }

        [HttpPost]
        public JsonResult Crear(EmpleadoDTO empleadoDTO)
        {
            if (string.IsNullOrEmpty(empleadoDTO.NOMEMP))
            {
                return Json(new { ok = false, mensaje = "El nombre no puede ser vacío" });
            }

            if (string.IsNullOrEmpty(empleadoDTO.SEXOEMP))
            {
                return Json(new { ok = false, mensaje = "El campo sexo es obligatorio" });
            }

            if (empleadoDTO.EDADEMP < 18 || empleadoDTO.EDADEMP > 100 || empleadoDTO.EDADEMP == null)
            {
                return Json(new { ok = false, mensaje = "La edad no puede ser inferior a 18 años ni superior a 100 años" });
            }

            if (empleadoDTO.SUELDOEMP <= 0 || empleadoDTO.SUELDOEMP >= 10000000)
            {
                return Json(new { ok = false, mensaje = "No pude ganar mas de un millón o nada" });
            }
            
            if (new EmpleadosRepositorio().CrearEmpleado(empleadoDTO))
                return Json(new { ok = true, mensaje = "Se creó correctamente" });
            else
                return Json(new { ok = false, mensaje = "No se creó el empleado" });
        }

        [HttpPost]
        public JsonResult Actualizar(EmpleadoDTO empleadoDTO)
        {
            if (empleadoDTO.EDADEMP < 18 && empleadoDTO.EDADEMP > 100)
            {
                return Json(new { ok = false, mensaje = "La edad no puede ser inferior a 18 años ni superior a 100 años" });
            }

            if (empleadoDTO.SUELDOEMP >= 10000000)
            {
                return Json(new { ok = false, mensaje = "No pude ganar mas de un millón" });
            }

            if (new EmpleadosRepositorio().ActualizarEmpleado(empleadoDTO))
                return Json(new { ok = true, mensaje = "Se actualizó correctamente" });
            else
                return Json(new { ok = false, mensaje = "No se actualizó el empleado" });
         }

        [HttpPost]
        public JsonResult EliminarLogico(decimal _id)
        {
            if(new EmpleadosRepositorio().EliminarEmpleadoLogico(_id))
            {
                return Json(new { ok = true, mensaje = "Se eliminó correctamente" });
            }
            else
            {
                return Json(new { ok = false, mensaje = "No se eliminó el empleado" });
            }
        }

        [HttpPost]
        public JsonResult EliminarFisico(decimal _id)
        {
            if (new EmpleadosRepositorio().EliminarEmpleadoFisico(_id))
            {
                return Json(new { ok = true, mensaje = "Se eliminó correctamente" });
            }
            else
            {
                return Json(new { ok = false, mensaje = "No se eliminó el empleado" });
            }
        }

    }

}