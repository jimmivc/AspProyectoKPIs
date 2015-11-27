using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProyectoKPI.Models
{
    public class DetalleFormula
    {
        public DetalleFormula()
        {

        }

        public DetalleFormula(int consecutivo, string tipo, string dato)
        {
            Consecutivo = consecutivo;
            TipoDato = tipo;
            if (tipo.Equals("campo"))
            {
                Tabla = dato;
            }
            else if (tipo.Equals("operador"))
            {
                DescCampoOperador = dato;
            }
            else if (tipo.Equals("valor"))
            {
                Valor = Convert.ToDouble(dato);
            }
        }

        public int DetalleFormulaID { get; set; }

        public int Consecutivo { get; set; }

        public string TipoDato { get; set; }

        public string Tabla { get; set; }
        public string DescCampoOperador { get; set; }
        public double Valor { get; set; }
        public KPI KPI { get; set; }
    }
}