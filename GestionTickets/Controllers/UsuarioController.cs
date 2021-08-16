using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionTickets.Models;

namespace GestionTickets.Controllers
{
    public class UsuarioController : Controller
    {
        private TicketsContex db = new TicketsContex();

        // GET: Usuario
        public ActionResult Index()
        {
            var oModel = db.Usuarios.ToList();

            return View(oModel);
        }

        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(Usuario oModel)
        {
            if (!ModelState.IsValid)
            {
                return View(oModel);
            }

            db.Usuarios.Add(oModel);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Actualizar(int Id)
        {
            var oUsuario = db.Usuarios.FirstOrDefault(d => d.Id == Id);

            return View(oUsuario);
        }

        [HttpPost]
        public ActionResult Actualizar(Usuario oModel)
        { 
            if (!ModelState.IsValid)
            {
                return View(oModel);
            }

            db.Entry(oModel).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int Id)
        {
            var oUsuario = db.Usuarios.FirstOrDefault(x => x.Id == Id);

            return View(oUsuario);
        }

        public ActionResult Eliminar(int Id)
        {
            var model = db.Usuarios.FirstOrDefault(d => d.Id == Id);
            db.Usuarios.Remove(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}