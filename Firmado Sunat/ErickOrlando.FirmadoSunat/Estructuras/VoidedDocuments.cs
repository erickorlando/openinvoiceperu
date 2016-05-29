using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ErickOrlando.FirmadoSunat.Estructuras
{
    public class VoidedDocuments : IXmlSerializable
    {

        public UBLExtensions UBLExtensions { get; set; }
        public string UBLVersionID { get; set; }
        public string CustomizationID { get; set; }
        public string ID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReferenceDate { get; set; }
        public SignatureCac Signature { get; set; }
        public AccountingSupplierParty AccountingSupplierParty { get; set; }
        public List<VoidedDocumentsLine> VoidedDocumentsLines { get; set; }


        public VoidedDocuments()
        {
            UBLExtensions = new UBLExtensions();
            Signature = new SignatureCac();
            AccountingSupplierParty = new AccountingSupplierParty();
            VoidedDocumentsLines = new List<VoidedDocumentsLine>();
            UBLVersionID = "2.0";
            CustomizationID = "1.0";
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
            writer.WriteAttributeString("xmlns", EspacioNombres.xmlnsVoidedDocuments);
            writer.WriteAttributeString("xmlns:cac", EspacioNombres.cac);
            writer.WriteAttributeString("xmlns:cbc", EspacioNombres.cbc);
            writer.WriteAttributeString("xmlns:ds", EspacioNombres.ds);
            writer.WriteAttributeString("xmlns:ext", EspacioNombres.ext);
            writer.WriteAttributeString("xmlns:sac", EspacioNombres.sac);
            writer.WriteAttributeString("xmlns:xsi", EspacioNombres.xsi);

            #region UBLExtensions
            {
                writer.WriteStartElement("ext:UBLExtensions");

                #region UBLExtension
                {
                    writer.WriteStartElement("ext:UBLExtension");
                    #region ExtensionContent
                    {
                        writer.WriteStartElement("ext:ExtensionContent");

                        // En esta zona va el certificado digital.

                        writer.WriteEndElement();

                    }
                    #endregion
                    writer.WriteEndElement();
                }
                #endregion

                writer.WriteEndElement();
            }
            #endregion

            writer.WriteElementString("cbc:UBLVersionID", UBLVersionID);
            writer.WriteElementString("cbc:CustomizationID", CustomizationID);
            writer.WriteElementString("cbc:ID", ID);
            writer.WriteElementString("cbc:ReferenceDate", ReferenceDate.ToString("yyyy-MM-dd"));
            writer.WriteElementString("cbc:IssueDate", IssueDate.ToString("yyyy-MM-dd"));

            #region Signature
            writer.WriteStartElement("cac:Signature");
            writer.WriteElementString("cbc:ID", Signature.ID);

            #region SignatoryParty

            writer.WriteStartElement("cac:SignatoryParty");

            writer.WriteStartElement("cac:PartyIdentification");
            writer.WriteElementString("cbc:ID", Signature.SignatoryParty.PartyIdentification.ID.value);
            writer.WriteEndElement();

            #region PartyName
            writer.WriteStartElement("cac:PartyName");

            //writer.WriteStartElement("cbc:Name");
            //writer.WriteCData(Signature.SignatoryParty.PartyName.Name);
            //writer.WriteEndElement();
            writer.WriteElementString("cbc:Name", Signature.SignatoryParty.PartyName.Name);

            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            #region DigitalSignatureAttachment
            writer.WriteStartElement("cac:DigitalSignatureAttachment");

            writer.WriteStartElement("cac:ExternalReference");
            writer.WriteElementString("cbc:URI", Signature.DigitalSignatureAttachment.ExternalReference.URI.Trim());
            writer.WriteEndElement();

            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            #region AccountingSupplierParty
            writer.WriteStartElement("cac:AccountingSupplierParty");

            writer.WriteElementString("cbc:CustomerAssignedAccountID", AccountingSupplierParty.CustomerAssignedAccountID);
            writer.WriteElementString("cbc:AdditionalAccountID",
                AccountingSupplierParty.AdditionalAccountID.ToString());

            #region Party
            writer.WriteStartElement("cac:Party");

            #region PartyLegalEntity
            writer.WriteStartElement("cac:PartyLegalEntity");

            {
                writer.WriteElementString("cbc:RegistrationName",
                            AccountingSupplierParty.Party.PartyLegalEntity.RegistrationName);
            }

            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            #region VoidedDocumentsLines
            foreach (var item in VoidedDocumentsLines)
            {
                writer.WriteStartElement("sac:VoidedDocumentsLine");
                {
                    writer.WriteElementString("cbc:LineID", item.LineID.ToString());
                    writer.WriteElementString("cbc:DocumentTypeCode", item.DocumentTypeCode);
                    writer.WriteElementString("sac:DocumentSerialID", item.DocumentSerialID);
                    writer.WriteElementString("sac:DocumentNumberID", item.DocumentNumberID.ToString());
                    writer.WriteElementString("sac:VoidReasonDescription", item.VoidReasonDescription);
                }
                writer.WriteEndElement();
            }
            #endregion
        }
    }
}
