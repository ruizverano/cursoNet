using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.Aplicacion
{
    public class EmpleadoDTO
    {
        public decimal CODEMP { get; set; }
        public String NOMEMP { get; set; }
        public decimal? EDADEMP { get; set; }
        public String SEXOEMP { get; set; }
        public decimal SUELDOEMP { get; set; }
        public bool VIGENTE { get; set; }
    }
}
