using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sistem_Ventas.Areas.Compras.Models;
using Sistem_Ventas.Data;
using Sistem_Ventas.Servicios.Interface;

namespace Sistem_Ventas.Areas.Compras.Pages.Compras
{
    public class DetallesModel : PageModel
    {
        private IListObject _objeto;
        private static TCompras_temp _model;
        private string dia = DateTime.Now.ToString("dd");
        private string mes = DateTime.Now.ToString("MMM");
        private string year = DateTime.Now.ToString("yyy");

        public DetallesModel(IListObject objeto, ApplicationDbContext context,UserManager<IdentityUser> UserManager)
        {
            _objeto = objeto;
            objeto._context = context;
            objeto._userManager = UserManager;
        }
        public void OnGet(DataCompras model)
        {
            _model = model;
            Input = new InputModel
            {
                TComprasTemp = model,
                AvatarImage= model.AvatarImage
            };

        }
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel : TCompras_temp
        {
            [TempData]
            public string ErrorMessage { get; set; }
            public IFormFile AvatarImage { get; set; }
            public TCompras_temp TComprasTemp { get; set; }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var valor = false;
            var strategy = _objeto._context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _objeto._context.Database.BeginTransaction())
                {
                    try
                    {
                        var idUser = _objeto._userManager.GetUserId(User);
                        var dataUser = _objeto._context.TUsuarios.Where(u => u.IdUser.Equals(idUser)).ToList().ElementAt(0);
                        var user = await _objeto._userManager.FindByIdAsync(idUser);
                        var role = await  _objeto._userManager.GetRolesAsync(user);

                        //_objeto._context.Add(_model);
                        //await _objeto._context.SaveChangesAsync();
                        var compra = new TCompras
                        {
                            Descripcion = _model.Descripcion,
                            Cantidad = _model.Cantidad,
                            Precio = _model.Precio,
                            Importe = _model.Importe,
                            IdProveedor = _model.IdProveedor,
                            Proveedor = _model.Proveedor,
                            Email = _model.Email,
                            IdSusuario = idUser,
                            Usuario = dataUser.Nombre + " " + dataUser.Apellido,
                            Role = role[0],
                            Dia = Convert.ToInt16(dia),
                            Mes = mes,
                            Year = year,
                            Fecha = _model.Fecha,
                            Credito=_model.Credito
                        };
                        int data = Convert.ToInt16("fg");
                        //_objeto._context.Add(compra);
                        //await _objeto._context.SaveChangesAsync();
                     
                        // si todos los comandos o procesos se ejecutaron con exito,
                        transaction.Commit();

                    }catch(Exception ex)
                    {
                        Input = new InputModel
                        {
                            TComprasTemp = _model,
                            AvatarImage = Input.AvatarImage,
                            ErrorMessage = ex.Message
                        };
                        transaction.Rollback();
                        valor = false;
                    }
                }
            });
            if (valor)
            {
               return RedirectToPage("Compras");
            }
            else
            {
                return Page();
            }
        }
    }
}
