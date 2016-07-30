using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace OpenInvoicePeru.ApiClientCSharp
{
    class Program
    {
        private static string _baseUrl = "http://localhost:50888/OpenInvoicePeru/api";

        static void Main(string[] args)
        {
            Console.WriteLine("Prueba de API REST de OpenInvoicePeru");
            var client = new RestClient(_baseUrl);

            var request = new RestRequest("invoice", Method.POST);
            
        }
    }
}
