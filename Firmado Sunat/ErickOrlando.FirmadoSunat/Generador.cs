using System;
using System.Collections.Generic;
using OpenInvoicePeru.FirmadoSunat.Estructuras;
using OpenInvoicePeru.FirmadoSunat.Models;

namespace OpenInvoicePeru.FirmadoSunat
{
    public static class Generador
    {
        public static Invoice GenerarInvoice(DocumentoElectronico documento)
        {
            var invoice = new Invoice
            {
                UblExtensions = new UBLExtensions
                {
                    Extension2 = new UBLExtension
                    {
                        ExtensionContent = new ExtensionContent
                        {
                            AdditionalInformation = new AdditionalInformation
                            {
                                AdditionalMonetaryTotals = new List<AdditionalMonetaryTotal>()
                                {
                                    new AdditionalMonetaryTotal()
                                    {
                                        ID ="1001",
                                        PayableAmount = new PayableAmount()
                                        {
                                            currencyID = documento.Moneda,
                                            value = documento.Gravadas
                                        }
                                    },
                                    new AdditionalMonetaryTotal
                                    {
                                        ID = "1002",
                                        PayableAmount = new PayableAmount
                                        {
                                            currencyID = documento.Moneda,
                                            value = documento.Inafectas
                                        }
                                    },
                                    new AdditionalMonetaryTotal
                                    {
                                        ID = "1003",
                                        PayableAmount = new PayableAmount
                                        {
                                            currencyID = documento.Moneda,
                                            value = documento.Exoneradas
                                        }
                                    },
                                    new AdditionalMonetaryTotal
                                    {
                                        ID = "1004",
                                        PayableAmount = new PayableAmount
                                        {
                                            currencyID = documento.Moneda,
                                            value = documento.Gratuitas
                                        }
                                    }
                                },
                                AdditionalProperties = new List<AdditionalProperty>()
                                {
                                    new AdditionalProperty
                                    {
                                        ID = 1000,
                                        Value = documento.MontoEnLetras
                                    }
                                }
                            }
                        }
                    }
                },
                ID = documento.IdDocumento,
                IssueDate = DateTime.Parse(documento.FechaEmision),
                InvoiceTypeCode = documento.TipoDocumento,
                DocumentCurrencyCode = documento.Moneda,
                Signature = new SignatureCac
                {
                    ID = documento.IdDocumento,
                    SignatoryParty = new SignatoryParty
                    {
                        PartyIdentification = new PartyIdentification
                        {
                            ID = new PartyIdentificationID
                            {
                                value = documento.Emisor.NroDocumento
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
                            URI = string.Format("{0}-{1}", documento.Emisor.NroDocumento, documento.IdDocumento)
                        }
                    }
                },
                AccountingSupplierParty = new AccountingSupplierParty
                {
                    CustomerAssignedAccountID = documento.Emisor.NroDocumento,
                    AdditionalAccountID = documento.Emisor.TipoDocumento,
                    Party = new Party
                    {
                        PartyName = new PartyName
                        {
                            Name = documento.Emisor.NombreComercial
                        },
                        PostalAddress = new PostalAddress
                        {
                            ID = documento.Emisor.Ubigeo,
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
                    }
                },
                AccountingCustomerParty = new AccountingSupplierParty
                {
                    CustomerAssignedAccountID = documento.Receptor.NroDocumento,
                    AdditionalAccountID = documento.Receptor.TipoDocumento,
                    Party = new Party
                    {
                        PartyName = new PartyName
                        {
                            Name = documento.Receptor.NombreComercial
                        },
                        PostalAddress = new PostalAddress
                        {
                            ID = documento.Receptor.Ubigeo,
                            StreetName = documento.Receptor.Direccion,
                            CitySubdivisionName = documento.Receptor.Urbanizacion,
                            CountrySubentity = documento.Receptor.Departamento,
                            CityName = documento.Receptor.Provincia,
                            District = documento.Receptor.Distrito,
                            Country = new Country { IdentificationCode = "PE" }
                        },
                        PartyLegalEntity = new PartyLegalEntity
                        {
                            RegistrationName = documento.Receptor.NombreLegal
                        }
                    }
                },
                UblVersionId = "2.0",
                CustomizationId = "1.0",
                LegalMonetaryTotal = new LegalMonetaryTotal
                {
                    PayableAmount = new PayableAmount
                    {
                        currencyID = documento.Moneda,
                        value = documento.TotalVenta
                    },
                    AllowanceTotalAmount = new PayableAmount
                    {
                        currencyID = documento.Moneda,
                        value = documento.DescuentoGlobal
                    }
                },
                TaxTotals = new List<TaxTotal>
                {
                    new TaxTotal
                    {
                        TaxAmount = new PayableAmount
                        {
                            currencyID = documento.Moneda,
                            value = documento.TotalIgv
                        },
                        TaxSubtotal = new TaxSubtotal
                        {
                            TaxAmount = new PayableAmount
                            {
                                currencyID = documento.Moneda,
                                value = documento.TotalIgv,
                            },
                            TaxCategory = new TaxCategory
                            {
                                TaxScheme = new TaxScheme
                                {
                                    ID = "1000",
                                    Name = "IGV",
                                    TaxTypeCode = "VAT"
                                }
                            }
                        }
                    }
                }
            };
            if (documento.TotalIsc > 0)
            {
                invoice.TaxTotals.Add(new TaxTotal
                {
                    TaxAmount = new PayableAmount
                    {
                        currencyID = documento.Moneda,
                        value = documento.TotalIsc,
                    },
                    TaxSubtotal = new TaxSubtotal
                    {
                        TaxAmount = new PayableAmount
                        {
                            currencyID = documento.Moneda,
                            value = documento.TotalIsc
                        },
                        TaxCategory = new TaxCategory
                        {
                            TaxScheme = new TaxScheme
                            {
                                ID = "2000",
                                Name = "ISC",
                                TaxTypeCode = "EXC"
                            }
                        }
                    }
                });
            }
            if (documento.TotalOtrosTributos > 0)
            {
                invoice.TaxTotals.Add(new TaxTotal
                {
                    TaxAmount = new PayableAmount
                    {
                        currencyID = documento.Moneda,
                        value = documento.TotalOtrosTributos,
                    },
                    TaxSubtotal = new TaxSubtotal
                    {
                        TaxAmount = new PayableAmount
                        {
                            currencyID = documento.Moneda,
                            value = documento.TotalOtrosTributos
                        },
                        TaxCategory = new TaxCategory
                        {
                            TaxScheme = new TaxScheme
                            {
                                ID = "9999",
                                Name = "OTROS",
                                TaxTypeCode = "OTH"
                            }
                        }
                    }
                });
            }
            /* Tipo de Operación - Catalogo N° 17 */
            if (!string.IsNullOrEmpty(documento.TipoOperacion))
            {
                invoice.UblExtensions.Extension2.ExtensionContent
                    .AdditionalInformation.SunatTransaction.Id = documento.TipoOperacion;
            }

            if (documento.Gratuitas > 0)
            {
                invoice.UblExtensions.Extension2.ExtensionContent
                        .AdditionalInformation.AdditionalProperties.Add(new AdditionalProperty
                        {
                            ID = 1002,
                            Value = "Articulos gratuitos"
                        });
            }
            if (documento.DescuentoGlobal > 0)
            {
                invoice.UblExtensions.Extension2.ExtensionContent
                    .AdditionalInformation.AdditionalMonetaryTotals.Add(new AdditionalMonetaryTotal
                    {
                        ID = "2005",
                        PayableAmount = new PayableAmount
                        {
                            currencyID = documento.Moneda,
                            value = documento.DescuentoGlobal
                        }
                    });
            }

            foreach (var detalleDocumento in documento.Items)
            {
                var linea = new InvoiceLine
                {
                    ID = detalleDocumento.Id,
                    InvoicedQuantity = new InvoicedQuantity
                    {
                        unitCode = detalleDocumento.UnidadMedida,
                        Value = detalleDocumento.Cantidad
                    },
                    LineExtensionAmount = new PayableAmount
                    {
                        currencyID = documento.Moneda,
                        value = detalleDocumento.TotalVenta
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
                            ID = detalleDocumento.CodigoItem
                        }
                    },
                    Price = new Price
                    {
                        PriceAmount = new PayableAmount
                        {
                            currencyID = documento.Moneda,
                            value = detalleDocumento.PrecioUnitario
                        }
                    },
                };
                /* 16 - Afectación al IGV por ítem */
                linea.TaxTotals.Add(new TaxTotal
                {
                    TaxAmount = new PayableAmount
                    {
                        currencyID = documento.Moneda,
                        value = detalleDocumento.Impuesto
                    },
                    TaxSubtotal = new TaxSubtotal
                    {
                        TaxAmount = new PayableAmount
                        {
                            currencyID = documento.Moneda,
                            value = detalleDocumento.Impuesto
                        },
                        TaxCategory = new TaxCategory
                        {
                            TaxExemptionReasonCode = detalleDocumento.TipoImpuesto,
                            TaxScheme = new TaxScheme()
                            {
                                ID = "1000",
                                Name = "IGV",
                                TaxTypeCode = "VAT"
                            }
                        }
                    }
                });

                /* 17 - Sistema de ISC por ítem */
                if (detalleDocumento.ImpuestoSelectivo > 0)
                    linea.TaxTotals.Add(new TaxTotal
                    {
                        TaxAmount = new PayableAmount
                        {
                            currencyID = documento.Moneda,
                            value = detalleDocumento.ImpuestoSelectivo
                        },
                        TaxSubtotal = new TaxSubtotal
                        {
                            TaxAmount = new PayableAmount
                            {
                                currencyID = documento.Moneda,
                                value = detalleDocumento.ImpuestoSelectivo
                            },
                            TaxCategory = new TaxCategory
                            {
                                TaxExemptionReasonCode = detalleDocumento.TipoImpuesto,
                                TierRange = "01",
                                TaxScheme = new TaxScheme()
                                {
                                    ID = "2000",
                                    Name = "ISC",
                                    TaxTypeCode = "EXC"
                                }
                            }
                        }
                    });

                linea.PricingReference.AlternativeConditionPrices.Add(new AlternativeConditionPrice
                {
                    PriceAmount = new PayableAmount
                    {
                        currencyID = documento.Moneda,
                        // Comprobamos que sea una operacion gratuita.
                        value = documento.Gratuitas > 0 ? 0 : detalleDocumento.PrecioReferencial
                    },
                    PriceTypeCode = detalleDocumento.TipoPrecio
                });
                // Para operaciones no onerosas (gratuitas)
                if (documento.Gratuitas > 0)
                    linea.PricingReference.AlternativeConditionPrices.Add(new AlternativeConditionPrice
                    {
                        PriceAmount = new PayableAmount
                        {
                            currencyID = documento.Moneda,
                            value = detalleDocumento.PrecioReferencial
                        },
                        PriceTypeCode = "02"
                    });

                invoice.InvoiceLines.Add(linea);
            }

            return invoice;
        }
    }
}
