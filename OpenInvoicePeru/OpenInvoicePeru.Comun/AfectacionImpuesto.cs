using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenInvoicePeru.Comun
{
    public class AfectacionImpuesto
    {
        public static decimal ObtenerTasa(string tipoImpuesto)
        {
            decimal tasa;
            switch (tipoImpuesto)
            {
                case "10":
                    tasa = 18.00m;
                    break;
                case "20":
                    tasa = 0.00m;
                    break;
                case "21":
                    tasa = 0.00m;
                    break;
                default:
                    tasa = 18.00m;
                    break;
            }

            return tasa;
        }

        public static string ObtenerCodigoTributo(string tipoImpuesto)
        {
            string codigoTributo;
            switch (tipoImpuesto)
            {
                case "10":
                    codigoTributo = "1000";
                    break;
                case "20":
                    codigoTributo = "9997";
                    break;
                case "21":
                    codigoTributo = "9996";
                    break;
                default:
                    codigoTributo = "1000";
                    break;
            }

            return codigoTributo;
        }

        public static string ObtenerDescripcionTributo(string tipoImpuesto)
        {
            string descripcionTributo;
            switch (tipoImpuesto)
            {
                case "10":
                    descripcionTributo = "IGV";
                    break;
                case "20":
                    descripcionTributo = "EXO";
                    break;
                case "21":
                    descripcionTributo = "GRA";
                    break;
                default:
                    descripcionTributo = "IGV";
                    break;
            }

            return descripcionTributo;
        }

        public static string ObtenerCodigoTipoTributo(string tipoImpuesto)
        {
            string descripcionTributo;
            switch (tipoImpuesto)
            {
                case "10":
                    descripcionTributo = "VAT";
                    break;
                case "20":
                    descripcionTributo = "VAT";
                    break;
                case "21":
                    descripcionTributo = "FRE";
                    break;
                default:
                    descripcionTributo = "VAT";
                    break;
            }

            return descripcionTributo;
        }
    }
}
