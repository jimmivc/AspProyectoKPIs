using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProyectoKPI.Models
{
    public class Plantilla
    {
        public Plantilla()
        {

        }

        public Plantilla(int pId, string pDesc) {
            PlantillaID = pId;
            DescripcionPlantilla = pDesc;
        }

        public int PlantillaID { get; set; }
        public string DescripcionPlantilla { get; set; }
    }
}