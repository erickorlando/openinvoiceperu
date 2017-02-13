using OpenInvoicePeru.Comun;
using OpenInvoicePeru.Comun.Dto.Contratos;
using OpenInvoicePeru.Comun.Dto.Modelos;
using OpenInvoicePeru.Estructuras.CommonAggregateComponents;
using OpenInvoicePeru.Estructuras.CommonBasicComponents;
using OpenInvoicePeru.Estructuras.EstandarUbl;
using OpenInvoicePeru.Estructuras.SunatAggregateComponents;

namespace OpenInvoicePeru.Xml
{
    public class PercepcionXml : IDocumentoXml
    {
        IEstructuraXml IDocumentoXml.Generar(IDocumentoElectronico request)
        {
            var documento = (DocumentoPercepcion)request;
            var perception = new Perception
            {
                Id = documento.IdDocumento,
                IssueDate = documento.FechaEmision,
                Signature = new SignatureCac
                {
                    Id = documento.IdDocumento,
                    SignatoryParty = new SignatoryParty
                    {
                        PartyIdentification = new PartyIdentification
                        {
                            Id = new PartyIdentificationId
                            {
                                Value = documento.Emisor.NroDocumento
                            }
                        },
                        PartyName = new PartyName
                        {
                            Name = documento.Emisor.NombreLegal
                        }
                    },
                    DigitalSignatureAttachment = new DigitalSignatureAttachment
                    {
                        ExternalReference = new ExternalReference
                        {
                            Uri = $"{documento.Emisor.NroDocumento}-{documento.IdDocumento}"
                        }
                    }
                },
                AgentParty = new AgentParty
                {
                    PartyIdentification = new PartyIdentification
                    {
                        Id = new PartyIdentificationId
                        {
                            SchemeId = documento.Emisor.TipoDocumento,
                            Value = documento.Emisor.NroDocumento
                        }
                    },
                    PartyName = new PartyName
                    {
                        Name = documento.Emisor.NombreComercial
                    },
                    PostalAddress = new PostalAddress
                    {
                        Id = documento.Emisor.Ubigeo,
                        StreetName = documento.Emisor.Direccion,
                        CitySubdivisionName = documento.Emisor.Urbanizacion,
                        CountrySubentity = documento.Emisor.Departamento,
                        CityName = documento.Emisor.Provincia,
                        District = documento.Emisor.Distrito,
                        Country = new Country { IdentificationCode = "PE" }
                    },
                    PartyLegalEntity = new PartyLegalEntity
                    {
                        RegistrationName = documento.Emisor.NombreLegal
                    }
                },
                ReceiverParty = new AgentParty
                {
                    PartyIdentification = new PartyIdentification
                    {
                        Id = new PartyIdentificationId
                        {
                            SchemeId = documento.Emisor.TipoDocumento,
                            Value = documento.Emisor.NroDocumento
                        }
                    },
                    PartyName = new PartyName
                    {
                        Name = documento.Emisor.NombreComercial
                    },
                    PostalAddress = new PostalAddress
                    {
                        Id = documento.Emisor.Ubigeo,
                        StreetName = documento.Emisor.Direccion,
                        CitySubdivisionName = documento.Emisor.Urbanizacion,
                        CountrySubentity = documento.Emisor.Departamento,
                        CityName = documento.Emisor.Provincia,
                        District = documento.Emisor.Distrito,
                        Country = new Country { IdentificationCode = "PE" }
                    },
                    PartyLegalEntity = new PartyLegalEntity
                    {
                        RegistrationName = documento.Emisor.NombreLegal
                    }
                },
                SunatPerceptionSystemCode = documento.RegimenPercepcion,
                SunatPerceptionPercent = documento.TasaPercepcion,
                Note = documento.Observaciones,
                TotalInvoiceAmount = new PayableAmount
                {
                    CurrencyId = documento.Moneda,
                    Value = documento.ImporteTotalPercibido
                },
                TotalPaid = new PayableAmount
                {
                    CurrencyId = documento.Moneda,
                    Value = documento.ImporteTotalCobrado
                }
            };

            foreach (var relacionado in documento.DocumentosRelacionados)
            {
                perception.SunatPerceptionDocumentReference.Add(new SunatRetentionDocumentReference
                {
                    Id = new PartyIdentificationId
                    {
                        SchemeId = relacionado.TipoDocumento,
                        Value = relacionado.NroDocumento
                    },
                    IssueDate = relacionado.FechaEmision,
                    TotalInvoiceAmount = new PayableAmount
                    {
                        CurrencyId = relacionado.MonedaDocumentoRelacionado,
                        Value = relacionado.ImporteTotal
                    },
                    Payment = new Payment
                    {
                        IdPayment = relacionado.NumeroPago,
                        PaidAmount = new PayableAmount
                        {
                            CurrencyId = relacionado.MonedaDocumentoRelacionado,
                            Value = relacionado.ImporteSinPercepcion
                        },
                        PaidDate = relacionado.FechaPago
                    },
                    SunatRetentionInformation = new SunatRetentionInformation
                    {
                        SunatRetentionAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = relacionado.ImportePercibido
                        },
                        SunatRetentionDate = relacionado.FechaPercepcion,
                        SunatNetTotalPaid = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = relacionado.ImporteTotalNeto
                        },
                        ExchangeRate = new ExchangeRate
                        {
                            SourceCurrencyCode = relacionado.MonedaDocumentoRelacionado,
                            TargetCurrencyCode = documento.Moneda,
                            CalculationRate = relacionado.TipoCambio,
                            Date = relacionado.FechaTipoCambio
                        }
                    }
                });
            }

            return perception;
        }
    }
}