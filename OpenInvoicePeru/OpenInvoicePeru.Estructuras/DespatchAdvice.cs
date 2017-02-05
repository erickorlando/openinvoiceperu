using OpenInvoicePeru.Comun;
using OpenInvoicePeru.Comun.Constantes;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace OpenInvoicePeru.Estructuras
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

            if (!string.IsNullOrEmpty(AdditionalDocumentReference.Id))
            {
                writer.WriteStartElement("cac:AdditionalDocumentReference");
                {
                    writer.WriteElementString("cbc:ID", AdditionalDocumentReference.Id);
                    writer.WriteElementString("cbc:DocumentTypeCode", AdditionalDocumentReference.DocumentTypeCode);
                }
                writer.WriteEndElement();
            }

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
        }
    }
}