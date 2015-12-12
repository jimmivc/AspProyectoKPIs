using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProyectoKPI.Models
{
    public class Curso
    {
        public Curso()
        {

        }
        public Curso(int id, string codigo, string nombre, TipoCurso tipo)
        {
            CursoID = id;
            CodigoCurso = codigo;
            NombreCurso = nombre;
            TipoCurso = tipo;
        }
        public int CursoID { get; set; }
        public string CodigoCurso{get; set;}
        public string NombreCurso{get; set;}
        public TipoCurso TipoCurso { get; set; }
    }
}