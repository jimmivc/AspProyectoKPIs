using AspProyectoKPI.Models;
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
    public partial class crearKPI : System.Web.UI.Page
    {
        List<string> formula;
        List<string> variables;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!txtValor.Text.Equals(""))
                txtFormula.Text += txtValor.Text;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFormula.Text += ddlCampo.Text;
        }

        protected void btnOperador_Click(object sender, EventArgs e)
        {
            var operador = (Button)sender;
            txtFormula.Text += operador.Text;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("indicadoreskpi.aspx");
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
            RestRequest request = new RestRequest("kpis/", Method.POST);

            List<DetalleFormula> formulaCompleta = new List<DetalleFormula>();
            formulaCompleta.Add(new DetalleFormula() {TipoDato = "campo", Consecutivo =0,Tabla ="Llamadas"});

            KPI kpiNuevo = new KPI(0, txtDescripcion.Text, ddlFormato.Text, Convert.ToDouble(txtObjetivo.Text), ddlPeriodicidad.Text, new ParametroKPI(Convert.ToInt32(txtLimiteInf.Text), Convert.ToInt32(txtLimiteSup.Text)),formulaCompleta);

            request.AddJsonBody(kpiNuevo);

            var response = client.Execute(request);

            Response.Redirect("indicadoresKPI.aspx");
        }

    }
}