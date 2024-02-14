using Comun.Aplicacion;
using Datos;
using Datos.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Negocio.Aplicacion
{
    public class EmpleadosRepositorio
    {
        /// <summary>
        /// Funcionalidad que me sirve para traer los empleados que tengan 27 años
        /// 1, crea metodo o función tipo lista de EmpleadoDTO
        /// 2, crea obj tipo Lista de EmpleadoDTO
        /// 3, crea obj ConextoSivvic dentro de using
        /// 4, asigna al obj la consulta SQL hecha a la tabla, inancia el DTO
        /// 5, retorna el obj
        /// </summary>
        /// <returns></returns>
        public List<EmpleadoDTO> ConsultarEmpleados()
        {
            List<EmpleadoDTO> resultados = new List<EmpleadoDTO>();

            using (ContextoSivicc db = new ContextoSivicc())
            {
                resultados = db.EMPLEADO.Where(x => x.VIGENTE == true).Select(x => new EmpleadoDTO 
                              {
                                  CODEMP = x.CODEMP,
                                  EDADEMP = x.EDADEMP,
                                  NOMEMP = x.NOMEMP,
                                  SEXOEMP = x.SEXOEMP,
                                  SUELDOEMP = (decimal)x.SUELDOEMP,
                                  VIGENTE = (bool)x.VIGENTE,
                                 
                                }).ToList();
            }

            return resultados;
        }

        /// <summary>
        /// Funcionalidad para consultar el empleado por identificación
        /// </summary>
        /// 1, crea metodo o función tipo EmpleadoDTO
        /// 2, crea obj tipo EmpleadoDTO
        /// 3, crea obj ConextoSivvic dentro de using
        /// 4, asigna al obj la consulta SQL hecha a la tabla, inancia el DTO
        /// 5, retorna el obj
        /// <param name="_identificacion"></param>
        /// <returns></returns>
        public EmpleadoDTO ConsultarEmpleadoPorId(decimal _identificacion)
        {
            EmpleadoDTO resultado = new EmpleadoDTO();
            using(ContextoSivicc db =new ContextoSivicc())
            {
                resultado=db.EMPLEADO.Where(x=> x.VIGENTE == true && x.CODEMP ==_identificacion).Select(x=> new EmpleadoDTO
                {
                    CODEMP = x.CODEMP,
                    EDADEMP = x.EDADEMP,
                    NOMEMP = x.NOMEMP,
                    SEXOEMP = x.SEXOEMP,
                    SUELDOEMP = (decimal)x.SUELDOEMP,
                    VIGENTE = (bool)x.VIGENTE,
                }).FirstOrDefault();
            }

            return resultado;
        }
        /// <summary>
        /// Funcion para crear empleados
        /// </summary>
        /// 1, crea metodo o función tipo bool que recibe como parametro un obj tipo DTO
        /// 2, crea obj ConextoSivvic dentro de using
        /// 3, asigna al obj la consulta SQL hecha a la tabla, inancia el DTO
        /// 4, condicion que devuelve verdadero si hay cambios en el obj
        /// 5, condicion que devuelve falso si no hay cambios en el obj
        /// <param name="empleadoDTO"></param>
        /// <returns></returns>
        public bool CrearEmpleado(EmpleadoDTO empleadoDTO)
        {
            using(ContextoSivicc db =new ContextoSivicc())
            {
                db.EMPLEADO.Add(new EMPLEADO
                {
                    CODEMP=empleadoDTO.CODEMP,
                    EDADEMP=empleadoDTO.EDADEMP,
                    NOMEMP=empleadoDTO.NOMEMP,
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
        /// <summary>
        /// Funcion para actualizar empleados
        /// </summary>
        /// 1, crea metodo o función tipo bool que recibe como parametro un obj tipo DTO
        /// 2, crea obj ConextoSivvic dentro de using
        /// 3, crea obj tipo Empleado de la capa de Datos y le asigna consulta SQL hecha sobre el obj del punto 2 
        /// 4, al obj del punto 3 le hace asignaciones a sus atributos de atributos del obj del punto 2
        /// 5, asigna un valor a variable del obj del punto2 que tiene que ver con el estado
        /// 6, condicion que devuelve verdadero si hay cambios en el obj
        /// 7, condicion que devuelve falso si no hay cambios en el obj
        public bool ActualizarEmpleado(EmpleadoDTO empleadoDTO)
        {
            using(ContextoSivicc db=new ContextoSivicc())
            {
                EMPLEADO empleado= db.EMPLEADO.FirstOrDefault(x => x.CODEMP==empleadoDTO.CODEMP);
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

        /// <summary>
        /// Funcion para eliminar empleados
        /// </summary>
        /// 1, crea metodo o función tipo bool que recibe como parametro un obj tipo DTO
        /// 2, crea obj ConextoSivvic dentro de using
        /// 3, crea obj tipo Empleado de la capa de Datos y le asigna consulta SQL hecha sobre el obj del punto 2 
        /// 3, asigna al obj la consulta SQL hecha a la tabla, inancia el DTO
        /// 4, condicion que devuelve verdadero si hay cambios en el obj
        /// 5, condicion que devuelve falso si no hay cambios en el obj
        public bool EliminarEmpleadoFisico(decimal _id)
        {
            using (ContextoSivicc db = new ContextoSivicc())
            {
                EMPLEADO empleado = db.EMPLEADO.FirstOrDefault(x => x.CODEMP == _id);
                
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

        /// <summary>
        /// Funcion para actualizar empleados
        /// </summary>
        /// 1, crea metodo o función tipo bool que recibe como parametro un obj tipo DTO
        /// 2, crea obj ConextoSivvic dentro de using
        /// 3, crea obj tipo Empleado de la capa de Datos y le asigna consulta SQL hecha sobre el obj del punto 2 
        /// 4, al obj del punto 3 le hace asignaciones a sus atributos de atributos del obj del punto 2
        /// 5, asigna un valor a variable del obj del punto2 que tiene que ver con el estado
        /// 6, condicion que devuelve verdadero si hay cambios en el obj
        /// 7, condicion que devuelve falso si no hay cambios en el obj
        public bool EliminarEmpleadoLogico(decimal _identificacion)
        {
            using (ContextoSivicc db = new ContextoSivicc())
            {
                EMPLEADO empleado = db.EMPLEADO.FirstOrDefault(x => x.CODEMP == _identificacion);
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
