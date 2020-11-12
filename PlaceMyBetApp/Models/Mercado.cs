using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AE2.Models
{
    public class Mercado
    {
        public Mercado(int mercadoId, int tipo, float cuotaOver, float cuotaUnder, float dineoroOver, float dineroUnder, int eventoId)
        {
            MercadoId   = mercadoId;
            Tipo        = tipo;
            CuotaOver   = cuotaOver;
            CuotaUnder  = cuotaUnder;
            DineoroOver = dineoroOver;
            DineroUnder = dineroUnder;
            EventoId    = eventoId;
        }

        public int   MercadoId   { get; set; }
        public int   Tipo        { get; set; }
        public float CuotaOver   { get; set; }
        public float CuotaUnder  { get; set; }
        public float DineoroOver { get; set; }
        public float DineroUnder { get; set; }

        public Evento        Evento   { get; set; }
        public int           EventoId { get; set; }
        public List<Apuesta> Apuestas { get; set; }
    }
}