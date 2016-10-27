using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenInvoicePeruApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenInvoicePeru.Firmado.Models;

namespace OpenInvoicePeruApi.Controllers.Tests
{
    [TestClass()]
    public class SendBillControllerTests
    {
        [TestMethod()]
        public void PostTest()
        {
            var enviarDocumentoRequest = new EnviarDocumentoRequest
            {
                Ruc = "20382567855",
                UsuarioSol = "MODDATOS",
                ClaveSol = "MODDATOS",
                EndPointUrl = "http://sunat.gob.pe",
                IdDocumento = "FF11-150",
                TipoDocumento = "01",
                TramaXmlFirmado = "PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iSVNPLTg4NTktMSIgc3RhbmRhbG9uZT0ibm8iPz4NCjxJbnZvaWNlIHhtbG5zPSJ1cm46b2FzaXM6bmFtZXM6c3BlY2lmaWNhdGlvbjp1Ymw6c2NoZW1hOnhzZDpJbnZvaWNlLTIiIHhtbG5zOmNhYz0idXJuOm9hc2lzOm5hbWVzOnNwZWNpZmljYXRpb246dWJsOnNjaGVtYTp4c2Q6Q29tbW9uQWdncmVnYXRlQ29tcG9uZW50cy0yIiB4bWxuczpjYmM9InVybjpvYXNpczpuYW1lczpzcGVjaWZpY2F0aW9uOnVibDpzY2hlbWE6eHNkOkNvbW1vbkJhc2ljQ29tcG9uZW50cy0yIiB4bWxuczpjY3RzPSJ1cm46dW46dW5lY2U6dW5jZWZhY3Q6ZG9jdW1lbnRhdGlvbjoyIiB4bWxuczpkcz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC8wOS94bWxkc2lnIyIgeG1sbnM6ZXh0PSJ1cm46b2FzaXM6bmFtZXM6c3BlY2lmaWNhdGlvbjp1Ymw6c2NoZW1hOnhzZDpDb21tb25FeHRlbnNpb25Db21wb25lbnRzLTIiIHhtbG5zOnFkdD0idXJuOm9hc2lzOm5hbWVzOnNwZWNpZmljYXRpb246dWJsOnNjaGVtYTp4c2Q6UXVhbGlmaWVkRGF0YXR5cGVzLTIiIHhtbG5zOnNhYz0idXJuOnN1bmF0Om5hbWVzOnNwZWNpZmljYXRpb246dWJsOnBlcnU6c2NoZW1hOnhzZDpTdW5hdEFnZ3JlZ2F0ZUNvbXBvbmVudHMtMSIgeG1sbnM6dWR0PSJ1cm46dW46dW5lY2U6dW5jZWZhY3Q6ZGF0YTpzcGVjaWZpY2F0aW9uOlVucXVhbGlmaWVkRGF0YVR5cGVzU2NoZW1hTW9kdWxlOjIiIHhtbG5zOnhzaT0iaHR0cDovL3d3dy53My5vcmcvMjAwMS9YTUxTY2hlbWEtaW5zdGFuY2UiPg0KCTxleHQ6VUJMRXh0ZW5zaW9ucz4NCgkJPGV4dDpVQkxFeHRlbnNpb24+DQoJCQk8ZXh0OkV4dGVuc2lvbkNvbnRlbnQ+DQoJCQkJPHNhYzpBZGRpdGlvbmFsSW5mb3JtYXRpb24+DQoJCQkJCTxzYWM6QWRkaXRpb25hbE1vbmV0YXJ5VG90YWw"
            };
            Assert.Fail();
        }
    }
}