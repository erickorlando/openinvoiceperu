using System;
using System.Collections.Generic;
using System.Linq;
using OpenInvoicePeru.Comun;
using OpenInvoicePeru.Comun.Dto.Contratos;
using OpenInvoicePeru.Comun.Dto.Modelos;
using OpenInvoicePeru.Estructuras.CommonAggregateComponents;
using OpenInvoicePeru.Estructuras.CommonBasicComponents;
using OpenInvoicePeru.Estructuras.EstandarUbl;

namespace OpenInvoicePeru.Xml
{
    public class NotaDebitoXml : IDocumentoXml
    {
        IEstructuraXml IDocumentoXml.Generar(IDocumentoElectronico request)
        {
            var documento = (DocumentoElectronico)request;
            documento.MontoEnLetras = Conversion.Enletras(documento.TotalVenta);
            var debitNote = new DebitNote
            {
                Id = documento.IdDocumento,
                IssueDate = DateTime.Parse(documento.FechaEmision),
                DocumentCurrencyCode = documento.Moneda,
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
                AccountingSupplierParty = new AccountingSupplierParty
                {
                    PartyTaxScheme = new PartyTaxScheme
                    {
                        RegistrationName = documento.Emisor.NombreLegal,
                        CompanyId = new CompanyId
                        {
                            SchemeId = documento.Emisor.TipoDocumento,
                            Value = documento.Emisor.NroDocumento
                        }
                    },
                    Party = new Party
                    {
                        PartyName = new PartyName
                        {
                            Name = documento.Emisor.NombreComercial
                        },
                        PartyLegalEntity = new PartyLegalEntity
                        {
                            RegistrationAddress = new RegistrationAddress
                            {
                                AddressTypeCode = documento.Emisor.CodigoAnexo
                            }
                        }
                    }
                },
                AccountingCustomerParty = new AccountingSupplierParty
                {
                    PartyTaxScheme = new PartyTaxScheme
                    {
                        RegistrationName = documento.Receptor.NombreLegal,
                        CompanyId = new CompanyId
                        {
                            SchemeId = documento.Receptor.TipoDocumento,
                            Value = documento.Receptor.NroDocumento
                        }
                    }
                },
                RequestedMonetaryTotal = new LegalMonetaryTotal
                {
                    PayableAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.TotalVenta
                    },
                    AllowanceTotalAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.DescuentoGlobal
                    }
                },
                TaxTotals = new List<TaxTotal>
                {
                    new TaxTotal
                    {
                        TaxAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.TotalIgv
                        },
                    }
                }
            };

            if (documento.TotalIgv > 0)
            {
                debitNote.TaxTotals.First().TaxSubTotals.AddRange(CalculoTotales.AgregarSubTotalCabecera(new TotalesDto
                {
                    CurrencyId = documento.Moneda,
                    Monto = documento.TotalIgv,
                    MontoBase = documento.Gravadas,
                    CategoryId = "S",
                    TaxSchemeId = "1000",
                    Name = "IGV",
                    TaxTypeCode = "VAT"
                }));
            }


            if (documento.Inafectas > 0)
            {
                debitNote.TaxTotals.First().TaxSubTotals.AddRange(CalculoTotales.AgregarSubTotalCabecera(new TotalesDto
                {
                    CurrencyId = documento.Moneda,
                    Monto = 0,
                    MontoBase = documento.Inafectas,
                    CategoryId = "O",
                    TaxSchemeId = "9998",
                    Name = "INA",
                    TaxTypeCode = "FRE"
                }));
            }

            if (documento.Exoneradas > 0)
            {
                debitNote.TaxTotals.First().TaxSubTotals.AddRange(CalculoTotales.AgregarSubTotalCabecera(new TotalesDto
                {
                    CurrencyId = documento.Moneda,
                    Monto = 0,
                    MontoBase = documento.Exoneradas,
                    CategoryId = "E",
                    TaxSchemeId = "9997",
                    Name = "EXO",
                    TaxTypeCode = "VAT"
                }));
            }

            if (documento.Gratuitas > 0)
            {
                debitNote.TaxTotals.First().TaxSubTotals.AddRange(CalculoTotales.AgregarSubTotalCabecera(new TotalesDto
                {
                    CurrencyId = documento.Moneda,
                    Monto = 0,
                    MontoBase = documento.Gratuitas,
                    CategoryId = "Z",
                    TaxSchemeId = "9996",
                    Name = "GRA",
                    TaxTypeCode = "FRE"
                }));
            }

            if (documento.Exportacion > 0)
            {
                debitNote.TaxTotals.First().TaxSubTotals.AddRange(CalculoTotales.AgregarSubTotalCabecera(new TotalesDto
                {
                    CurrencyId = documento.Moneda,
                    Monto = 0,
                    MontoBase = documento.Exportacion,
                    CategoryId = "",
                    TaxSchemeId = "9995",
                    Name = "EXP",
                    TaxTypeCode = "FRE"
                }));
            }

            if (!string.IsNullOrEmpty(documento.FechaVencimiento))
                debitNote.DueDate = DateTime.Parse(documento.FechaVencimiento);

            if (documento.TotalIsc > 0)
            {
                debitNote.TaxTotals.First().TaxSubTotals.AddRange(CalculoTotales.AgregarSubTotalCabecera(new TotalesDto
                {
                    CurrencyId = documento.Moneda,
                    Monto = documento.TotalIsc,
                    MontoBase = documento.Gravadas,
                    CategoryId = "S",
                    TaxSchemeId = "2000",
                    Name = "ISC",
                    TaxTypeCode = "EXC"
                }));
            }
            if (documento.TotalOtrosTributos > 0)
            {
                debitNote.TaxTotals.First().TaxSubTotals.AddRange(CalculoTotales.AgregarSubTotalCabecera(new TotalesDto
                {
                    CurrencyId = documento.Moneda,
                    Monto = documento.TotalIsc,
                    MontoBase = documento.Gravadas,
                    CategoryId = "S",
                    TaxSchemeId = "7152",
                    Name = "ICBPER",
                    TaxTypeCode = "OTH"
                }));
            }

            if (!string.IsNullOrEmpty(documento.FechaVencimiento))
                debitNote.DueDate = DateTime.Parse(documento.FechaVencimiento);

            foreach (var discrepancia in documento.Discrepancias)
            {
                debitNote.DiscrepancyResponses.Add(new DiscrepancyResponse
                {
                    ReferenceId = discrepancia.NroReferencia,
                    ResponseCode = discrepancia.Tipo,
                    Description = discrepancia.Descripcion
                });
            }

            foreach (var relacionado in documento.Relacionados)
            {
                debitNote.BillingReferences.Add(new BillingReference
                {
                    InvoiceDocumentReference = new InvoiceDocumentReference
                    {
                        Id = relacionado.NroDocumento,
                        DocumentTypeCode = relacionado.TipoDocumento
                    }
                });
            }

            foreach (var relacionado in documento.OtrosDocumentosRelacionados)
            {
                debitNote.AdditionalDocumentReferences.Add(new InvoiceDocumentReference
                {
                    DocumentTypeCode = relacionado.TipoDocumento,
                    Id = relacionado.NroDocumento
                });
            }

            foreach (var detalleDocumento in documento.Items)
            {
                var linea = new InvoiceLine
                {
                    Id = detalleDocumento.Id,
                    DebitedQuantity = new InvoicedQuantity
                    {
                        UnitCode = detalleDocumento.UnidadMedida,
                        Value = detalleDocumento.Cantidad
                    },
                    LineExtensionAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = detalleDocumento.TotalVenta
                    },
                    PricingReference = new PricingReference
                    {
                        AlternativeConditionPrices = new List<AlternativeConditionPrice>()
                    },
                    Item = new Item
                    {
                        Description = detalleDocumento.Descripcion,
                        SellersItemIdentification = new SellersItemIdentification
                        {
                            Id = detalleDocumento.CodigoItem
                        }
                    },
                    Price = new Price
                    {
                        PriceAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = detalleDocumento.PrecioUnitario
                        }
                    },
                };
                linea.PricingReference.AlternativeConditionPrices.Add(new AlternativeConditionPrice
                {
                    PriceAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        // Comprobamos que sea una operacion gratuita.
                        Value = documento.Gratuitas > 0 ? 0 : detalleDocumento.PrecioReferencial
                    },
                    PriceTypeCode = detalleDocumento.TipoPrecio
                });
                /* 16 - Afectación al IGV por ítem */
                linea.TaxTotals.Add(new TaxTotal
                {
                    TaxAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = detalleDocumento.Impuesto
                    },
                    TaxSubTotals = CalculoTotales.AgregarSubTotalDetalles(new TotalesDto
                    {
                        CurrencyId = documento.Moneda,
                        Monto = detalleDocumento.Impuesto,
                        CategoryId = AfectacionImpuesto.ObtenerLetraTributo(detalleDocumento.TipoImpuesto),
                        TaxPercent = AfectacionImpuesto.ObtenerTasa(detalleDocumento.TipoImpuesto),
                        TaxExemptionReasonCode = detalleDocumento.TipoImpuesto,
                        TaxSchemeId = AfectacionImpuesto.ObtenerCodigoTributo(detalleDocumento.TipoImpuesto),
                        Name = AfectacionImpuesto.ObtenerDescripcionTributo(detalleDocumento.TipoImpuesto),
                        TaxTypeCode = AfectacionImpuesto.ObtenerCodigoInternacionalTributo(detalleDocumento.TipoImpuesto)
                    })
                });

                if (detalleDocumento.Descuento > 0)
                {
                    linea.AllowanceCharge.ChargeIndicator = false;
                    linea.AllowanceCharge.ReasonCode = "00";
                    linea.AllowanceCharge.Amount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = detalleDocumento.Descuento
                    };
                }

                debitNote.DebitNoteLines.Add(linea);
            }

            return debitNote;
        }
    }
}