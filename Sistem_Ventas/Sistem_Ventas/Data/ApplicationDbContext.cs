using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sistem_Ventas.Areas.Clientes.Models;
using Sistem_Ventas.Areas.Proveedores.Models;
using Sistem_Ventas.Areas.Usuarios.Models;
using Sistem_Ventas.Models;

namespace Sistem_Ventas.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TUsuarios> TUsuarios { get; set; }
        public DbSet<TClientes> TClientes { get; set; }
        public DbSet<TReportes_clientes> TReportes_clientes { get; set; }
        public DbSet<TCreditos> TCreditos { get; set; }
   public DbSet<TTicket> TTickets { get; set; }
  
    public DbSet<TProvedores> TProvedores { get; set; }
        public DbSet<TReportes_provedores> TReportes_provedores { get; set; }
            
            }
}
