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
    public partial class asignarIndicadoresKPI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadRolData();
                bindData();
            }
        }

        private void loadRolData()
        {
            RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
            RestRequest request = new RestRequest("rols",Method.GET);

            var response = client.Execute(request);

            string json = response.Content;

            List<Rol> listaRoles = JsonConvert.DeserializeObject<List<Rol>>(json);
            if (listaRoles != null)
            {
                foreach (Rol rol in listaRoles)
                    ddlRoles.Items.Add(rol.RolID.ToString()+" - "+rol.Nombre);
            }
            
        }

        private void bindData()
        {
            dtgIndicadoresKPI.DataSource = Session["indicadoresKPI"];
            dtgIndicadoresKPI.DataBind();

            dtgIndicadoresAsignados.DataSource = Session["indicadoresKPIAsignados"];
            dtgIndicadoresAsignados.DataBind();

        }

        protected void dtgIndicadoresKPI_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
            RestRequest request = new RestRequest("kpis/asignar/{idKPI}/{idRol}", Method.GET);

            request.AddUrlSegment("idKPI", dtgIndicadoresKPI.Rows[e.NewSelectedIndex].Cells[0].Text);
            request.AddUrlSegment("idRol", (string)Session["idRolSeleccionado"]);
            
            var response = client.Execute(request);

            string json = response.Content;
            cargarKPIsAsignados();    
        }

        protected void ddlRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRoles.SelectedIndex != 0)
            {
                Session["idRolSeleccionado"] = ddlRoles.SelectedItem.ToString().Substring(0,1);
                
                cargarKPIsAsignados();
            }
        }

        private void cargarKPIsAsignados()
        {
            
            RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
            RestRequest request = new RestRequest("kpis/indicadoresAsignados/{idRol}", Method.GET);

            request.AddUrlSegment("idRol", (string)Session["idRolSeleccionado"]);

            var response = client.Execute(request);

            string json = response.Content;

            List<KPI> listaKpis = JsonConvert.DeserializeObject<List<KPI>>(json);

            if (listaKpis != null)
            {
                DataTable tablaIndicadoresKPIAsignados = new DataTable("kpis");
                tablaIndicadoresKPIAsignados.Columns.AddRange(new DataColumn[5] {new DataColumn("ID",typeof(int)),
                new DataColumn("Descripcion",typeof(string)),
                new DataColumn("Formato",typeof(string)),
                new DataColumn("Objetivo",typeof(string)),
                new DataColumn("Periodicidad",typeof(string))
                });
                if (listaKpis.Count > 0)
                    foreach (var kpi in listaKpis)
                        tablaIndicadoresKPIAsignados.Rows.Add(kpi.KPIID, kpi.DescKpi, kpi.Formato, kpi.Objetivo, kpi.Periodicidad);

                Session["indicadoresKPIAsignados"] = tablaIndicadoresKPIAsignados;
                bindData();
            }
        }

        protected void quitarKPI(object sender, GridViewDeleteEventArgs e)
        {
            RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
            RestRequest request = new RestRequest("kpis/desasignar/{idKPI}/{idRol}", Method.GET);

            request.AddUrlSegment("idKPI", dtgIndicadoresKPI.Rows[e.RowIndex].Cells[0].Text);
            request.AddUrlSegment("idRol", (string)Session["idRolSeleccionado"]);

            var response = client.Execute(request);

            string json = response.Content;
            cargarKPIsAsignados();  
        }
    }
}