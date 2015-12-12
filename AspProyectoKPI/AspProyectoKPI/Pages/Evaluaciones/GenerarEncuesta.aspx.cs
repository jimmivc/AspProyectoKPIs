using AspProyectoKPI.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspProyectoKPI.Pages.Evaluaciones
{
    public partial class GenerarEncuesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                loadProfesores();
                loadCuatrimestres();
                loadAnio();
                loadCurso();
                loadPlantillas();
                loadEncuestasData();
                bindData();

            }
        }

        private void bindData()
        {
            GridEncuestas.DataSource = Session["EncuestasDataTable"];
            GridEncuestas.DataBind();
        }

        private void loadEncuestasData()
        {
            RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
            RestRequest request = new RestRequest("EncuestaMaestroes", Method.GET);

            var response = client.Execute(request);

            string json = response.Content;

            List<EncuestaMaestro> listaEncuestas = JsonConvert.DeserializeObject<List<EncuestaMaestro>>(json);
           
            DataTable tableEncuestas = new DataTable();
            tableEncuestas.Columns.AddRange(new DataColumn[1]{
                new DataColumn("idEncuesta", typeof(int))
                //new DataColumn("categoria", typeof(string)),
                //new DataColumn("minimo", typeof(int)),
                //new DataColumn("maximo", typeof(int))
            });

            foreach (var encuesta in listaEncuestas)
            {

                tableEncuestas.Rows.Add(encuesta.EncuestaMaestroID);
                //txtSelected.Text = pregunta.DescPregunta;
            }

            Session["EncuestaDataTable"] = tableEncuestas;


        }

        private void loadProfesores()
        {
            RestClient client = new RestClient(ConfigurationManager.AppSettings["endpoint"]);
            RestRequest request = new RestRequest("Usuarios/Tipo/4", Method.GET);
            var response = client.Execute(request);
            string json = response.Content;

            List<Usuario> listaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);
            if (listaUsuarios != null)
            {
                foreach (Usuario usuario in listaUsuarios)
                    ddlProfesor.Items.Add(usuario.UsuarioID.ToString() + " - " + usuario.Nombre + " " + usuario.Apellidos);
            }
         }
        private void loadCuatrimestres()
        {
            ddlCuatrimestre.Items.Add("1");
            ddlCuatrimestre.Items.Add("2");
            ddlCuatrimestre.Items.Add("3");
        }
        private void loadAnio()
        {
            for (int i = 2010; i <= 2060; i++)
            {
                ddlAnio.Items.Add(Convert.ToString(i));
            }
         }

        private void loadCurso()
        {
            RestClient client = new RestClient(ConfigurationManager.AppSettings["endpoint"]);
            RestRequest request = new RestRequest("Cursoes", Method.GET);
            var response = client.Execute(request);
            string json = response.Content;

            List<Curso> listaCursos = JsonConvert.DeserializeObject<List<Curso>>(json);
            if (listaCursos != null)
            {
                foreach (Curso curso in listaCursos)
                    ddlCurso.Items.Add(curso.CursoID.ToString() + " - " + curso.NombreCurso);
            }
        }

        private void loadPlantillas()
        {
            RestClient client = new RestClient(ConfigurationManager.AppSettings["endpoint"]);
            RestRequest request = new RestRequest("Plantillas", Method.GET);
            var response = client.Execute(request);
            string json = response.Content;

            List<Plantilla> listaPlantillas = JsonConvert.DeserializeObject<List<Plantilla>>(json);
            if (listaPlantillas != null)
            {
                foreach (Plantilla plantilla in listaPlantillas)
                {
                    ddlPlantilla.Items.Add(plantilla.PlantillaID.ToString() + " - " + plantilla.DescripcionPlantilla);
                }
                    
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
            RestRequest request = new RestRequest("RelacionCursos/Generar/{idProfesor}/{cuatrimestre}/{anio}/{curso}/{plantilla}", Method.GET);

            string txtProfesor = ddlProfesor.SelectedItem.ToString().Substring(0, 1);
            string txtCuatrimestre = ddlCuatrimestre.SelectedItem.ToString().Substring(0, 1);
            string txtAnio = ddlAnio.SelectedItem.ToString().Substring(0, 4);
            string txtCurso = ddlCurso.SelectedItem.ToString().Substring(0, 1);
            string txtPlantilla = ddlPlantilla.SelectedItem.ToString().Substring(0, 1);

            request.AddUrlSegment("idProfesor", txtProfesor);
            request.AddUrlSegment("cuatrimestre", txtCuatrimestre);
            request.AddUrlSegment("anio", txtAnio);
            request.AddUrlSegment("curso", txtCurso);
            request.AddUrlSegment("plantilla", txtPlantilla);

            var response = client.Execute(request);
            string json = response.Content;
        }
            
    }
}