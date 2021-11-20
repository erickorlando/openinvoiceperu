using OpenInvoicePeru.Comun;
using OpenInvoicePeru.Comun.Dto.Contratos;
using OpenInvoicePeru.Comun.Dto.Modelos;
using OpenInvoicePeru.Estructuras.CommonAggregateComponents;
using OpenInvoicePeru.Estructuras.CommonBasicComponents;
using OpenInvoicePeru.Estructuras.EstandarUbl;
using OpenInvoicePeru.Estructuras.SunatAggregateComponents;
using System;
using System.Collections.Generic;
using System.Linq;

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
                Id = documento.IdDocumento,
                IssueDate = DateTime.Parse(documento.FechaEmision),
                IssueTime = DateTime.Parse(documento.HoraEmision),
                InvoiceTypeCode = documento.TipoDocumento,
                ProfileId = documento.TipoOperacion,
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
                    AllowanceTotalAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.Items.Sum(x => x.Descuento)
                    },
                    TaxInclusiveAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.TaxInclusiveAmount > 0 ? documento.TaxInclusiveAmount : documento.TotalVenta
                    },
                    LineExtensionAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.LineExtensionAmount > 0 ? documento.LineExtensionAmount : 0
                    },
                    ChargeTotalAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.OtrosCargos
                    },
                    PayableRoundingAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.Redondeo
                    }
                },
                AllowanceCharge = new AllowanceCharge
                {
                    Amount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.DescuentoGlobal
                    },
                    ReasonCode = string.IsNullOrEmpty(documento.CodigoRazonDcto) ? "02" : documento.CodigoRazonDcto,
                    MultiplierFactorNumeric = documento.FactorMultiplicadorDscto,
                    BaseAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.MontoBaseParaDcto
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

            invoice.Credito = documento.Credito;
            if (invoice.Credito)
            {
                invoice.InfoCreditsList.AddRange(documento.DatoCreditos
                    .Select(p => new InfoCredits
                    {
                        NroCuota = p.NroCuota,
                        MontoCuota = p.MontoCuota,
                        FechaCredito = p.FechaCredito
                    }));
            }

            if (documento.TotalVenta > 0 && documento.LineExtensionAmount == 0)
            {
                invoice.LegalMonetaryTotal.LineExtensionAmount = new PayableAmount
                {
                    CurrencyId = documento.Moneda,
                    Value = (documento.Gravadas + documento.Exoneradas + documento.Inafectas) - documento.DescuentoGlobal
                };
            }

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

            if (documento.Exoneradas > 0)
            {
                invoice.TaxTotals.First().TaxSubTotals.AddRange(CalculoTotales.AgregarSubTotalCabecera(new TotalesDto
                {
                    CurrencyId = documento.Moneda,
                    MontoBase = documento.Exoneradas,
                    Monto = 0,
                    CategoryId = "E",
                    TaxSchemeId = "9997",
                    Name = "EXO",
                    TaxTypeCode = "VAT"
                }));
            }

            if (documento.Inafectas > 0)
            {
                invoice.TaxTotals.First().TaxSubTotals.AddRange(CalculoTotales.AgregarSubTotalCabecera(new TotalesDto
                {
                    CurrencyId = documento.Moneda,
                    MontoBase = documento.Inafectas,
                    Monto = 0,
                    CategoryId = "O",
                    TaxSchemeId = "9998",
                    Name = "INA",
                    TaxTypeCode = "FRE"
                }));
            }

            if (documento.Gratuitas > 0)
            {
                invoice.TaxTotals.First().TaxSubTotals.AddRange(CalculoTotales.AgregarSubTotalCabecera(new TotalesDto
                {
                    CurrencyId = documento.Moneda,
                    Monto = documento.Gratuitas * documento.TasaImpuesto,
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
                    Monto = documento.TotalOtrosTributos,
                    MontoBase = documento.Gravadas,
                    CategoryId = "S",
                    TaxSchemeId = "7152",
                    Name = "ICBPER",
                    TaxTypeCode = "OTH"
                }));
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
            if (documento.Anticipos != null)
            {
                foreach (var anticipo in documento.Anticipos)
                {
                    invoice.PrepaidPayments.Add(new BillingPayment
                    {
                        Id = new PartyIdentificationId
                        {
                            SchemeId = anticipo.TipoDocAnticipo,
                            Value = anticipo.DocAnticipo
                        },
                        PaidAmount = new PayableAmount
                        {
                            CurrencyId = anticipo.MonedaAnticipo,
                            Value = anticipo.MontoAnticipo
                        },
                        InstructionId = documento.Emisor.NroDocumento
                    });

                    invoice.AdditionalDocumentReferences.Add(new InvoiceDocumentReference
                    {
                        DocumentTypeCode = anticipo.TipoDocAnticipo,
                        Id = anticipo.DocAnticipo
                    }
                    );
                }

                invoice.LegalMonetaryTotal.PrepaidAmount = new PayableAmount
                {
                    CurrencyId = documento.Moneda,
                    Value = documento.MontoTotalAnticipo
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

            if (!string.IsNullOrEmpty(documento.MontoEnLetras))
            {
                invoice.NotesList.Add("1000", documento.MontoEnLetras);
            }

            if (!string.IsNullOrEmpty(documento.Notas))
            {
                invoice.NotesList.Add("2010", documento.Notas);
            }

            foreach (var leyenda in documento.Leyendas)
            {
                invoice.NotesList.Add(leyenda.Codigo, leyenda.Descripcion);
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
                        NameCode = "5010",
                        Value = detalleDocumento.PlacaVehiculo
                    });
                }

                // Datos Adicionales a la Factura.
                foreach (var adicional in detalleDocumento.DatosAdicionales)
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

                /* Detracciones Servicio de Transporte de Carga */
                if (!string.IsNullOrEmpty(detalleDocumento.UbigeoOrigen) && !string.IsNullOrEmpty(detalleDocumento.UbigeoDestino))
                {
                    linea.Delivery = new Delivery
                    {
                        Despatch = new Despatch
                        {
                            DespatchAddress = new DespatchAddress
                            {
                                Id = detalleDocumento.UbigeoOrigen,
                                AddressLine = detalleDocumento.DireccionOrigen
                            },
                            Instructions = detalleDocumento.DetalleViaje
                        },
                        DeliveryLocation = new Despatch
                        {
                            DespatchAddress = new DespatchAddress
                            {
                                Id = detalleDocumento.UbigeoDestino,
                                AddressLine = detalleDocumento.DireccionDestino
                            }
                        },
                        DeliveryTerms = new List<DeliveryTerms>
                        {
                            new DeliveryTerms
                            {
                                Id = "01",
                                Amount = new PayableAmount
                                {
                                    CurrencyId = "PEN",
                                    Value = detalleDocumento.ValorReferencial
                                }
                            },
                            new DeliveryTerms
                            {
                                Id = "02",
                                Amount = new PayableAmount
                                {
                                    CurrencyId = "PEN",
                                    Value = detalleDocumento.ValorReferencialCargaEfectiva
                                }
                            },
                            new DeliveryTerms
                            {
                                Id = "03",
                                Amount = new PayableAmount
                                {
                                    CurrencyId = "PEN",
                                    Value = detalleDocumento.ValorReferencialCargaUtil
                                }
                            },
                        },
                        Shipment = new Shipment
                        {
                            Consignment = new Consignment
                            {
                                TransportHandlingUnit = new TransportHandlingUnit
                                {
                                    TransportEquipments = new List<TransportEquipment>()
                                    {
                                        new TransportEquipment
                                        {
                                            SizeTypeCode = detalleDocumento.ConfiguracionVehicular,
                                            Delivery = new Delivery
                                            {
                                                DeliveryTerms = new List<DeliveryTerms>()
                                                {
                                                    new DeliveryTerms
                                                    {
                                                        Amount = new PayableAmount
                                                        {
                                                            CurrencyId = "PEN",
                                                            Value = detalleDocumento.ValorReferencialTm
                                                        }
                                                    }
                                                }
                                            },
                                            ReturnabilityIndicator = detalleDocumento.ViajeConRetorno
                                        }
                                    },
                                    MeasurementDimensions = new List<MeasurementDimension>()
                                    {
                                        new MeasurementDimension
                                        {
                                            AttributeId = "01",
                                            Measure = detalleDocumento.CargaUtil
                                        },
                                        new MeasurementDimension
                                        {
                                            AttributeId = "02",
                                            Measure = detalleDocumento.CargaUtil
                                        },
                                    }
                                },
                                DeclaredForCarriageValueAmount = detalleDocumento.ValorPreliminarReferencial
                            }
                        }
                    };
                }

                /* 16 - Afectación al IGV por ítem */
                linea.TaxTotals.Add(new TaxTotal
                {
                    TaxAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = detalleDocumento.PrecioUnitario == 0 ? 0 : detalleDocumento.Impuesto
                    },
                    TaxSubTotals = CalculoTotales.AgregarSubTotalDetalles(new TotalesDto
                    {
                        CurrencyId = documento.Moneda,
                        Monto = detalleDocumento.Impuesto,
                        MontoBase = detalleDocumento.BaseImponible ?? 0,
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

                /* Otros Impuestos */
                if (detalleDocumento.OtroImpuesto > 0)
                {
                    // Cuando hay impuesto de Bolsa no se deben considerar ningun otro tipo de impuesto mas.
                    //linea.TaxTotals.First().TaxSubTotals.Clear();
                    linea.TaxTotals.First().TaxSubTotals.AddRange(CalculoTotales.AgregarSubTotalDetalles(new TotalesDto
                    {
                        CurrencyId = documento.Moneda,
                        Monto = detalleDocumento.OtroImpuesto,
                        CategoryId = AfectacionImpuesto.ObtenerLetraTributo(detalleDocumento.TipoImpuesto),
                        TaxPercent = detalleDocumento.TasaImpuestoSelectivo,
                        TaxExemptionReasonCode = detalleDocumento.TipoImpuesto,
                        TaxSchemeId = "7152",
                        Name = "ICBPER",
                        TaxTypeCode = "OTH",
                        CantidadBolsas = detalleDocumento.CantidadBolsas,
                        PrecioUnitarioBolsa = detalleDocumento.PrecioUnitarioBolsa
                    }));
                }

                linea.PricingReference.AlternativeConditionPrices.Add(new AlternativeConditionPrice
                {
                    PriceAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        // Comprobamos que sea una operacion gratuita.
                        Value = detalleDocumento.PrecioReferencial
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