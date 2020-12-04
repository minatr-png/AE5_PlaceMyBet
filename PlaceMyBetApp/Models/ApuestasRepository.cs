using MySql.Data.MySqlClient;
using PlaceMyBetApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        internal Apuesta Retrieve(int id)
        {
            Apuesta apuesta;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuesta = context.Apuestas.Where(s => s.ApuestaId == id).FirstOrDefault();
            }

            return apuesta;
        }

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
    }
}