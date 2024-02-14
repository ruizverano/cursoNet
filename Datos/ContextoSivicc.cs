using Datos.Aplicacion;
using Datos.General;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ContextoSivicc: DbContext
    {
        public ContextoSivicc(): base("ContextoSivicc")
        {
            Database.SetInitializer<ContextoSivicc>(null);
        }

        public virtual DbSet<EMPLEADO> EMPLEADO { get; set; }
        public virtual DbSet<VM_PERSONAL_AGRUPADO> VM_PERSONAL_AGRUPADO { get; set; }

    }
}
