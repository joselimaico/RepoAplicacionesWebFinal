using pruebaAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace WebApplicationMGOFinal.Controllers
{
	public class ReservaController : Controller
	{
		// GET: Reserva
		public ActionResult Index()
		{
			ReservasModelContainer db = new ReservasModelContainer();
			return View(db.ReservaSet);
		}

		public ActionResult Create(String fecha)
		{


			string[] date_format;
			date_format = fecha.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
			string day = date_format[2];
			string year = date_format[3];
			string month = "";

			switch (date_format[1])
			{
				case "Jan":
					month = "01";
					break;
				case "Feb":
					month = "02";
					break;
				case "Mar":
					month = "03";
					break;
				case "Apr":
					month = "04";
					break;
				case "May":
					month = "05";
					break;
				case "Jun":
					month = "06";
					break;
				case "Jul":
					month = "07";
					break;
				case "Aug":
					month = "08";
					break;
				case "Sep":
					month = "09";
					break;
				case "Oct":
					month = "10";
					break;
				case "Nov":
					month = "11";
					break;
				case "Dec":
					month = "12";
					break;
			}

			string hora = date_format[4];
			string[] hour_format = hora.Split(':');
			int horas = Int32.Parse(hour_format[0]);
			string minutos = hour_format[1];
			string segundos = hour_format[2];

			string fecha_inicio = "";
			string fecha_final = "";

			fecha_inicio = day + "/" + month + "/" + year + " " + horas + ":" + minutos + ":" + segundos;

			ViewData.Add(new KeyValuePair<string, object>("fechaInicio", fecha_inicio));



			if (minutos.Equals("00"))
			{


				fecha_final = day + "/" + month + "/" + year + " " + horas + ":" + "30" + ":" + segundos;
				ViewData.Add(new KeyValuePair<string, object>("fechaFin", fecha_final));


			}

			else if (minutos.Equals("30"))
			{



				fecha_final = day + "/" + month + "/" + year + " " + (horas + 1) + ":" + "00" + ":" + segundos;

				ViewData.Add(new KeyValuePair<string, object>("fechaFin", fecha_final));



			}








			return View();

		}



		[HttpPost]
		public ActionResult Create(Reserva std)
		{

			if (ModelState.IsValid)
			{
				using (ReservasModelContainer DBContext = new ReservasModelContainer())
				{


					std.EstadoReserva = "Reservado";
					std.Color = "red";
					std.IsFullDay = 0;
					DBContext.ReservaSet.Add(std);
					DBContext.SaveChanges();
				}


			}
			return RedirectToAction("Index");

		}
		//Editar

		public ActionResult Edit(int idReserva)
		{
			using (ReservasModelContainer db = new ReservasModelContainer())
			{
				var std = (from q in db.ReservaSet
						   where q.IdReserva == idReserva
						   select q).FirstOrDefault();
				return View(std);
			}

		}

		public ActionResult Delete(int idreserva)
		{
			using (ReservasModelContainer db = new ReservasModelContainer())
			{
				var std = (from q in db.ReservaSet
						   where
				q.IdReserva == idreserva
						   select q).FirstOrDefault();
				return View(std);
			}

		}

		[HttpPost, ActionName("Delete")]
		public ActionResult Delete(Reserva reservastd)
		{

			
			using (ReservasModelContainer db = new ReservasModelContainer())
			{
				reservastd.CorreoCliente = Request.Form["Correo"];
				try
				{
					var v = (from q in db.ReservaSet
							 where q.CorreoCliente == reservastd.CorreoCliente
							 select q).FirstOrDefault();

					db.ReservaSet.Remove(v);
					db.SaveChanges();
				}
				catch (Exception e)
				{
					TempData["msg"] = "<script>alert('Email Inválido');</script>";
					return View();
				}

					



			}
			return RedirectToAction("Calendario");
		}

		[HttpPost]
		public ActionResult Edit(Reserva reservastd)
		{
			if (ModelState.IsValid)
			{
				using (ReservasModelContainer db = new ReservasModelContainer())
				{

					var u = (from q in db.ReservaSet
							 where q.IdReserva == reservastd.IdReserva
							 select q).FirstOrDefault();
					if (u != null)
					{
						u.NombreCliente = reservastd.NombreCliente;
						u.ApellidoCliente = reservastd.ApellidoCliente;
						u.CorreoCliente = reservastd.CorreoCliente;
						u.EstadoReserva = reservastd.EstadoReserva;
						u.FechaInicio = reservastd.FechaInicio;
						u.FechaFin = reservastd.FechaFin;
						u.InstitucionCliente = reservastd.InstitucionCliente;
						u.TelefonoCliente = reservastd.TelefonoCliente;
					}
					db.SaveChanges();


				}
				return RedirectToAction("Index");
			}
			return View(reservastd);

		}

		public ActionResult Calendario()
		{
			return View();
		}

		public ActionResult Agenda(string fecha)
		{
			var std = fecha;
			string[] date_format;
			date_format = fecha.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
			string date = date_format[2].ToString();
			string year = date_format[3].ToString();
			string month = "";

			switch (date_format[1].ToString())
			{
				case "Jan":
					month = "01";
					break;
				case "Feb":
					month = "02";
					break;
				case "Mar":
					month = "03";
					break;
				case "Apr":
					month = "04";
					break;
				case "May":
					month = "05";
					break;
				case "Jun":
					month = "06";
					break;
				case "Jul":
					month = "07";
					break;
				case "Aug":
					month = "08";
					break;
				case "Sep":
					month = "09";
					break;
				case "Oct":
					month = "10";
					break;
				case "Nov":
					month = "11";
					break;
				case "Dec":
					month = "12";
					break;
			}
			string test = month + "/" + date + "/" + year;

			ViewData.Add(new KeyValuePair<string, object>("fecha", test));
			return View();
		}

		public JsonResult GetEvents()
		{
			using (ReservasModelContainer db = new ReservasModelContainer())
			{
				var events = db.ReservaSet.ToList();
				return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
			}
		}

		public JsonResult getHolidays()
		{
			using (ReservasModelContainer db = new ReservasModelContainer())
			{
				var events = db.DiaSet.ToList();
				return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
			}
		}
	}
}