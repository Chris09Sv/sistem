using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sistem_Ventas.Areas.Compras.Controllers
{
    [Authorize]

    [Area("Compras")]
    public class ComprasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}