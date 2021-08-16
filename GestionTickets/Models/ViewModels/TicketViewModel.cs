using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionTickets.Models.ViewModels
{
    public class TicketViewModel
    {  
        public Ticket ticket { get; set; }
        public List<Responsable> responsables { get; set; }
        public List<Usuario> usuarios { get; set; }
        public List<Estado> estados { get; set; }
        
    }
}