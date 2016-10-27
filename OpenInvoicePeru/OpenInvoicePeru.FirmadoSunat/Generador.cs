using System;
using System.Collections.Generic;
using OpenInvoicePeru.Firmado.Estructuras;
using OpenInvoicePeru.Firmado.Models;

namespace OpenInvoicePeru.Firmado
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
                                        ID = "1000",
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
                            URI = $"{documento.Emisor.NroDocumento}-{documento.IdDocumento}"
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
                            ID = "3000", // En el catalogo aparece como 2005 pero es 3000
                            Value = "Venta realizada por emisor itinerante"
                        });
                }
            }

            foreach (var relacionado in documento.Relacionados)
            {
                invoice.DespatchDocumentReferences.Add(new InvoiceDocumentReference
                {
                    DocumentTypeCode = relacionado.TipoDocumento,
                    ID = relacionado.NroDocumento
                });
            }

            if (documento.Gratuitas > 0)
            {
                invoice.UblExtensions.Extension2.ExtensionContent
                        .AdditionalInformation.AdditionalProperties.Add(new AdditionalProperty
                        {
                            ID = "1002",
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
            if (documento.MontoPercepcion > 0)
            {
                invoice.UblExtensions.Extension2.ExtensionContent
                    .AdditionalInformation.AdditionalMonetaryTotals.Add(new AdditionalMonetaryTotal
                    {
                        ID = "2001",
                        PayableAmount = new PayableAmount
                        {
                            currencyID = documento.Moneda,
                            value = documento.MontoPercepcion
                        },
                        TotalAmount = new PayableAmount
                        {
                            currencyID = documento.Moneda,
                            value = documento.Gravadas + documento.MontoPercepcion
                        }
                    });
            }
            if (documento.MontoAnticipo > 0)
            {
                invoice.PrepaidPayment = new BillingPayment
                {
                    Id = new PartyIdentificationID
                    {
                        schemeID = documento.TipoDocAnticipo,
                        value = documento.DocAnticipo
                    },
                    PaidAmount = new PayableAmount
                    {
                        currencyID = documento.MonedaAnticipo,
                        value = documento.MontoAnticipo
                    },
                    InstructionId = documento.Emisor.NroDocumento
                };
                invoice.LegalMonetaryTotal.PrepaidAmount = new PayableAmount
                {
                    currencyID = documento.MonedaAnticipo,
                    value = documento.MontoAnticipo
                };
            }

            // Datos Adicionales a la Factura.
            foreach (var adicional in documento.DatoAdicionales)
            {
                invoice.UblExtensions.Extension2.ExtensionContent
                    .AdditionalInformation.AdditionalProperties.Add(new AdditionalProperty
                    {
                        ID = adicional.Codigo,
                        Value = adicional.Contenido
                    });
            }

            if (documento.MontoDetraccion > 0)
            {
                invoice.UblExtensions.Extension2.ExtensionContent
                    .AdditionalInformation.AdditionalMonetaryTotals.Add(new AdditionalMonetaryTotal
                    {
                        ID = "2003",
                        PayableAmount = new PayableAmount
                        {
                            currencyID = documento.Moneda,
                            value = documento.MontoDetraccion
                        },
                        Percent = documento.CalculoDetraccion *100
                    });
            }

            // Para datos de Guia de Remision Transportista.
            if (documento.DatosGuiaTransportista != null)
            {
                invoice.UblExtensions.Extension2.ExtensionContent
                    .AdditionalInformation.SunatEmbededDespatchAdvice = new SunatEmbededDespatchAdvice
                    {
                        DeliveryAddress = new PostalAddress
                        {
                            ID =  documento.DatosGuiaTransportista.DireccionDestino.Ubigeo,
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
                            ID =  documento.DatosGuiaTransportista.DireccionOrigen.Ubigeo,
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
                            CustomerAssignedAccountID = documento.DatosGuiaTransportista.RucTransportista,
                            AdditionalAccountID = "06",
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
                                ID = new PartyIdentificationID
                                {
                                    value = documento.DatosGuiaTransportista.NroLicenciaConducir
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
                            unitCode = documento.DatosGuiaTransportista.UnidadMedida,
                            Value = documento.DatosGuiaTransportista.PesoBruto
                        }
                    };
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

        public static CreditNote GenerarCreditNote(DocumentoElectronico documento)
        {
            var creditNote = new CreditNote
            {
                UBLExtensions = new UBLExtensions
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
                                    }
                                },
                                AdditionalProperties = new List<AdditionalProperty>()
                                {
                                    new AdditionalProperty
                                    {
                                        ID = "1000",
                                        Value = documento.MontoEnLetras
                                    }
                                }
                            }
                        }
                    }
                },
                ID = documento.IdDocumento,
                IssueDate = DateTime.Parse(documento.FechaEmision),
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
                            URI = $"{documento.Emisor.NroDocumento}-{documento.IdDocumento}"
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
                UBLVersionID = "2.0",
                CustomizationID = "1.0",
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

            foreach (var discrepancia in documento.Discrepancias)
            {
                creditNote.DiscrepancyResponses.Add(new DiscrepancyResponse
                {
                    ReferenceID = discrepancia.NroReferencia,
                    ResponseCode = discrepancia.Tipo,
                    Description = discrepancia.Descripcion
                });
            }

            foreach (var relacionado in documento.Relacionados)
            {
                creditNote.BillingReferences.Add(new BillingReference
                {
                    InvoiceDocumentReference = new InvoiceDocumentReference
                    {
                        ID = relacionado.NroDocumento,
                        DocumentTypeCode = relacionado.TipoDocumento
                    }
                });
            }

            foreach (var detalleDocumento in documento.Items)
            {
                var linea = new InvoiceLine
                {
                    ID = detalleDocumento.Id,
                    CreditedQuantity = new InvoicedQuantity
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
                creditNote.CreditNoteLines.Add(linea);
            }

            return creditNote;
        }

        public static DebitNote GenerarDebitNote(DocumentoElectronico documento)
        {
            var debitNote = new DebitNote
            {
                UBLExtensions = new UBLExtensions
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
                                    }
                                },
                                AdditionalProperties = new List<AdditionalProperty>()
                                {
                                    new AdditionalProperty
                                    {
                                        ID = "1000",
                                        Value = documento.MontoEnLetras
                                    }
                                }
                            }
                        }
                    }
                },
                ID = documento.IdDocumento,
                IssueDate = DateTime.Parse(documento.FechaEmision),
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
                            URI = $"{documento.Emisor.NroDocumento}-{documento.IdDocumento}"
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
                UBLVersionID = "2.0",
                CustomizationID = "1.0",
                RequestedMonetaryTotal = new LegalMonetaryTotal
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

            foreach (var discrepancia in documento.Discrepancias)
            {
                debitNote.DiscrepancyResponses.Add(new DiscrepancyResponse
                {
                    ReferenceID = discrepancia.NroReferencia,
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
                        ID = relacionado.NroDocumento,
                        DocumentTypeCode = relacionado.TipoDocumento
                    }
                });
            }

            foreach (var detalleDocumento in documento.Items)
            {
                var linea = new InvoiceLine
                {
                    ID = detalleDocumento.Id,
                    DebitedQuantity = new InvoicedQuantity
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
                debitNote.DebitNoteLines.Add(linea);
            }

            return debitNote;
        }

        public static VoidedDocuments GenerarVoidedDocuments(ComunicacionBaja comunicacion)
        {
            var voidedDocument = new VoidedDocuments
            {
                ID = comunicacion.IdDocumento,
                IssueDate = Convert.ToDateTime(comunicacion.FechaEmision),
                ReferenceDate = Convert.ToDateTime(comunicacion.FechaReferencia),
                CustomizationID = "1.0",
                UBLVersionID = "2.0",
                Signature = new SignatureCac
                {
                    ID = comunicacion.IdDocumento,
                    SignatoryParty = new SignatoryParty
                    {
                        PartyIdentification = new PartyIdentification
                        {
                            ID = new PartyIdentificationID
                            {
                                value = comunicacion.Emisor.NroDocumento
                            }
                        },
                        PartyName = new PartyName
                        {
                            Name= comunicacion.Emisor.NombreLegal
                        }
                    },
                    DigitalSignatureAttachment = new DigitalSignatureAttachment
                    {
                        ExternalReference = new ExternalReference
                        {
                            URI = $"{comunicacion.Emisor.NroDocumento}-{comunicacion.IdDocumento}"
                        }
                    }
                },
                AccountingSupplierParty = new AccountingSupplierParty
                {
                    CustomerAssignedAccountID = comunicacion.Emisor.NroDocumento,
                    AdditionalAccountID = comunicacion.Emisor.TipoDocumento,
                    Party = new Party
                    {
                        PartyLegalEntity = new PartyLegalEntity
                        {
                            RegistrationName = comunicacion.Emisor.NombreLegal
                        }
                    }
                }
            };
            
            foreach (var baja in comunicacion.Bajas)
            {
                voidedDocument.VoidedDocumentsLines.Add(new VoidedDocumentsLine
                {
                    LineID = baja.Id,
                    DocumentTypeCode = baja.TipoDocumento,
                    DocumentSerialID = baja.Serie,
                    DocumentNumberID = Convert.ToInt32(baja.Correlativo),
                    VoidReasonDescription = baja.MotivoBaja
                });    
            }

            return voidedDocument;
        }

        public static SummaryDocuments GenerarSummaryDocuments(ResumenDiario resumen)
        {
            var summary = new SummaryDocuments
            {
                ID = resumen.IdDocumento,
                IssueDate = Convert.ToDateTime(resumen.FechaEmision),
                ReferenceDate = Convert.ToDateTime(resumen.FechaReferencia),
                CustomizationID = "1.0",
                UBLVersionID = "2.0",
                Signature = new SignatureCac
                {
                    ID = resumen.IdDocumento,
                    SignatoryParty = new SignatoryParty
                    {
                        PartyIdentification = new PartyIdentification
                        {
                            ID = new PartyIdentificationID
                            {
                                value = resumen.Emisor.NroDocumento
                            }
                        },
                        PartyName = new PartyName
                        {
                            Name = resumen.Emisor.NombreLegal
                        }
                    },
                    DigitalSignatureAttachment = new DigitalSignatureAttachment
                    {
                        ExternalReference = new ExternalReference
                        {
                            URI = $"{resumen.Emisor.NroDocumento}-{resumen.IdDocumento}"
                        }
                    }
                },
                AccountingSupplierParty = new AccountingSupplierParty
                {
                    CustomerAssignedAccountID = resumen.Emisor.NroDocumento,
                    AdditionalAccountID = resumen.Emisor.TipoDocumento,
                    Party = new Party
                    {
                        PartyLegalEntity = new PartyLegalEntity
                        {
                            RegistrationName = resumen.Emisor.NombreLegal
                        }
                    }
                }
            };

            foreach (var grupo in resumen.Resumenes)
            {
                var linea = new VoidedDocumentsLine
                {
                    LineID = grupo.Id,
                    DocumentTypeCode = grupo.TipoDocumento,
                    DocumentSerialID = grupo.Serie,
                    StartDocumentNumberID = grupo.CorrelativoInicio,
                    EndDocumentNumberID = grupo.CorrelativoFin,
                    TotalAmount = new PayableAmount
                    {
                        currencyID = grupo.Moneda,
                        value = grupo.TotalVenta
                    },
                    BillingPayments = new List<BillingPayment>()
                    {
                      new BillingPayment
                      {
                          PaidAmount = new PayableAmount
                          {
                              currencyID = grupo.Moneda,
                              value = grupo.Gravadas
                          },
                          InstructionId = "01"
                      },
                      new BillingPayment
                      {
                          PaidAmount = new PayableAmount
                          {
                              currencyID = grupo.Moneda,
                              value = grupo.Exoneradas
                          },
                          InstructionId = "02"
                      },
                      new BillingPayment
                      {
                          PaidAmount = new PayableAmount
                          {
                              currencyID = grupo.Moneda,
                              value = grupo.Inafectas
                          },
                          InstructionId = "03"
                      },  
                    },
                    AllowanceCharge = new AllowanceCharge
                    {
                        ChargeIndicator = true,
                        Amount = new PayableAmount
                        {
                            currencyID = grupo.Moneda,
                            value = grupo.TotalDescuentos
                        }
                    },
                    TaxTotals = new List<TaxTotal>()
                    {
                        new TaxTotal
                        {
                            TaxAmount = new PayableAmount
                            {
                                currencyID = grupo.Moneda,
                                value = grupo.TotalIsc
                            },
                            TaxSubtotal = new TaxSubtotal
                            {
                                TaxAmount = new PayableAmount
                                {
                                    currencyID = grupo.Moneda,
                                    value = grupo.TotalIsc
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
                        },
                        new TaxTotal
                        {
                            TaxAmount = new PayableAmount
                            {
                                currencyID = grupo.Moneda,
                                value = grupo.TotalIgv
                            },
                            TaxSubtotal = new TaxSubtotal
                            {
                                TaxAmount = new PayableAmount
                                {
                                    currencyID = grupo.Moneda,
                                    value = grupo.TotalIgv
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
                        },
                        new TaxTotal
                        {
                            TaxAmount = new PayableAmount
                            {
                                currencyID = grupo.Moneda,
                                value = grupo.TotalOtrosImpuestos
                            },
                            TaxSubtotal = new TaxSubtotal
                            {
                                TaxAmount = new PayableAmount
                                {
                                    currencyID = grupo.Moneda,
                                    value = grupo.TotalOtrosImpuestos
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
                        },
                    }
                };
                if (grupo.Exportacion > 0)
                {
                    linea.BillingPayments.Add(new BillingPayment
                    {
                        PaidAmount = new PayableAmount
                        {
                            currencyID = grupo.Moneda,
                            value = grupo.Exportacion
                        },
                        InstructionId = "04"
                    });
                }
                if (grupo.Gratuitas > 0)
                {
                    linea.BillingPayments.Add(new BillingPayment
                    {
                        PaidAmount = new PayableAmount
                        {
                            currencyID = grupo.Moneda,
                            value = grupo.Gratuitas
                        },
                        InstructionId = "05"
                    });
                }
                summary.SummaryDocumentsLines.Add(linea);
            }

            return summary;
        }
    }
}
