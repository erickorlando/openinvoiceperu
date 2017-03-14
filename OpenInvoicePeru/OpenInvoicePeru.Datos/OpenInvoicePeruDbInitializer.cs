using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using OpenInvoicePeru.Entidades;
using SQLite.CodeFirst;

namespace OpenInvoicePeru.Datos
{
    public class OpenInvoicePeruDbInitializer : SqliteDropCreateDatabaseAlways<OpenInvoicePeruDb>
    {
        public OpenInvoicePeruDbInitializer(DbModelBuilder modelBuilder)
            : base(modelBuilder)
        {

        }

        protected override void Seed(OpenInvoicePeruDb context)
        {
            var separador = '|';
            var carpeta = @".\Data\";

            var direccionesSunat = File.ReadAllLines($"{carpeta}DireccionesSunat.txt");
            context.DireccionesSunat.AddOrUpdate(direccionesSunat.Select(linea => linea.Split(separador))
                .Select(valores => new DireccionSunat
                {
                    Codigo = valores.First(),
                    Descripcion = valores.Last()
                }).ToArray());

            var monedas = File.ReadAllLines($"{carpeta}Monedas.txt");
            context.Monedas.AddOrUpdate(monedas.Select(linea => linea.Split(separador))
                .Select(valores => new Moneda
                {
                    Codigo = valores.First(),
                    Descripcion = valores.Last()
                }).ToArray());

            var modalidadTransportes = File.ReadAllLines($"{carpeta}ModalidadTransportes.txt");
            context.ModalidadTransportes.AddOrUpdate(modalidadTransportes.Select(linea => linea.Split(separador))
                .Select(valores => new ModalidadTransporte
                {
                    Codigo = valores.First(),
                    Descripcion = valores.Last()
                }).ToArray());

            var tipoDatoAdicionales = File.ReadAllLines($"{carpeta}TipoDatoAdicionales.txt");
            context.TipoDatoAdicionales.AddOrUpdate(tipoDatoAdicionales.Select(linea => linea.Split(separador))
                .Select(valores => new TipoDatoAdicional
                {
                    Codigo = valores.First(),
                    Descripcion = valores.Last()
                }).ToArray());

            var tipoDiscrepancias = File.ReadAllLines($"{carpeta}TipoDiscrepancias.txt");
            context.TipoDiscrepancias.AddOrUpdate(tipoDiscrepancias.Select(linea => linea.Split(separador))
                .Select(valores => new TipoDiscrepancia
                {
                    Codigo = valores.First(),
                    Descripcion = valores[1],
                    IdTipoDocumento = Convert.ToInt32(valores.Last())
                }).ToArray());

            var tipoDocumentoAnticipos = File.ReadAllLines($"{carpeta}TipoDocumentoAnticipos.txt");
            context.TipoDocumentoAnticipos.AddOrUpdate(tipoDocumentoAnticipos.Select(linea => linea.Split(separador))
                .Select(valores => new TipoDocumentoAnticipo
                {
                    Codigo = valores.First(),
                    Descripcion = valores.Last()
                }).ToArray());

            var tipoDocumentoContribuyentes = File.ReadAllLines($"{carpeta}TipoDocumentoContribuyentes.txt");
            context.TipoDocumentoContribuyentes.AddOrUpdate(tipoDocumentoContribuyentes.Select(linea => linea.Split(separador))
                .Select(valores => new TipoDocumentoContribuyente
                {
                    Codigo = valores.First(),
                    Descripcion = valores.Last()
                }).ToArray());

            var tipoDocumentoRelacionados = File.ReadAllLines($"{carpeta}TipoDocumentoRelacionados.txt");
            context.TipoDocumentoRelacionados.AddOrUpdate(tipoDocumentoRelacionados.Select(linea => linea.Split(separador))
                .Select(valores => new TipoDocumentoRelacionado
                {
                    Codigo = valores.First(),
                    Descripcion = valores.Last()
                }).ToArray());

            var tipoDocumentos = File.ReadAllLines($"{carpeta}TipoDocumentos.txt");
            context.TipoDocumentos.AddOrUpdate(tipoDocumentos.Select(linea => linea.Split(separador))
                .Select(valores => new TipoDocumento
                {
                    Codigo = valores.First(),
                    Descripcion = valores.Last()
                }).ToArray());

            var tipoImpuestos = File.ReadAllLines($"{carpeta}TipoImpuestos.txt");
            context.TipoImpuestos.AddOrUpdate(tipoImpuestos.Select(linea => linea.Split(separador))
                .Select(valores => new TipoImpuesto
                {
                    Codigo = valores.First(),
                    Descripcion = valores.Last()
                }).ToArray());

            var tipoOperaciones = File.ReadAllLines($"{carpeta}TipoOperaciones.txt");
            context.TipoOperaciones.AddOrUpdate(tipoOperaciones.Select(linea => linea.Split(separador))
                .Select(valores => new TipoOperacion
                {
                    Codigo = valores.First(),
                    Descripcion = valores.Last()
                }).ToArray());

            var tipoPrecios = File.ReadAllLines($"{carpeta}TipoPrecios.txt");
            context.TipoPrecios.AddOrUpdate(tipoPrecios.Select(linea => linea.Split(separador))
                .Select(valores => new TipoPrecio
                {
                    Codigo = valores.First(),
                    Descripcion = valores.Last()
                }).ToArray());

        }
    }
}
