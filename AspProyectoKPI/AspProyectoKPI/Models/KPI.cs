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

        public int KPIID { get; set; }
        public string DescKpi { get; set; }
        public string Formato { get; set; }
        public double Objetivo { get; set; }
        public bool Estado { get; set; }
        public string Peridiocidad{ get; set; }

        public ParametroKPI Parametro { get; set; }
        public List<DetalleFormula> Formula { get; set; }
    }
}