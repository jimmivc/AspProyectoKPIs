using ApiProyectoKPI.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspProyectoKPI.Paginas
{
    public partial class IniciarSesion : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string correo = user.Text;
            string pass = password.Text;

            if (correo.Equals("gsaenzp@ucenfotec.ac.cr")) {

                pass = "tXFOeepeTOFiXdv5UUVUBA==";

            }

            RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
            RestRequest request = new RestRequest("Usuarios/correo/{id}/{a}/", Method.GET);

            request.AddUrlSegment("id", correo);
            request.AddUrlSegment("a", "a");

            var response = client.Execute(request);
            string json = response.Content;

            Usuario newUser = JsonConvert.DeserializeObject<Usuario>(json);

            if (newUser != null)
            {

                Session["globalUser"] = newUser;
                Response.Redirect("../Default.aspx");

            }
            else {

                Label1.Text = "Error de contraseña o usuario";

            }

            
            

        }

    }
}