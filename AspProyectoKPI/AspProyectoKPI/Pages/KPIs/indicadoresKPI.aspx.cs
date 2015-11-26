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

namespace AspProyectoKPI.Paginas
{
    public partial class indicadoresKPI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadKpiData();
                bindData();
            }
        }

        private void bindData()
        {
            dtgIndicadoresKPI.DataSource = Session["indicadoresKPI"];
            dtgIndicadoresKPI.DataBind();
        }

        private void loadKpiData()
        {
            RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
            RestRequest request = new RestRequest("kpis",Method.GET);

            var response = client.Execute(request);

            string json = response.Content;

            List<KPI> listaKpis = JsonConvert.DeserializeObject<List<KPI>>(json);

            DataTable tablaIndicadoresKPI = new DataTable("kpis");
            tablaIndicadoresKPI.Columns.AddRange(new DataColumn[5] {new DataColumn("ID",typeof(int)),
                new DataColumn("Descripcion",typeof(string)),
                new DataColumn("Formato",typeof(string)),
                new DataColumn("Objetivo",typeof(string)),
                new DataColumn("Periodicidad",typeof(string))
            });
            if (listaKpis.Count > 0)
                foreach (var kpi in listaKpis)
                    tablaIndicadoresKPI.Rows.Add(kpi.KPIID, kpi.DescKpi, kpi.Formato, kpi.Objetivo, kpi.Periodicidad);

            Session["indicadoresKPI"] = tablaIndicadoresKPI;
        }

        protected void dtgIndicadoresKPI_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dtgIndicadoresKPI.EditIndex = e.NewEditIndex;
            bindData();
        }

        protected void dtgIndicadoresKPI_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dtgIndicadoresKPI.EditIndex = -1;
            bindData();
        }

        protected void btnCrearKPI_Click(object sender, EventArgs e)
        {
            Response.Redirect("crearKPI.aspx");
        }

        protected void dtgIndicadoresKPI_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("endpoint"));
            RestRequest request = new RestRequest("kpis/deshabilitar/{id}", Method.PUT);
            GridViewRow row = dtgIndicadoresKPI.Rows[e.RowIndex];

            request.AddUrlSegment("id", row.Cells[0].Text);
            var response = client.Execute(request);

            string json = response.Content;

            loadKpiData();
            bindData();
        }

    }
}