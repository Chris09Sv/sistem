using Sistem_Ventas.Areas.Proveedores.Models;
using Sistem_Ventas.Data;
using Sistem_Ventas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistem_Ventas.Library
{
    public class LProveedores:ListObject
    {
        public LProveedores()
        {

        }
        public LProveedores(ApplicationDbContext context )
        {
            _context = context;
        }
        public List<InputModelRegistrar> getProveedores(String valor)
        {
            List<TProvedores> listProveedores;
            if (valor == null)
            {
                listProveedores = _context.TProvedores.ToList();
            }
            else
            {
                listProveedores = _context.TProvedores.Where(u => u.Proveedor.StartsWith(valor) || u.Email.StartsWith(valor)).ToList();
            }
            List<InputModelRegistrar> provedoresList = new List<InputModelRegistrar>();
            listProveedores.ForEach(item =>
            {
                provedoresList.Add(new TProvedores
                {
                    ID=item.ID,
                    Proveedor=item.Proveedor,
                    Email=item.Email,
                    Telefono=item.Telefono,
                    Direccion=item.Direccion
                });
            });
            return provedoresList;
        }
        public List<TTicket> getTickets(String valor)
        {
            List<TTicket> listTickets;
            if (valor == null)
            {
                listTickets = _context.TTickets.Where(t => t.Propietario.Equals("Proveedor")).ToList();
            }
            else
            {
                listTickets = _context.TTickets.Where(t => t.Email.StartsWith(valor) && t.Propietario.Equals("Proveedor")).ToList();
            }
            List<TTicket> list = new List<TTicket>();
            listTickets.ForEach(item =>
            {
                list.Add(item);
            });
            
            return list  ;
        }

    }
}
