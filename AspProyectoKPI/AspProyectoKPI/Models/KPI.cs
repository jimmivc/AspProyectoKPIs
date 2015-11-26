using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProyectoKPI.Models
{
    public class KPI
    {
        public KPI()
        {
        }

        public KPI(int id,string desc, string format, double objetive, string period, ParametroKPI param, List<DetalleFormula> form)
        {
            KPIID = id;
            DescKpi = desc;
            Formato = format;
            Objetivo = objetive;
            Periodicidad = period;
            Parametro = param;
            Formula = form;
        }

        public int KPIID { get; set; }
        public string DescKpi { get; set; }
        public string Formato { get; set; }
        public double Objetivo { get; set; }
        public bool Estado { get; set; }
        public string Periodicidad{ get; set; }

        public ParametroKPI Parametro { get; set; }
        public List<DetalleFormula> Formula { get; set; }
    }
}