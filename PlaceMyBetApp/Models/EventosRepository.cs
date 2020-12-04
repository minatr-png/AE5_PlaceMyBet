﻿using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using PlaceMyBetApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AE2.Models
{
    public class EventosRepository
    {
        internal List<Evento> Retrieve()
        {
            List<Evento> eventos = new List<Evento>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                eventos = context.Eventos.ToList();
            }

            return eventos;
        }

        internal Evento Retrieve(int id)
        {
            Evento evento;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                evento = context.Eventos.Where(s => s.EventoId == id).FirstOrDefault();
            }

            return evento;
        }

        internal void Save(Evento evento)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            context.Eventos.Add(evento);
            context.SaveChanges();
        }
        internal void Delete(int id)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            context.Eventos.Remove(Retrieve(id)); //He creado la función retrieve aunque no la usemos ya que creo que sería de más utilidad (si no la pudiese crear sería copiar y pegar el código)
            context.SaveChanges();
        }

    }
}