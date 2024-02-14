using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.General
{
    [Serializable]
    [Table(nameof(VM_PERSONAL_AGRUPADO),Schema = "SIGIDESA")]
    public class VM_PERSONAL_AGRUPADO
    {
        [Key]
        public decimal IDENTIFICACION { get; set; }

        public string GRAD_ALFABETICO { get; set; }
        public string NOMBRES { get; set; }

        public string APELLIDOS { get; set; }

    }
}
