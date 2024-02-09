using Comun.Apllicacion;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using Datos.Aplicacion;
namespace Negocio.Aplicacion
{
    public class EmpleadosRepositorio
    {
        /// <summary>
        /// Funcionalidad que me sirve para traer los empleados que tengan 27 años
        /// </summary>
        /// <returns></returns>
        public List<EmpleadoDTO> ConsultarEmpleados()
        {
            List<EmpleadoDTO> resultados = new List<EmpleadoDTO>();

            using (ContextoSivicc db = new ContextoSivicc())
            {
                resultados=db.EMPLEADO.Where(x=>x.VIGENTE==true).Select(x=>new EmpleadoDTO
                {
                    CODEMP=x.CODEMP,
                    EDADEMP=x.EDADEMP,
                    NONEMP=x.NONEMP,
                    SEXOEMP=x.SEXOEMP,
                    SUELDOEMP=x.SUELDOEMP,
                    VIGENTE=x.VIGENTE,
                }).ToList();
            }

            return resultados;
        }

        /// <summary>
        /// Funcionalidad para consultar el empleado por identificación
        /// </summary>
        /// <param name="_identificacion"></param>
        /// <returns></returns>
        public EmpleadoDTO ConsultarEmpleadoPorId(decimal _identificacion)
        {
            EmpleadoDTO resultado = new EmpleadoDTO();
            using(ContextoSivicc db =new ContextoSivicc())
            {
                resultado=db.EMPLEADO.Where(x=> x.VIGENTE == true && x.CODEMP==_identificacion).Select(x=> new EmpleadoDTO
                {
                    CODEMP = x.CODEMP,
                    EDADEMP = x.EDADEMP,
                    NONEMP = x.NONEMP,
                    VIGENTE = x.VIGENTE,
                }).FirstOrDefault();
            }

            return resultado;
        }
        /// <summary>
        /// Funcion para crear empleados
        /// </summary>
        /// <param name="empleadoDTO"></param>
        /// <returns></returns>
        public bool CrearEmpleado(EmpleadoDTO empleadoDTO)
        {
            using(ContextoSivicc db =new ContextoSivicc())
            {
                db.EMPLEADO.Add(new Empleado
                {
                    CODEMP=empleadoDTO.CODEMP,
                    EDADEMP=empleadoDTO.EDADEMP,
                    NONEMP=empleadoDTO.NONEMP,
                    SEXOEMP=empleadoDTO.SEXOEMP,
                    SUELDOEMP=empleadoDTO.SUELDOEMP,
                    VIGENTE = true
                });

                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool ActualizarEmpleado(EmpleadoDTO empleadoDTO)
        {
            using(ContextoSivicc db=new ContextoSivicc())
            {
                Empleado empleado= db.EMPLEADO.FirstOrDefault(x => x.CODEMP==empleadoDTO.CODEMP);
                empleado.EDADEMP=empleadoDTO.EDADEMP;
                empleado.SUELDOEMP = empleadoDTO.SUELDOEMP;

                db.Entry(empleado).State=EntityState.Modified;


                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool EliminarEmpleadoFisico(decimal _identificacion)
        {
            using (ContextoSivicc db = new ContextoSivicc())
            {
                Empleado empleado = db.EMPLEADO.FirstOrDefault(x => x.CODEMP == _identificacion);
                
                db.Entry(empleado).State = EntityState.Deleted;


                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool EliminarEmpleadoLogico(decimal _identificacion)
        {
            using (ContextoSivicc db = new ContextoSivicc())
            {
                Empleado empleado = db.EMPLEADO.FirstOrDefault(x => x.CODEMP == _identificacion);
                empleado.VIGENTE = false;

                db.Entry(empleado).State = EntityState.Modified;


                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
    }    
}
