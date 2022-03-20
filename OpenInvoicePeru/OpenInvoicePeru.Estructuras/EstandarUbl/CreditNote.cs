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
    public class CreditNote : IXmlSerializable, IEstructuraXml
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

        public LegalMonetaryTotal LegalMonetaryTotal { get; set; }

        public List<InvoiceLine> CreditNoteLines { get; set; }

        public IFormatProvider Formato { get; set; }

        public bool Credito { get; set; }
        public decimal MontoCredito { get; set; }
        public List<InfoCredits> InfoCreditsList { get; set; }

        public Dictionary<string, string> NotesList { get; set; }

        public CreditNote()
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
            LegalMonetaryTotal = new LegalMonetaryTotal();
            CreditNoteLines = new List<InvoiceLine>();
            InfoCreditsList = new List<InfoCredits>();
            UblVersionId = "2.1";
            CustomizationId = "2.0";
            Formato = new System.Globalization.CultureInfo(Formatos.Cultura);
            NotesList = new Dictionary<string, string>();
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
            writer.WriteAttributeString("xmlns", EspacioNombres.xmlnsCreditNote);
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

            writer.WriteStartElement("cbc:Note");
            {
                writer.WriteAttributeString("languageLocaleID", "1000");
                writer.WriteCData(Note ?? "Nota de Credito");
            }
            writer.WriteEndElement();

            foreach (var note in NotesList)
            {
                writer.WriteStartElement("cbc:Note");
                {
                    if (!string.IsNullOrEmpty(note.Key))
                        writer.WriteAttributeString("languageLocaleID", note.Key);
                    writer.WriteCData(note.Value);
                }
                writer.WriteEndElement();
            }

            writer.WriteComment(Properties.Resources.Comment);

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
                        writer.WriteAttributeString("listName", ValoresUbl.DiscrepancyResponseCodeListName);
                        writer.WriteAttributeString("listURI", ValoresUbl.DiscrepancyResponseCodeListUri);
                        writer.WriteValue(discrepancy.ResponseCode);
                    }
                    writer.WriteEndElement();
                    writer.WriteStartElement("cbc:Description");
                    {
                        writer.WriteCData(discrepancy.Description);
                    }
                    writer.WriteEndElement();
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
                        writer.WriteStartElement("cbc:DocumentTypeCode");
                        {
                            writer.WriteAttributeString("listAgencyName", ValoresUbl.SchemeAgencyName);
                            writer.WriteAttributeString("listName", ValoresUbl.InvoiceTypeCodeName);
                            writer.WriteAttributeString("listURI", ValoresUbl.InvoiceTypeCodeSchemeUri);
                            writer.WriteValue(item.InvoiceDocumentReference.DocumentTypeCode);
                        }
                        writer.WriteEndElement();
                        if (!string.IsNullOrEmpty(item.InvoiceDocumentReference.DocumentTypeDescription))
                        {
                            writer.WriteStartElement("cbc:DocumentType");
                            writer.WriteCData(item.InvoiceDocumentReference.DocumentTypeDescription);
                            writer.WriteEndElement();
                        }
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
                    writer.WriteStartElement("cbc:DocumentTypeCode");
                    {
                        writer.WriteAttributeString("listAgencyName", ValoresUbl.SchemeAgencyName);
                        writer.WriteAttributeString("listName", ValoresUbl.InvoiceTypeCodeName);
                        writer.WriteAttributeString("listUri", ValoresUbl.InvoiceTypeCodeSchemeUri);
                        writer.WriteValue(item.DocumentTypeCode);
                    }
                    writer.WriteEndElement();
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
                    writer.WriteStartElement("cbc:DocumentTypeCode");
                    {
                        writer.WriteAttributeString("schemeName", ValoresUbl.AdditionalDocumentsSchemeName);
                        writer.WriteAttributeString("schemeAgencyName", ValoresUbl.SchemeAgencyName);
                        writer.WriteAttributeString("schemeUri", ValoresUbl.AdditionalDocumentsSchemeUri);
                        writer.WriteValue(item.DocumentTypeCode);
                    }
                    writer.WriteEndElement();
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

            #region Credito

            if (Credito)
            {
                writer.WriteComment("Inicio Credito");

                writer.WriteStartElement("cac:PaymentTerms");
                {
                    writer.WriteElementString("cbc:ID", "FormaPago");
                    writer.WriteElementString("cbc:PaymentMeansID", "Credito");
                    if (Credito)
                    {
                        writer.WriteStartElement("cbc:Amount");
                        {
                            writer.WriteAttributeString("currencyID", DocumentCurrencyCode);
                            writer.WriteValue(MontoCredito.ToString(Formatos.FormatoNumerico, Formato));
                        }
                        writer.WriteEndElement();
                    }
                }
                writer.WriteEndElement();

                foreach (var credit in InfoCreditsList)
                {
                    writer.WriteStartElement("cac:PaymentTerms");
                    {
                        writer.WriteElementString("cbc:ID", "FormaPago");
                        writer.WriteElementString("cbc:PaymentMeansID", $"Cuota{credit.NroCuota:000}");

                        writer.WriteStartElement("cbc:Amount");
                        {
                            writer.WriteAttributeString("currencyID", DocumentCurrencyCode);
                            writer.WriteValue(credit.MontoCuota.ToString(Formatos.FormatoNumerico, Formato));
                        }
                        writer.WriteEndElement();

                        writer.WriteElementString("cbc:PaymentDueDate", credit.FechaCredito);
                    }
                    writer.WriteEndElement();
                }

                writer.WriteComment("Fin Credito");
            }

            #endregion

            #region TaxTotal

            foreach (var taxTotal in TaxTotals)
            {
                writer.WriteStartElement("cac:TaxTotal");
                {
                    writer.WriteStartElement("cbc:TaxAmount");
                    {
                        writer.WriteAttributeString("currencyID", taxTotal.TaxAmount.CurrencyId);
                        writer.WriteString(taxTotal.TaxAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();

                    foreach (var taxSubTotal in taxTotal.TaxSubTotals)
                    {
                        #region TaxSubtotal

                        {
                            writer.WriteStartElement("cac:TaxSubtotal");
                            {
                                writer.WriteStartElement("cbc:TaxableAmount");
                                {
                                    writer.WriteAttributeString("currencyID", taxSubTotal.TaxableAmount.CurrencyId);
                                    writer.WriteValue(taxSubTotal.TaxableAmount.Value.ToString(Formatos.FormatoNumerico,
                                            Formato));
                                }
                                writer.WriteEndElement();

                                writer.WriteStartElement("cbc:TaxAmount");
                                {
                                    writer.WriteAttributeString("currencyID", taxSubTotal.TaxAmount.CurrencyId);
                                    writer.WriteString(taxSubTotal.TaxAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                                }
                                writer.WriteEndElement();

                                #region TaxCategory

                                {
                                    writer.WriteStartElement("cac:TaxCategory");

                                    writer.WriteStartElement("cbc:ID");
                                    {
                                        writer.WriteAttributeString("schemeID", ValoresUbl.TaxCategorySchemeId);
                                        writer.WriteAttributeString("schemeName", ValoresUbl.TaxCategorySchemeName);
                                        writer.WriteAttributeString("schemeAgencyName", ValoresUbl.SchemeAgencyName);
                                        writer.WriteValue(taxSubTotal.TaxCategory.Id);
                                    }
                                    writer.WriteEndElement();

                                    #region TaxScheme

                                    {
                                        writer.WriteStartElement("cac:TaxScheme");
                                        {
                                            writer.WriteStartElement("cbc:ID");
                                            {
                                                writer.WriteAttributeString("schemeID", ValoresUbl.TaxCategorySchemeId);
                                                writer.WriteAttributeString("schemeAgencyID", "6");
                                                writer.WriteValue(taxSubTotal.TaxCategory.TaxScheme.Id);
                                            }
                                            writer.WriteEndElement();
                                            writer.WriteElementString("cbc:Name", taxSubTotal.TaxCategory.TaxScheme.Name);
                                            writer.WriteElementString("cbc:TaxTypeCode", taxSubTotal.TaxCategory.TaxScheme.TaxTypeCode);
                                        }
                                        writer.WriteEndElement();
                                    }

                                    #endregion TaxScheme

                                    writer.WriteEndElement();
                                }

                                #endregion TaxCategory
                            }
                            writer.WriteEndElement();
                        }

                        #endregion TaxSubtotal 
                    }
                }
                writer.WriteEndElement();
            }

            #endregion TaxTotal

            #region LegalMonetaryTotal

            writer.WriteStartElement("cac:LegalMonetaryTotal");
            {
                writer.WriteStartElement("cbc:LineExtensionAmount");
                {
                    writer.WriteAttributeString("currencyID", LegalMonetaryTotal.LineExtensionAmount.CurrencyId);
                    writer.WriteValue(LegalMonetaryTotal.LineExtensionAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                }
                writer.WriteEndElement();

                writer.WriteStartElement("cbc:TaxInclusiveAmount");
                {
                    writer.WriteAttributeString("currencyID", LegalMonetaryTotal.TaxInclusiveAmount.CurrencyId);
                    writer.WriteValue(LegalMonetaryTotal.TaxInclusiveAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                }
                writer.WriteEndElement();

                writer.WriteStartElement("cbc:AllowanceTotalAmount");
                {
                    writer.WriteAttributeString("currencyID", LegalMonetaryTotal.AllowanceTotalAmount.CurrencyId);
                    writer.WriteValue(LegalMonetaryTotal.AllowanceTotalAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                }
                writer.WriteEndElement();

                writer.WriteStartElement("cbc:PrepaidAmount");
                {
                    writer.WriteAttributeString("currencyID", LegalMonetaryTotal.PrepaidAmount.CurrencyId);
                    writer.WriteValue(LegalMonetaryTotal.PrepaidAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                }
                writer.WriteEndElement();

                writer.WriteStartElement("cbc:PayableAmount");
                {
                    writer.WriteAttributeString("currencyID", LegalMonetaryTotal.PayableAmount.CurrencyId);
                    writer.WriteValue(LegalMonetaryTotal.PayableAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            #endregion LegalMonetaryTotal


            #region CreditNoteLines

            foreach (var creditNoteLine in CreditNoteLines)
            {
                writer.WriteStartElement("cac:CreditNoteLine");
                {
                    writer.WriteElementString("cbc:ID", creditNoteLine.Id.ToString());

                    #region CreditedQuantity

                    writer.WriteStartElement("cbc:CreditedQuantity");
                    {
                        writer.WriteAttributeString("unitCode", creditNoteLine.CreditedQuantity.UnitCode);
                        writer.WriteAttributeString("unitCodeListID", ValoresUbl.QuantityCodeListId);
                        writer.WriteAttributeString("unitCodeListAgencyName", ValoresUbl.CurrencyAgencyName);
                        writer.WriteValue(
                            creditNoteLine.CreditedQuantity.Value.ToString(Formatos.FormatoNumericoExtenso, Formato));
                    }
                    writer.WriteEndElement();

                    #endregion CreditedQuantity

                    #region LineExtensionAmount

                    writer.WriteStartElement("cbc:LineExtensionAmount");
                    {
                        writer.WriteAttributeString("currencyID", creditNoteLine.LineExtensionAmount.CurrencyId);
                        writer.WriteValue(
                            creditNoteLine.LineExtensionAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();

                    #endregion LineExtensionAmount

                    #region BillingReference
                    if (creditNoteLine.BillingReference > 0)
                    {
                        writer.WriteStartElement("cac:BillingReference");
                        {
                            writer.WriteStartElement("cac:BillingReferenceLine");
                            {
                                writer.WriteElementString("cbc:ID", creditNoteLine.BillingReference.ToString("####0"));
                            }
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                    }
                    #endregion

                    #region PricingReference

                    writer.WriteStartElement("cac:PricingReference");
                    {
                        #region AlternativeConditionPrice

                        foreach (var item in creditNoteLine.PricingReference.AlternativeConditionPrices)
                        {
                            writer.WriteStartElement("cac:AlternativeConditionPrice");
                            {
                                #region PriceAmount

                                writer.WriteStartElement("cbc:PriceAmount");
                                {
                                    writer.WriteAttributeString("currencyID", item.PriceAmount.CurrencyId);
                                    writer.WriteValue(
                                        item.PriceAmount.Value.ToString(Formatos.FormatoNumericoExtenso, Formato));
                                }
                                writer.WriteEndElement();

                                #endregion PriceAmount

                                writer.WriteElementString("cbc:PriceTypeCode", item.PriceTypeCode);
                            }
                            writer.WriteEndElement();
                        }

                        #endregion AlternativeConditionPrice
                    }
                    writer.WriteEndElement();

                    #endregion PricingReference

                    #region AllowanceCharge

                    if (creditNoteLine.AllowanceCharge.ChargeIndicator)
                    {
                        writer.WriteStartElement("cac:AllowanceCharge");
                        {
                            writer.WriteElementString("cbc:ChargeIndicator",
                                creditNoteLine.AllowanceCharge.ChargeIndicator.ToString());

                            #region Amount

                            writer.WriteStartElement("cbc:Amount");
                            {
                                writer.WriteAttributeString("currencyID",
                                    creditNoteLine.AllowanceCharge.Amount.CurrencyId);
                                writer.WriteValue(
                                    creditNoteLine.AllowanceCharge.Amount.Value.ToString(Formatos.FormatoNumerico,
                                        Formato));
                            }
                            writer.WriteEndElement();

                            #endregion Amount
                        }
                        writer.WriteEndElement();
                    }

                    #endregion AllowanceCharge

                    #region TaxTotal
                    foreach (var taxTotal in creditNoteLine.TaxTotals)
                    {
                        writer.WriteStartElement("cac:TaxTotal");
                        {
                            writer.WriteStartElement("cbc:TaxAmount");
                            {
                                writer.WriteAttributeString("currencyID", taxTotal.TaxAmount.CurrencyId);
                                writer.WriteString(taxTotal.TaxAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                            }
                            writer.WriteEndElement();

                            foreach (var taxSubTotal in taxTotal.TaxSubTotals)
                            {
                                writer.WriteStartElement("cac:TaxSubtotal");
                                {
                                    writer.WriteStartElement("cbc:TaxableAmount");
                                    {
                                        writer.WriteAttributeString("currencyID", taxSubTotal.TaxAmount.CurrencyId);
                                        decimal monto;

                                        if (taxSubTotal.TaxableAmount.Value > 0)
                                            monto = taxSubTotal.TaxableAmount.Value;
                                        else
                                        {
                                            monto = creditNoteLine.Price.PriceAmount.Value * creditNoteLine.CreditedQuantity.Value;
                                            if (monto == 0)
                                                monto = creditNoteLine.PricingReference
                                                            .AlternativeConditionPrices
                                                            .First().PriceAmount.Value
                                                        * creditNoteLine.CreditedQuantity.Value;
                                        }
                                        writer.WriteValue(monto.ToString(Formatos.FormatoNumerico, Formato));
                                    }
                                    writer.WriteEndElement();

                                    writer.WriteStartElement("cbc:TaxAmount");
                                    {
                                        writer.WriteAttributeString("currencyID", taxSubTotal.TaxAmount.CurrencyId);
                                        writer.WriteValue(taxSubTotal.TaxAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                                    }
                                    writer.WriteEndElement();

                                    #region TaxCategory
                                    {
                                        writer.WriteStartElement("cac:TaxCategory");
                                        {
                                            writer.WriteStartElement("cbc:ID");
                                            {
                                                //writer.WriteAttributeString("schemeID", ValoresUbl.TaxCategorySchemeId);
                                                //writer.WriteAttributeString("schemeName", ValoresUbl.TaxCategorySchemeName);
                                                //writer.WriteAttributeString("schemeAgencyName", ValoresUbl.SchemeAgencyName);
                                                writer.WriteValue(taxSubTotal.TaxCategory.Id);
                                            }
                                            writer.WriteEndElement();

                                            //if (taxSubTotal.TaxCategory.Percent > 0)
                                            //{
                                            writer.WriteElementString("cbc:Percent",
                                                taxSubTotal.TaxCategory.Percent.ToString("#0", Formato));
                                            //}
                                            writer.WriteStartElement("cbc:TaxExemptionReasonCode");
                                            {
                                                writer.WriteAttributeString("listAgencyName", ValoresUbl.SchemeAgencyName);
                                                writer.WriteAttributeString("listName", ValoresUbl.TaxExemptionListName);
                                                writer.WriteAttributeString("listURI", ValoresUbl.TaxExemptionUri);
                                                writer.WriteValue(taxSubTotal.TaxCategory.TaxExemptionReasonCode);
                                            }
                                            writer.WriteEndElement();

                                            if (!string.IsNullOrEmpty(taxSubTotal.TaxCategory.TierRange))
                                            {
                                                writer.WriteElementString("cbc:TierRange", taxSubTotal.TaxCategory.TierRange);
                                            }

                                            #region TaxScheme

                                            writer.WriteStartElement("cac:TaxScheme");
                                            {
                                                writer.WriteStartElement("cbc:ID");
                                                {
                                                    writer.WriteAttributeString("schemeID", ValoresUbl.TaxSchemeId);
                                                    writer.WriteAttributeString("schemeName", ValoresUbl.TaxCategorySchemeName);
                                                    writer.WriteAttributeString("schemeAgencyName", ValoresUbl.SchemeAgencyName);

                                                    writer.WriteValue(taxSubTotal.TaxCategory.TaxScheme.Id);
                                                }
                                                writer.WriteEndElement();

                                                writer.WriteElementString("cbc:Name", taxSubTotal.TaxCategory.TaxScheme.Name);
                                                writer.WriteElementString("cbc:TaxTypeCode",
                                                    taxSubTotal.TaxCategory.TaxScheme.TaxTypeCode);
                                            }
                                            writer.WriteEndElement();

                                            #endregion TaxScheme
                                        }
                                        writer.WriteEndElement();
                                    }
                                    #endregion TaxCategory 
                                }
                                writer.WriteEndElement();
                            }
                        }
                        writer.WriteEndElement();
                    }

                    #endregion TaxTotal

                    #region Item

                    writer.WriteStartElement("cac:Item");
                    {
                        writer.WriteElementString("cbc:Description", creditNoteLine.Item.Description);

                        #region SellersItemIdentification

                        writer.WriteStartElement("cac:SellersItemIdentification");
                        {
                            writer.WriteElementString("cbc:ID", creditNoteLine.Item.SellersItemIdentification.Id);
                        }
                        writer.WriteEndElement();

                        #endregion SellersItemIdentification

                    }
                    writer.WriteEndElement();

                    #endregion Item

                    #region Price

                    writer.WriteStartElement("cac:Price");
                    {
                        writer.WriteStartElement("cbc:PriceAmount");
                        {
                            writer.WriteAttributeString("currencyID", creditNoteLine.Price.PriceAmount.CurrencyId);
                            writer.WriteValue(
                                creditNoteLine.Price.PriceAmount.Value.ToString(Formatos.FormatoNumericoExtenso, Formato));
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                    #endregion Price

                    writer.WriteEndElement();
                }

            }

            #endregion CreditNoteLines

        }

    }
}