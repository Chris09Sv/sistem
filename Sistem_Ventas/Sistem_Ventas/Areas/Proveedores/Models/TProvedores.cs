using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistem_Ventas.Areas.Proveedores.Models
{
    public class TProvedores:InputModelRegistrar
    {
        public ICollection<TReportes_provedores> TReportes_provedores { get; set; }
    }
}
