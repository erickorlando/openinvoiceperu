using OpenInvoicePeru.RestService;
using OpenInvoicePeru.RestService.ApiSunatDto;
using System;
using System.Linq;

namespace PruebaConexion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prueba de conexion");

            var helper = new ValidezComprobanteHelper();

            var response = helper.GenerarToken("d6123ad3-26aa-4632-9871-424ed0483892",
                "ZwDJQTCBxzKBUw2IUhfSpw==");

            Console.WriteLine(response.Success
                ? $"Token: {response.Result.AccessToken}" : response.ErrorMessage);

            var responseValidacion = helper.Validar("20541144278", response.Result.AccessToken,
                new ValidacionRequest
                {
                    RucEmisor = "20493654463",
                    CodigoComprobante = "01",
                    NumeroSerie = "F004",
                    Numero = 34275,
                    FechaEmision = "02/09/2021",
                    Monto = 222.64M
                });

            Console.WriteLine(responseValidacion.Success
                ? $"Comprobante => {responseValidacion.Data.EstadoComprobante}"
                : responseValidacion.Message);

            if (responseValidacion.Success && responseValidacion.Data.Observaciones != null)
            {
                var observaciones = responseValidacion.Data.Observaciones
                    .SelectMany(x => x)
                    .Select(x => x);

                var message = string.Join(";", observaciones);

                Console.WriteLine($"Observaciones: {message}");
            }

            Console.ReadLine();
        }
    }
}
