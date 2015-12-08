using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProyectoKPI.Models
{
    public class Categoria
    {

        public Categoria()
        {

        }
        public Categoria(int id, string categoria, int minimo, int maximo)
        {
            CategoriaID = id;
            DescCategoria = categoria;
            PuntajeMinimo = minimo;
            PuntajeMaximo = maximo;
        }

        public int CategoriaID { get; set; }
        public string DescCategoria { get; set; }
        public int PuntajeMinimo { get; set; }
        public int PuntajeMaximo { get; set; }

    }
}