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
    public class ApuestasRepository
    {
        internal List<Apuesta> Retrieve()
        {
            List<Apuesta> apuestas = new List<Apuesta>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuestas.Include(p => p.Mercado).ToList();
            }

            return apuestas;
        }

        internal List<ApuestaDTO> RetrieveDTO()
        {
            List<Apuesta> apuestas = new List<Apuesta>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuestas.Include(p => p.Mercado).ToList();
            }

            List<ApuestaDTO> apuestasDTO = new List<ApuestaDTO>();
            for (int i = 0; i < apuestas.Count; i++) apuestasDTO.Add(ToDTO(apuestas[i]));

            return apuestasDTO;
        }

        internal Apuesta Retrieve(int id)
        {
            Apuesta apuesta;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuesta = context.Apuestas.Where(s => s.ApuestaId == id).FirstOrDefault();
            }

            return apuesta;
        }

        /***Inicio ejercicio 2 EXAMEN***/
        internal List<ApuestaExamen2> RetrieveExamen(float dinero)
        {
            List<Apuesta> apuestas = new List<Apuesta>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuestas.Where(s => s.Dinero > dinero).Include(p => p.Mercado).ToList();
            }

            List<ApuestaExamen2> apuestasExamen2 = new List<ApuestaExamen2>();
            for (int i = 0; i < apuestas.Count; i++)
            {
                Apuesta apuesta = apuestas[i];
                Evento evento;
                using (PlaceMyBetContext context = new PlaceMyBetContext())
                {
                    evento = context.Eventos.Where(s => s.EventoId == apuesta.MercadoId).FirstOrDefault(); 
                }
                apuestasExamen2.Add(new ApuestaExamen2(apuesta.OverUnder, ))
            }

            return apuestasExamen2;
        }
        /***Final ejercicio 2 EXAMEN***/

        internal void Save(Apuesta apuesta)
        {
            PlaceMyBetContext contextApuesta = new PlaceMyBetContext();
            contextApuesta.Apuestas.Add(apuesta);
            contextApuesta.SaveChanges();

            Mercado mercado;
            using (PlaceMyBetContext contextMercado = new PlaceMyBetContext())
            {
                mercado = contextMercado.Mercados.Where(p => p.MercadoId == apuesta.MercadoId).FirstOrDefault();
                if (apuesta.OverUnder == "over")
                {
                    mercado.DineroOver += apuesta.Dinero;

                    float probabilidad = mercado.DineroOver / (mercado.DineroOver + mercado.DineroUnder);
                    mercado.CuotaOver  = (float)(1 / probabilidad * 0.95); 
                }
                else
                {
                    mercado.DineroUnder += apuesta.Dinero;

                    float probabilidad = mercado.DineroUnder / (mercado.DineroOver + mercado.DineroUnder);
                    mercado.CuotaUnder = (float)(1 / probabilidad * 0.95);
                }

                contextMercado.SaveChanges();
            }
        }

        public ApuestaDTO ToDTO(Apuesta a)
        {
            return new ApuestaDTO(a.UsuarioId, a.Mercado.EventoId, a.Tipo, a.Cuota, a.Dinero);
        }
    }
}