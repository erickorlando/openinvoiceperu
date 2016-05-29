using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ErickOrlando.FirmadoSunat.Estructuras
{
    public class DebitNote : IXmlSerializable
    {
        public UBLExtensions UBLExtensions { get; set; }
        public string UBLVersionID { get; set; }
        public string CustomizationID { get; set; }
        public string ID { get; set; }
        public DateTime IssueDate { get; set; }
        public string DocumentCurrencyCode { get; set; }
        public List<DiscrepancyResponse> DiscrepancyResponses { get; set; }
        public List<BillingReference> BillingReferences { get; set; }
        public List<InvoiceDocumentReference> DespatchDocumentReferences { get; set; }
        public List<InvoiceDocumentReference> AdditionalDocumentReferences { get; set; }
        public SignatureCac Signature { get; set; }
        public AccountingSupplierParty AccountingSupplierParty { get; set; }
        public AccountingSupplierParty AccountingCustomerParty { get; set; }
        public List<TaxTotal> TaxTotals { get; set; }
        public LegalMonetaryTotal RequestedMonetaryTotal { get; set; }
        public List<InvoiceLine> DebitNoteLines { get; set; }

        public DebitNote()
        {
            UBLExtensions = new UBLExtensions();
            DiscrepancyResponses = new List<DiscrepancyResponse>();
            BillingReferences = new List<BillingReference>();
            DespatchDocumentReferences = new List<InvoiceDocumentReference>();
            AdditionalDocumentReferences = new List<InvoiceDocumentReference>();
            Signature = new SignatureCac();
            AccountingCustomerParty = new AccountingSupplierParty();
            AccountingSupplierParty = new AccountingSupplierParty();
            TaxTotals = new List<TaxTotal>();
            RequestedMonetaryTotal = new LegalMonetaryTotal();
            DebitNoteLines = new List<InvoiceLine>();
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
            writer.WriteAttributeString("xmlns", EspacioNombres.xmlnsDebitNote);
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
                    var ext2 = UBLExtensions.Extension2.ExtensionContent.AdditionalInformation;
                    writer.WriteStartElement("ext:UBLExtension");

                    #region ExtensionContent
                    {
                        writer.WriteStartElement("ext:ExtensionContent");

                        #region AdditionalInformation
                        {
                            if (ext2.AdditionalMonetaryTotals.Count > 0)
                                writer.WriteStartElement("sac:AdditionalInformation");

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
                                        writer.WriteValue(additionalMonetaryTotal.PayableAmount.value.ToString(Constantes.Constantes.FormatoNumerico));
                                        writer.WriteEndElement();
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

                            writer.WriteEndElement();
                        }
                        #endregion

                        writer.WriteEndElement();
                    }
                    #endregion

                    writer.WriteEndElement();

                }
                #endregion

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
            writer.WriteElementString("cbc:IssueDate", IssueDate.ToString("yyyy-MM-dd"));
            writer.WriteElementString("cbc:DocumentCurrencyCode", DocumentCurrencyCode);

            #region DiscrepancyResponse
            foreach (var discrepancy in DiscrepancyResponses)
            {
                writer.WriteStartElement("cac:DiscrepancyResponse");
                {
                    writer.WriteElementString("cbc:ReferenceID", discrepancy.ReferenceID);
                    writer.WriteElementString("cbc:ResponseCode", discrepancy.ResponseCode);
                    writer.WriteElementString("cbc:Description", discrepancy.Description);
                }
                writer.WriteEndElement();
            }
            #endregion

            #region BillingReference
            foreach (var item in BillingReferences)
            {
                writer.WriteStartElement("cac:BillingReference");
                {
                    writer.WriteStartElement("cac:InvoiceDocumentReference");
                    {
                        writer.WriteElementString("cbc:ID", item.InvoiceDocumentReference.ID);
                        writer.WriteElementString("cbc:DocumentTypeCode", item.InvoiceDocumentReference.DocumentTypeCode);
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            #endregion

            #region DespatchDocumentReference
            foreach (var item in DespatchDocumentReferences)
            {
                writer.WriteStartElement("cac:DespatchDocumentReference");
                {
                    writer.WriteElementString("cbc:ID", item.ID);
                    writer.WriteElementString("cbc:DocumentTypeCode", item.DocumentTypeCode);
                }
                writer.WriteEndElement();
            }
            #endregion

            #region AdditionalDocumentReference
            foreach (var item in AdditionalDocumentReferences)
            {
                writer.WriteStartElement("cac:AdditionalDocumentReference");
                {
                    writer.WriteElementString("cbc:ID", item.ID);
                    writer.WriteElementString("cbc:DocumentTypeCode", item.DocumentTypeCode);
                }
                writer.WriteEndElement();
            }
            #endregion

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
                writer.WriteString(taxTotal.TaxAmount.value.ToString(Constantes.Constantes.FormatoNumerico));
                writer.WriteEndElement();

                #region TaxSubtotal
                {
                    writer.WriteStartElement("cac:TaxSubtotal");

                    writer.WriteStartElement("cbc:TaxAmount");
                    writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxAmount.currencyID);
                    writer.WriteString(taxTotal.TaxAmount.value.ToString(Constantes.Constantes.FormatoNumerico));
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

            #region RequestedMonetaryTotal
            writer.WriteStartElement("cac:RequestedMonetaryTotal");

            writer.WriteStartElement("cbc:PayableAmount");
            writer.WriteAttributeString("currencyID", RequestedMonetaryTotal.PayableAmount.currencyID);
            writer.WriteValue(RequestedMonetaryTotal.PayableAmount.value.ToString(Constantes.Constantes.FormatoNumerico));
            writer.WriteEndElement();

            writer.WriteEndElement();
            #endregion

            #region DebitNoteLines
            foreach (var line in DebitNoteLines)
            {
                writer.WriteStartElement("cac:DebitNoteLine");

                writer.WriteElementString("cbc:ID", line.ID.ToString());

                #region DebitedQuantity
                writer.WriteStartElement("cbc:DebitedQuantity");
                {
                    writer.WriteAttributeString("unitCode", line.DebitedQuantity.unitCode);
                    writer.WriteValue(line.DebitedQuantity.Value.ToString(Constantes.Constantes.FormatoNumerico));
                }
                writer.WriteEndElement();
                #endregion

                #region LineExtensionAmount
                writer.WriteStartElement("cbc:LineExtensionAmount");
                {
                    writer.WriteAttributeString("currencyID", line.LineExtensionAmount.currencyID);
                    writer.WriteValue(line.LineExtensionAmount.value.ToString(Constantes.Constantes.FormatoNumerico));
                }
                writer.WriteEndElement();
                #endregion

                #region PricingReference
                writer.WriteStartElement("cac:PricingReference");

                #region AlternativeConditionPrice
                foreach (var item in line.PricingReference.AlternativeConditionPrices)
                {
                    writer.WriteStartElement("cac:AlternativeConditionPrice");

                    #region PriceAmount
                    writer.WriteStartElement("cbc:PriceAmount");
                    writer.WriteAttributeString("currencyID", item.PriceAmount.currencyID);
                    writer.WriteValue(item.PriceAmount.value.ToString(Constantes.Constantes.FormatoNumerico));
                    writer.WriteEndElement();
                    #endregion

                    writer.WriteElementString("cbc:PriceTypeCode", item.PriceTypeCode);

                    writer.WriteEndElement();
                }
                #endregion

                writer.WriteEndElement();
                #endregion

                #region AllowanceCharge
                if (line.AllowanceCharge.ChargeIndicator)
                {
                    writer.WriteStartElement("cac:AllowanceCharge");

                    writer.WriteElementString("cbc:ChargeIndicator", line.AllowanceCharge.ChargeIndicator.ToString());

                    #region Amount
                    writer.WriteStartElement("cbc:Amount");
                    writer.WriteAttributeString("currencyID", line.AllowanceCharge.Amount.currencyID);
                    writer.WriteValue(line.AllowanceCharge.Amount.value.ToString(Constantes.Constantes.FormatoNumerico));
                    writer.WriteEndElement();
                    #endregion

                    writer.WriteEndElement();
                }
                #endregion

                #region TaxTotal
                {
                    foreach (var taxTotal in line.TaxTotals)
                    {
                        writer.WriteStartElement("cac:TaxTotal");

                        writer.WriteStartElement("cbc:TaxAmount");
                        writer.WriteAttributeString("currencyID", taxTotal.TaxAmount.currencyID);
                        writer.WriteString(taxTotal.TaxAmount.value.ToString(Constantes.Constantes.FormatoNumerico));
                        writer.WriteEndElement();

                        #region TaxSubtotal
                        writer.WriteStartElement("cac:TaxSubtotal");

                        #region TaxableAmount

                        if (!string.IsNullOrEmpty(taxTotal.TaxableAmount.currencyID))
                        {
                            writer.WriteStartElement("cbc:TaxableAmount");
                            writer.WriteAttributeString("currencyID", taxTotal.TaxableAmount.currencyID);
                            writer.WriteString(taxTotal.TaxableAmount.value.ToString(Constantes.Constantes.FormatoNumerico));
                            writer.WriteEndElement();
                        }

                        #endregion

                        writer.WriteStartElement("cbc:TaxAmount");
                        writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxAmount.currencyID);
                        writer.WriteString(taxTotal.TaxAmount.value.ToString(Constantes.Constantes.FormatoNumerico));
                        writer.WriteEndElement();
                        if (taxTotal.TaxSubtotal.Percent > 0)
                            writer.WriteElementString("cbc:Percent", taxTotal.TaxSubtotal.Percent.ToString(Constantes.Constantes.FormatoNumerico));

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
                writer.WriteElementString("cbc:Description", line.Item.Description);
                //writer.WriteStartElement("cbc:Description");
                //writer.WriteCData(invoiceLine.Item.Description);
                //writer.WriteEndElement();
                #endregion

                #region SellersItemIdentification
                writer.WriteStartElement("cac:SellersItemIdentification");
                writer.WriteElementString("cbc:ID", line.Item.SellersItemIdentification.ID);
                writer.WriteEndElement();
                #endregion


                writer.WriteEndElement();
                #endregion

                #region Price
                writer.WriteStartElement("cac:Price");

                writer.WriteStartElement("cbc:PriceAmount");
                writer.WriteAttributeString("currencyID", line.Price.PriceAmount.currencyID);
                writer.WriteString(line.Price.PriceAmount.value.ToString(Constantes.Constantes.FormatoNumerico));
                writer.WriteEndElement();

                writer.WriteEndElement();
                #endregion

                writer.WriteEndElement();
            }
            #endregion
        }
    }
}
