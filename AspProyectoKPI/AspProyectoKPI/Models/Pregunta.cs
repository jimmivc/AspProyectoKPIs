using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProyectoKPI.Models
{
    public class Pregunta
    {

        public Pregunta()
        {

        }
        public Pregunta(int id, string pregunta, Categoria categoria)
        {
            PreguntaID = id;
            DescPregunta = pregunta;
            Categoria = categoria;
        }

        public int PreguntaID { get; set; }
        public string DescPregunta { get; set; }
        public Categoria Categoria { get; set; }

    }
}