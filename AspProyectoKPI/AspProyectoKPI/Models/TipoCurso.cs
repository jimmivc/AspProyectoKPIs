using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProyectoKPI.Models
{
    public class TipoCurso
    {
        public TipoCurso()
        {

        }
        public TipoCurso(int id, string nombre)
        {
            TipoCursoID = id;
            NombreTipoCurso = nombre;
        }
        public int TipoCursoID { get; set; }
        public string NombreTipoCurso { get; set; }
    }
}