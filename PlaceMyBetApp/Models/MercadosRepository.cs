using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using PlaceMyBetApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AE2.Models
{
    public class MercadosRepository
    {
        internal List<Mercado> Retrieve()
        {
            List<Mercado> mercados = new List<Mercado>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercados = context.Mercados.Include(p => p.Evento).ToList();
            }

            return mercados;
        }

        internal List<MercadoDTO> RetrieveDTO()
        {
            List<Mercado> mercados = new List<Mercado>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercados = context.Mercados.ToList();
            }

            List<MercadoDTO> mercadosDTO = new List<MercadoDTO>();
            for (int i = 0; i < mercados.Count; i++) mercadosDTO.Add(ToDTO(mercados[i]));

            return mercadosDTO;
        }

        internal Mercado Retrieve(int id)
        {
            Mercado mercado;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercado = context.Mercados.Where(s => s.MercadoId == id).FirstOrDefault();
            }

            return mercado;
        }

        /***Inicio ejercicio 1 EXAMEN***/
        internal List<ApuestaExamen> RetrieveExamen(int id)
        {
            Mercado mercado;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercado = context.Mercados.Where(s => s.MercadoId == id).Include(p => p.Apuestas).FirstOrDefault();
            }

            if (mercado != null)
            {
                List<ApuestaExamen> apuestas = new List<ApuestaExamen>();
                for (int i = 0; i < mercado.Apuestas.Count; i++)
                {
                    Apuesta apuesta = mercado.Apuestas[i];

                    Usuario usuario;
                    using (PlaceMyBetContext context = new PlaceMyBetContext()) usuario = context.Usuarios.Where(s => s.UsuarioId == apuesta.UsuarioId).FirstOrDefault();
                    apuestas.Add(new ApuestaExamen(apuesta.Dinero, apuesta.OverUnder, usuario.Nombre));
                }

                return apuestas;
            }

            return null;
        }
        /***Final ejercicio 1 EXAMEN***/

        internal void Save(Mercado mercado)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            context.Mercados.Add(mercado);
            context.SaveChanges();
        }

        public MercadoDTO ToDTO(Mercado m) 
        { 
            return new MercadoDTO(m.Tipo, m.CuotaOver, m.CuotaUnder); 
        }
    }
}