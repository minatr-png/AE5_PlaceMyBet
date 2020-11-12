using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AE2.Models
{
    public class Apuestas
    {
        public int      idApuesta  { get; set; }
        public int      mercadoApu { get; set; }
        public int      tipo       { get; set; }
        public float    cuota      { get; set; }
        public float    dinero     { get; set; }
        public DateTime fecha      { get; set; }
        public string   emailUsu   { get; set; }
        public string   overUnder  { get; set; }
    }

    public class ApuestasDTO
    {
        public int      tipo      { get; set; }
        public float    cuota     { get; set; }
        public float    dinero    { get; set; }
        public DateTime fecha     { get; set; }
        public string   emailUsu  { get; set; }
        public string   overUnder { get; set; }
    }

    public class ApuestasMercadoEmail
    {
        public int    tipo      { get; set; }
        public string overUnder { get; set; }
        public float  cuota     { get; set; }
        public float  dinero    { get; set; }
    }
}