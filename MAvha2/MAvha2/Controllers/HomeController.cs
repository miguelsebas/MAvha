using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MAvha2.Modelo;
using MAvha2.Servicios;

namespace MAvha2.Controllers
{

    public class HomeController : Controller
    {
        public ServiciosMAvha serviciosMAvha = new ServiciosMAvha();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Agregar(Modelo.TODO pEN)
        {
            try
            {
                if (pEN.Description != null)
                {
                    HttpPostedFileBase fileBase = Request.Files[0];
                    WebImage image = new WebImage(fileBase.InputStream);
                    pEN.Image = image.GetBytes();

                    serviciosMAvha.InsertarProducto(pEN);
                    return View("Index");
                }
                else
                {
                    return View("Agregar");
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult GetAll()
        {
            try
            {
                List<TODO> list = new List<TODO>();
                list = serviciosMAvha.GetAll();
                return View(list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult GetByIdPost(long? Id)
        {
            try
            {
                if (Id != null)
                {
                    return GetById(Id);
                }
                return View("GetByIdEnviar");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ActionResult GetById(long? Id)
        {
            try
            {
                TODO entidad = new TODO();
                if (Id != null)
                {
                    entidad = serviciosMAvha.GetById(Id);
                }
                if (entidad != null)
                {
                    return View("GetById", entidad);
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ActionResult GetByStatusPost(byte? status)
        {
            try
            {
                if (status != null)
                {
                    return GetByStatus(status);
                }
                return View("GetByStatusPost");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult GetByStatus(byte? status)
        {
            try
            {
                List<TODO> list = new List<TODO>();
                list = serviciosMAvha.GetByStatus(status);
                if (list != null)
                {
                    return View("GetByStatus", list);
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult GetByDescriptionPost(string description)
        {
            try
            {
                if (!String.IsNullOrEmpty(description))
                {
                    return GetByDescription(description);
                }
                return View("GetByDescriptionPost");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult GetByDescription(string description)
        {
            try
            {
                List<TODO> list = new List<TODO>();
                list = serviciosMAvha.GetByDescription(description);
                if (list != null)
                {
                    return View("GetByDescription", list);
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}