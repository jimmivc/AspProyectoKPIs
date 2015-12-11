using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProyectoKPI.Models
{
    public class Rol
    {
        public Rol()
        {

        }

        public int RolID { get; set; }
        public string Nombre { get; set; }
        //public List<Permiso> Permisos { get; set; }
        //public List<Usuario> Usuarios { get; set; }
        //public List<KPI> IndicadoresKPI { get; set; }
    }
}