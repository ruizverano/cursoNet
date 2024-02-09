using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Aplicacion
{
    [Serializable]
    [Table(nameof(Empleado), Schema = "DEV_CRUIZ")]
    public class Empleado
    {
        [Key]
        public decimal CODEMP { get; set; }
        public String NONEMP { get; set; }
        public decimal? EDADEMP { get; set; }
        public char SEXOEMP { get; set; }
        public decimal SUELDOEMP { get; set; }
        public bool VIGENTE {  get; set; }
    }
}
