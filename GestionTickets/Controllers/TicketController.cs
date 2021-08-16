using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionTickets.Models;
using GestionTickets.Models.ViewModels;

namespace GestionTickets.Controllers
{
    public class TicketController : Controller
    {
        private TicketsContex db = new TicketsContex();

        // GET: Ticket
        public ActionResult Index()
        {
                var listado = db.Tickets;
                return View(listado);
           
        }

        public ActionResult Nuevo()
        {
            var viewModel = new TicketViewModel();

            viewModel.responsables = db.Responsables.ToList();
            viewModel.estados = db.Estados.ToList();
            viewModel.usuarios = db.Usuarios.ToList();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Nuevo(TicketViewModel model)
        {
            db.Tickets.Add(model.ticket);
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int Id)
        {
            var viewModel = new TicketViewModel();
            viewModel.ticket = db.Tickets.FirstOrDefault(x => x.Id == Id);
            
           
            return View(viewModel);
        }

        public ActionResult Actualizar(int Id)
        {
            var viewModel = new TicketViewModel();
            viewModel.ticket = db.Tickets.FirstOrDefault(x => x.Id == Id);
            viewModel.responsables = db.Responsables.ToList();
            viewModel.estados = db.Estados.ToList();
            viewModel.usuarios = db.Usuarios.ToList();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Actualizar(TicketViewModel model)
        {
            db.Entry(model.ticket).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int Id)
        {
            var model = db.Tickets.FirstOrDefault(d => d.Id == Id);
            db.Tickets.Remove(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}