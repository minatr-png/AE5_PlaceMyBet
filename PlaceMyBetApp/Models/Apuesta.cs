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
        public int     MercadoId { get; set; }
        public Usuario Usuario   { get; set; }
        public string  UsuarioId { get; set; }
    }

    public class ApuestaDTO
    {
        public ApuestaDTO(string usuarioID, int eventoId, int tipo, float cuota, float dinero)
        {
            UsuarioId = usuarioID;
            EventoId  = eventoId;
            Tipo      = tipo;
            Cuota     = cuota;
            Dinero    = dinero;
        }

        public int    Tipo      { get; set; }
        public float  Cuota     { get; set; }
        public float  Dinero    { get; set; }
        public int    EventoId  { get; set; }
        public string UsuarioId { get; set; }
    }

    /***Inicio ejercicio 1 EXAMEN***/
    public class ApuestaExamen
    {
        public ApuestaExamen(float dinero_Apostado, string tipo, string nombre)
        {
            Dinero_Apostado = dinero_Apostado;
            Tipo            = tipo;
            Nombre          = nombre;
        }

        public float  Dinero_Apostado { get; set; }
        public string Tipo            { get; set; }
        public string Nombre          { get; set; }
    }
    /***Final ejercicio 1 EXAMEN***/

    /***Inicio ejercicio 2 EXAMEN***/
    public class ApuestaExamen2
    {
        public ApuestaExamen2(string tipo, string equipo_local, string equipo_visitante)
        {
            Tipo             = tipo;
            Equipo_local     = equipo_local;
            Equipo_visitante = equipo_visitante;
        }

        public string Tipo             { get; set; }
        public string Equipo_local     { get; set; }
        public string Equipo_visitante { get; set; }
    }
    /***Final ejercicio 2 EXAMEN***/
}