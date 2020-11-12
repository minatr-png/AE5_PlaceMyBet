using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AE2.Models
{
    public class Apuesta
    {
        public Apuesta(int apuestaId, int tipo, float cuota, float dinero, DateTime fecha, string overUnder, string usuarioId)
        {
            ApuestaId = apuestaId;
            Tipo      = tipo;
            Cuota     = cuota;
            Dinero    = dinero;
            Fecha     = fecha;
            OverUnder = overUnder;
            UsuarioId = usuarioId;
        }

        public int      ApuestaId  { get; set; }
        public int      Tipo       { get; set; }
        public float    Cuota      { get; set; }
        public float    Dinero     { get; set; }
        public DateTime Fecha      { get; set; }
        public string   OverUnder  { get; set; }

        public Mercado Mercado   { get; set; }
        public Usuario Usuario   { get; set; }
        public string  UsuarioId { get; set; }
    }
}