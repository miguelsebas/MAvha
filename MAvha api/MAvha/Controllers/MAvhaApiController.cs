using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using FParsec;
using MAvha.ClasesVM;
using MAvha.Modelo;

namespace MAvha.Controllers
{
    public class MAvhaApiController : ApiController
    {
        Servicios.ServicesMAvha _servicios = new Servicios.ServicesMAvha();

        [HttpPost]
        public async void Insertar(TODO entidad)
        {
            try
            {
                if (entidad.Description != null)
                {
                    _servicios.InsertTODO(entidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TODO> GetAll()
        {
            try
            {
                return _servicios.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TODO GetById(long Id)
        {
            try
            {
                return _servicios.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TODO> GetByStatus(byte Status)
        {
            try
            {
                return _servicios.GetByStatus(Status);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        public List<TODO> GetByDescription(string description)
        {
            try
            {
                return _servicios.GetByDescription(description);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
