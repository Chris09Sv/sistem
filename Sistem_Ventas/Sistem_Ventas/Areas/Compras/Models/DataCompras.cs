using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistem_Ventas.Areas.Compras.Models
{
    public class DataCompras:TCompras_temp
    {
        private static IFormFile image { get; set; }
        public IFormFile AvatarImage { get { return image; } set { image=value; } }
    }
}
