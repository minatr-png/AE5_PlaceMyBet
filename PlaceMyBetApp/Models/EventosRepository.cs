using Microsoft.Ajax.Utilities;
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

        internal void Save(Evento evento)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            context.Eventos.Add(evento);
            context.SaveChanges();
        }
    }
}