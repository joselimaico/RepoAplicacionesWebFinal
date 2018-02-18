using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pruebaAuth.Controllers
{
    public class PorConfirmarReservaController : Controller
    {
        // GET: PorConfirmarReserva
        public ActionResult Index()
        {

            ReservasModelContainer DBContext = new ReservasModelContainer();

            List<Reserva> reservaVMlist = new List<Reserva>();

            var reservaList = (from q in DBContext.ReservaSet
                               where q.EstadoReserva == "Por Confirmar" 
                               select q).ToList();
            foreach (var item in reservaList)
            {
                Reserva objcvm = new Reserva();
                objcvm = item;

                reservaVMlist.Add(objcvm);
                                   
            }
            return View(reservaVMlist);
        }

        public ActionResult Edit(int? ReservaId)


        {
            PopulateCustomer();
            using (ReservasModelContainer DBContext = new ReservasModelContainer())
            {
                var std = (from q in DBContext.ReservaSet
                           where q.IdReserva == ReservaId
                           select q).FirstOrDefault();
                return View(std);
            }

        }

        [HttpPost]
        public ActionResult Edit(Reserva std)
        {
            if (ModelState.IsValid)
            {
                using (ReservasModelContainer DBContext = new ReservasModelContainer())
                {
                    var u = (from q in DBContext.ReservaSet
                             where q.IdReserva == std.IdReserva
                             select q).FirstOrDefault();
                    if (u != null)
                    {
                     
                        u.EstadoReserva = "Reservado";
                        u.ApellidoCliente = std.ApellidoCliente;
                        u.NombreCliente = std.NombreCliente;
               
                        u.NumeroPersonas = std.NumeroPersonas;
                        u.TelefonoCliente = std.TelefonoCliente;
                        u.Color = "red";
                        u.Subject = std.Subject;
                        u.InstitucionCliente = std.InstitucionCliente;
                  
                        u.CorreoCliente = std.CorreoCliente;
                    }
                    DBContext.SaveChanges();
                }


            }
            return RedirectToAction("Index","ConfirmadoReserva");
        }

        private void PopulateCustomer(object selectedCustomer = null)
        {


            List<SelectListItem> items = new List<SelectListItem>();



            items.Add(new SelectListItem { Text = "Reservado", Value = "0", Selected = true });

              ViewBag.MovieType = items;

        }


    }
}