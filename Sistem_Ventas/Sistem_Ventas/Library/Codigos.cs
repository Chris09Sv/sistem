using Sistem_Ventas.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistem_Ventas.Library
{
    public class Codigos
    {
        public static Random rnd = new Random();
        private ApplicationDbContext _context;

        public Codigos(ApplicationDbContext context)
        {
            _context = context;
        }
        public string CodigoTicket()
        {
            String Ticket = null;
            int codigo = 0, count = 0;

            do
            {
                for (int i = 0; i < 20; i++)
                {
                    codigo = rnd.Next(100000, 10000001);
                }
                Ticket = Convert.ToString(codigo);
                var report = _context.TTickets.Where(r => r.Ticket.Equals(Ticket)).ToList();
                count = report.Count();
            } while (count>0);
            return Ticket;
        }
        public String codigosTickets(String Propietario,String Email)
        {
            string Ticket = null;
            string Codigo = null;
            var report = _context.TTickets.Where(r => r.Propietario.Equals(Propietario) 
            && r.Email.Equals(Email)).ToList();

            if (report.Count.Equals(0))
            {
                Ticket = "0000000001";
            }
            else
            {
                var data = report.Last();
                if (data.Ticket.Equals("9999999999"))
                {
                    Ticket = "0000000001";

                }
                else
                {
                    var cod = Convert.ToUInt64(data.Ticket);
                    cod++;
                    //
                    var num = cod.ToString("D10");
                    //for (int i = num.Length; i < 10; i++)
                    //{
                    //    Codigo += "0";
                    //}
                    Ticket = num; 
                }
               
            }
            return Ticket;
        }
    }
}
