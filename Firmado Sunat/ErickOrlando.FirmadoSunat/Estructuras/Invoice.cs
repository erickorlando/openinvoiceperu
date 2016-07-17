using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace OpenInvoicePeru.FirmadoSunat.Estructuras
{
    [Serializable]
    public class Invoice : IXmlSerializable
    {
        public DateTime IssueDate { get; set; }
        public UBLExtensions UblExtensions { get; set; }
        public SignatureCac Signature { get; set; }
        public AccountingSupplierParty AccountingSupplierParty { get; set; }
        public string InvoiceTypeCode { get; set; }
        public string ID { get; set; }
        public AccountingSupplierParty AccountingCustomerParty { get; set; }
        public List<InvoiceLine> InvoiceLines { get; set; }
        public string DocumentCurrencyCode { get; set; }
        public List<TaxTotal> TaxTotals { get; set; }
        public LegalMonetaryTotal LegalMonetaryTotal { get; set; }
        public string UblVersionId { get; set; }
        public string CustomizationId { get; set; }
        public IFormatProvider Formato { get; set; }

        public Invoice()
        {
            AccountingSupplierParty = new AccountingSupplierParty();
            AccountingCustomerParty = new AccountingSupplierParty();
            UblExtensions = new UBLExtensions();
            Signature = new SignatureCac();
            InvoiceLines = new List<InvoiceLine>();
            TaxTotals = new List<TaxTotal>();
            LegalMonetaryTotal = new LegalMonetaryTotal();

            UblVersionId = "2.0";
            CustomizationId = "1.0";
            Formato = new System.Globalization.CultureInfo("es-PE");
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
            writer.WriteAttributeString("xmlns", EspacioNombres.xmlnsInvoice);
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
            var ext2 = UblExtensions.Extension2.ExtensionContent.AdditionalInformation;
            writer.WriteStartElement("ext:UBLExtension");

            #region ExtensionContent
            writer.WriteStartElement("ext:ExtensionContent");

            #region AdditionalInformation
            writer.WriteStartElement("sac:AdditionalInformation");
            {


                #region AdditionalMonetaryTotal

                {

                    foreach (var additionalMonetaryTotal in ext2.AdditionalMonetaryTotals)
                    {
                        writer.WriteStartElement("sac:AdditionalMonetaryTotal");
                        writer.WriteElementString("cbc:ID", additionalMonetaryTotal.ID);

                        #region PayableAmount

                        {
                            writer.WriteStartElement("cbc:PayableAmount");
                            writer.WriteAttributeString("currencyID", additionalMonetaryTotal.PayableAmount.currencyID);
                            writer.WriteValue(additionalMonetaryTotal.PayableAmount.value.ToString(Constantes.Constantes.FormatoNumerico, Formato));
                            writer.WriteEndElement();
                        }
                        if (additionalMonetaryTotal.Percent > 0)
                        {
                            writer.WriteElementString("sac:Percent",
                                additionalMonetaryTotal.Percent.ToString("#%"));
                        }
                        #endregion

                        writer.WriteEndElement();
                    }
                }

                #endregion

                #region AdditionalProperty

                {
                    foreach (var additionalProperty in ext2.AdditionalProperties)
                    {
                        writer.WriteStartElement("sac:AdditionalProperty");
                        writer.WriteElementString("cbc:ID", additionalProperty.ID.ToString());

                        #region Value

                        writer.WriteElementString("cbc:Value", additionalProperty.Value);

                        #endregion

                        writer.WriteEndElement();
                    }
                }

                #endregion

                if (!string.IsNullOrEmpty(ext2.SunatTransaction.Id))
                {
                    writer.WriteStartElement("sac:SUNATTransaction");
                    {
                        writer.WriteElementString("cbc:ID", ext2.SunatTransaction.Id);
                    }
                    writer.WriteEndElement();
                }

            }
            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            #region UBLExtension
            var ext1 = UblExtensions.Extension1;
            writer.WriteStartElement("ext:UBLExtension");
            #region ExtensionContent
            writer.WriteStartElement("ext:ExtensionContent");

            // En esta zona va el certificado digital.

            writer.WriteEndElement();
            #endregion
            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            writer.WriteElementString("cbc:UBLVersionID", UblVersionId);
            writer.WriteElementString("cbc:CustomizationID", CustomizationId);
            writer.WriteElementString("cbc:ID", ID);
            writer.WriteElementString("cbc:IssueDate", IssueDate.ToString("yyyy-MM-dd"));
            writer.WriteElementString("cbc:InvoiceTypeCode", InvoiceTypeCode);
            writer.WriteElementString("cbc:DocumentCurrencyCode", DocumentCurrencyCode);

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

            //#region PartyName
            //writer.WriteStartElement("cac:PartyName");

            ////writer.WriteStartElement("cbc:Name");
            ////writer.WriteCData(AccountingSupllierParty.Party.PartyName.Name);
            ////writer.WriteEndElement();
            //writer.WriteElementString("cbc:Name", AccountingSupllierParty.Party.PartyName.Name);

            //writer.WriteEndElement();
            //#endregion

            #region PostalAddress
            writer.WriteStartElement("cac:PostalAddress");
            writer.WriteElementString("cbc:ID", AccountingSupplierParty.Party.PostalAddress.ID);
            writer.WriteElementString("cbc:StreetName", AccountingSupplierParty.Party.PostalAddress.StreetName);
            writer.WriteElementString("cbc:CitySubdivisionName", AccountingSupplierParty.Party.PostalAddress.CitySubdivisionName);
            writer.WriteElementString("cbc:CityName", AccountingSupplierParty.Party.PostalAddress.CityName);
            writer.WriteElementString("cbc:CountrySubentity", AccountingSupplierParty.Party.PostalAddress.CountrySubentity);
            writer.WriteElementString("cbc:District", AccountingSupplierParty.Party.PostalAddress.District);

            #region Country
            writer.WriteStartElement("cac:Country");
            writer.WriteElementString("cbc:IdentificationCode",
                AccountingSupplierParty.Party.PostalAddress.Country.IdentificationCode);
            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            #region PartyLegalEntity
            writer.WriteStartElement("cac:PartyLegalEntity");

            //writer.WriteStartElement("cbc:RegistrationName");
            //writer.WriteCData(AccountingSupllierParty.Party.PartyLegalEntity.RegistrationName);
            //writer.WriteEndElement();
            writer.WriteElementString("cbc:RegistrationName",
                AccountingSupplierParty.Party.PartyLegalEntity.RegistrationName);

            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            #region AccountingCustomerParty
            writer.WriteStartElement("cac:AccountingCustomerParty");

            writer.WriteElementString("cbc:CustomerAssignedAccountID", AccountingCustomerParty.CustomerAssignedAccountID);
            writer.WriteElementString("cbc:AdditionalAccountID",
                AccountingCustomerParty.AdditionalAccountID.ToString());

            #region Party
            writer.WriteStartElement("cac:Party");

            #region cbc:PartyLegalEntity
            writer.WriteStartElement("cac:PartyLegalEntity");

            //writer.WriteStartElement("cbc:RegistrationName");
            //writer.WriteCData(AccountingCustomerParty.Party.PartyLegalEntity.RegistrationName);
            //writer.WriteEndElement();
            writer.WriteElementString("cbc:RegistrationName",
                AccountingCustomerParty.Party.PartyLegalEntity.RegistrationName);

            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            #region TaxTotal
            foreach (var taxTotal in TaxTotals)
            {
                writer.WriteStartElement("cac:TaxTotal");

                writer.WriteStartElement("cbc:TaxAmount");
                writer.WriteAttributeString("currencyID", taxTotal.TaxAmount.currencyID);
                writer.WriteString(taxTotal.TaxAmount.value.ToString(Constantes.Constantes.FormatoNumerico, Formato));
                writer.WriteEndElement();

                #region TaxSubtotal
                {
                    writer.WriteStartElement("cac:TaxSubtotal");

                    writer.WriteStartElement("cbc:TaxAmount");
                    writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxAmount.currencyID);
                    writer.WriteString(taxTotal.TaxAmount.value.ToString(Constantes.Constantes.FormatoNumerico, Formato));
                    writer.WriteEndElement();

                    #region TaxCategory

                    {
                        writer.WriteStartElement("cac:TaxCategory");

                        #region TaxScheme
                        {
                            writer.WriteStartElement("cac:TaxScheme");

                            writer.WriteElementString("cbc:ID", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.ID);
                            writer.WriteElementString("cbc:Name", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.Name);
                            writer.WriteElementString("cbc:TaxTypeCode", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.TaxTypeCode);

                            writer.WriteEndElement();
                        }
                        #endregion

                        writer.WriteEndElement();
                    }
                    #endregion

                    writer.WriteEndElement();
                }
                #endregion

                writer.WriteEndElement();
            }
            #endregion

            #region LegalMonetaryTotal
            writer.WriteStartElement("cac:LegalMonetaryTotal");
            {
                if (LegalMonetaryTotal.AllowanceTotalAmount.value > 0)
                {
                    writer.WriteStartElement("cbc:AllowanceTotalAmount");
                    {
                        writer.WriteAttributeString("currencyID", LegalMonetaryTotal.AllowanceTotalAmount.currencyID);
                        writer.WriteValue(LegalMonetaryTotal.AllowanceTotalAmount.value.ToString(Constantes.Constantes.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();
                }
                writer.WriteStartElement("cbc:PayableAmount");
                {
                    writer.WriteAttributeString("currencyID", LegalMonetaryTotal.PayableAmount.currencyID);
                    writer.WriteValue(LegalMonetaryTotal.PayableAmount.value.ToString(Constantes.Constantes.FormatoNumerico, Formato));
                }
                writer.WriteEndElement();

            }
            writer.WriteEndElement();
            #endregion

            #region InvoiceLines
            foreach (var invoiceLine in InvoiceLines)
            {
                writer.WriteStartElement("cac:InvoiceLine");

                writer.WriteElementString("cbc:ID", invoiceLine.ID.ToString());

                #region InvoicedQuantity
                writer.WriteStartElement("cbc:InvoicedQuantity");
                writer.WriteAttributeString("unitCode", invoiceLine.InvoicedQuantity.unitCode);
                writer.WriteValue(invoiceLine.InvoicedQuantity.Value.ToString(Constantes.Constantes.FormatoNumerico, Formato));
                writer.WriteEndElement();
                #endregion

                #region LineExtensionAmount
                writer.WriteStartElement("cbc:LineExtensionAmount");
                writer.WriteAttributeString("currencyID", invoiceLine.LineExtensionAmount.currencyID);
                writer.WriteValue(invoiceLine.LineExtensionAmount.value.ToString(Constantes.Constantes.FormatoNumerico, Formato));
                writer.WriteEndElement();
                #endregion

                #region PricingReference
                writer.WriteStartElement("cac:PricingReference");

                #region AlternativeConditionPrice
                foreach (var item in invoiceLine.PricingReference.AlternativeConditionPrices)
                {
                    writer.WriteStartElement("cac:AlternativeConditionPrice");

                    #region PriceAmount
                    writer.WriteStartElement("cbc:PriceAmount");
                    writer.WriteAttributeString("currencyID", item.PriceAmount.currencyID);
                    writer.WriteValue(item.PriceAmount.value.ToString(Constantes.Constantes.FormatoNumerico, Formato));
                    writer.WriteEndElement();
                    #endregion

                    writer.WriteElementString("cbc:PriceTypeCode", item.PriceTypeCode);

                    writer.WriteEndElement();
                }
                #endregion

                writer.WriteEndElement();
                #endregion

                #region AllowanceCharge
                if (invoiceLine.AllowanceCharge.ChargeIndicator)
                {
                    writer.WriteStartElement("cac:AllowanceCharge");

                    writer.WriteElementString("cbc:ChargeIndicator", invoiceLine.AllowanceCharge.ChargeIndicator.ToString());

                    #region Amount
                    writer.WriteStartElement("cbc:Amount");
                    writer.WriteAttributeString("currencyID", invoiceLine.AllowanceCharge.Amount.currencyID);
                    writer.WriteValue(invoiceLine.AllowanceCharge.Amount.value.ToString(Constantes.Constantes.FormatoNumerico, Formato));
                    writer.WriteEndElement();
                    #endregion

                    writer.WriteEndElement();
                }
                #endregion

                #region TaxTotal
                {
                    foreach (var taxTotal in invoiceLine.TaxTotals)
                    {
                        writer.WriteStartElement("cac:TaxTotal");

                        writer.WriteStartElement("cbc:TaxAmount");
                        writer.WriteAttributeString("currencyID", taxTotal.TaxAmount.currencyID);
                        writer.WriteString(taxTotal.TaxAmount.value.ToString(Constantes.Constantes.FormatoNumerico, Formato));
                        writer.WriteEndElement();

                        #region TaxSubtotal
                        writer.WriteStartElement("cac:TaxSubtotal");

                        #region TaxableAmount

                        if (!string.IsNullOrEmpty(taxTotal.TaxableAmount.currencyID))
                        {
                            writer.WriteStartElement("cbc:TaxableAmount");
                            writer.WriteAttributeString("currencyID", taxTotal.TaxableAmount.currencyID);
                            writer.WriteString(taxTotal.TaxableAmount.value.ToString(Constantes.Constantes.FormatoNumerico, Formato));
                            writer.WriteEndElement();
                        }

                        #endregion

                        writer.WriteStartElement("cbc:TaxAmount");
                        writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxAmount.currencyID);
                        writer.WriteString(taxTotal.TaxAmount.value.ToString(Constantes.Constantes.FormatoNumerico, Formato));
                        writer.WriteEndElement();
                        if (taxTotal.TaxSubtotal.Percent > 0)
                            writer.WriteElementString("cbc:Percent", taxTotal.TaxSubtotal.Percent.ToString(Constantes.Constantes.FormatoNumerico, Formato));

                        #region TaxCategory
                        writer.WriteStartElement("cac:TaxCategory");
                        //writer.WriteElementString("cbc:ID", invoiceLine.TaxTotal.TaxSubtotal.TaxCategory.ID);
                        writer.WriteElementString("cbc:TaxExemptionReasonCode", taxTotal.TaxSubtotal.TaxCategory.TaxExemptionReasonCode.ToString());
                        if (!string.IsNullOrEmpty(taxTotal.TaxSubtotal.TaxCategory.TierRange))
                            writer.WriteElementString("cbc:TierRange", taxTotal.TaxSubtotal.TaxCategory.TierRange);

                        #region TaxScheme
                        {
                            writer.WriteStartElement("cac:TaxScheme");

                            writer.WriteElementString("cbc:ID", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.ID);
                            writer.WriteElementString("cbc:Name", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.Name);
                            writer.WriteElementString("cbc:TaxTypeCode", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.TaxTypeCode);

                            writer.WriteEndElement();
                        }
                        #endregion

                        writer.WriteEndElement();
                        #endregion

                        writer.WriteEndElement();
                        #endregion

                        writer.WriteEndElement();
                    }
                }
                #endregion

                #region Item
                writer.WriteStartElement("cac:Item");

                #region Description
                writer.WriteElementString("cbc:Description", invoiceLine.Item.Description);
                //writer.WriteStartElement("cbc:Description");
                //writer.WriteCData(invoiceLine.Item.Description);
                //writer.WriteEndElement();
                #endregion

                #region SellersItemIdentification
                writer.WriteStartElement("cac:SellersItemIdentification");
                writer.WriteElementString("cbc:ID", invoiceLine.Item.SellersItemIdentification.ID);
                writer.WriteEndElement();
                #endregion


                writer.WriteEndElement();
                #endregion

                #region Price
                writer.WriteStartElement("cac:Price");

                writer.WriteStartElement("cbc:PriceAmount");
                writer.WriteAttributeString("currencyID", invoiceLine.Price.PriceAmount.currencyID);
                writer.WriteString(invoiceLine.Price.PriceAmount.value.ToString(Constantes.Constantes.FormatoNumerico, Formato));
                writer.WriteEndElement();

                writer.WriteEndElement();
                #endregion

                writer.WriteEndElement();
            }
            #endregion

        }
    }
}
