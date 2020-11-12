using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AE2.Models
{
    public class Mercados
    {
        public int   idMercado   { get; set; }
        public int   tipo        { get; set; }
        public float cuotaOver   { get; set; }
        public float cuotaUnder  { get; set; }
        public float dineoroOver { get; set; }
        public float dineroUnder { get; set; }
        public int   eventoMer   { get; set; }
    }

    public class MercadosDTO
    {
        public int   tipo       { get; set; }
        public float cuotaOver  { get; set; }
        public float cuotaUnder { get; set; }
    }
}