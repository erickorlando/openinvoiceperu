using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using OpenInvoicePeru.Comun;
using OpenInvoicePeru.Comun.Constantes;
using OpenInvoicePeru.Estructuras.CommonAggregateComponents;
using OpenInvoicePeru.Estructuras.CommonExtensionComponents;

namespace OpenInvoicePeru.Estructuras.EstandarUbl
{
    public class DebitNote : IXmlSerializable, IEstructuraXml
    {
        public UblExtensions UblExtensions { get; set; }

        public string UblVersionId { get; set; }

        public string CustomizationId { get; set; }

        public string Id { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime IssueTime { get; set; }

        public string DocumentCurrencyCode { get; set; }

        public string Note { get; set; }

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

        public IFormatProvider Formato { get; set; }

        public DebitNote()
        {
            UblExtensions = new UblExtensions();
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
            UblVersionId = "2.1";
            CustomizationId = "2.0";
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
            writer.WriteAttributeString("xmlns", EspacioNombres.xmlnsDebitNote);
            writer.WriteAttributeString("xmlns:cac", EspacioNombres.cac);
            writer.WriteAttributeString("xmlns:cbc", EspacioNombres.cbc);
            writer.WriteAttributeString("xmlns:ccts", EspacioNombres.ccts);
            writer.WriteAttributeString("xmlns:ds", EspacioNombres.ds);
            writer.WriteAttributeString("xmlns:ext", EspacioNombres.ext);
            writer.WriteAttributeString("xmlns:qdt", EspacioNombres.qdt);
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
            writer.WriteElementString("cbc:IssueTime", IssueTime.ToString(Formatos.FormatoHora));
            if (DueDate != null)
                writer.WriteElementString("cbc:DueDate", DueDate?.ToString(Formatos.FormatoFecha));

            if (!string.IsNullOrEmpty(Note))
            {
                writer.WriteStartElement("cbc:Note");
                {
                    writer.WriteAttributeString("languageLocaleID", "1000");
                    writer.WriteValue(Note);
                }
                writer.WriteEndElement();
            }

            #region DocumentCurrencyCode
            writer.WriteStartElement("cbc:DocumentCurrencyCode");
            {
                writer.WriteAttributeString("listID", ValoresUbl.DocumentCurrencyCode);
                writer.WriteAttributeString("listName", ValoresUbl.CurrencyListName);
                writer.WriteAttributeString("listAgencyName", ValoresUbl.CurrencyAgencyName);
                writer.WriteValue(DocumentCurrencyCode);
            }
            writer.WriteEndElement();
            #endregion

            #region DiscrepancyResponse

            foreach (var discrepancy in DiscrepancyResponses)
            {
                writer.WriteStartElement("cac:DiscrepancyResponse");
                {
                    writer.WriteElementString("cbc:ReferenceID", discrepancy.ReferenceId);
                    writer.WriteStartElement("cbc:ResponseCode");
                    {
                        writer.WriteAttributeString("listAgencyName", ValoresUbl.SchemeAgencyName);
                        writer.WriteAttributeString("listName", ValoresUbl.DiscrepancyDebitResponseCodeListName);
                        writer.WriteAttributeString("listURI", ValoresUbl.DiscrepancyDebitResponseCodeListUri);
                        writer.WriteValue(discrepancy.ResponseCode);
                    }
                    writer.WriteEndElement();
                    writer.WriteElementString("cbc:Description", discrepancy.Description);
                }
                writer.WriteEndElement();
            }

            #endregion DiscrepancyResponse

            #region BillingReference

            foreach (var item in BillingReferences)
            {
                writer.WriteStartElement("cac:BillingReference");
                {
                    writer.WriteStartElement("cac:InvoiceDocumentReference");
                    {
                        writer.WriteElementString("cbc:ID", item.InvoiceDocumentReference.Id);
                        writer.WriteElementString("cbc:DocumentTypeCode", item.InvoiceDocumentReference.DocumentTypeCode);
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            #endregion BillingReference

            #region DespatchDocumentReference

            foreach (var item in DespatchDocumentReferences)
            {
                writer.WriteStartElement("cac:DespatchDocumentReference");
                {
                    writer.WriteElementString("cbc:ID", item.Id);
                    writer.WriteElementString("cbc:DocumentTypeCode", item.DocumentTypeCode);
                }
                writer.WriteEndElement();
            }

            #endregion DespatchDocumentReference

            #region AdditionalDocumentReference

            foreach (var item in AdditionalDocumentReferences)
            {
                writer.WriteStartElement("cac:AdditionalDocumentReference");
                {
                    writer.WriteElementString("cbc:ID", item.Id);
                    writer.WriteElementString("cbc:DocumentTypeCode", item.DocumentTypeCode);
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
                    {
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
                }
                writer.WriteEndElement();

                #endregion SignatoryParty

                #region DigitalSignatureAttachment

                writer.WriteStartElement("cac:DigitalSignatureAttachment");
                {
                    writer.WriteStartElement("cac:ExternalReference");
                    {
                        writer.WriteElementString("cbc:URI",
                            Signature.DigitalSignatureAttachment.ExternalReference.Uri.Trim());
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                #endregion DigitalSignatureAttachment
            }
            writer.WriteEndElement();

            #endregion Signature

            #region AccountingSupplierParty

            writer.WriteStartElement("cac:AccountingSupplierParty");
            {
                #region Party

                writer.WriteStartElement("cac:Party");
                {
                    writer.WriteStartElement("cac:PartyIdentification");
                    {
                        writer.WriteStartElement("cbc:ID");
                        {
                            writer.WriteAttributeString("schemeID",
                                AccountingSupplierParty.PartyTaxScheme.CompanyId.SchemeId);
                            writer.WriteAttributeString("schemeName", ValoresUbl.CompanySchemeName);
                            writer.WriteAttributeString("schemeAgencyName", ValoresUbl.SchemeAgencyName);
                            writer.WriteAttributeString("schemeURI", ValoresUbl.CompanySchemeUri);
                            writer.WriteValue(AccountingSupplierParty.PartyTaxScheme.CompanyId.Value);
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                    #region PartyName

                    writer.WriteStartElement("cac:PartyName");
                    {
                        writer.WriteStartElement("cbc:Name");
                        {
                            writer.WriteString(AccountingSupplierParty.Party.PartyName.Name);
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                    #endregion PartyName

                    writer.WriteStartElement("cac:PartyLegalEntity");
                    {
                        writer.WriteElementString("cbc:RegistrationName",
                            AccountingSupplierParty.PartyTaxScheme.RegistrationName);

                        writer.WriteStartElement("cac:RegistrationAddress");
                        {
                            writer.WriteElementString("cbc:AddressTypeCode",
                                AccountingSupplierParty.Party.PartyLegalEntity.RegistrationAddress.AddressTypeCode);
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                }
                writer.WriteEndElement();

                #endregion Party
            }
            writer.WriteEndElement();

            #endregion AccountingSupplierParty

            #region AccountingCustomerParty

            writer.WriteStartElement("cac:AccountingCustomerParty");
            {
                #region Party

                writer.WriteStartElement("cac:Party");
                {
                    writer.WriteStartElement("cac:PartyIdentification");
                    {
                        writer.WriteStartElement("cbc:ID");
                        {
                            writer.WriteAttributeString("schemeID",
                                AccountingCustomerParty.PartyTaxScheme.CompanyId.SchemeId);
                            writer.WriteAttributeString("schemeName", ValoresUbl.CompanySchemeName);
                            writer.WriteAttributeString("schemeAgencyName", ValoresUbl.SchemeAgencyName);
                            writer.WriteAttributeString("schemeURI", ValoresUbl.CompanySchemeUri);
                            writer.WriteValue(AccountingCustomerParty.PartyTaxScheme.CompanyId.Value);
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                    writer.WriteStartElement("cac:PartyLegalEntity");
                    {
                        writer.WriteElementString("cbc:RegistrationName",
                            AccountingCustomerParty.PartyTaxScheme.RegistrationName);
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                #endregion Party
            }
            writer.WriteEndElement();

            #endregion AccountingCustomerParty

            #region TaxTotal

            foreach (var taxTotal in TaxTotals)
            {
                writer.WriteStartElement("cac:TaxTotal");

                writer.WriteStartElement("cbc:TaxAmount");
                writer.WriteAttributeString("currencyID", taxTotal.TaxAmount.CurrencyId);
                writer.WriteString(taxTotal.TaxAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                writer.WriteEndElement();

                #region TaxSubtotal

                {
                    writer.WriteStartElement("cac:TaxSubtotal");

                    writer.WriteStartElement("cbc:TaxableAmount");
                    writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxableAmount.CurrencyId);
                    writer.WriteString(
                        taxTotal.TaxSubtotal.TaxableAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    writer.WriteEndElement();

                    writer.WriteStartElement("cbc:TaxAmount");
                    writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxAmount.CurrencyId);
                    writer.WriteString(
                        taxTotal.TaxSubtotal.TaxAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    writer.WriteEndElement();

                    #region TaxCategory

                    {
                        writer.WriteStartElement("cac:TaxCategory");

                        #region TaxScheme

                        {
                            writer.WriteStartElement("cac:TaxScheme");
                            writer.WriteStartElement("cbc:ID");
                            {
                                writer.WriteAttributeString("schemeName", "Codigo de Tributos");
                                writer.WriteAttributeString("schemeAgencyName", ValoresUbl.SchemeAgencyName);
                                writer.WriteAttributeString("schemeURI", ValoresUbl.TaxSchemeSchemeUri);
                                writer.WriteValue(taxTotal.TaxSubtotal.TaxCategory.TaxScheme.Id);
                            }
                            writer.WriteEndElement();
                            writer.WriteElementString("cbc:Name", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.Name);
                            writer.WriteElementString("cbc:TaxTypeCode",
                                taxTotal.TaxSubtotal.TaxCategory.TaxScheme.TaxTypeCode);

                            writer.WriteEndElement();
                        }

                        #endregion TaxScheme

                        writer.WriteEndElement();
                    }

                    #endregion TaxCategory

                    writer.WriteEndElement();
                }

                #endregion TaxSubtotal

                writer.WriteEndElement();
            }

            #endregion TaxTotal

            #region RequestedMonetaryTotal

            writer.WriteStartElement("cac:RequestedMonetaryTotal");

            writer.WriteStartElement("cbc:PayableAmount");
            writer.WriteAttributeString("currencyID", RequestedMonetaryTotal.PayableAmount.CurrencyId);
            writer.WriteValue(RequestedMonetaryTotal.PayableAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
            writer.WriteEndElement();

            writer.WriteEndElement();

            #endregion RequestedMonetaryTotal

            #region DebitNoteLines

            foreach (var line in DebitNoteLines)
            {
                writer.WriteStartElement("cac:DebitNoteLine");
                {
                    writer.WriteElementString("cbc:ID", line.Id.ToString());

                    #region DebitedQuantity

                    writer.WriteStartElement("cbc:DebitedQuantity");
                    {
                        writer.WriteAttributeString("unitCode", line.DebitedQuantity.UnitCode);
                        writer.WriteAttributeString("unitCodeListID", ValoresUbl.QuantityCodeListId);
                        writer.WriteAttributeString("unitCodeListAgencyName", ValoresUbl.CurrencyAgencyName);
                        writer.WriteValue(line.DebitedQuantity.Value.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();

                    #endregion DebitedQuantity

                    #region LineExtensionAmount

                    writer.WriteStartElement("cbc:LineExtensionAmount");
                    {
                        writer.WriteAttributeString("currencyID", line.LineExtensionAmount.CurrencyId);
                        writer.WriteValue(line.LineExtensionAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();

                    #endregion LineExtensionAmount

                    #region PricingReference

                    writer.WriteStartElement("cac:PricingReference");

                    #region AlternativeConditionPrice

                    foreach (var item in line.PricingReference.AlternativeConditionPrices)
                    {
                        writer.WriteStartElement("cac:AlternativeConditionPrice");

                        #region PriceAmount

                        writer.WriteStartElement("cbc:PriceAmount");
                        {
                            writer.WriteAttributeString("currencyID", item.PriceAmount.CurrencyId);
                            writer.WriteValue(item.PriceAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                        }
                        writer.WriteEndElement();

                        #endregion PriceAmount

                        writer.WriteElementString("cbc:PriceTypeCode", item.PriceTypeCode);

                        writer.WriteEndElement();
                    }

                    #endregion AlternativeConditionPrice

                    writer.WriteEndElement();

                    #endregion PricingReference

                    #region AllowanceCharge

                    if (line.AllowanceCharge.ChargeIndicator)
                    {
                        writer.WriteStartElement("cac:AllowanceCharge");

                        writer.WriteElementString("cbc:ChargeIndicator",
                            line.AllowanceCharge.ChargeIndicator.ToString());

                        #region Amount

                        writer.WriteStartElement("cbc:Amount");
                        writer.WriteAttributeString("currencyID", line.AllowanceCharge.Amount.CurrencyId);
                        writer.WriteValue(
                            line.AllowanceCharge.Amount.Value.ToString(Formatos.FormatoNumerico, Formato));
                        writer.WriteEndElement();

                        #endregion Amount

                        writer.WriteEndElement();
                    }

                    #endregion AllowanceCharge

                    #region TaxTotal

                    {
                        foreach (var taxTotal in line.TaxTotals)
                        {
                            writer.WriteStartElement("cac:TaxTotal");

                            writer.WriteStartElement("cbc:TaxAmount");
                            writer.WriteAttributeString("currencyID", taxTotal.TaxAmount.CurrencyId);
                            writer.WriteString(taxTotal.TaxAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                            writer.WriteEndElement();

                            #region TaxSubtotal

                            writer.WriteStartElement("cac:TaxSubtotal");

                            #region TaxableAmount

                            if (!string.IsNullOrEmpty(taxTotal.TaxSubtotal.TaxableAmount.CurrencyId))
                            {
                                writer.WriteStartElement("cbc:TaxableAmount");
                                writer.WriteAttributeString("currencyID",
                                    taxTotal.TaxSubtotal.TaxableAmount.CurrencyId);
                                writer.WriteString(
                                    taxTotal.TaxSubtotal.TaxableAmount.Value.ToString(Formatos.FormatoNumerico,
                                        Formato));
                                writer.WriteEndElement();
                            }

                            #endregion TaxableAmount

                            writer.WriteStartElement("cbc:TaxAmount");
                            writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxAmount.CurrencyId);
                            writer.WriteString(taxTotal.TaxAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                            writer.WriteEndElement();

                            #region TaxCategory

                            writer.WriteStartElement("cac:TaxCategory");
                            //writer.WriteElementString("cbc:ID", invoiceLine.TaxTotal.TaxSubtotal.TaxCategory.ID);
                            if (taxTotal.TaxSubtotal.TaxCategory.Percent > 0)
                                writer.WriteElementString("cbc:Percent",
                                    taxTotal.TaxSubtotal.TaxCategory.Percent.ToString(Formatos.FormatoNumerico,
                                        Formato));
                            writer.WriteElementString("cbc:TaxExemptionReasonCode",
                                taxTotal.TaxSubtotal.TaxCategory.TaxExemptionReasonCode);
                            if (!string.IsNullOrEmpty(taxTotal.TaxSubtotal.TaxCategory.TierRange))
                                writer.WriteElementString("cbc:TierRange", taxTotal.TaxSubtotal.TaxCategory.TierRange);

                            #region TaxScheme

                            {
                                writer.WriteStartElement("cac:TaxScheme");

                                writer.WriteElementString("cbc:ID", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.Id);
                                writer.WriteElementString("cbc:Name", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.Name);
                                writer.WriteElementString("cbc:TaxTypeCode",
                                    taxTotal.TaxSubtotal.TaxCategory.TaxScheme.TaxTypeCode);

                                writer.WriteEndElement();
                            }

                            #endregion TaxScheme

                            writer.WriteEndElement();

                            #endregion TaxCategory

                            writer.WriteEndElement();

                            #endregion TaxSubtotal

                            writer.WriteEndElement();
                        }
                    }

                    #endregion TaxTotal

                    #region Item

                    writer.WriteStartElement("cac:Item");

                    #region Description

                    writer.WriteElementString("cbc:Description", line.Item.Description);

                    #endregion Description

                    #region SellersItemIdentification

                    writer.WriteStartElement("cac:SellersItemIdentification");
                    writer.WriteElementString("cbc:ID", line.Item.SellersItemIdentification.Id);
                    writer.WriteEndElement();

                    #endregion SellersItemIdentification

                    writer.WriteEndElement();

                    #endregion Item

                    #region Price

                    writer.WriteStartElement("cac:Price");

                    writer.WriteStartElement("cbc:PriceAmount");
                    writer.WriteAttributeString("currencyID", line.Price.PriceAmount.CurrencyId);
                    writer.WriteString(line.Price.PriceAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    writer.WriteEndElement();

                    writer.WriteEndElement();

                    #endregion Price
                }
                writer.WriteEndElement();
            }

            #endregion DebitNoteLines
        }
    }
}