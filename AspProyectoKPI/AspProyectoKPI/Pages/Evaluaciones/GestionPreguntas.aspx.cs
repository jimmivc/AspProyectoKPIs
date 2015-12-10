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

namespace AspProyectoKPI.Pages.KPIs
{
    public partial class GestionPreguntas : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TabName.Value = Request.Form[TabName.UniqueID];
                loadPreguntasData();
                loadCategoriasData();
                bindData();
                bindData2();

            }
            else
            {
                TabName.Value = Request.Form[TabName.UniqueID];
            }


        }

        private void bindData()
        {
            GridListaPreguntas.DataSource = Session["PreguntasDataTable"];
            GridListaPreguntas.DataBind();
            
        }
        private void bindData2()
        {
            GridCategorias.DataSource = Session["CategoriasDataTable"];
            GridCategorias.DataBind();
        }

        private void loadCategoriasData()
        {
            RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
            RestRequest request = new RestRequest("Categorias", Method.GET);

            var response = client.Execute(request);

            string json = response.Content;

            List<Categoria> listaCategorias = JsonConvert.DeserializeObject<List<Categoria>>(json);
            if (listaCategorias != null)
            {
                foreach (Categoria categoria in listaCategorias)
                    ddlCategoria.Items.Add(categoria.CategoriaID.ToString() + " - " + categoria.DescCategoria);
            }

            DataTable tableCategorias = new DataTable();
            tableCategorias.Columns.AddRange(new DataColumn[4]{
                new DataColumn("idCategoria", typeof(int)),
                new DataColumn("categoria", typeof(string)),
                new DataColumn("minimo", typeof(int)),
                new DataColumn("maximo", typeof(int))
            });

            foreach (var categoria in listaCategorias)
            {
                
                tableCategorias.Rows.Add(categoria.CategoriaID, categoria.DescCategoria, categoria.PuntajeMinimo, categoria.PuntajeMaximo);
                //txtSelected.Text = pregunta.DescPregunta;
            }

            Session["CategoriasDataTable"] = tableCategorias;


        }

        private void loadPreguntasData()
        {
            RestClient client = new RestClient(ConfigurationManager.AppSettings["endpoint"]);
            RestRequest request = new RestRequest("Preguntas", Method.GET);
            var response = client.Execute(request);
            string json = response.Content;

            List<Pregunta> listaPreguntas = JsonConvert.DeserializeObject<List<Pregunta>>(json);

            DataTable tablePreguntas = new DataTable();
            tablePreguntas.Columns.AddRange(new DataColumn[3]{
                new DataColumn("idPregunta", typeof(int)),
                new DataColumn("pregunta", typeof(string)),
                new DataColumn("categoria", typeof(string))
            });
            
            foreach (var pregunta in listaPreguntas)
            {
                string descCategoria = "";
                if (!(pregunta.Categoria == null))
                {
                    descCategoria = pregunta.Categoria.DescCategoria;
                }
                
                tablePreguntas.Rows.Add(pregunta.PreguntaID, pregunta.DescPregunta, descCategoria);
                //txtSelected.Text = pregunta.DescPregunta;
            }

            Session["PreguntasDataTable"] = tablePreguntas;
        }



        protected void GridListaPreguntas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = GridListaPreguntas.Rows[GridListaPreguntas.SelectedIndex].Cells[1].Text;
           // txtSelected.Text = name;
        }

        protected void GridListaPreguntas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Setear edit index
            GridListaPreguntas.EditIndex = e.NewEditIndex;
            //Rebindear los datos
            bindData();
        }

        protected void GridListaPreguntas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
            RestRequest request = new RestRequest("Preguntas/{id}", Method.PUT);

            DataTable preguntasTable = (DataTable)Session["PreguntasDataTable"];
            GridViewRow row = GridListaPreguntas.Rows[e.RowIndex];

            Pregunta pregunta = new Pregunta(Convert.ToInt32(e.NewValues[0]), Convert.ToString(e.NewValues[1]), 
                                new Categoria(Convert.ToInt32(e.NewValues[2]),"nueva", 1, 4));

            request.AddUrlSegment("id", Convert.ToString(e.NewValues[0]));
            request.AddJsonBody(pregunta);
            var response = client.Execute(request);

            GridListaPreguntas.EditIndex = -1;
            Session["PreguntasDataTable"] = preguntasTable;
            loadPreguntasData();
            bindData();
        }

        protected void GridListaPreguntas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridListaPreguntas.EditIndex = -1;
            bindData();
        }

        protected void GridListaPreguntas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
            RestRequest request = new RestRequest("Preguntas/{id}", Method.DELETE);
            GridViewRow row = GridListaPreguntas.Rows[e.RowIndex];

            request.AddUrlSegment("id", row.Cells[0].Text);
            var response = client.Execute(request);

            string json = response.Content;

            loadPreguntasData();
            bindData();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
          
            RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
            RestRequest request = new RestRequest("Preguntas", Method.POST);

            string textPregunta = txtPregunta.Text;
            int idCategoria = Convert.ToInt32(ddlCategoria.SelectedItem.ToString().Substring(0, 1));
            

            Pregunta pregunta = new Pregunta(0, textPregunta, ObtenerCategoriaXId(idCategoria));
            request.AddJsonBody(pregunta);
            var response = client.Execute(request);

            GridListaPreguntas.EditIndex = -1;
            
            loadPreguntasData();
            bindData();
        
        }

        protected Categoria ObtenerCategoriaXId(int idCat)
        {

            RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
            RestRequest request = new RestRequest("Categorias/{id}", Method.GET);

            request.AddUrlSegment("id", Convert.ToString(idCat));
           
            var response = client.Execute<Categoria>(request).Data;

            return response;

        }


        //*****segundo tab menu*****************************************************************

        protected void GridCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = GridCategorias.Rows[GridCategorias.SelectedIndex].Cells[1].Text;
            // txtSelected.Text = name;
        }

        protected void GridCategorias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Setear edit index
            GridCategorias.EditIndex = e.NewEditIndex;
            bindData2();
        }

        protected void GridCategorias_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
            RestRequest request = new RestRequest("Categorias/{id}", Method.PUT);

            DataTable categoriasTable = (DataTable)Session["CategoriasDataTable"];
            GridViewRow row = GridCategorias.Rows[e.RowIndex];

            ////int idP = Convert.ToInt32(e.NewValues[0]);
            //string catP = Convert.ToString(e.NewValues[1]);
            //int min = Convert.ToInt32(e.NewValues[2]);

            Categoria categoria = new Categoria(Convert.ToInt32(e.NewValues[0]),Convert.ToString(e.NewValues[1]), Convert.ToInt32(e.NewValues[2]), Convert.ToInt32(e.NewValues[3]));

            request.AddUrlSegment("id", Convert.ToString(e.NewValues[0]));
            request.AddJsonBody(categoria);
            var response = client.Execute(request);

            GridCategorias.EditIndex = -1;
            Session["CategoriasDataTable"] = categoriasTable;
            loadCategoriasData();
            bindData2();
        }

        protected void GridCategorias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridCategorias.EditIndex = -1;
            loadCategoriasData();
            bindData2();
            
        }

        protected void GridCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
            RestRequest request = new RestRequest("Categorias/{id}", Method.DELETE);
            GridViewRow row = GridCategorias.Rows[e.RowIndex];

            request.AddUrlSegment("id", row.Cells[0].Text);
            var response = client.Execute(request);

            string json = response.Content;

            loadCategoriasData();
            bindData2();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
            RestRequest request = new RestRequest("Categorias", Method.POST);

            string textCategoria = TextCategoria.Text;
            int textMinimo = Convert.ToInt32(TextMinimo.Text);
            int textMaximo = Convert.ToInt32(TextMaximo.Text);

            Categoria categoria = new Categoria(0, textCategoria, textMinimo, textMaximo);
            request.AddJsonBody(categoria);
            var response = client.Execute(request);

            GridCategorias.EditIndex = -1;
            loadCategoriasData();
            bindData2();
        }
    }
}