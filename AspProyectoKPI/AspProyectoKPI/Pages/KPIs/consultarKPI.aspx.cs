using AspProyectoKPI.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspProyectoKPI.Pages.KPIs
{
    public partial class consultarKPI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDatos();
            }
        }

        private void cargarDatos()
        {
            RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
            RestRequest request = new RestRequest("kpis/{id}", Method.GET);
            

            request.AddUrlSegment("id", (string)Session["idIndicador"]);
            var response = client.Execute(request);

            string json = response.Content;

            KPI kpi = JsonConvert.DeserializeObject<KPI>(json);

            txtDescripcion.Text = kpi.DescKpi;
            txtObjetivo.Text = kpi.Objetivo.ToString();
            ddlFormato.Items.Add(kpi.Formato);
            ddlPeriodicidad.Items.Add(kpi.Periodicidad);
            verde.Text = "KPI>=" + kpi.Parametro.LimiteSuperior.ToString();
            amarillo.Text = kpi.Parametro.LimiteInferior.ToString() + "-" + kpi.Parametro.LimiteSuperior.ToString();
            rojo.Text = "KPI <" + kpi.Parametro.LimiteInferior.ToString();

            foreach (DetalleFormula dato in kpi.Formula)
            {
                switch (dato.TipoDato)
                {
                    case "campo":
                        txtFormula.Text += dato.Tabla;
                        break;
                    case "valor":
                        txtFormula.Text += dato.Valor; 
                        break;
                    case "operador":
                        txtFormula.Text += dato.DescCampoOperador;
                        break;
                }
            }

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect("indicadoresKPI.aspx");
        }
    }
}