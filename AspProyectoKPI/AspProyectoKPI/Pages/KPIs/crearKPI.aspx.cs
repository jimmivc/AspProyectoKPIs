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
    public partial class crearKPI : System.Web.UI.Page
    {
        static List<string> formula = new List<string>();
        static List<string> variables = new List<string>();
        static bool operador = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!txtValor.Text.Equals(""))
            {
                armarFormula(txtValor.Text);
                variables.Add("valor");
                txtValor.Text = "";
            }
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCampo.SelectedIndex != 0)
            {
                armarFormula(ddlCampo.Text);
                variables.Add("campo");
                ddlCampo.SelectedIndex = 0;
            }
        }

        protected void btnOperador_Click(object sender, EventArgs e)
        {
            var operador = (Button)sender;
            armarFormula(operador.Text);
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("indicadoreskpi.aspx");
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
                RestRequest request = new RestRequest("kpis/", Method.POST);

                List<DetalleFormula> formulaCompleta = new List<DetalleFormula>();

                for (int i = 0; i < formula.Count; i++)
                {
                    formulaCompleta.Add(new DetalleFormula(i, variables[i], formula[i]));
                }

                KPI kpiNuevo = new KPI(0, txtDescripcion.Text, ddlFormato.Text, Convert.ToDouble(txtObjetivo.Text), ddlPeriodicidad.Text, new ParametroKPI(Convert.ToInt32(ddlLimiteInf.Text), Convert.ToInt32(ddlLimiteSup.Text)), formulaCompleta);

                request.AddJsonBody(kpiNuevo);

                var response = client.Execute(request);

                formula = new List<string>();
                variables = new List<string>();
                operador = false;

                Response.Redirect("indicadoresKPI.aspx");
            }
            else
            {
                //"error"
            }
        }

        private bool validarCampos()
        {
            bool resul = false;
            if (!txtDescripcion.Text.Equals("") && !txtFormula.Text.Equals("") && !ddlFormato.SelectedItem.Equals("") && !txtObjetivo.Text.Equals("") && !ddlPeriodicidad.SelectedItem.Equals("") && ddlLimiteInf.Items.Count>0 && ddlLimiteSup.Items.Count>0)
            {
                if (!variables[variables.Count - 1].Equals("operador"))
                {

                    resul = true;

                }
                else
                {
                    //MessageBox.Show("formula incompleta");
                }
            }else{
                //datos incompletos
            }
            return resul;
        }

        protected void btnAceptarObj_Click(object sender, EventArgs e)
        {
            ddlLimiteInf.Items.Clear();
            ddlLimiteSup.Items.Clear();

            int objetive = Convert.ToInt32(txtObjetivo.Text);
            ddlLimiteInf.Items.Add((objetive/2).ToString());
            if(!txtObjetivo.Text.Equals(""))
                for (int i = objetive; i > -1 ; i--)
                {
                    ddlLimiteSup.Items.Add(i.ToString());
                }
        }

        protected void ddlLimiteSup_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLimiteInf.Items.Clear();
            var limiteSup = (DropDownList)sender;
            int limiteSeleccionado = Convert.ToInt32(limiteSup.Text)-1;
            for (int i = limiteSeleccionado; i > -1 ; i--)
            {
                ddlLimiteInf.Items.Add(i.ToString());
            }
        }

        private void armarFormula(string dato){
            if (operador == false && !isOperador(dato))
            {
                formula.Add(dato);
                operador = true;
            }
            else
            {
                if (operador == true && isOperador(dato))
                {
                    formula.Add(dato);
                    variables.Add("operador");
                    operador = false;
                }
                else
                {
                    //mensaje de error orden incorrecto
                }
            }
            txtFormula.Text = "";

            foreach (string dat in formula)
                txtFormula.Text += dat;
        }

        private bool isOperador(string dato)
        {
            if (dato.Equals("+") || dato.Equals("-") || dato.Equals("*") || dato.Equals("/"))
                return true;
            else
                return false;
        }

        protected void ddlDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddlDatos.SelectedItem.ToString().Equals(""))
            {
                RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
                RestRequest request = new RestRequest("kpis/datos/{campos}", Method.GET);

                request.AddUrlSegment("campos", ddlDatos.SelectedItem.ToString());

                var response = client.Execute(request);

                string json = response.Content;

                List<string> datos = JsonConvert.DeserializeObject<List<string>>(json);
                ddlCampo.Items.Clear();
                ddlCampo.Items.Add("");
                foreach (var dat in datos)
                {
                    ddlCampo.Items.Add(dat);
                }
                borrar();
            }
            
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            borrar();
        }

        private void borrar()
        {
            formula = new List<string>();
            variables = new List<string>();
            operador = false;
            txtFormula.Text = "";
        }
    }
}