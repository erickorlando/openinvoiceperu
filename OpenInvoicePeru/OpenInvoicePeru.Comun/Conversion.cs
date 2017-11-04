using System;

namespace OpenInvoicePeru.Comun
{
    public class Conversion
    {
        private const int Millon = 1000000;
        private const long Billon = 1000000000000;

        public static string Enletras(decimal num)
        {
            var entero = Convert.ToInt64(Math.Truncate(num));
            var decimales = Convert.ToInt32(Math.Round((num - entero) * 100, 2));
            var dec = decimales > 0 ? $" CON {decimales}/100" : " CON 00/100";

            var res = ToText(entero) + dec;
            return res;
        }

        private static string ToText(decimal value)
        {
            string num2Text;
            value = Math.Truncate(value);
            if (value == 0) num2Text = "CERO";
            else if (value == 1) num2Text = "UNO";
            else if (value == 2) num2Text = "DOS";
            else if (value == 3) num2Text = "TRES";
            else if (value == 4) num2Text = "CUATRO";
            else if (value == 5) num2Text = "CINCO";
            else if (value == 6) num2Text = "SEIS";
            else if (value == 7) num2Text = "SIETE";
            else if (value == 8) num2Text = "OCHO";
            else if (value == 9) num2Text = "NUEVE";
            else if (value == 10) num2Text = "DIEZ";
            else if (value == 11) num2Text = "ONCE";
            else if (value == 12) num2Text = "DOCE";
            else if (value == 13) num2Text = "TRECE";
            else if (value == 14) num2Text = "CATORCE";
            else if (value == 15) num2Text = "QUINCE";
            else if (value < 20) num2Text = $"DIECI{ToText(value - 10)}";
            else if (value == 20) num2Text = "VEINTE";
            else if (value < 30) num2Text = $"VEINTI{ToText(value - 20)}";
            else if (value == 30) num2Text = "TREINTA";
            else if (value == 40) num2Text = "CUARENTA";
            else if (value == 50) num2Text = "CINCUENTA";
            else if (value == 60) num2Text = "SESENTA";
            else if (value == 70) num2Text = "SETENTA";
            else if (value == 80) num2Text = "OCHENTA";
            else if (value == 90) num2Text = "NOVENTA";
            else if (value < 100) num2Text = $"{ToText(Math.Truncate(value / 10) * 10)} Y {ToText(value % 10)}";
            else if (value == 100) num2Text = "CIEN";
            else if (value < 200) num2Text = $"CIENTO {ToText(value - 100)}";
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) num2Text =
                $"{ToText(Math.Truncate(value / 100))}CIENTOS";
            else if (value == 500) num2Text = "QUINIENTOS";
            else if (value == 700) num2Text = "SETECIENTOS";
            else if (value == 900) num2Text = "NOVECIENTOS";
            else if (value < 1000) num2Text = $"{ToText(Math.Truncate(value / 100) * 100)} {ToText(value % 100)}";
            else if (value == 1000) num2Text = "MIL";
            else if (value < 2000) num2Text = $"MIL {ToText(value % 1000)}";
            else if (value < Millon)
            {
                num2Text = $"{ToText(Math.Truncate(value / 1000))} MIL";
                if ((value % 1000) > 0) num2Text = $"{num2Text} {ToText(value % 1000)}";
            }

            else if (value == Millon) num2Text = "UN MILLON";
            else if (value < 2000000) num2Text = $"UN MILLON {ToText(value % Millon)}";
            else if (value < Billon)
            {
                num2Text = $"{ToText(Math.Truncate(value / Millon))} MILLONES ";
                if ((value - Math.Truncate(value / Millon) * Millon) > 0) num2Text =
                    $"{num2Text} {ToText(value - Math.Truncate(value / Millon) * Millon)}";
            }

            else if (value == Billon) num2Text = "UN BILLON";
            else if (value < 2000000000000) num2Text =
                $"UN BILLON {ToText(value - Math.Truncate(value / Billon) * Billon)}";

            else
            {
                num2Text = $"{ToText(Math.Truncate(value / Billon))} BILLONES";
                if ((value - Math.Truncate(value / Billon) * Billon) > 0) num2Text =
                    $"{num2Text} {ToText(value - Math.Truncate(value / Billon) * Billon)}";
            }
            return num2Text;

        }
    }
}
