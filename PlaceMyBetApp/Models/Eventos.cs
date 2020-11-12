using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AE2.Models
{
    public class Eventos
    {
        public int      idEvento     { get; set; }
        public string   nomLocal     { get; set; }
        public string   nomVisitante { get; set; }
        public DateTime fecha        { get; set; }
    }

    public class EventosDTO
    {
        public string nomLocal     { get; set; }
        public string nomVisitante { get; set; }
        public DateTime fecha      { get; set; }
    }
}