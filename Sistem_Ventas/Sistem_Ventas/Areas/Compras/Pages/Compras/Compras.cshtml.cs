using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sistem_Ventas.Areas.Compras.Models;
using Sistem_Ventas.Areas.Proveedores.Models;
using Sistem_Ventas.Data;
using Sistem_Ventas.Library;
using Sistem_Ventas.Models;
using Sistem_Ventas.Servicios.Interface;

namespace Sistem_Ventas.Areas.Compras.Pages.Compras
{
    public class ComprasModel : PageModel
    {
        private IListObject _objeto;
        private static String idGet = null,proveedor;
        private static InputModelRegistrar inputModel;
        private string Fecha = DateTime.Now.ToString("dd/MMM/yyy");
        private static DataPaginador<InputModelRegistrar> dataPaginador;
        public ComprasModel(IListObject objeto, ApplicationDbContext context)
        {
            _objeto = objeto;
            objeto._context = context;
            objeto._provedores = new Library.LProveedores(context);
        }
        public void OnGet(int id,String Search)
        {
            var proveedor = "";
            dataPaginador= getProveedores(id, Search);

            if(Search!=null&& 0 < dataPaginador.List.Count)
            {
                inputModel = dataPaginador.List.Last();
                proveedor = inputModel.Proveedor;
            }
            Input = new InputModel
            {
                model = dataPaginador,
                Proveedor= proveedor
            };
        }
        public String Search { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel: InputModelProductos
        {
            [TempData]
            public string ErrorMessage { get; set; }
            public IFormFile AvatarImage { get; set; }
            public DataPaginador<InputModelRegistrar> model { get; set; }
            public bool Credito { get; set; }
        }
        private DataPaginador<InputModelRegistrar> getProveedores(int id, String Search)
        {
            Object[] objects = new Object[3];
            var url = Request.Scheme + "://" + Request.Host.Value;
            var data = _objeto._provedores.getProveedores(Search);
            if (data.Count > 0)
            {
                objects = new Paginador<InputModelRegistrar>().paginador(data, id, "Compras", "Compras", "Compras/Compras", url);
            }
            else
            {
                objects[0] = "No data";
                objects[1] = "No data";
                objects[2] = new List<InputModelRegistrar>();

            }
            var models = new DataPaginador<InputModelRegistrar>
            {
                List = (List<InputModelRegistrar>)objects[2],
                Pagi_info = (String)objects[0],
                Pagi_navegacion = (String)objects[1],
                Input = new InputModelRegistrar()
            };
            return models;

        }
        public async Task<ActionResult> OnPostAsync()
        {
            if (inputModel != null)
            {
                decimal Precio = Convert.ToDecimal(Input.Precio);
                decimal Importe = Precio * Input.Cantidad;

                var compra = new DataCompras
                {
                    Descripcion = Input.Descripcion,
                    Cantidad = Input.Cantidad,
                    Precio = String.Format("${0:#,###,###,##0.00####}", Precio),
                    Importe = String.Format("${0:#,###,###,##0.00####}", Importe),
                    IdProveedor = inputModel.ID,
                    Proveedor = inputModel.Proveedor,
                    Email = inputModel.Email,
                    Fecha = Fecha,
                    AvatarImage=Input.AvatarImage,
                    Credito=Input.Credito
                    

                };
                //_objeto._context.Add(compra);
                //await _objeto._context.SaveChangesAsync();
                return RedirectToPage("Detalles", compra);
            }
            else
            {
                Input = new InputModel
                {
                    ErrorMessage = "Seleccione un proveedor",
                    model = dataPaginador
                };
                return Page();

            }


        }
    }
}
