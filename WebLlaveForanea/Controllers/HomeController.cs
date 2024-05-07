using EntidadRegistroPersonal;
using NegocioRegistroPersonal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLlaveForanea.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        NegPersonal negPer = new NegPersonal();
        NegPuestosDeTrabajo negPuesTrabajo = new NegPuestosDeTrabajo();
        NegTurnos negoTurno = new NegTurnos();
        public ActionResult Index()
        {
            try
            {
                List<EntPersonal> lista = negPer.Obtener();
                return View("Index", lista);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Index", new List<EntPersonal>());
            }
        }
        
        //Get y Post de Crear
        [HttpGet]
        public ActionResult Crear()
        {
            try
            {
                List<EntPuestoDeTrabajo> listaPuesto = new List<EntPuestoDeTrabajo> { };
                listaPuesto = negPuesTrabajo.Obtener();
                List<EntTurnos> listaTurno = new List<EntTurnos> { };
                listaTurno = negoTurno.Obtener();
                ViewBag.PuestoDeTrabajoId = new SelectList(listaPuesto, "Id","Nombre");
                ViewBag.Turno = new SelectList(listaTurno, "Turno","Turno");
                return View("Crear");
            }
            catch (Exception)
            {
                return View("Crear");
                throw;
            }
        }
        [HttpPost]
        public ActionResult Crear(EntPersonal p)
        {
            try
            {
                string mensaje = negPer.Agregar(p);
                TempData["mensaje"] = mensaje;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                List<EntPuestoDeTrabajo> listaPuesto = new List<EntPuestoDeTrabajo> { };
                listaPuesto = negPuesTrabajo.Obtener();
                List<EntTurnos> listaTurno = new List<EntTurnos> { };
                listaTurno = negoTurno.Obtener();
                ViewBag.PuestoDeTrabajoId = new SelectList(listaPuesto, "Id", "Nombre");
                ViewBag.Turno = new SelectList(listaTurno, "Turno", "Turno");
                return View("Crear");
            }
        }

        //Get y Post de Editar

        [HttpGet]
        public ActionResult Editar(int id)
        {
            try
            {
                EntPersonal personal = negPer.ObtenerPorId(id);
                List<EntPuestoDeTrabajo> listaPuesto = new List<EntPuestoDeTrabajo> { };
                listaPuesto = negPuesTrabajo.Obtener();
                List<EntTurnos> listaTurno = new List<EntTurnos> { };
                listaTurno = negoTurno.Obtener();
                ViewBag.PuestoDeTrabajoId = new SelectList(listaPuesto, "Id", "Nombre",personal.PuestoDeTrabajoId);
                //ViewBag.Turno = new SelectList(listaTurno, "Turno", "Turno", personal.Turno);
                ViewBag.Turno = new SelectList(listaTurno,"Turno","Turno",personal.EntityTurnos.Turno);
                return View("Editar", personal);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Editar(EntPersonal p)
        {
            try
            {
                string mensaje = negPer.Editar(p);
                TempData["mensaje"] = mensaje;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                List<EntPuestoDeTrabajo> listaPuesto = new List<EntPuestoDeTrabajo> { };
                listaPuesto = negPuesTrabajo.Obtener();
                List<EntTurnos> listaTurno = new List<EntTurnos> { };
                listaTurno = negoTurno.Obtener();
                ViewBag.PuestoDeTrabajoId = new SelectList(listaPuesto, "Id", "Nombre");
                ViewBag.Turno = new SelectList(listaTurno, "Turno", "Turno");
                return View("Editar");
            }
        }

        //Get y Post de Borrar

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            try
            {
                EntPersonal personal = negPer.ObtenerPorId(id);
                return View("Eliminar", personal);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Eliminar(EntPersonal p)
        {
            try
            {
                string mensaje = negPer.Borrar(p);
                TempData["mensaje"] = mensaje;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Eliminar", new {id = p.Id});
            }
        }

        //Buscar
        public ActionResult Buscar(string txtBuscar)
        {
            try
            {
                List<EntPersonal> lista = negPer.BuscarPorNombre(txtBuscar);
                return View("Index", lista);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Index", new List<EntPersonal>());
            }
        }

    }
}