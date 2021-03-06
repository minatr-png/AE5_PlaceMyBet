﻿using MySql.Data.MySqlClient;
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
                mercados = context.Mercados.ToList();
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