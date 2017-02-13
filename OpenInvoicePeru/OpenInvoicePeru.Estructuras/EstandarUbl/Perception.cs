using OpenInvoicePeru.Comun;
using OpenInvoicePeru.Comun.Constantes;
using OpenInvoicePeru.Estructuras.CommonAggregateComponents;
using OpenInvoicePeru.Estructuras.CommonBasicComponents;
using OpenInvoicePeru.Estructuras.CommonExtensionComponents;
using OpenInvoicePeru.Estructuras.SunatAggregateComponents;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace OpenInvoicePeru.Estructuras.EstandarUbl
{
    [Serializable]
    public class Perception : IXmlSerializable, IEstructuraXml
    {
        public string UblVersionId { get; set; }

        public string CustomizationId { get; set; }

        public string Id { get; set; }

        public UblExtensions UblExtensions { get; set; }

        public SignatureCac Signature { get; set; }

        public string IssueDate { get; set; }

        public AgentParty AgentParty { get; set; }

        public AgentParty ReceiverParty { get; set; }

        public string SunatPerceptionSystemCode { get; set; }

        public decimal SunatPerceptionPercent { get; set; }

        public string Note { get; set; }

        public PayableAmount TotalInvoiceAmount { get; set; }

        public PayableAmount TotalPaid { get; set; }

        public List<SunatRetentionDocumentReference> SunatPerceptionDocumentReference { get; set; }

        public IFormatProvider Formato { get; set; }

        public Perception()
        {
            UblExtensions = new UblExtensions();
            AgentParty = new AgentParty();
            ReceiverParty = new AgentParty();
            TotalInvoiceAmount = new PayableAmount();
            TotalPaid = new PayableAmount();
            SunatPerceptionDocumentReference = new List<SunatRetentionDocumentReference>();

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
            writer.WriteAttributeString("xmlns", EspacioNombres.xmlnsPerception);
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

                    #endregion ExtensionContent

                    writer.WriteEndElement();
                }

                #endregion UBLExtension

                writer.WriteEndElement();
            }

            #endregion UBLExtensions

            writer.WriteElementString("cbc:UBLVersionID", UblVersionId);
            writer.WriteElementString("cbc:CustomizationID", CustomizationId);

            #region Signature

            writer.WriteStartElement("cac:Signature");
            {
                writer.WriteElementString("cbc:ID", Signature.Id);

                #region SignatoryParty

                writer.WriteStartElement("cac:SignatoryParty");
                {
                    writer.WriteStartElement("cac:PartyIdentification");
                    {
                        writer.WriteElementString("cbc:ID", Signature.SignatoryParty.PartyIdentification.Id.Value);
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

                    #endregion PartyName
                }
                writer.WriteEndElement();

                #endregion SignatoryParty

                #region DigitalSignatureAttachment

                writer.WriteStartElement("cac:DigitalSignatureAttachment");
                {
                    writer.WriteStartElement("cac:ExternalReference");
                    {
                        writer.WriteElementString("cbc:URI", Signature.DigitalSignatureAttachment.ExternalReference.Uri);
                    }
                    writer.WriteEndElement();

                    #endregion DigitalSignatureAttachment
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            #endregion Signature

            writer.WriteElementString("cbc:ID", Id);
            writer.WriteElementString("cbc:IssueDate", IssueDate);

            #region AgentParty

            writer.WriteStartElement("cac:AgentParty");

            #region PartyIdentification

            writer.WriteStartElement("cac:PartyIdentification");

            writer.WriteStartElement("cbc:ID");
            writer.WriteAttributeString("schemeID", AgentParty.PartyIdentification.Id.SchemeId);
            writer.WriteValue(AgentParty.PartyIdentification.Id.Value);
            writer.WriteEndElement();

            writer.WriteEndElement();

            #endregion PartyIdentification

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

            #endregion PartyName

            #region PostalAddress

            writer.WriteStartElement("cac:PostalAddress");
            writer.WriteElementString("cbc:ID", AgentParty.PostalAddress.Id);
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

            #endregion Country

            writer.WriteEndElement();

            #endregion PostalAddress

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

            #endregion PartyLegalEntity

            writer.WriteEndElement();

            #endregion AgentParty

            #region ReceiverParty

            writer.WriteStartElement("cac:ReceiverParty");
            {
                #region PartyIdentification

                writer.WriteStartElement("cac:PartyIdentification");
                {
                    writer.WriteStartElement("cbc:ID");
                    {
                        writer.WriteAttributeString("schemeID", ReceiverParty.PartyIdentification.Id.SchemeId);
                        writer.WriteValue(ReceiverParty.PartyIdentification.Id.Value);
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                #endregion PartyIdentification

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

                #endregion PartyName

                #region PostalAddress

                writer.WriteStartElement("cac:PostalAddress");
                {
                    if (!string.IsNullOrEmpty(ReceiverParty.PostalAddress.Id))
                        writer.WriteElementString("cbc:ID", ReceiverParty.PostalAddress.Id);
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

                    #endregion Country
                }
                writer.WriteEndElement();

                #endregion PostalAddress

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

                #endregion PartyLegalEntity

                writer.WriteEndElement();
            }

            #endregion ReceiverParty

            writer.WriteElementString("sac:SUNATPerceptionSystemCode", SunatPerceptionSystemCode);
            writer.WriteElementString("sac:SUNATPerceptionPercent", SunatPerceptionPercent.ToString(Formatos.FormatoNumerico, Formato));
            if (!string.IsNullOrEmpty(Note))
                writer.WriteElementString("cbc:Note", Note);

            writer.WriteStartElement("cbc:TotalInvoiceAmount");
            {
                writer.WriteAttributeString("currencyID", TotalInvoiceAmount.CurrencyId);
                writer.WriteValue(TotalInvoiceAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
            }
            writer.WriteEndElement();

            writer.WriteStartElement("sac:SUNATTotalCashed");
            {
                writer.WriteAttributeString("currencyID", TotalPaid.CurrencyId);
                writer.WriteValue(TotalPaid.Value.ToString(Formatos.FormatoNumerico, Formato));
            }
            writer.WriteEndElement();

            #region SUNATPerceptionDocumentReference

            foreach (var info in SunatPerceptionDocumentReference)
            {
                writer.WriteStartElement("sac:SUNATPerceptionDocumentReference");

                #region ID

                writer.WriteStartElement("cbc:ID");
                {
                    writer.WriteAttributeString("schemeID", info.Id.SchemeId);
                    writer.WriteValue(info.Id.Value);
                }
                writer.WriteEndElement();

                #endregion ID

                writer.WriteElementString("cbc:IssueDate", info.IssueDate);

                #region TotalInvoiceAmount

                writer.WriteStartElement("cbc:TotalInvoiceAmount");
                {
                    writer.WriteAttributeString("currencyID", info.TotalInvoiceAmount.CurrencyId);
                    writer.WriteValue(info.TotalInvoiceAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                }
                writer.WriteEndElement();

                #endregion TotalInvoiceAmount

                #region Payment

                writer.WriteStartElement("cac:Payment");
                {
                    writer.WriteElementString("cbc:ID", info.Payment.IdPayment.ToString());

                    writer.WriteStartElement("cbc:PaidAmount");
                    {
                        writer.WriteAttributeString("currencyID", info.Payment.PaidAmount.CurrencyId);
                        writer.WriteValue(info.Payment.PaidAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                        writer.WriteEndElement();
                    }
                    writer.WriteElementString("cbc:PaidDate", info.Payment.PaidDate);
                }
                writer.WriteEndElement();

                #endregion Payment

                #region SUNATPerceptionInformation

                writer.WriteStartElement("sac:SUNATPerceptionInformation");
                {
                    #region SUNATPerceptionAmount

                    writer.WriteStartElement("sac:SUNATPerceptionAmount");
                    {
                        writer.WriteAttributeString("currencyID", info.SunatRetentionInformation.SunatRetentionAmount.CurrencyId);
                        writer.WriteValue(info.SunatRetentionInformation.SunatRetentionAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();

                    #endregion SUNATPerceptionAmount

                    writer.WriteElementString("sac:SUNATPerceptionDate", info.SunatRetentionInformation.SunatRetentionDate);

                    #region SUNATNetTotalCashed

                    writer.WriteStartElement("sac:SUNATNetTotalCashed");
                    {
                        writer.WriteAttributeString("currencyID", info.SunatRetentionInformation.SunatNetTotalPaid.CurrencyId);
                        writer.WriteValue(info.SunatRetentionInformation.SunatNetTotalPaid.Value.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();

                    #endregion SUNATNetTotalCashed

                    #region ExchangeRate

                    writer.WriteStartElement("cac:ExchangeRate");
                    {
                        writer.WriteElementString("cbc:SourceCurrencyCode", info.SunatRetentionInformation.ExchangeRate.SourceCurrencyCode);
                        writer.WriteElementString("cbc:TargetCurrencyCode", info.SunatRetentionInformation.ExchangeRate.TargetCurrencyCode);
                        writer.WriteElementString("cbc:CalculationRate", info.SunatRetentionInformation.ExchangeRate.CalculationRate.ToString(Formatos.FormatoNumerico, Formato));
                        writer.WriteElementString("cbc:Date",
                            !string.IsNullOrEmpty(info.SunatRetentionInformation.ExchangeRate.Date)
                                ? info.SunatRetentionInformation.ExchangeRate.Date
                                : info.SunatRetentionInformation.SunatRetentionDate);
                    }
                    writer.WriteEndElement();

                    #endregion ExchangeRate
                }
                writer.WriteEndElement();

                #endregion SUNATPerceptionInformation

                writer.WriteEndElement();
            }

            #endregion SUNATPerceptionDocumentReference
        }
    }
}