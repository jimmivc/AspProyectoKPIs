using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProyectoKPI.Models
{
    public class PlantillaDetalle
    {
        public PlantillaDetalle()
        {

        }

        public PlantillaDetalle(int pID, Plantilla pPlantilla, Pregunta pPregunta) {
            PlantillaDetalleID = pID;
            Plantilla = pPlantilla;
            Pregunta = pPregunta;
        }

        public int PlantillaDetalleID { get; set; }
        public Plantilla Plantilla { get; set; }
        public Pregunta Pregunta { get; set; }
    }
}