using AE2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AE2.Controllers
{
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
        //[Authorize(Roles = "Admin")]
        public IEnumerable<ApuestaDTO> Get()
        {
            var repo = new ApuestasRepository();
            List<ApuestaDTO> apus = repo.RetrieveDTO();
            return apus;
        }

        // GET: api/Apuestas?emailUsu=valor1&mercadoApu=valor2
        /*public IEnumerable<ApuestaMercadoEmail> GetMercadoEmail(int mercadoApu, string emailUsu)
        {
            var repo = new ApuestasRepository();
            //List<ApuestaMercadoEmail> apus = repo.RetrieveByEmailAndMercado(mercadoApu, emailUsu);
            return null;
        }*/

        // GET: api/Apuestas/id
        /*public Apuesta Get(int id)
        {
            var repo = new ApuestasRepository();
            Apuesta apu = repo.Retrieve(id);
            return apu;
        }*/

        /***Inicio ejercicio 1 EXAMEN***/
        /*public Apuesta Get(float dinero)
        {
            var repo = new ApuestasRepository();
            Apuesta apu = repo.Retrieve(dinero);
            return apu;
        }*/
        /***Final ejercicio 1 EXAMEN***/

        // POST: api/Apuestas
        public void Post(Apuesta apuesta)
        {
            var repo = new ApuestasRepository();
            repo.Save(apuesta);
        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/id
        public void Delete(int id)
        {
        }
    }
}
