using AE2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AE2.Controllers
{
    public class MercadosController : ApiController
    {
        // GET: api/Mercados
        public IEnumerable<MercadoDTO> Get()
        {
            var repo = new MercadosRepository();
            List<MercadoDTO> mercs = repo.RetrieveDTO();

            return mercs;
        }

        /***Inicio ejercicio 1 EXAMEN***/
        // GET: api/Mercados/5
        public List<ApuestaExamen> Get(int id)
        {
            var repo = new MercadosRepository();
            List<ApuestaExamen> merc = repo.RetrieveExamen(id);
            return merc;
        }
        /***Final ejercicio 1 EXAMEN***/

        // POST: api/Apuestas
        public void Post(Mercado mercado)
        {
            var repo = new MercadosRepository();
            repo.Save(mercado);
        }

        // PUT: api/Mercados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercados/5
        public void Delete(int id)
        {
        }
    }
}
