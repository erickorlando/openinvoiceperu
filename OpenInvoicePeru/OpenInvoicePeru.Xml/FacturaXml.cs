using System;
using System.Collections.Generic;
using System.Linq;
using OpenInvoicePeru.Comun;
using OpenInvoicePeru.Comun.Dto.Contratos;
using OpenInvoicePeru.Comun.Dto.Modelos;
using OpenInvoicePeru.Estructuras.CommonAggregateComponents;
using OpenInvoicePeru.Estructuras.CommonBasicComponents;
using OpenInvoicePeru.Estructuras.EstandarUbl;
using OpenInvoicePeru.Estructuras.SunatAggregateComponents;

namespace OpenInvoicePeru.Xml
{
    public class FacturaXml : IDocumentoXml
    {
        public IEstructuraXml Generar(IDocumentoElectronico request)
        {
            var documento = (DocumentoElectronico)request;
            documento.MontoEnLetras = Conversion.Enletras(documento.TotalVenta);
            var invoice = new Invoice
            {
                Note = documento.MontoEnLetras,
                Id = documento.IdDocumento,
                IssueDate = DateTime.Parse(documento.FechaEmision),
                IssueTime = DateTime.Parse(documento.HoraEmision),
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
                            Uri = $"{documento.Emisor.NroDocumento}-{documento.TipoDocumento}-{documento.IdDocumento}"
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
                LegalMonetaryTotal = new LegalMonetaryTotal
                {
                    PayableAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.TotalVenta
                    },
                    TaxInclusiveAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.Gravadas
                    }
                },
                AllowanceCharge = new AllowanceCharge
                {
                    Amount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.DescuentoGlobal
                    },
                    ReasonCode = "02"
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
                invoice.TaxTotals.First().TaxSubTotals.AddRange(CalculoTotales.AgregarSubTotalCabecera(new TotalesDto
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
                invoice.TaxTotals.First().TaxSubTotals.AddRange(CalculoTotales.AgregarSubTotalCabecera(new TotalesDto
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
                invoice.TaxTotals.First().TaxSubTotals.AddRange(CalculoTotales.AgregarSubTotalCabecera(new TotalesDto
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
                invoice.TaxTotals.First().TaxSubTotals.AddRange(CalculoTotales.AgregarSubTotalCabecera(new TotalesDto
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
                invoice.TaxTotals.First().TaxSubTotals.AddRange(CalculoTotales.AgregarSubTotalCabecera(new TotalesDto
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
                invoice.DueDate = DateTime.Parse(documento.FechaVencimiento);

            if (!string.IsNullOrEmpty(documento.NroOrdenCompra))
            {
                invoice.OrderReference = documento.NroOrdenCompra;
            }

            if (documento.TotalIsc > 0)
            {
                invoice.TaxTotals.First().TaxSubTotals.AddRange(CalculoTotales.AgregarSubTotalCabecera(new TotalesDto
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
                invoice.TaxTotals.First().TaxSubTotals.AddRange(CalculoTotales.AgregarSubTotalCabecera(new TotalesDto
                {
                    CurrencyId = documento.Moneda,
                    Monto = documento.TotalIsc,
                    MontoBase = documento.Gravadas,
                    CategoryId = "S",
                    TaxSchemeId = "9999",
                    Name = "OTROS",
                    TaxTypeCode = "OTH"
                }));
            }

            /* Tipo de Operación - Catalogo N° 17 */
            if (!string.IsNullOrEmpty(documento.TipoOperacion)
                && documento.DatosGuiaTransportista == null)
            {
                invoice.ProfileId = documento.TipoOperacion;
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

            if (documento.MontoPercepcion > 0)
            {
                invoice.UblExtensions.Extension2.ExtensionContent
                    .AdditionalInformation.AdditionalMonetaryTotals.Add(new AdditionalMonetaryTotal
                    {
                        Id = "2001",
                        ReferenceAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.TotalVenta
                        },
                        PayableAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.MontoPercepcion
                        },
                        TotalAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.TotalVenta + documento.MontoPercepcion
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
                invoice.AdditionalDocumentReferences = new List<InvoiceDocumentReference>
                {
                   new InvoiceDocumentReference
                   {
                       DocumentTypeCode = documento.TipoDocAnticipo,
                       Id = documento.DocAnticipo
                   }
                };
                invoice.LegalMonetaryTotal.PrepaidAmount = new PayableAmount
                {
                    CurrencyId = documento.MonedaAnticipo,
                    Value = documento.MontoAnticipo
                };
            }

            if (documento.MontoDetraccion > 0)
            {
                invoice.PayeeFinancialAccountId = documento.CuentaBancoNacion;
                invoice.PaymentTermsAmount = documento.MontoDetraccion;
                invoice.PaymentTermsPercent = documento.TasaDetraccion;
                invoice.PaymentMeansId = documento.CodigoBienOServicio;
                invoice.PaymentMeansCode = documento.CodigoMedioPago;
            }

            foreach (var leyenda in documento.Leyendas)
            {
                invoice.NotesList.Add(leyenda.Codigo, leyenda.Descripcion);
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
                            //CustomerAssignedAccountId = documento.DatosGuiaTransportista.RucTransportista,
                            //AdditionalAccountId = "06",
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
                        },
                        CommodityClassification = new CommodityClassification
                        {
                            ItemClassificationCode = detalleDocumento.CodigoProductoSunat
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
                if (!string.IsNullOrEmpty(detalleDocumento.PlacaVehiculo))
                {
                    linea.Item.AdditionalItemProperties.Add(new AdditionalItemProperty
                    {
                        Name = "Gastos Art. 37 Renta: Número de Placa",
                        NameCode = "700",
                        Value = detalleDocumento.PlacaVehiculo
                    });
                }

                // Datos Adicionales a la Factura.
                foreach (var adicional in detalleDocumento.DatosAdcionales)
                {
                    linea.Item.AdditionalItemProperties.Add(new AdditionalItemProperty
                    {
                        Name = adicional.Nombre,
                        NameCode = adicional.Codigo ?? "-",
                        Value = adicional.Contenido,
                        UsabilityPeriod = new UsabilityPeriod
                        {
                            StartDate = adicional.FechaInicio,
                            EndDate = adicional.FechaFin,
                            DurationMeasure = adicional.Duracion
                        }
                    });
                }

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

                /* 17 - Sistema de ISC por ítem */
                if (detalleDocumento.ImpuestoSelectivo > 0)
                    linea.TaxTotals.First().TaxSubTotals.AddRange(CalculoTotales.AgregarSubTotalDetalles(new TotalesDto
                    {
                        CurrencyId = documento.Moneda,
                        Monto = detalleDocumento.ImpuestoSelectivo,
                        CategoryId = AfectacionImpuesto.ObtenerLetraTributo(detalleDocumento.TipoImpuesto),
                        TaxPercent = detalleDocumento.TasaImpuestoSelectivo,
                        TaxExemptionReasonCode = detalleDocumento.TipoImpuesto,
                        TaxSchemeId = "2000",
                        Name = "ISC",
                        TaxTypeCode = "EXC"
                    }));

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
                //// Para operaciones no onerosas (gratuitas)
                //if (documento.Gratuitas > 0)
                //    linea.PricingReference.AlternativeConditionPrices.Add(new AlternativeConditionPrice
                //    {
                //        PriceAmount = new PayableAmount
                //        {
                //            CurrencyId = documento.Moneda,
                //            Value = detalleDocumento.PrecioReferencial
                //        },
                //        PriceTypeCode = "02"
                //    });

                // linea.AditionalItemIdentification.Id = documento.PlacaVehiculo;



                /* 51 - Descuentos por ítem */
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

                invoice.InvoiceLines.Add(linea);
            }

            return invoice;
        }
    }
}