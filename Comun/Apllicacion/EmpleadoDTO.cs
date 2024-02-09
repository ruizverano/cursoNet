using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.Apllicacion
{
    public class EmpleadoDTO
    {
        public decimal CODEMP { get; set; }
        public String NONEMP { get; set; }
        public decimal? EDADEMP { get; set; }
        public char SEXOEMP { get; set; }
        public decimal SUELDOEMP { get; set; }
        public bool VIGENTE { get; set; }
    }
}
