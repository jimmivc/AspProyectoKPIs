using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProyectoKPI.Models
{
    public class EncuestaMaestro
    {
        public EncuestaMaestro()
        {

        }

        public int EncuestaMaestroID { get; set; }
        public RelacionCursos RelacionCursos { get; set;}
        public Plantilla PlantillaEncuestaMaestro { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaVence { get; set;}
        public bool Estatus { get; set; }
        public List<EncuestaDetalle> EncuestaDetalle { get; set; }

    }
}