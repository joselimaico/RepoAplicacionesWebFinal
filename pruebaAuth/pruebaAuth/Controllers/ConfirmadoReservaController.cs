using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pruebaAuth.Controllers
{
    public class ConfirmadoReservaController : Controller
    {
        // GET: ConfirmadoReserva
        public ActionResult Index()
        {
            ReservasModelContainer DBContext = new ReservasModelContainer();

            List<Reserva> reservaVMlist = new List<Reserva>();

            var reservaList = (from q in DBContext.ReservaSet
                               where q.EstadoReserva == "Reservado"
                               select q).ToList();
            foreach (var item in reservaList)
            {
                Reserva objcvm = new Reserva();
                objcvm = item;

                reservaVMlist.Add(objcvm);

            }
            return View(reservaVMlist);
        }
    }
}