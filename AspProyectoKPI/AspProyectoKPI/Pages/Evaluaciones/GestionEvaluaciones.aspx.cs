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
    public partial class GestionEvaluaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadPlantillaData();
                bindData();
            }
        }

        private void bindData()
        {
            dtgPreguntas.DataSource = Session["preguntasParaPlantilla"];
            dtgPreguntas.DataBind();
        }

        private void loadPlantillaData()
        {
            RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
            RestRequest request = new RestRequest("PreguntasCategoria", Method.GET);

            var response = client.Execute(request);

            string json = response.Content;

            List<Pregunta> listaPreguntas = JsonConvert.DeserializeObject<List<Pregunta>>(json);
            if (listaPreguntas != null)
            {
                DataTable tablaPreguntas = new DataTable("Preguntas");
                tablaPreguntas.Columns.AddRange(new DataColumn[3] {new DataColumn("ID",typeof(int)),
                new DataColumn("Descripción",typeof(string)),
                new DataColumn("Categoría",typeof(string))
                });
                if (listaPreguntas.Count > 0)
                    foreach (var pregunta in listaPreguntas)
                        tablaPreguntas.Rows.Add(pregunta.PreguntaID, pregunta.DescPregunta, pregunta.Categoria.DescCategoria);
                
                Session["preguntasParaPlantilla"] = tablaPreguntas;
            }
            else
            {
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<int> PreguntaIDS = new List<int>();
            foreach (GridViewRow row in dtgPreguntas.Rows) {
                CheckBox cb = (CheckBox)row.FindControl("ckBxPreguntas");
                if (cb != null && cb.Checked)
                {

                    PreguntaIDS.Add(Int32.Parse(row.Cells[1].Text));

                }
            }
            Session["NombrePlantilla"] = txtDescPlantilla;
            Session["IdsPreguntaPlantilla"] = PreguntaIDS;
            crearPlantilla();
        }

        private void crearPlantilla() {

            RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
            RestRequest request = new RestRequest("Plantillas/", Method.POST);

            Plantilla nuevaPlantilla = new Plantilla(0, txtDescPlantilla.Text);

            request.AddJsonBody(nuevaPlantilla);

            var response = client.Execute(request);

            request = new RestRequest("Plantillas/", Method.GET);

            response = client.Execute(request);

            string json = response.Content;

            List<Plantilla> plantillas = JsonConvert.DeserializeObject<List<Plantilla>>(json);

            nuevaPlantilla = plantillas[plantillas.Count-1];

            crearDetallePlantilla(nuevaPlantilla);

            Response.Redirect("GestionEvaluaciones.aspx");

        }

        private void crearDetallePlantilla(Plantilla pPlantilla)
        {

            List<int> ids = (List<int>)HttpContext.Current.Session["IdsPreguntaPlantilla"];
            List<Pregunta> preguntas = new List<Pregunta>();

            foreach (int valor in ids) {
                
                RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
                RestRequest request = new RestRequest("Preguntas/{id}", Method.GET);

                request.AddUrlSegment("id", Convert.ToString(valor));

                var response = client.Execute(request);

                string json = response.Content;

                Pregunta nuevaPregunta = JsonConvert.DeserializeObject<Pregunta>(json);

                preguntas.Add(nuevaPregunta);

            }

            RestClient client2 = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
            

            foreach (Pregunta item in preguntas) {

                RestRequest request2 = new RestRequest("PlantillaDetalle/", Method.POST);
                PlantillaDetalle x = new PlantillaDetalle(0, pPlantilla, item);

                request2.AddJsonBody(x);

                var response = client2.Execute(request2);
                Console.WriteLine(response.Content.ToString());
            }

        }
    }
}