namespace OpenInvoicePeru.Comun
{
    public class AfectacionImpuesto
    {

        public static string ObtenerLetraTributo(string tipoImpuesto)
        {
            string letra;
            switch (tipoImpuesto)
            {
                case "10":
                case "11":
                case "12":
                case "13":
                case "14":
                case "15":
                case "16":
                case "17": //Gravado - Operación Onerosa
                    letra = "S";
                    break;
                case "20":
                case "21": //Exonerado - Operación Onerosa 
                    letra = "E";
                    break;
                case "30":
                case "31":
                case "32":
                case "33":
                case "34":
                case "35":
                case "36": //Inafecto - Operación Onerosa
                    letra = "O";
                    break;
                case "40": //Exportación de bienes o servicios
                    letra = "";
                    break;
                default:
                    letra = "S";
                    break;
            }
            return letra;
        }

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
                case "11":
                case "12":
                case "13":
                case "14":
                case "15":
                case "16":
                case "17": //Gravado - Operación Onerosa
                    codigoTributo = "1000";
                    break;
                case "20":
                    codigoTributo = "9997";
                    break;
                case "21": //Exonerado - Operación Onerosa 
                    codigoTributo = "9996";
                    break;
                case "30":
                case "31":
                case "32":
                case "33":
                case "34":
                case "35":
                case "36": //Inafecto - Operación Onerosa
                    codigoTributo = "9998";
                    break;
                case "40": //Exportación de bienes o servicios
                    codigoTributo = "9995";
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
                case "11":
                case "12":
                case "13":
                case "14":
                case "15":
                case "16":
                case "17": //Gravado - Operación Onerosa
                    descripcionTributo = "IGV";
                    break;
                case "20":
                    descripcionTributo = "EXO";
                    break;
                case "21": //Exonerado - Operación Onerosa 
                    descripcionTributo = "GRA";
                    break;
                case "30":
                case "31":
                case "32":
                case "33":
                case "34":
                case "35":
                case "36": //Inafecto - Operación Onerosa
                    descripcionTributo = "INA";
                    break;
                case "40": //Exportación de bienes o servicios
                    descripcionTributo = "EXP";
                    break;
                default:
                    descripcionTributo = "IGV";
                    break;
            }

            return descripcionTributo;
        }


        public static string ObtenerCodigoInternacionalTributo(string tipoImpuesto)
        {
            string descripcionTributo;
            switch (tipoImpuesto)
            {
                case "10":
                case "11":
                case "12":
                case "13":
                case "14":
                case "15":
                case "16":
                case "17": //Gravado - Operación Onerosa
                    descripcionTributo = "VAT";
                    break;
                case "20": //Exonerado - Operación Onerosa 
                    descripcionTributo = "VAT";
                    break;
                case "21": 
                    descripcionTributo = "FRE";
                    break;
                case "30":
                case "31":
                case "32":
                case "33":
                case "34":
                case "35":
                case "36": //Inafecto - Operación Onerosa
                    descripcionTributo = "FRE";
                    break;
                case "40": //Exportación de bienes o servicios
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
