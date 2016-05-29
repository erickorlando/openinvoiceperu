using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ErickOrlando.FirmadoSunat.Estructuras
{

    [Serializable]
    public class Retention : IXmlSerializable
    {
        public string UBLVersionID { get; set; }
        public string CustomizationID { get; set; }
        public UBLExtensions UBLExtensions { get; set; }
        public SignatureCac Signature { get; set; }
        public string ID { get; set; }
        public string IssueDate { get; set; }
        public AgentParty AgentParty { get; set; }
        public ReceiverParty ReceiverParty { get; set; }
        public string SUNATRetentionSystemCode { get; set; }
        public decimal SUNATRetentionPercent { get; set; }
        public string Note { get; set; }
        public PayableAmount TotalInvoiceAmount { get; set; }
        public PayableAmount TotalPaid { get; set; }
        public List<SUNATRetentionDocumentReference> SUNATRetentionDocumentReference { get; set; }
        public IFormatProvider Formato { get; set; }
        public Retention()
        {
            UBLExtensions = new UBLExtensions();
            AgentParty = new AgentParty();
            ReceiverParty = new ReceiverParty();
            TotalInvoiceAmount = new PayableAmount();
            TotalPaid = new PayableAmount();
            SUNATRetentionDocumentReference = new List<SUNATRetentionDocumentReference>();

            UBLVersionID = "2.0";
            CustomizationID = "1.0";
            Formato = new System.Globalization.CultureInfo("es-PE");
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement("ext:Extensions");
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("xmlns", EspacioNombres.xmlnsRetention);
            writer.WriteAttributeString("xmlns:cac", EspacioNombres.cac);
            writer.WriteAttributeString("xmlns:cbc", EspacioNombres.cbc);
            writer.WriteAttributeString("xmlns:ccts", EspacioNombres.ccts);
            writer.WriteAttributeString("xmlns:ds", EspacioNombres.ds);
            writer.WriteAttributeString("xmlns:ext", EspacioNombres.ext);
            writer.WriteAttributeString("xmlns:qdt", EspacioNombres.qdt);
            writer.WriteAttributeString("xmlns:sac", EspacioNombres.sac);
            writer.WriteAttributeString("xmlns:udt", EspacioNombres.udt);
            writer.WriteAttributeString("xmlns:xsi", EspacioNombres.xsi);
            //writer.WriteAttributeString("xmlns:schemaLocation", EspacioNombres.schemaLocation);


            #region UBLExtensions
            {
                writer.WriteStartElement("ext:UBLExtensions");
                #region UBLExtension
                {
                    writer.WriteStartElement("ext:UBLExtension");
                    #region ExtensionContent
                    {
                        writer.WriteStartElement("ext:ExtensionContent");



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

            #region Signature
            writer.WriteStartElement("cac:Signature");
            {
                writer.WriteElementString("cbc:ID", Signature.ID);

                #region SignatoryParty

                writer.WriteStartElement("cac:SignatoryParty");
                {
                    writer.WriteStartElement("cac:PartyIdentification");
                    {
                        writer.WriteElementString("cbc:ID", Signature.SignatoryParty.PartyIdentification.ID.value);
                    }
                    writer.WriteEndElement();

                    #region PartyName
                    writer.WriteStartElement("cac:PartyName");
                    {
                        writer.WriteStartElement("cbc:Name");
                        writer.WriteCData(Signature.SignatoryParty.PartyName.Name);
                        writer.WriteEndElement();
                        //writer.WriteElementString("cbc:Name", Signature.SignatoryParty.PartyName.Name);
                    }
                    writer.WriteEndElement();
                    #endregion
                }
                writer.WriteEndElement();
                #endregion

                #region DigitalSignatureAttachment
                writer.WriteStartElement("cac:DigitalSignatureAttachment");
                {
                    writer.WriteStartElement("cac:ExternalReference");
                    {
                        writer.WriteElementString("cbc:URI", Signature.DigitalSignatureAttachment.ExternalReference.URI);
                    }
                    writer.WriteEndElement();
                    #endregion
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            #endregion

            writer.WriteElementString("cbc:ID", ID);
            writer.WriteElementString("cbc:IssueDate", IssueDate);

            #region AgentParty
            writer.WriteStartElement("cac:AgentParty");
            #region PartyIdentification
            writer.WriteStartElement("cac:PartyIdentification");

            writer.WriteStartElement("cbc:ID");
            writer.WriteAttributeString("schemeID", AgentParty.PartyIdentification.ID.schemeID);
            writer.WriteValue(AgentParty.PartyIdentification.ID.value);
            writer.WriteEndElement();

            writer.WriteEndElement();
            #endregion

            #region PartyName
            writer.WriteStartElement("cac:PartyName");
            {

                writer.WriteStartElement("cbc:Name");
                {
                    writer.WriteCData(AgentParty.PartyName.Name);
                }
                writer.WriteEndElement();
                //writer.WriteElementString("cbc:Name", AgentParty.PartyName.Name);
            }
            writer.WriteEndElement();
            #endregion

            #region PostalAddress
            writer.WriteStartElement("cac:PostalAddress");
            writer.WriteElementString("cbc:ID", AgentParty.PostalAddress.ID);
            writer.WriteStartElement("cbc:StreetName");
            {
                writer.WriteCData(AgentParty.PostalAddress.StreetName);
            }
            writer.WriteEndElement();
            //writer.WriteElementString("cbc:StreetName", AgentParty.PostalAddress.StreetName);
            writer.WriteElementString("cbc:CitySubdivisionName", AgentParty.PostalAddress.CitySubdivisionName);
            writer.WriteElementString("cbc:CityName", AgentParty.PostalAddress.CityName);
            writer.WriteElementString("cbc:CountrySubentity", AgentParty.PostalAddress.CountrySubentity);
            writer.WriteElementString("cbc:District", AgentParty.PostalAddress.District);

            #region Country
            writer.WriteStartElement("cac:Country");
            writer.WriteElementString("cbc:IdentificationCode",
                AgentParty.PostalAddress.Country.IdentificationCode);
            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            #region PartyLegalEntity
            writer.WriteStartElement("cac:PartyLegalEntity");
            {
                writer.WriteStartElement("cbc:RegistrationName");
                {
                    writer.WriteCData(AgentParty.PartyLegalEntity.RegistrationName);
                }
                writer.WriteEndElement();
                //writer.WriteElementString("cbc:RegistrationName", AgentParty.PartyLegalEntity.RegistrationName);
            }
            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            #region ReceiverParty
            writer.WriteStartElement("cac:ReceiverParty");
            {
                #region PartyIdentification
                writer.WriteStartElement("cac:PartyIdentification");
                {
                    writer.WriteStartElement("cbc:ID");
                    {
                        writer.WriteAttributeString("schemeID", ReceiverParty.PartyIdentification.ID.schemeID);
                        writer.WriteValue(ReceiverParty.PartyIdentification.ID.value);
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                #endregion

                #region PartyName
                writer.WriteStartElement("cac:PartyName");
                {
                    writer.WriteStartElement("cbc:Name");
                    {
                        writer.WriteCData(ReceiverParty.PartyName.Name);
                    }
                    writer.WriteEndElement();
                    //writer.WriteElementString("cbc:Name", ReceiverParty.PartyName.Name);
                }
                writer.WriteEndElement();
                #endregion

                #region PostalAddress
                writer.WriteStartElement("cac:PostalAddress");
                {
                    if (!string.IsNullOrEmpty(ReceiverParty.PostalAddress.ID))
                        writer.WriteElementString("cbc:ID", ReceiverParty.PostalAddress.ID);
                    writer.WriteElementString("cbc:StreetName", ReceiverParty.PostalAddress.StreetName);
                    writer.WriteElementString("cbc:CitySubdivisionName", ReceiverParty.PostalAddress.CitySubdivisionName);
                    writer.WriteElementString("cbc:CityName", ReceiverParty.PostalAddress.CityName);
                    writer.WriteElementString("cbc:CountrySubentity", ReceiverParty.PostalAddress.CountrySubentity);
                    writer.WriteElementString("cbc:District", ReceiverParty.PostalAddress.District);

                    #region Country
                    writer.WriteStartElement("cac:Country");
                    {
                        writer.WriteElementString("cbc:IdentificationCode",
                            ReceiverParty.PostalAddress.Country.IdentificationCode);
                        writer.WriteEndElement();
                    }
                    #endregion
                }
                writer.WriteEndElement();
                #endregion

                #region PartyLegalEntity
                writer.WriteStartElement("cac:PartyLegalEntity");
                {
                    writer.WriteStartElement("cbc:RegistrationName");
                    {
                        writer.WriteCData(ReceiverParty.PartyLegalEntity.RegistrationName);
                    }
                    writer.WriteEndElement();
                    //writer.WriteElementString("cbc:RegistrationName", ReceiverParty.PartyLegalEntity.RegistrationName);
                }
                writer.WriteEndElement();
                #endregion

                writer.WriteEndElement();
            }
            #endregion

            writer.WriteElementString("sac:SUNATRetentionSystemCode", SUNATRetentionSystemCode);
            writer.WriteElementString("sac:SUNATRetentionPercent", SUNATRetentionPercent.ToString(Constantes.Constantes.FormatoNumerico, Formato));
            if (!string.IsNullOrEmpty(Note))
                writer.WriteElementString("cbc:Note", Note);

            writer.WriteStartElement("cbc:TotalInvoiceAmount");
            {
                writer.WriteAttributeString("currencyID", TotalInvoiceAmount.currencyID);
                writer.WriteValue(TotalInvoiceAmount.value.ToString(Constantes.Constantes.FormatoNumerico, Formato));
            }
            writer.WriteEndElement();


            writer.WriteStartElement("sac:SUNATTotalPaid");
            {
                writer.WriteAttributeString("currencyID", TotalPaid.currencyID);
                writer.WriteValue(TotalPaid.value.ToString(Constantes.Constantes.FormatoNumerico, Formato));
            }
            writer.WriteEndElement();


            #region SUNATRetentionDocumentReference
            foreach (var info in SUNATRetentionDocumentReference)
            {
                writer.WriteStartElement("sac:SUNATRetentionDocumentReference");

                #region ID
                writer.WriteStartElement("cbc:ID");
                {
                    writer.WriteAttributeString("schemeID", info.ID.schemeID);
                    writer.WriteValue(info.ID.value);
                }
                writer.WriteEndElement();
                #endregion

                writer.WriteElementString("cbc:IssueDate", info.IssueDate);

                #region TotalInvoiceAmount
                writer.WriteStartElement("cbc:TotalInvoiceAmount");
                {
                    writer.WriteAttributeString("currencyID", info.TotalInvoiceAmount.currencyID);
                    writer.WriteValue(info.TotalInvoiceAmount.value.ToString(Constantes.Constantes.FormatoNumerico, Formato));
                }
                writer.WriteEndElement();
                #endregion

                #region Payment
                writer.WriteStartElement("cac:Payment");
                {
                    writer.WriteElementString("cbc:ID", info.Payment.IdPayment.ToString());

                    writer.WriteStartElement("cbc:PaidAmount");
                    {
                        writer.WriteAttributeString("currencyID", info.Payment.PaidAmount.currencyID);
                        writer.WriteValue(info.Payment.PaidAmount.value.ToString(Constantes.Constantes.FormatoNumerico, Formato));
                        writer.WriteEndElement();
                    }
                    writer.WriteElementString("cbc:PaidDate", info.Payment.PaidDate);
                }
                writer.WriteEndElement();
                #endregion

                #region SUNATRetentionInformation
                writer.WriteStartElement("sac:SUNATRetentionInformation");
                {
                    #region SUNATRetentionAmount
                    writer.WriteStartElement("sac:SUNATRetentionAmount");
                    {
                        writer.WriteAttributeString("currencyID", info.SUNATRetentionInformation.SUNATRetentionAmount.currencyID);
                        writer.WriteValue(info.SUNATRetentionInformation.SUNATRetentionAmount.value.ToString(Constantes.Constantes.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();
                    #endregion

                    writer.WriteElementString("sac:SUNATRetentionDate", info.SUNATRetentionInformation.SUNATRetentionDate);

                    #region SUNATNetTotalPaid
                    writer.WriteStartElement("sac:SUNATNetTotalPaid");
                    {
                        writer.WriteAttributeString("currencyID", info.SUNATRetentionInformation.SUNATNetTotalPaid.currencyID);
                        writer.WriteValue(info.SUNATRetentionInformation.SUNATNetTotalPaid.value.ToString(Constantes.Constantes.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();
                    #endregion


                    #region ExchangeRate

                    //if (info.Payment.PaidAmount.currencyID.Trim() != "PEN")
                    //{
                    writer.WriteStartElement("cac:ExchangeRate");
                    {
                        writer.WriteElementString("cbc:SourceCurrencyCode", info.SUNATRetentionInformation.ExchangeRate.SourceCurrencyCode);
                        writer.WriteElementString("cbc:TargetCurrencyCode", info.SUNATRetentionInformation.ExchangeRate.TargetCurrencyCode);
                        writer.WriteElementString("cbc:CalculationRate", info.SUNATRetentionInformation.ExchangeRate.CalculationRate.ToString(Constantes.Constantes.FormatoNumerico, Formato));
                        writer.WriteElementString("cbc:Date",
                            !string.IsNullOrEmpty(info.SUNATRetentionInformation.ExchangeRate.Date)
                                ? info.SUNATRetentionInformation.ExchangeRate.Date
                                : info.SUNATRetentionInformation.SUNATRetentionDate);
                    }
                    writer.WriteEndElement();
                    //}

                    #endregion
                }
                writer.WriteEndElement();
                #endregion

                writer.WriteEndElement();
            }
            #endregion
        }
    }
}
