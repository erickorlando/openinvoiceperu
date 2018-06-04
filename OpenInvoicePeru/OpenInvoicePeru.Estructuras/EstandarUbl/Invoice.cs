using OpenInvoicePeru.Comun;
using OpenInvoicePeru.Comun.Constantes;
using OpenInvoicePeru.Estructuras.CommonAggregateComponents;
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
    public class Invoice : IXmlSerializable, IEstructuraXml
    {
        public DateTime IssueDate { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime IssueTime { get; set; }

        public string ProfileId { get; set; }

        public string Note { get; set; }

        public UblExtensions UblExtensions { get; set; }

        public SignatureCac Signature { get; set; }

        public AccountingSupplierParty AccountingSupplierParty { get; set; }

        public string InvoiceTypeCode { get; set; }

        public string Id { get; set; }

        public AccountingSupplierParty AccountingCustomerParty { get; set; }

        public List<InvoiceLine> InvoiceLines { get; set; }

        public List<InvoiceDocumentReference> DespatchDocumentReferences { get; set; }

        public string DocumentCurrencyCode { get; set; }

        public List<TaxTotal> TaxTotals { get; set; }

        public AllowanceCharge AllowanceCharge { get; set; }

        public LegalMonetaryTotal LegalMonetaryTotal { get; set; }

        public BillingPayment PrepaidPayment { get; set; }

        public string UblVersionId { get; set; }

        public string CustomizationId { get; set; }

        public IFormatProvider Formato { get; set; }

        public Invoice()
        {
            AccountingSupplierParty = new AccountingSupplierParty();
            AccountingCustomerParty = new AccountingSupplierParty();
            DespatchDocumentReferences = new List<InvoiceDocumentReference>();
            UblExtensions = new UblExtensions();
            Signature = new SignatureCac();
            InvoiceLines = new List<InvoiceLine>();
            AllowanceCharge = new AllowanceCharge();
            TaxTotals = new List<TaxTotal>();
            LegalMonetaryTotal = new LegalMonetaryTotal();
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
            writer.WriteAttributeString("xmlns", EspacioNombres.xmlnsInvoice);
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
            writer.WriteStartElement("cbc:ProfileID");
            {
                writer.WriteAttributeString("schemeName", ValoresUbl.TipoOperacionSchemeName);
                writer.WriteAttributeString("schemeAgencyName", ValoresUbl.SchemeAgencyName);
                writer.WriteAttributeString("schemeURI", ValoresUbl.TipoOperacionSchemeUri);
                writer.WriteValue(ProfileId);
            }
            writer.WriteEndElement();
            writer.WriteElementString("cbc:ID", Id);
            writer.WriteElementString("cbc:IssueDate", IssueDate.ToString(Formatos.FormatoFecha));
            if (DueDate != null)
                writer.WriteElementString("cbc:DueDate", DueDate?.ToString(Formatos.FormatoFecha));

            writer.WriteElementString("cbc:IssueTime", IssueTime.ToString(Formatos.FormatoHora));
            writer.WriteStartElement("cbc:InvoiceTypeCode");
            {
                writer.WriteAttributeString("listAgencyName", ValoresUbl.SchemeAgencyName);
                writer.WriteAttributeString("listName", ValoresUbl.InvoiceTypeCodeName);
                writer.WriteAttributeString("listURI", ValoresUbl.InvoiceTypeCodeSchemeUri);
                writer.WriteValue(InvoiceTypeCode);
            }
            writer.WriteEndElement();

            writer.WriteStartElement("cbc:Note");
            {
                writer.WriteAttributeString("languageLocaleID", "1000");
                writer.WriteValue(Note);
            }
            writer.WriteEndElement();

            writer.WriteStartElement("cbc:DocumentCurrencyCode");
            {
                writer.WriteAttributeString("listID", ValoresUbl.DocumentCurrencyCode);
                writer.WriteAttributeString("listName", ValoresUbl.CurrencyListName);
                writer.WriteAttributeString("listAgencyName", ValoresUbl.CurrencyAgencyName);
                writer.WriteValue(DocumentCurrencyCode);
            }
            writer.WriteEndElement();

            writer.WriteElementString("cbc:LineCountNumeric", InvoiceLines.Count.ToString());

            #region DespatchDocumentReferences

            foreach (var reference in DespatchDocumentReferences)
            {
                writer.WriteStartElement("cac:DespatchDocumentReference");
                {
                    writer.WriteElementString("cbc:ID", reference.Id);
                    writer.WriteElementString("cbc:DocumentTypeCode", reference.DocumentTypeCode);
                }
                writer.WriteEndElement();
            }

            #endregion DespatchDocumentReferences

            #region Signature

            writer.WriteStartElement("cac:Signature");
            writer.WriteElementString("cbc:ID", Signature.Id);

            #region SignatoryParty

            writer.WriteStartElement("cac:SignatoryParty");

            writer.WriteStartElement("cac:PartyIdentification");
            writer.WriteElementString("cbc:ID", Signature.SignatoryParty.PartyIdentification.Id.Value);
            writer.WriteEndElement();

            #region PartyName

            writer.WriteStartElement("cac:PartyName");

            //writer.WriteStartElement("cbc:Name");
            //writer.WriteCData(Signature.SignatoryParty.PartyName.Name);
            //writer.WriteEndElement();
            writer.WriteElementString("cbc:Name", Signature.SignatoryParty.PartyName.Name);

            writer.WriteEndElement();

            #endregion PartyName

            writer.WriteEndElement();

            #endregion SignatoryParty

            #region DigitalSignatureAttachment

            writer.WriteStartElement("cac:DigitalSignatureAttachment");

            writer.WriteStartElement("cac:ExternalReference");
            writer.WriteElementString("cbc:URI", Signature.DigitalSignatureAttachment.ExternalReference.Uri.Trim());
            writer.WriteEndElement();

            writer.WriteEndElement();

            #endregion DigitalSignatureAttachment

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
                            writer.WriteAttributeString("schemeID", AccountingSupplierParty.PartyTaxScheme.CompanyId.SchemeId);
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
                        writer.WriteElementString("cbc:RegistrationName", AccountingSupplierParty.PartyTaxScheme.RegistrationName);

                        writer.WriteStartElement("cac:RegistrationAddress");
                        {
                            writer.WriteElementString("cbc:AddressTypeCode", AccountingSupplierParty.Party.PartyLegalEntity.RegistrationAddress.AddressTypeCode);
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                    //#region PartyTaxScheme

                    //writer.WriteStartElement("cac:PartyTaxScheme");
                    //{
                    //    writer.WriteElementString("cbc:RegistrationName", AccountingSupplierParty.PartyTaxScheme.RegistrationName);

                    //    #region CompanyID
                    //    writer.WriteStartElement("cbc:CompanyID");
                    //    {
                    //        writer.WriteAttributeString("schemeID", AccountingSupplierParty.PartyTaxScheme.CompanyId.SchemeId);
                    //        writer.WriteAttributeString("schemeName", ValoresUbl.CompanySchemeName);
                    //        writer.WriteAttributeString("schemeAgencyName", ValoresUbl.SchemeAgencyName);
                    //        writer.WriteAttributeString("schemeURI", ValoresUbl.CompanySchemeUri);
                    //        writer.WriteValue(AccountingSupplierParty.PartyTaxScheme.CompanyId.Value);
                    //    }
                    //    writer.WriteEndElement();
                    //    #endregion

                    //    writer.WriteStartElement("cac:RegistrationAddress");
                    //    {
                    //        writer.WriteElementString("cbc:AddressTypeCode", AccountingSupplierParty.Party.PartyLegalEntity.RegistrationAddress.AddressTypeCode);
                    //    }
                    //    writer.WriteEndElement();

                    //    writer.WriteStartElement("cac:TaxScheme");
                    //    {
                    //        writer.WriteElementString("cbc:ID", "-");
                    //    }
                    //    writer.WriteEndElement();
                    //}
                    //writer.WriteEndElement();

                    //#endregion

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
                            writer.WriteAttributeString("schemeID", AccountingCustomerParty.PartyTaxScheme.CompanyId.SchemeId);
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
                        writer.WriteElementString("cbc:RegistrationName", AccountingSupplierParty.PartyTaxScheme.RegistrationName);
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                #endregion Party
            }
            writer.WriteEndElement();

            #endregion AccountingCustomerParty

            #region PrepaidPayment

            if (PrepaidPayment != null)
            {
                writer.WriteStartElement("cac:PrepaidPayment");
                {
                    writer.WriteStartElement("cbc:ID");
                    {
                        writer.WriteAttributeString("schemeID", PrepaidPayment.Id.SchemeId);
                        writer.WriteValue(PrepaidPayment.Id.Value);
                    }
                    writer.WriteEndElement();
                    writer.WriteStartElement("cbc:PaidAmount");
                    {
                        writer.WriteAttributeString("currencyID", PrepaidPayment.PaidAmount.CurrencyId);
                        writer.WriteValue(PrepaidPayment.PaidAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();
                    writer.WriteStartElement("cbc:InstructionID");
                    {
                        writer.WriteAttributeString("schemeID", "6");
                        writer.WriteValue(PrepaidPayment.InstructionId);
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            #endregion PrepaidPayment

            #region AllowanceCharge
            if (AllowanceCharge.Amount.Value > 0)
            {
                writer.WriteStartElement("cac:AllowanceCharge");
                {
                    writer.WriteElementString("cbc:ChargeIndicator", AllowanceCharge.ChargeIndicator.ToString().ToLower());
                    writer.WriteElementString("cbc:AllowanceChargeReasonCode", AllowanceCharge.ReasonCode);
                    writer.WriteElementString("cbc:MultiplierFactorNumeric", AllowanceCharge.MultiplierFactorNumeric.ToString(Formatos.FormatoNumerico));

                    writer.WriteStartElement("cbc:Amount");
                    {
                        writer.WriteAttributeString("currencyID", AllowanceCharge.Amount.CurrencyId);
                        writer.WriteValue(AllowanceCharge.Amount.Value.ToString(Formatos.FormatoNumerico));
                    }
                    writer.WriteEndElement();
                    if (AllowanceCharge.BaseAmount.Value > 0)
                    {
                        writer.WriteStartElement("cbc:BaseAmount");
                        {
                            writer.WriteAttributeString("currencyID", AllowanceCharge.BaseAmount.CurrencyId);
                            writer.WriteValue(AllowanceCharge.BaseAmount.Value.ToString(Formatos.FormatoNumerico));
                        }
                        writer.WriteEndElement();
                    }
                }
                writer.WriteEndElement();
            }
            #endregion

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
                    {
                        writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxableAmount.CurrencyId);
                        writer.WriteValue(taxTotal.TaxSubtotal.TaxableAmount.Value.ToString(Formatos.FormatoNumerico));
                    }
                    writer.WriteEndElement();

                    writer.WriteStartElement("cbc:TaxAmount");
                    {
                        writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxAmount.CurrencyId);
                        writer.WriteString(taxTotal.TaxAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();

                    #region TaxCategory

                    {
                        writer.WriteStartElement("cac:TaxCategory");

                        writer.WriteStartElement("cbc:ID");
                        {
                            writer.WriteAttributeString("schemeID", ValoresUbl.TaxCategorySchemeId);
                            writer.WriteAttributeString("schemeName", ValoresUbl.TaxCategorySchemeName);
                            writer.WriteAttributeString("schemeAgencyName", ValoresUbl.CurrencyAgencyName);
                            writer.WriteValue(taxTotal.TaxCategoryId);
                        }
                        writer.WriteEndElement();

                        #region TaxScheme

                        {
                            writer.WriteStartElement("cac:TaxScheme");

                            writer.WriteStartElement("cbc:ID");
                            {
                                writer.WriteAttributeString("schemeID", ValoresUbl.TaxCategorySchemeId);
                                writer.WriteAttributeString("schemeAgencyID", "6");
                                writer.WriteValue(taxTotal.TaxSubtotal.TaxCategory.TaxScheme.Id);
                            }
                            writer.WriteEndElement();
                            writer.WriteElementString("cbc:Name", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.Name);
                            writer.WriteElementString("cbc:TaxTypeCode", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.TaxTypeCode);

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

            #region LegalMonetaryTotal

            writer.WriteStartElement("cac:LegalMonetaryTotal");
            {
                if (LegalMonetaryTotal.AllowanceTotalAmount.Value > 0)
                {
                    writer.WriteStartElement("cbc:AllowanceTotalAmount");
                    {
                        writer.WriteAttributeString("currencyID", LegalMonetaryTotal.AllowanceTotalAmount.CurrencyId);
                        writer.WriteValue(LegalMonetaryTotal.AllowanceTotalAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();
                }
                if (LegalMonetaryTotal.PrepaidAmount.Value > 0)
                {
                    writer.WriteStartElement("cbc:PrepaidAmount");
                    {
                        writer.WriteAttributeString("currencyID", LegalMonetaryTotal.PrepaidAmount.CurrencyId);
                        writer.WriteValue(LegalMonetaryTotal.PrepaidAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();
                }
                writer.WriteStartElement("cbc:PayableAmount");
                {
                    writer.WriteAttributeString("currencyID", LegalMonetaryTotal.PayableAmount.CurrencyId);
                    writer.WriteValue(LegalMonetaryTotal.PayableAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            #endregion LegalMonetaryTotal

            //#region InvoiceLines

            foreach (var invoiceLine in InvoiceLines)
            {
                writer.WriteStartElement("cac:InvoiceLine");

                writer.WriteElementString("cbc:ID", invoiceLine.Id.ToString());

                #region InvoicedQuantity

                writer.WriteStartElement("cbc:InvoicedQuantity");
                {
                    writer.WriteAttributeString("unitCode", invoiceLine.InvoicedQuantity.UnitCode);
                    writer.WriteAttributeString("unitCodeListID", ValoresUbl.QuantityCodeListId);
                    writer.WriteAttributeString("unitCodeListAgencyName", ValoresUbl.CurrencyAgencyName);
                    writer.WriteValue(invoiceLine.InvoicedQuantity.Value.ToString(Formatos.FormatoNumerico, Formato));
                }

                writer.WriteEndElement();

                #endregion InvoicedQuantity

                #region LineExtensionAmount

                writer.WriteStartElement("cbc:LineExtensionAmount");
                writer.WriteAttributeString("currencyID", invoiceLine.LineExtensionAmount.CurrencyId);
                writer.WriteValue(invoiceLine.LineExtensionAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                writer.WriteEndElement();

                #endregion LineExtensionAmount

                #region PricingReference

                writer.WriteStartElement("cac:PricingReference");

                #region AlternativeConditionPrice

                foreach (var item in invoiceLine.PricingReference.AlternativeConditionPrices)
                {
                    writer.WriteStartElement("cac:AlternativeConditionPrice");

                    #region PriceAmount

                    writer.WriteStartElement("cbc:PriceAmount");
                    writer.WriteAttributeString("currencyID", item.PriceAmount.CurrencyId);
                    writer.WriteValue(item.PriceAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    writer.WriteEndElement();

                    #endregion PriceAmount

                    #region PriceTypeCode
                    writer.WriteStartElement("cbc:PriceTypeCode");
                    {
                        writer.WriteAttributeString("listName", ValoresUbl.PriceTypeCodeListName);
                        writer.WriteAttributeString("listAgencyName", ValoresUbl.SchemeAgencyName);
                        writer.WriteAttributeString("listURI", ValoresUbl.PriceTypeCodeUri);
                        writer.WriteValue(item.PriceTypeCode);
                    }
                    writer.WriteEndElement();
                    #endregion

                    writer.WriteEndElement();
                }

                #endregion AlternativeConditionPrice

                writer.WriteEndElement();

                #endregion PricingReference

                #region AllowanceCharge

                if (invoiceLine.AllowanceCharge.Amount.Value > 0)
                {
                    writer.WriteStartElement("cac:AllowanceCharge");

                    writer.WriteElementString("cbc:ChargeIndicator", invoiceLine.AllowanceCharge.ChargeIndicator.ToString().ToLower());

                    #region Amount

                    writer.WriteStartElement("cbc:Amount");
                    writer.WriteAttributeString("currencyID", invoiceLine.AllowanceCharge.Amount.CurrencyId);
                    writer.WriteValue(invoiceLine.AllowanceCharge.Amount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    writer.WriteEndElement();

                    #endregion Amount

                    writer.WriteEndElement();
                }

                #endregion AllowanceCharge

                #region TaxTotal
                foreach (var taxTotal in invoiceLine.TaxTotals)
                {
                    writer.WriteStartElement("cac:TaxTotal");
                    {
                        writer.WriteStartElement("cbc:TaxAmount");
                        {
                            writer.WriteAttributeString("currencyID", taxTotal.TaxAmount.CurrencyId);
                            writer.WriteString(taxTotal.TaxAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                        }
                        writer.WriteEndElement();

                        writer.WriteStartElement("cac:TaxSubtotal");
                        {
                            writer.WriteStartElement("cbc:TaxableAmount");
                            {
                                writer.WriteAttributeString("currencyID", taxTotal.TaxAmount.CurrencyId);
                                writer.WriteValue(invoiceLine.LineExtensionAmount.Value.ToString(Formatos.FormatoNumerico));
                            }
                            writer.WriteEndElement();

                            writer.WriteStartElement("cbc:TaxAmount");
                            {
                                writer.WriteAttributeString("currencyID", taxTotal.TaxAmount.CurrencyId);
                                writer.WriteValue(taxTotal.TaxAmount.Value.ToString(Formatos.FormatoNumerico));
                            }
                            writer.WriteEndElement();

                            #region TaxCategory
                            {
                                writer.WriteStartElement("cac:TaxCategory");
                                {
                                    writer.WriteStartElement("cbc:ID");
                                    {
                                        writer.WriteAttributeString("schemeID", ValoresUbl.TaxCategorySchemeId);
                                        writer.WriteAttributeString("schemeName", ValoresUbl.TaxCategorySchemeName);
                                        writer.WriteAttributeString("schemeAgencyName", ValoresUbl.CurrencyAgencyName);
                                        writer.WriteValue(taxTotal.TaxCategoryId);
                                    }
                                    writer.WriteEndElement();

                                    writer.WriteElementString("cbc:Percent", taxTotal.TaxCategory.Percent.ToString(Formatos.FormatoNumerico));
                                    writer.WriteStartElement("cbc:TaxExemptionReasonCode");
                                    {
                                        writer.WriteAttributeString("listAgencyName", ValoresUbl.SchemeAgencyName);
                                        writer.WriteAttributeString("listName", ValoresUbl.TaxExemptionListName);
                                        writer.WriteAttributeString("listURI", ValoresUbl.TaxExemptionUri);
                                        writer.WriteValue(taxTotal.TaxCategory.TaxExemptionReasonCode);
                                    }
                                    writer.WriteEndElement();

                                    #region TaxScheme

                                    writer.WriteStartElement("cac:TaxScheme");
                                    {
                                        writer.WriteStartElement("cbc:ID");
                                        {
                                            writer.WriteAttributeString("schemeID", ValoresUbl.TaxSchemeId);
                                            writer.WriteAttributeString("schemeName", ValoresUbl.TaxSchemeName);
                                            writer.WriteAttributeString("schemeAgencyName", ValoresUbl.CurrencyAgencyName);

                                            writer.WriteValue(taxTotal.TaxCategoryId);
                                        }
                                        writer.WriteEndElement();

                                        writer.WriteElementString("cbc:Name", taxTotal.TaxCategory.TaxScheme.Name);
                                        writer.WriteElementString("cbc:TaxTypeCode",
                                            taxTotal.TaxCategory.TaxScheme.TaxTypeCode);
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
                    writer.WriteEndElement();
                }

                #endregion TaxTotal

                #region Item

                writer.WriteStartElement("cac:Item");
                {
                    #region Description

                    writer.WriteElementString("cbc:Description", invoiceLine.Item.Description);
                    //writer.WriteStartElement("cbc:Description");
                    //writer.WriteCData(invoiceLine.Item.Description);
                    //writer.WriteEndElement();

                    #endregion Description

                    #region SellersItemIdentification

                    writer.WriteStartElement("cac:SellersItemIdentification");
                    {
                        writer.WriteElementString("cbc:ID", invoiceLine.Item.SellersItemIdentification.Id);
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
                        writer.WriteAttributeString("currencyID", invoiceLine.Price.PriceAmount.CurrencyId);
                        writer.WriteString(invoiceLine.Price.PriceAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();

                }
                writer.WriteEndElement();

                #endregion Price

                writer.WriteEndElement();
            }

            //#endregion InvoiceLines
        }
    }
}