using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sistem_Ventas.Areas.Proveedores.Controllers;
using Sistem_Ventas.Areas.Proveedores.Models;
using Sistem_Ventas.Data;
using Sistem_Ventas.Library;
using Sistem_Ventas.Servicios.Interface;

namespace Sistem_Ventas.Areas.Proveedores.Pages.Account
{
    [Authorize(Roles ="Administrador")]
    public class ReportesModel : PageModel
    {
        private IListObject _objeto;
        private static String idGet = null,proveedor;
        private static InputModelRegistrar inputModel;
        private static TProvedores tProvedores;
        private static TReportes_provedores proveedore_Report;
        private static IList<TReportes_provedores> provedoresReport;

        public ReportesModel(IListObject objeto,ApplicationDbContext context)
        {
            _objeto = objeto;
            objeto._context = context;
            objeto._provedores = new LProveedores(context);
        }
        public IActionResult OnGet(String Id)
        {
            if (Id != null)
            {
                idGet = Id;
                if (setProveedores(Id))
                {
                    return Page();
                }
                {
                    return RedirectToAction(nameof(ProveedoresController.Index), "Proveedores");
                }
            }
            else
            {
                return Page();
            }
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel : InputModelRegistrar
        {
            [TempData]
            public string ErrorMessage { get; set; }
            public string Ticket { get; set; }
            public string Credito { get; set; }
            public IList<TReportes_provedores> ProvedoresReport { get; set; }
        }
        private bool setProveedores(String Email)
        {
            try
            {
                if(new EmailAddressAttribute().IsValid(Email))
                {
                    var proveedorList = _objeto._provedores.getProveedores(Email).ToList();
                    if (0 < proveedorList.Count)
                    {
                        inputModel = proveedorList.ElementAt(0);

                        tProvedores = new TProvedores
                        {
                            ID = inputModel.ID,
                            Proveedor = inputModel.Proveedor,
                            Telefono = inputModel.Telefono,
                            Email = inputModel.Email,
                            Direccion = inputModel.Direccion
                        };
                        provedoresReport = _objeto._context.TReportes_provedores.Where(r => r.TProvedores.
                        Equals(tProvedores)).ToList();
                        if (0 < provedoresReport.Count)
                        {   proveedore_Report = provedoresReport.ElementAt(0);
                            Input = new InputModel
                            {
                                Proveedor = inputModel.Proveedor,
                                Email = Email,
                                  ProvedoresReport= provedoresReport,
                            };

                        }
                        else
                        {
                            Input = new InputModel
                            {
                                Proveedor = inputModel.Proveedor,
                                Email = idGet,
                                ErrorMessage = "El proveedor " + inputModel.Proveedor + " no contiene reportes.",
                                ProvedoresReport = new List<TReportes_provedores>()
                            };
                            return true;
                        }
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }catch(Exception ex)
            {
                Input = new InputModel
                {
                    Proveedor = inputModel.Proveedor,
                    Email = idGet,
                    ErrorMessage = ex.Message,
                    ProvedoresReport = new List<TReportes_provedores>()
                };
                return true;
            }
        }
        [BindProperty]
        public InputModel1 Input1 { get; set; }
        public class InputModel1
        {
            [Required(ErrorMessage = "<font color='red'>Ingrese el pago. </font>")]
            [RegularExpression(@"^[0-9]+([.][0-9]+)?$", ErrorMessage = "<font color='red'>El formato del pago no es válido . </font>")]
            public string Pago { get; set; }
            public string ErrorMessage { get; set; }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (Input1.Pago != null)
            {
                if(await savePagoAsync())
                {
                    if (setProveedores(idGet))
                    {
                        return Redirect("/Proveedores/account/Reportes?id=" + idGet);
                    }
                    else
                    {
                        return RedirectToAction(nameof(ProveedoresController.Index), "Proveedores");
                    }
                }
                else
                {
                    return Page();
                }
            }
            else
            {
                return Page();

            }
        }

        private async Task<bool> savePagoAsync()
        {
            try
            {
                var pago = Convert.ToDecimal(Input1.Pago);
                var deuda=Convert.ToDecimal(proveedore_Report.Deuda.Replace("$",""))-pago;

                var dataInput = new InputModel
                {
                    Proveedor = proveedor,
                    Email = idGet,
                    ProvedoresReport = provedoresReport
                };
                if (proveedore_Report.Deuda.Equals("$0.00"))
                {
                    Input = dataInput;
                    Input1 = new InputModel1
                    {
                        ErrorMessage = "El proveedor no contiene deuda."
                    };return false;
                }
                else
                {
                    if (deuda < pago)
                    {
                        Input = dataInput;
                        Input1 = new InputModel1
                        {
                            ErrorMessage = "El pago excede la cantidad que el proveedor adueda."
                        }; return false;
                    }
                    else
                    {
                        var ticket = new Codigos(_objeto._context).codigosTickets("Proveedor", idGet);
                        _objeto._context.Update(tProvedores);
                        await _objeto._context.SaveChangesAsync();
                        var reportes = new TReportes_provedores
                        {
                            ReportesID = proveedore_Report.ReportesID,
                            Deuda = string.Format("${0:#,###,###,##0.00####}", deuda),
                            FechaDeuda = DateTime.Today,
                            Pago = string.Format("${0:#,###,###,##0.00####}", pago),
                            FechaPago = DateTime.Today,
                            Ticket = ticket,
                            TProvedores = tProvedores

                        };
                        _objeto._context.Update(reportes);
                        await _objeto._context.SaveChangesAsync();
                    }
                }
            }
            catch(Exception ex)
            {
                Input = new InputModel
                {
                    Proveedor = proveedor,
                    Email = idGet,
                    ErrorMessage = ex.Message,
                    ProvedoresReport = new List<TReportes_provedores>()
                };
                return false;
            }
            return true;

        }
    }
}
