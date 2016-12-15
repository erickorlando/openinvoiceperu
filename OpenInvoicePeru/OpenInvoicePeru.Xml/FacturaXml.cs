using System;
using System.Collections.Generic;
using System.Linq;
using OpenInvoicePeru.Comun;
using OpenInvoicePeru.Comun.Dto.Contratos;
using OpenInvoicePeru.Comun.Dto.Modelos;
using OpenInvoicePeru.Estructuras;

namespace OpenInvoicePeru.Xml
{
    public class FacturaXml : IDocumentoXml
    {
        IEstructuraXml IDocumentoXml.Generar(IDocumentoElectronico request)
        {
            var documento = (DocumentoElectronico)request;
            var invoice = new Invoice
            {
                UblExtensions = new UblExtensions
                {
                    Extension2 = new UblExtension
                    {
                        ExtensionContent = new ExtensionContent
                        {
                            AdditionalInformation = new AdditionalInformation
                            {
                                AdditionalMonetaryTotals = new List<AdditionalMonetaryTotal>()
                                {
                                    new AdditionalMonetaryTotal()
                                    {
                                        Id = "1001",
                                        PayableAmount = new PayableAmount()
                                        {
                                            CurrencyId = documento.Moneda,
                                            Value = documento.Gravadas
                                        }
                                    },
                                    new AdditionalMonetaryTotal
                                    {
                                        Id = "1002",
                                        PayableAmount = new PayableAmount
                                        {
                                            CurrencyId = documento.Moneda,
                                            Value = documento.Inafectas
                                        }
                                    },
                                    new AdditionalMonetaryTotal
                                    {
                                        Id = "1003",
                                        PayableAmount = new PayableAmount
                                        {
                                            CurrencyId = documento.Moneda,
                                            Value = documento.Exoneradas
                                        }
                                    },
                                    new AdditionalMonetaryTotal
                                    {
                                        Id = "1004",
                                        PayableAmount = new PayableAmount
                                        {
                                            CurrencyId = documento.Moneda,
                                            Value = documento.Gratuitas
                                        }
                                    }
                                },
                                AdditionalProperties = new List<AdditionalProperty>()
                                {
                                    new AdditionalProperty
                                    {
                                        Id = "1000",
                                        Value = documento.MontoEnLetras
                                    }
                                }
                            }
                        }
                    }
                },
                Id = documento.IdDocumento,
                IssueDate = DateTime.Parse(documento.FechaEmision),
                InvoiceTypeCode = documento.TipoDocumento,
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
                    CustomerAssignedAccountId = documento.Emisor.NroDocumento,
                    AdditionalAccountId = documento.Emisor.TipoDocumento,
                    Party = new Party
                    {
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
                    }
                },
                AccountingCustomerParty = new AccountingSupplierParty
                {
                    CustomerAssignedAccountId = documento.Receptor.NroDocumento,
                    AdditionalAccountId = documento.Receptor.TipoDocumento,
                    Party = new Party
                    {
                        PartyName = new PartyName
                        {
                            Name = documento.Receptor.NombreComercial ?? string.Empty
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
                        TaxSubtotal = new TaxSubtotal
                        {
                            TaxAmount = new PayableAmount
                            {
                                CurrencyId = documento.Moneda,
                                Value = documento.TotalIgv,
                            },
                            TaxCategory = new TaxCategory
                            {
                                TaxScheme = new TaxScheme
                                {
                                    Id = "1000",
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
                        CurrencyId = documento.Moneda,
                        Value = documento.TotalIsc,
                    },
                    TaxSubtotal = new TaxSubtotal
                    {
                        TaxAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.TotalIsc
                        },
                        TaxCategory = new TaxCategory
                        {
                            TaxScheme = new TaxScheme
                            {
                                Id = "2000",
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
                        CurrencyId = documento.Moneda,
                        Value = documento.TotalOtrosTributos,
                    },
                    TaxSubtotal = new TaxSubtotal
                    {
                        TaxAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.TotalOtrosTributos
                        },
                        TaxCategory = new TaxCategory
                        {
                            TaxScheme = new TaxScheme
                            {
                                Id = "9999",
                                Name = "OTROS",
                                TaxTypeCode = "OTH"
                            }
                        }
                    }
                });
            }

            /* Numero de Placa del Vehiculo - Gastos art.37° Renta */
            if (!string.IsNullOrEmpty(documento.PlacaVehiculo))
            {
                invoice.UblExtensions.Extension2.ExtensionContent
                    .AdditionalInformation.SunatCosts.RoadTransport
                    .LicensePlateId = documento.PlacaVehiculo;
            }

            /* Tipo de Operación - Catalogo N° 17 */
            if (!string.IsNullOrEmpty(documento.TipoOperacion)
                && documento.DatosGuiaTransportista == null)
            {
                invoice.UblExtensions.Extension2.ExtensionContent
                    .AdditionalInformation.SunatTransaction.Id = documento.TipoOperacion;
                // Si es Emisor Itinerante.
                if (documento.TipoOperacion == "05")
                {
                    invoice.UblExtensions.Extension2.ExtensionContent
                        .AdditionalInformation.AdditionalProperties.Add(new AdditionalProperty
                        {
                            Id = "3000", // En el catalogo aparece como 2005 pero es 3000
                            Value = "Venta realizada por emisor itinerante"
                        });
                }
            }

            foreach (var relacionado in documento.Relacionados)
            {
                invoice.DespatchDocumentReferences.Add(new InvoiceDocumentReference
                {
                    DocumentTypeCode = relacionado.TipoDocumento,
                    Id = relacionado.NroDocumento
                });
            }

            if (documento.Gratuitas > 0)
            {
                invoice.UblExtensions.Extension2.ExtensionContent
                        .AdditionalInformation.AdditionalProperties.Add(new AdditionalProperty
                        {
                            Id = "1002",
                            Value = "Articulos gratuitos"
                        });
            }
            var dctosPorItem = documento.Items.Sum(d => d.Descuento);
            if (documento.DescuentoGlobal > 0 || dctosPorItem > 0)
            {
                invoice.UblExtensions.Extension2.ExtensionContent
                    .AdditionalInformation.AdditionalMonetaryTotals.Add(new AdditionalMonetaryTotal
                    {
                        Id = "2005",
                        PayableAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.DescuentoGlobal + dctosPorItem
                        }
                    });
            }
            if (documento.MontoPercepcion > 0)
            {
                invoice.UblExtensions.Extension2.ExtensionContent
                    .AdditionalInformation.AdditionalMonetaryTotals.Add(new AdditionalMonetaryTotal
                    {
                        Id = "2001",
                        PayableAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.MontoPercepcion
                        },
                        TotalAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.Gravadas + documento.MontoPercepcion
                        }
                    });
            }
            if (documento.MontoAnticipo > 0)
            {
                invoice.PrepaidPayment = new BillingPayment
                {
                    Id = new PartyIdentificationId
                    {
                        SchemeId = documento.TipoDocAnticipo,
                        Value = documento.DocAnticipo
                    },
                    PaidAmount = new PayableAmount
                    {
                        CurrencyId = documento.MonedaAnticipo,
                        Value = documento.MontoAnticipo
                    },
                    InstructionId = documento.Emisor.NroDocumento
                };
                invoice.LegalMonetaryTotal.PrepaidAmount = new PayableAmount
                {
                    CurrencyId = documento.MonedaAnticipo,
                    Value = documento.MontoAnticipo
                };
            }

            // Datos Adicionales a la Factura.
            foreach (var adicional in documento.DatoAdicionales)
            {
                invoice.UblExtensions.Extension2.ExtensionContent
                    .AdditionalInformation.AdditionalProperties.Add(new AdditionalProperty
                    {
                        Id = adicional.Codigo,
                        Value = adicional.Contenido
                    });
            }

            if (documento.MontoDetraccion > 0)
            {
                invoice.UblExtensions.Extension2.ExtensionContent
                    .AdditionalInformation.AdditionalMonetaryTotals.Add(new AdditionalMonetaryTotal
                    {
                        Id = "2003",
                        PayableAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.MontoDetraccion
                        },
                        Percent = documento.CalculoDetraccion * 100
                    });
            }

            // Para datos de Guia de Remision Transportista.
            if (!string.IsNullOrEmpty(documento.DatosGuiaTransportista?.RucTransportista))
            {
                invoice.UblExtensions.Extension2.ExtensionContent
                    .AdditionalInformation.SunatEmbededDespatchAdvice = new SunatEmbededDespatchAdvice
                    {
                        DeliveryAddress = new PostalAddress
                        {
                            Id = documento.DatosGuiaTransportista.DireccionDestino.Ubigeo,
                            StreetName = documento.DatosGuiaTransportista.DireccionDestino.Direccion,
                            CitySubdivisionName = documento.DatosGuiaTransportista.DireccionDestino.Urbanizacion,
                            CityName = documento.DatosGuiaTransportista.DireccionDestino.Departamento,
                            CountrySubentity = documento.DatosGuiaTransportista.DireccionDestino.Provincia,
                            District = documento.DatosGuiaTransportista.DireccionDestino.Distrito,
                            Country = new Country
                            {
                                IdentificationCode = "PE"
                            }
                        },
                        OriginAddress = new PostalAddress
                        {
                            Id = documento.DatosGuiaTransportista.DireccionOrigen.Ubigeo,
                            StreetName = documento.DatosGuiaTransportista.DireccionOrigen.Direccion,
                            CitySubdivisionName = documento.DatosGuiaTransportista.DireccionOrigen.Urbanizacion,
                            CityName = documento.DatosGuiaTransportista.DireccionOrigen.Departamento,
                            CountrySubentity = documento.DatosGuiaTransportista.DireccionOrigen.Provincia,
                            District = documento.DatosGuiaTransportista.DireccionOrigen.Distrito,
                            Country = new Country
                            {
                                IdentificationCode = "PE"
                            }
                        },
                        SunatCarrierParty = new AccountingSupplierParty
                        {
                            CustomerAssignedAccountId = documento.DatosGuiaTransportista.RucTransportista,
                            AdditionalAccountId = "06",
                            Party = new Party
                            {
                                PartyLegalEntity = new PartyLegalEntity
                                {
                                    RegistrationName = documento.DatosGuiaTransportista.NombreTransportista
                                }
                            }
                        },
                        DriverParty = new AgentParty
                        {
                            PartyIdentification = new PartyIdentification
                            {
                                Id = new PartyIdentificationId
                                {
                                    Value = documento.DatosGuiaTransportista.NroLicenciaConducir
                                }
                            }
                        },
                        SunatRoadTransport = new SunatRoadTransport
                        {
                            LicensePlateId = documento.DatosGuiaTransportista.PlacaVehiculo,
                            TransportAuthorizationCode = documento.DatosGuiaTransportista.CodigoAutorizacion,
                            BrandName = documento.DatosGuiaTransportista.MarcaVehiculo
                        },
                        TransportModeCode = documento.DatosGuiaTransportista.ModoTransporte,
                        GrossWeightMeasure = new InvoicedQuantity
                        {
                            UnitCode = documento.DatosGuiaTransportista.UnidadMedida,
                            Value = documento.DatosGuiaTransportista.PesoBruto
                        }
                    };
            }

            foreach (var detalleDocumento in documento.Items)
            {
                var linea = new InvoiceLine
                {
                    Id = detalleDocumento.Id,
                    InvoicedQuantity = new InvoicedQuantity
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
                /* 16 - Afectación al IGV por ítem */
                linea.TaxTotals.Add(new TaxTotal
                {
                    TaxAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = detalleDocumento.Impuesto
                    },
                    TaxSubtotal = new TaxSubtotal
                    {
                        TaxAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = detalleDocumento.Impuesto
                        },
                        TaxCategory = new TaxCategory
                        {
                            TaxExemptionReasonCode = detalleDocumento.TipoImpuesto,
                            TaxScheme = new TaxScheme()
                            {
                                Id = "1000",
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
                            CurrencyId = documento.Moneda,
                            Value = detalleDocumento.ImpuestoSelectivo
                        },
                        TaxSubtotal = new TaxSubtotal
                        {
                            TaxAmount = new PayableAmount
                            {
                                CurrencyId = documento.Moneda,
                                Value = detalleDocumento.ImpuestoSelectivo
                            },
                            TaxCategory = new TaxCategory
                            {
                                TaxExemptionReasonCode = detalleDocumento.TipoImpuesto,
                                TierRange = "01",
                                TaxScheme = new TaxScheme()
                                {
                                    Id = "2000",
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
                        CurrencyId = documento.Moneda,
                        // Comprobamos que sea una operacion gratuita.
                        Value = documento.Gratuitas > 0 ? 0 : detalleDocumento.PrecioReferencial
                    },
                    PriceTypeCode = detalleDocumento.TipoPrecio
                });
                // Para operaciones no onerosas (gratuitas)
                if (documento.Gratuitas > 0)
                    linea.PricingReference.AlternativeConditionPrices.Add(new AlternativeConditionPrice
                    {
                        PriceAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = detalleDocumento.PrecioReferencial
                        },
                        PriceTypeCode = "02"
                    });

                /* 51 - Descuentos por ítem */
                if (detalleDocumento.Descuento > 0)
                {
                    linea.AllowanceCharge.ChargeIndicator = false;
                    linea.AllowanceCharge.Amount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = detalleDocumento.Descuento
                    };
                }

                invoice.InvoiceLines.Add(linea);
            }

            return invoice;
        }
    }
}