using System;
using System.Collections.Generic;
using OpenInvoicePeru.Comun;
using OpenInvoicePeru.Comun.Dto.Contratos;
using OpenInvoicePeru.Comun.Dto.Modelos;
using OpenInvoicePeru.Estructuras.CommonAggregateComponents;
using OpenInvoicePeru.Estructuras.CommonBasicComponents;
using OpenInvoicePeru.Estructuras.EstandarUbl;
using OpenInvoicePeru.Estructuras.SunatAggregateComponents;

namespace OpenInvoicePeru.Xml
{
    public class GuiaRemisionXml : IDocumentoXml
    {
        IEstructuraXml IDocumentoXml.Generar(IDocumentoElectronico request)
        {
            var documento = (GuiaRemision)request;
            var despatchAdvice = new DespatchAdvice
            {
                Id = documento.IdDocumento,
                IssueDate = Convert.ToDateTime(documento.FechaEmision),
                CustomizationId = "1.0",
                UblVersionId = "2.0",
                DespatchAdviceTypeCode = documento.TipoDocumento,
                Note = documento.Glosa,
                Signature = new SignatureCac
                {
                    Id = documento.IdDocumento,
                    SignatoryParty = new SignatoryParty
                    {
                        PartyIdentification = new PartyIdentification
                        {
                            Id = new PartyIdentificationId
                            {
                                Value = documento.Remitente.NroDocumento
                            }
                        },
                        PartyName = new PartyName
                        {
                            Name = documento.Remitente.NombreLegal
                        }
                    },
                    DigitalSignatureAttachment = new DigitalSignatureAttachment
                    {
                        ExternalReference = new ExternalReference
                        {
                            Uri = $"{documento.Remitente.NroDocumento}-{documento.IdDocumento}"
                        }
                    }
                },
                DespatchSupplierParty = new AccountingSupplierParty
                {
                    CustomerAssignedAccountId = documento.Remitente.NroDocumento,
                    AdditionalAccountId = documento.Remitente.TipoDocumento,
                    Party = new Party
                    {
                        PartyLegalEntity = new PartyLegalEntity
                        {
                            RegistrationName = documento.Remitente.NombreLegal
                        }
                    }
                },
                DeliveryCustomerParty = new AccountingSupplierParty
                {
                    CustomerAssignedAccountId = documento.Destinatario.NroDocumento,
                    AdditionalAccountId = documento.Destinatario.TipoDocumento,
                    Party = new Party
                    {
                        PartyLegalEntity = new PartyLegalEntity
                        {
                            RegistrationName = documento.Destinatario.NombreLegal
                        }
                    }
                },
            };

            if (!string.IsNullOrEmpty(documento.Tercero?.NroDocumento))
            {
                despatchAdvice.SellerSupplierParty = new AccountingSupplierParty
                {
                    CustomerAssignedAccountId = documento.Tercero.NroDocumento,
                    AdditionalAccountId = documento.Tercero.TipoDocumento,
                    Party = new Party
                    {
                        PartyLegalEntity = new PartyLegalEntity
                        {
                            RegistrationName = documento.Tercero.NombreLegal
                        }
                    }
                };
            }

            if (documento.DocumentoRelacionado != null)
            {
                despatchAdvice.AdditionalDocumentReference = new InvoiceDocumentReference
                {
                    Id = documento.DocumentoRelacionado.NroDocumento,
                    DocumentTypeCode = documento.DocumentoRelacionado.TipoDocumento
                };
            }

            if (documento.GuiaBaja != null)
            {
                despatchAdvice.OrderReference = new OrderReference
                {
                    Id = documento.GuiaBaja.NroDocumento,
                    OrderTypeCode = new OrderTypeCode
                    {
                        Name = "Guia de Remision",
                        Value = documento.GuiaBaja.TipoDocumento
                    }
                };
            }

            despatchAdvice.Shipment = new Shipment
            {
                HandlingCode = documento.CodigoMotivoTraslado,
                Information = documento.DescripcionMotivo,
                SplitConsignmentIndicator = documento.Transbordo,
                GrossWeightMeasure = new InvoicedQuantity
                {
                    UnitCode = "KG",
                    Value = documento.PesoBrutoTotal
                },
                TotalTransportHandlingUnitQuantity = documento.NroPallets,
                ShipmentStages = new List<ShipmentStage>
                {
                    new ShipmentStage
                    {
                        Id = 1,
                        TransportModeCode = documento.ModalidadTraslado,
                        TransitPeriodStartPeriod = Convert.ToDateTime(documento.FechaInicioTraslado),
                        CarrierParty = new CarrierParty
                        {
                            PartyIdentification = new PartyIdentification
                            {
                                Id = new PartyIdentificationId
                                {
                                    SchemeId = "6",
                                    Value = documento.RucTransportista
                                }
                            },
                            PartyLegalEntity = new PartyLegalEntity
                            {
                                RegistrationName = documento.RazonSocialTransportista
                            }
                        },
                        DriverPerson = new PartyIdentification
                        {
                            Id = new PartyIdentificationId
                            {
                                SchemeId = "1",
                                Value = documento.NroDocumentoConductor
                            }
                        },
                        TransportMeans = new SunatRoadTransport
                        {
                            LicensePlateId = documento.NroPlacaVehiculo
                        }
                    }
                },
                DeliveryAddress = new PostalAddress
                {
                    Id = documento.DireccionLlegada.Ubigeo,
                    StreetName = documento.DireccionLlegada.DireccionCompleta
                },
                OriginAddress = new PostalAddress
                {
                    Id = documento.DireccionPartida.Ubigeo,
                    StreetName = documento.DireccionPartida.DireccionCompleta
                },
                TransportHandlingUnit = new TransportHandlingUnit
                {
                    Id = documento.NroPlacaVehiculo,
                    TransportEquipments = new List<TransportEquipment>
                    {
                        new TransportEquipment
                        {
                            Id = documento.NumeroContenedor
                        }
                    }
                },
                FirstArrivalPortLocationId = documento.CodigoPuerto
            };

            foreach (var detalleGuia in documento.BienesATransportar)
            {
                despatchAdvice.DespatchLines.Add(new DespatchLine
                {
                    Id = detalleGuia.Correlativo,
                    DeliveredQuantity = new InvoicedQuantity
                    {
                        UnitCode = detalleGuia.UnidadMedida,
                        Value = detalleGuia.Cantidad
                    },
                    Item = new DespatchLineItem
                    {
                        Description = detalleGuia.Descripcion,
                        SellersIdentificationId = detalleGuia.CodigoItem
                    },
                    OrderLineReferenceId = detalleGuia.LineaReferencia
                });
            }

            return despatchAdvice;
        }
    }
}