using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProyectoKPI.Models
{
   
    public class Usuario
    {

        public Usuario()
        {

        }
        public Usuario(int id, string nombre, string apellido, string correo, string contrasena, int cedula, bool isActivo, Rol rol)
        {
            UsuarioID = id;
            Nombre = nombre;
            Apellidos = apellido;
            Correo = correo;
            Contrasena = contrasena;
            Cedula = cedula;
            IsActivo = isActivo;
            Rol = rol;
        }
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public int Cedula { get; set; }
        public bool IsActivo { get; set; }
        public Rol Rol { get; set; }


    }
}