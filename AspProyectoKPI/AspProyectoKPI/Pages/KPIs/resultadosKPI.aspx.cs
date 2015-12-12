using AspProyectoKPI.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspProyectoKPI.Pages.KPIs
{
    public partial class resultadosKPI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadRolData();
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

            dtgResultadosKPI.DataSource = Session["resultadosKPI"];
            dtgResultadosKPI.DataBind();

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
            RestRequest request = new RestRequest("kpis/resultados/{idRol}", Method.GET);

            request.AddUrlSegment("idRol", (string)Session["idRolSeleccionado"]);

            var response = client.Execute(request);

            string json = response.Content;
            
            List<List<string>> listaKpis = JsonConvert.DeserializeObject<List<List<string>>>(json);
            actualizarResultados(listaKpis);
        }

        private void actualizarResultados(List<List<string>> resultados)
        {
            DataTable tablaResultadosKPI = new DataTable("kpis");
            tablaResultadosKPI.Columns.AddRange(new DataColumn[6] {new DataColumn("Descripcion",typeof(string)),
                new DataColumn("Usuario",typeof(string)),
                new DataColumn("Formato",typeof(string)),
                new DataColumn("Objetivo",typeof(string)),
                new DataColumn("Resultado",typeof(string)),
                new DataColumn("Color",typeof(string))
                });
            List<Color> sysColors = new List<Color>();

            for (int i = 0; i < resultados.Count;i++ )
            {
                int kpi = 0;
                int nombres = 1;
                int formato = 2;
                int objetivo = 3;
                int resul = 4;
                int semaforos = 5;
                for (int j = 0; j < (resultados[0].Count / 6); j++)
                {
                    tablaResultadosKPI.Rows.Add(resultados[i][kpi], resultados[i][nombres], resultados[i][formato], resultados[i][objetivo], resultados[i][resul], "            ");

                    switch (resultados[i][semaforos])
                    {
                        case "verde":
                            sysColors.Add(Color.Green);
                        break;
                        case "amarillo":
                            sysColors.Add(Color.Yellow);
                            break;
                          case "rojo":
                            sysColors.Add(Color.Red);
                            break;
                    }


                    kpi += 6;
                    nombres += 6;
                    resul += 6;
                    semaforos += 6;
                    objetivo += 6;
                    formato += 6;
                }

            }
            Session["resultadosKPI"] = tablaResultadosKPI;
            bindData();
            for (int i = 0;i<sysColors.Count;i++)
            {
                dtgResultadosKPI.Rows[i].Cells[5].BackColor = sysColors[i];
            }
        }

    }
}