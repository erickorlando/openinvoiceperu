using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using OpenInvoicePeru.Comun;
using OpenInvoicePeru.Comun.Constantes;
using OpenInvoicePeru.Estructuras.CommonAggregateComponents;
using OpenInvoicePeru.Estructuras.CommonExtensionComponents;

namespace OpenInvoicePeru.Estructuras.EstandarUbl
{
    [Serializable]
    public class DespatchAdvice : IXmlSerializable, IEstructuraXml
    {
        public UblExtensions UblExtensions { get; set; }

        public string UblVersionId { get; set; }

        public string CustomizationId { get; set; }

        public string Id { get; set; }

        public DateTime IssueDate { get; set; }

        public string DespatchAdviceTypeCode { get; set; }

        public string Note { get; set; }

        public OrderReference OrderReference { get; set; }

        public InvoiceDocumentReference AdditionalDocumentReference { get; set; }

        public SignatureCac Signature { get; set; }

        public AccountingSupplierParty DespatchSupplierParty { get; set; }

        public AccountingSupplierParty DeliveryCustomerParty { get; set; }

        public AccountingSupplierParty SellerSupplierParty { get; set; }

        public Shipment Shipment { get; set; }

        public List<DespatchLine> DespatchLines { get; set; }

        public IFormatProvider Formato { get; set; }

        public DespatchAdvice()
        {
            UblExtensions = new UblExtensions();
            OrderReference = new OrderReference();
            AdditionalDocumentReference = new InvoiceDocumentReference();
            Signature = new SignatureCac();
            DespatchSupplierParty = new AccountingSupplierParty();
            DeliveryCustomerParty = new AccountingSupplierParty();
            SellerSupplierParty = new AccountingSupplierParty();
            Shipment = new Shipment();
            DespatchLines = new List<DespatchLine>();
            UblVersionId = "2.0";
            CustomizationId = "1.0";
            Formato = new System.Globalization.CultureInfo(Formatos.Cultura);
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("xmlns", EspacioNombres.xmlnsDespatchAdvice);
            writer.WriteAttributeString("xmlns:cac", EspacioNombres.cac);
            writer.WriteAttributeString("xmlns:cbc", EspacioNombres.cbc);
            writer.WriteAttributeString("xmlns:ccts", EspacioNombres.ccts);
            writer.WriteAttributeString("xmlns:ds", EspacioNombres.ds);
            writer.WriteAttributeString("xmlns:ext", EspacioNombres.ext);
            writer.WriteAttributeString("xmlns:qdt", EspacioNombres.qdt);
            writer.WriteAttributeString("xmlns:sac", EspacioNombres.sac);
            writer.WriteAttributeString("xmlns:udt", EspacioNombres.udt);
            writer.WriteAttributeString("xmlns:xsi", EspacioNombres.xsi);

            #region UBLExtensions

            writer.WriteStartElement("ext:UBLExtensions");

            #region UBLExtension

            writer.WriteStartElement("ext:UBLExtension");

            #region ExtensionContent

            writer.WriteStartElement("ext:ExtensionContent");

            // En esta zona va el certificado digital.

            writer.WriteEndElement();

            #endregion ExtensionContent

            writer.WriteEndElement();

            #endregion UBLExtension

            writer.WriteEndElement();

            #endregion UBLExtensions

            writer.WriteElementString("cbc:UBLVersionID", UblVersionId);
            writer.WriteElementString("cbc:CustomizationID", CustomizationId);
            writer.WriteElementString("cbc:ID", Id);
            writer.WriteElementString("cbc:IssueDate", IssueDate.ToString(Formatos.FormatoFecha));
            writer.WriteElementString("cbc:DespatchAdviceTypeCode", DespatchAdviceTypeCode);
            if (!string.IsNullOrEmpty(Note))
                writer.WriteElementString("cbc:Note", Note);

            #region OrderReference

            if (!string.IsNullOrEmpty(OrderReference.Id))
            {
                writer.WriteStartElement("cac:OrderReference");
                {
                    writer.WriteElementString("cbc:ID", OrderReference.Id);

                    writer.WriteStartElement("cbc:OrderTypeCode");
                    {
                        writer.WriteAttributeString("name", OrderReference.OrderTypeCode.Name);
                        writer.WriteValue(OrderReference.OrderTypeCode.Value);
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            #endregion OrderReference

            #region AdditionalDocumentReference

            if (!string.IsNullOrEmpty(AdditionalDocumentReference.Id))
            {
                writer.WriteStartElement("cac:AdditionalDocumentReference");
                {
                    writer.WriteElementString("cbc:ID", AdditionalDocumentReference.Id);
                    writer.WriteElementString("cbc:DocumentTypeCode", AdditionalDocumentReference.DocumentTypeCode);
                }
                writer.WriteEndElement();
            }

            #endregion AdditionalDocumentReference

            #region Signature

            writer.WriteStartElement("cac:Signature");
            {
                writer.WriteElementString("cbc:ID", Signature.Id);

                #region SignatoryParty

                writer.WriteStartElement("cac:SignatoryParty");
                {
                    writer.WriteStartElement("cac:PartyIdentification");
                    writer.WriteElementString("cbc:ID", Signature.SignatoryParty.PartyIdentification.Id.Value);
                }
                writer.WriteEndElement();

                #region PartyName

                writer.WriteStartElement("cac:PartyName");
                {
                    writer.WriteElementString("cbc:Name", Signature.SignatoryParty.PartyName.Name);
                }
                writer.WriteEndElement();

                #endregion PartyName

                writer.WriteEndElement();

                #endregion SignatoryParty

                #region DigitalSignatureAttachment

                writer.WriteStartElement("cac:DigitalSignatureAttachment");
                {
                    writer.WriteStartElement("cac:ExternalReference");
                    {
                        writer.WriteElementString("cbc:URI", Signature.DigitalSignatureAttachment.ExternalReference.Uri.Trim());
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                #endregion DigitalSignatureAttachment
            }

            writer.WriteEndElement();

            #endregion Signature

            #region DespatchSupplierParty

            writer.WriteStartElement("cac:DespatchSupplierParty");
            {
                writer.WriteStartElement("cbc:CustomerAssignedAccountID");
                {
                    writer.WriteAttributeString("schemeID", DespatchSupplierParty.AdditionalAccountId);
                    writer.WriteValue(DespatchSupplierParty.CustomerAssignedAccountId);
                }
                writer.WriteEndElement();

                writer.WriteStartElement("cac:Party");
                {
                    writer.WriteStartElement("cac:PartyLegalEntity");
                    {
                        writer.WriteElementString("cbc:RegistrationName", DespatchSupplierParty.Party.PartyLegalEntity.RegistrationName);
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            #endregion DespatchSupplierParty

            #region DeliveryCustomerParty

            writer.WriteStartElement("cac:DeliveryCustomerParty");
            {
                writer.WriteStartElement("cbc:CustomerAssignedAccountID");
                {
                    writer.WriteAttributeString("schemeID", DeliveryCustomerParty.AdditionalAccountId);
                    writer.WriteValue(DeliveryCustomerParty.CustomerAssignedAccountId);
                }
                writer.WriteEndElement();

                writer.WriteStartElement("cac:Party");
                {
                    writer.WriteStartElement("cac:PartyLegalEntity");
                    {
                        writer.WriteElementString("cbc:RegistrationName", DeliveryCustomerParty.Party.PartyLegalEntity.RegistrationName);
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            #endregion DeliveryCustomerParty

            #region SellerSupplierParty

            if (!string.IsNullOrEmpty(SellerSupplierParty.AdditionalAccountId))
            {
                writer.WriteStartElement("cac:SellerSupplierParty");
                {
                    writer.WriteStartElement("cbc:CustomerAssignedAccountID");
                    {
                        writer.WriteAttributeString("schemeID", SellerSupplierParty.AdditionalAccountId);
                        writer.WriteValue(SellerSupplierParty.CustomerAssignedAccountId);
                    }
                    writer.WriteEndElement();

                    writer.WriteStartElement("cac:Party");
                    {
                        writer.WriteStartElement("cac:PartyLegalEntity");
                        {
                            writer.WriteElementString("cbc:RegistrationName", SellerSupplierParty.Party.PartyLegalEntity.RegistrationName);
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            #endregion SellerSupplierParty

            #region Shipment

            writer.WriteStartElement("cac:Shipment");
            {
                writer.WriteElementString("cbc:HandlingCode", Shipment.HandlingCode);
                writer.WriteElementString("cbc:Information", Shipment.Information);
                writer.WriteElementString("cbc:SplitConsignmentIndicator",
                    Shipment.SplitConsignmentIndicator.ToString().ToLower());

                writer.WriteStartElement("cbc:GrossWeightMeasure");
                {
                    writer.WriteAttributeString("unitCode", Shipment.GrossWeightMeasure.UnitCode);
                    writer.WriteValue(Shipment.GrossWeightMeasure.Value.ToString(Formatos.FormatoNumerico, Formato));
                }
                writer.WriteEndElement();
                writer.WriteElementString("cbc:TotalTransportHandlingUnitQuantity", Shipment.TotalTransportHandlingUnitQuantity.ToString());

                #region ShipmentStages

                foreach (var shipmentStage in Shipment.ShipmentStages)
                {
                    writer.WriteElementString("cbc:ID", shipmentStage.Id.ToString());
                    writer.WriteElementString("cbc:TransportModeCode", shipmentStage.TransportModeCode);

                    writer.WriteStartElement("cac:TransitPeriod");
                    {
                        writer.WriteElementString("cbc:StartDate", shipmentStage.TransitPeriodStartPeriod.ToString(Formatos.FormatoFecha));
                    }
                    writer.WriteEndElement();

                    if (!string.IsNullOrEmpty(shipmentStage.CarrierParty.PartyIdentification.Id.Value))
                    {
                        writer.WriteStartElement("cac:CarrierParty");
                        {
                            writer.WriteStartElement("cac:PartyIdentification");
                            {
                                writer.WriteStartElement("cbc:ID");
                                {
                                    writer.WriteAttributeString("schemeID",
                                        shipmentStage.CarrierParty.PartyIdentification.Id.SchemeId);
                                    writer.WriteValue(shipmentStage.CarrierParty.PartyIdentification.Id.Value);
                                }
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                            writer.WriteElementString("cbc:RegistrationName",
                                shipmentStage.CarrierParty.PartyLegalEntity.RegistrationName);
                        }
                        writer.WriteEndElement();
                    }

                    writer.WriteStartElement("cac:TransportMeans");
                    {
                        writer.WriteStartElement("cac:RoadTransport");
                        {
                            writer.WriteElementString("cbc:LicensePlateID", shipmentStage.TransportMeans.LicensePlateId);
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                    writer.WriteStartElement("cac:DriverPerson");
                    {
                        writer.WriteStartElement("cbc:ID");
                        {
                            writer.WriteAttributeString("schemeID", shipmentStage.DriverPerson.Id.SchemeId);
                            writer.WriteValue(shipmentStage.DriverPerson.Id.Value);
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }

                #endregion ShipmentStages

                #region DeliveryAddress

                writer.WriteStartElement("cac:DeliveryAddress");
                {
                    writer.WriteElementString("cbc:ID", Shipment.DeliveryAddress.Id);
                    writer.WriteElementString("cbc:StreetName", Shipment.DeliveryAddress.StreetName);
                }
                writer.WriteEndElement();

                #endregion DeliveryAddress

                #region TransportHandlingUnit

                writer.WriteStartElement("cac:TransportHandlingUnit");
                {
                    // Se repite la misma placa del primer vehiculo
                    writer.WriteElementString("cbc:ID", Shipment.ShipmentStages.First().TransportMeans.LicensePlateId);
                    foreach (var transportEquipment in Shipment.TransportHandlingUnit.TransportEquipments)
                    {
                        if (string.IsNullOrEmpty(transportEquipment.Id)) continue;
                        writer.WriteStartElement("cac:TransportEquipment");
                        {
                            writer.WriteElementString("cbc:ID", transportEquipment.Id);
                        }
                        writer.WriteEndElement();
                    }
                }
                writer.WriteEndElement();

                #endregion TransportHandlingUnit

                #region OriginAddress

                writer.WriteStartElement("cac:OriginAddress");
                {
                    writer.WriteElementString("cbc:ID", Shipment.OriginAddress.Id);
                    writer.WriteElementString("cbc:StreetName", Shipment.OriginAddress.StreetName);
                }
                writer.WriteEndElement();

                #endregion OriginAddress

                #region FirstArrivalPortLocation

                if (!string.IsNullOrEmpty(Shipment.FirstArrivalPortLocationId))
                {
                    writer.WriteStartElement("cac:FirstArrivalPortLocation");
                    {
                        writer.WriteElementString("cbc:ID", Shipment.FirstArrivalPortLocationId);
                    }
                    writer.WriteEndElement();
                }

                #endregion FirstArrivalPortLocation
            }
            writer.WriteEndElement();

            #endregion Shipment

            #region DespatchLine

            foreach (var despatchLine in DespatchLines)
            {
                writer.WriteStartElement("cac:DespatchLine");
                {
                    writer.WriteElementString("cbc:ID", despatchLine.Id.ToString());

                    writer.WriteStartElement("cbc:DeliveredQuantity");
                    {
                        writer.WriteAttributeString("unitCode", despatchLine.DeliveredQuantity.UnitCode);
                        writer.WriteValue(despatchLine.DeliveredQuantity.Value.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();

                    if (despatchLine.OrderLineReferenceId > 0)
                    {
                        writer.WriteStartElement("cac:OrderLineReference");
                        {
                            writer.WriteElementString("cbc:LineID", despatchLine.OrderLineReferenceId.ToString());
                        }
                        writer.WriteEndElement();
                    }

                    writer.WriteStartElement("cac:Item");
                    {
                        writer.WriteElementString("cbc:Description", despatchLine.Item.Description);

                        writer.WriteStartElement("cac:SellersItemIdentification");
                        {
                            writer.WriteElementString("cbc:ID", despatchLine.Item.SellersIdentificationId);
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            #endregion DespatchLine
        }
    }
}