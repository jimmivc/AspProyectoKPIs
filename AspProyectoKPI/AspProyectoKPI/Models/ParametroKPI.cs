using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProyectoKPI.Models
{
    public class ParametroKPI
    {
        public ParametroKPI()
        {

        }
        public ParametroKPI(int inf, int sup)
        {
            LimiteInferior = inf;
            LimiteSuperior = sup;
        }

        public int ParametroKPIID { get; set; }

        public int LimiteSuperior { get; set; }
        public int LimiteInferior { get; set; }
        
    }
}