using OpenInvoicePeru.Comun;
using OpenInvoicePeru.Comun.Constantes;
using OpenInvoicePeru.Estructuras.CommonAggregateComponents;
using OpenInvoicePeru.Estructuras.CommonExtensionComponents;
using OpenInvoicePeru.Estructuras.SunatAggregateComponents;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public List<InvoiceDocumentReference> AdditionalDocumentReferences { get; set; }

        public string DocumentCurrencyCode { get; set; }

        public List<TaxTotal> TaxTotals { get; set; }

        public AllowanceCharge AllowanceCharge { get; set; }

        public LegalMonetaryTotal LegalMonetaryTotal { get; set; }

        public BillingPayment PrepaidPayment { get; set; }

        public List<BillingPayment> PrepaidPayments { get; set; }

        public string OrderReference { get; set; }

        /// <summary>
        /// Codigo de BS de Detracciones
        /// </summary>
        public string PaymentMeansId { get; set; }

        /// <summary>
        /// Nro. Cuenta BN Detracciones
        /// </summary>
        public string PayeeFinancialAccountId { get; set; }

        /// <summary>
        /// Monto Detraccion
        /// </summary>
        public decimal PaymentTermsAmount { get; set; }

        /// <summary>
        /// Tasa Detraccion
        /// </summary>
        public decimal PaymentTermsPercent { get; set; }

        /// <summary>
        /// Codigo de Medio de Pago
        /// </summary>
        public string PaymentMeansCode { get; set; }

        public Dictionary<string, string> NotesList { get; set; }

        public string UblVersionId { get; set; }

        public string CustomizationId { get; set; }

        public IFormatProvider Formato { get; set; }

        public bool Credito { get; set; }

        public List<InfoCredits> InfoCreditsList { get; set; }

        public Invoice()
        {
            AccountingSupplierParty = new AccountingSupplierParty();
            AccountingCustomerParty = new AccountingSupplierParty();
            DespatchDocumentReferences = new List<InvoiceDocumentReference>();
            AdditionalDocumentReferences = new List<InvoiceDocumentReference>();
            PrepaidPayments = new List<BillingPayment>();
            UblExtensions = new UblExtensions();
            Signature = new SignatureCac();
            InvoiceLines = new List<InvoiceLine>();
            AllowanceCharge = new AllowanceCharge();
            TaxTotals = new List<TaxTotal>();
            NotesList = new Dictionary<string, string>();
            LegalMonetaryTotal = new LegalMonetaryTotal();
            InfoCreditsList = new List<InfoCredits>();
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
            writer.WriteElementString("cbc:ID", Id);
            writer.WriteElementString("cbc:IssueDate", IssueDate.ToString(Formatos.FormatoFecha));
            writer.WriteElementString("cbc:IssueTime", IssueTime.ToString(Formatos.FormatoHora));
            if (DueDate != null)
                writer.WriteElementString("cbc:DueDate", DueDate?.ToString(Formatos.FormatoFecha));

            writer.WriteStartElement("cbc:InvoiceTypeCode");
            {
                writer.WriteAttributeString("listAgencyName", ValoresUbl.SchemeAgencyName);
                writer.WriteAttributeString("listName", ValoresUbl.InvoiceTypeCodeName);
                writer.WriteAttributeString("listURI", ValoresUbl.InvoiceTypeCodeSchemeUri);
                writer.WriteAttributeString("listID", ProfileId);
                writer.WriteAttributeString("name", ValoresUbl.TipoOperacionSchemeName);
                writer.WriteAttributeString("listSchemeURI", ValoresUbl.TipoOperacionSchemeUri);

                writer.WriteValue(InvoiceTypeCode);
            }
            writer.WriteEndElement();

            writer.WriteStartElement("cbc:Note");
            {
                writer.WriteAttributeString("languageLocaleID", "1000");
                writer.WriteValue(Note);
            }
            writer.WriteEndElement();

            foreach (var note in NotesList)
            {
                writer.WriteStartElement("cbc:Note");
                {
                    writer.WriteAttributeString("languageLocaleID", note.Key);
                    writer.WriteValue(note.Value);
                }
                writer.WriteEndElement();
            }

            writer.WriteStartElement("cbc:DocumentCurrencyCode");
            {
                writer.WriteAttributeString("listID", ValoresUbl.DocumentCurrencyCode);
                writer.WriteAttributeString("listName", ValoresUbl.CurrencyListName);
                writer.WriteAttributeString("listAgencyName", ValoresUbl.CurrencyAgencyName);
                writer.WriteValue(DocumentCurrencyCode);
            }
            writer.WriteEndElement();

            writer.WriteElementString("cbc:LineCountNumeric", InvoiceLines.Count.ToString());

            writer.WriteComment(Properties.Resources.Comment);

            #region OrderReference
            if (!string.IsNullOrEmpty(OrderReference))
            {
                writer.WriteStartElement("cac:OrderReference");
                {
                    writer.WriteElementString("cbc:ID", OrderReference);
                }
                writer.WriteEndElement();
            }
            #endregion

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

            #region AdditionalDocumentReference

            foreach (var item in AdditionalDocumentReferences)
            {
                writer.WriteStartElement("cac:AdditionalDocumentReference");
                {
                    writer.WriteElementString("cbc:ID", item.Id);
                    writer.WriteStartElement("cbc:DocumentTypeCode");
                    {
                        writer.WriteAttributeString("listName", "Documento Relacionado");
                        writer.WriteAttributeString("listAgencyName", ValoresUbl.SchemeAgencyName);
                        writer.WriteAttributeString("listURI", ValoresUbl.AdditionalDocumentsSchemeUri);
                        writer.WriteValue(item.DocumentTypeCode);
                    }
                    writer.WriteEndElement();

                    writer.WriteStartElement("cbc:DocumentStatusCode");
                    {
                        writer.WriteAttributeString("listName", "Anticipo");
                        writer.WriteAttributeString("listAgencyName", ValoresUbl.SchemeAgencyName);
                        writer.WriteValue(item.Id);
                    }
                    writer.WriteEndElement();

                    writer.WriteStartElement("cac:IssuerParty");
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
                        writer.WriteElementString("cbc:RegistrationName", AccountingCustomerParty.PartyTaxScheme.RegistrationName);
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                #endregion Party
            }
            writer.WriteEndElement();

            #endregion AccountingCustomerParty

            #region PaymentMeans
            if (!string.IsNullOrEmpty(PayeeFinancialAccountId))
            {
                writer.WriteStartElement("cac:PaymentMeans");
                {
                    writer.WriteElementString("cbc:ID", "Detraccion");
                    writer.WriteElementString("cbc:PaymentMeansCode", PaymentMeansCode); // Medio de Pago (Catalogo 59)
                    writer.WriteStartElement("cac:PayeeFinancialAccount");
                    {
                        writer.WriteElementString("cbc:ID", PayeeFinancialAccountId);
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteStartElement("cac:PaymentTerms");
                {
                    writer.WriteElementString("cbc:ID", "Detraccion");
                    writer.WriteStartElement("cbc:PaymentMeansID");
                    {
                        writer.WriteAttributeString("schemeName", ValoresUbl.PaymentMeansSchemeName);
                        writer.WriteAttributeString("schemeAgencyName", ValoresUbl.SchemeAgencyName);
                        writer.WriteAttributeString("schemeURI", ValoresUbl.PaymentMeansSchemeUri);
                        writer.WriteValue(PaymentMeansId);
                    }
                    writer.WriteEndElement();
                    writer.WriteElementString("cbc:PaymentPercent", PaymentTermsPercent.ToString(Formatos.FormatoNumerico, Formato));
                    writer.WriteStartElement("cbc:Amount");
                    {
                        writer.WriteAttributeString("currencyID", DocumentCurrencyCode != "PEN" ? "PEN" : DocumentCurrencyCode);
                        writer.WriteValue(PaymentTermsAmount.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            #endregion

            #region PrepaidPayment
            if (PrepaidPayments != null)
                foreach (var prepaidPayment in PrepaidPayments)
                {
                    writer.WriteComment("Inicio de Anticipo");
                    writer.WriteStartElement("cac:PrepaidPayment");
                    {
                        writer.WriteStartElement("cbc:ID");
                        {
                            writer.WriteAttributeString("schemeName", "Anticipo");
                            writer.WriteAttributeString("schemeAgencyName", ValoresUbl.SchemeAgencyName);
                            writer.WriteValue(prepaidPayment.Id.Value);
                        }
                        writer.WriteEndElement();

                        writer.WriteStartElement("cbc:PaidAmount");
                        {
                            writer.WriteAttributeString("currencyID", prepaidPayment.PaidAmount.CurrencyId);
                            writer.WriteValue(prepaidPayment.PaidAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                        }
                        writer.WriteEndElement();

                        // Segun documentacion de SUNAT esto ya no va.
                        //writer.WriteStartElement("cbc:InstructionID");
                        //{
                        //    writer.WriteAttributeString("schemeID", "6");
                        //    writer.WriteValue(prepaidPayment.InstructionId);
                        //}
                        //writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteComment("Fin de Anticipo");
                }

            #endregion PrepaidPayment

            #region Credito

            writer.WriteComment("Inicio Credito o al Contado");

            writer.WriteStartElement("cac:PaymentTerms");
            {
                writer.WriteElementString("cbc:ID", "FormaPago");
                writer.WriteElementString("cbc:PaymentMeansID", Credito ? "Credito" : "Contado");
                if (Credito)
                {
                    writer.WriteStartElement("cbc:Amount");
                    {
                        writer.WriteAttributeString("currencyID", DocumentCurrencyCode);
                        writer.WriteValue(LegalMonetaryTotal.PayableAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();

            if (Credito)
            {
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
            }

            writer.WriteComment("Fin Credito o al Contado");

            #endregion

            #region AllowanceCharge
            if (AllowanceCharge.Amount.Value > 0)
            {
                writer.WriteStartElement("cac:AllowanceCharge");
                {
                    writer.WriteElementString("cbc:ChargeIndicator", AllowanceCharge.ChargeIndicator.ToString().ToLower());

                    //writer.WriteElementString("cbc:AllowanceChargeReasonCode", AllowanceCharge.ReasonCode);
                    writer.WriteStartElement("cbc:AllowanceChargeReasonCode");
                    {
                        writer.WriteAttributeString("listAgencyName", ValoresUbl.SchemeAgencyName);
                        writer.WriteAttributeString("listName", "Cargo/descuento");
                        writer.WriteAttributeString("listURI", ValoresUbl.AllowanceChargeReasonCodeListUri);
                        writer.WriteValue(AllowanceCharge.ReasonCode);
                    }
                    writer.WriteEndElement();

                    if (AllowanceCharge.MultiplierFactorNumeric > 0)
                        writer.WriteElementString("cbc:MultiplierFactorNumeric",
                            AllowanceCharge.MultiplierFactorNumeric.ToString("###0.####0", Formato));

                    writer.WriteStartElement("cbc:Amount");
                    {
                        writer.WriteAttributeString("currencyID", AllowanceCharge.Amount.CurrencyId);
                        writer.WriteValue(AllowanceCharge.Amount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();
                    if (AllowanceCharge.BaseAmount.Value > 0)
                    {
                        writer.WriteStartElement("cbc:BaseAmount");
                        {
                            writer.WriteAttributeString("currencyID", AllowanceCharge.BaseAmount.CurrencyId);
                            writer.WriteValue(AllowanceCharge.BaseAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
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

                                    /* La etiqueta cac:TaxCategoryID para el TaxTotal de la Cabecera
                                     ya no aparece en el Excel de Validaciones de SUNAT */

                                    //writer.WriteStartElement("cbc:ID");
                                    //{
                                    //    //writer.WriteAttributeString("schemeID", ValoresUbl.TaxCategorySchemeId);
                                    //    //writer.WriteAttributeString("schemeName", ValoresUbl.TaxCategorySchemeName);
                                    //    //writer.WriteAttributeString("schemeAgencyName", ValoresUbl.SchemeAgencyName);
                                    //    writer.WriteValue(taxSubTotal.TaxCategory.Id);
                                    //}
                                    //writer.WriteEndElement();

                                    #region TaxScheme

                                    {
                                        writer.WriteStartElement("cac:TaxScheme");
                                        {
                                            writer.WriteStartElement("cbc:ID");
                                            {
                                                writer.WriteAttributeString("schemeAgencyID", "6");
                                                writer.WriteAttributeString("schemeAgencyName", ValoresUbl.SchemeAgencyName);
                                                writer.WriteAttributeString("schemeID", ValoresUbl.TaxCategorySchemeId);
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


                if (LegalMonetaryTotal.PrepaidAmount.Value > 0)
                {
                    writer.WriteStartElement("cbc:PrepaidAmount");
                    {
                        writer.WriteAttributeString("currencyID", LegalMonetaryTotal.PrepaidAmount.CurrencyId);
                        writer.WriteValue(LegalMonetaryTotal.PrepaidAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();
                }

                if (LegalMonetaryTotal.PayableRoundingAmount.Value > 0)
                {
                    writer.WriteStartElement("cbc:PayableRoundingAmount");
                    {
                        writer.WriteAttributeString("currencyID", LegalMonetaryTotal.PayableRoundingAmount.CurrencyId);
                        writer.WriteValue(LegalMonetaryTotal.PayableRoundingAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();
                }

                if (LegalMonetaryTotal.ChargeTotalAmount.Value > 0)
                {
                    writer.WriteStartElement("cbc:ChargeTotalAmount");
                    {
                        writer.WriteAttributeString("currencyID", LegalMonetaryTotal.ChargeTotalAmount.CurrencyId);
                        writer.WriteValue(LegalMonetaryTotal.ChargeTotalAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
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

            #region InvoiceLines

            foreach (var invoiceLine in InvoiceLines)
            {
                writer.WriteStartElement("cac:InvoiceLine");
                {

                    writer.WriteElementString("cbc:ID", invoiceLine.Id.ToString());

                    #region InvoicedQuantity

                    writer.WriteStartElement("cbc:InvoicedQuantity");
                    {
                        writer.WriteAttributeString("unitCode", invoiceLine.InvoicedQuantity.UnitCode);
                        //writer.WriteAttributeString("unitCodeListID", ValoresUbl.QuantityCodeListId);
                        //writer.WriteAttributeString("unitCodeListAgencyName", ValoresUbl.CurrencyAgencyName);
                        writer.WriteValue(invoiceLine.InvoicedQuantity.Value.ToString(Formatos.FormatoNumericoExtenso, Formato));
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
                    {
                        #region AlternativeConditionPrice

                        foreach (var item in invoiceLine.PricingReference.AlternativeConditionPrices)
                        {
                            writer.WriteStartElement("cac:AlternativeConditionPrice");
                            {

                                #region PriceAmount

                                writer.WriteStartElement("cbc:PriceAmount");
                                {
                                    writer.WriteAttributeString("currencyID", item.PriceAmount.CurrencyId);
                                    writer.WriteValue(item.PriceAmount.Value.ToString(Formatos.FormatoNumericoExtenso, Formato));
                                }
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

                            }
                            writer.WriteEndElement();
                        }

                        #endregion AlternativeConditionPrice
                    }
                    writer.WriteEndElement();

                    #endregion PricingReference

                    #region Delivery
                    if (invoiceLine.Delivery != null && !string.IsNullOrEmpty(invoiceLine.Delivery.Despatch.Instructions))
                    {
                        writer.WriteStartElement("cac:Delivery");
                        {
                            writer.WriteStartElement("cac:DeliveryLocation");
                            {
                                writer.WriteStartElement("cac:Address");
                                {
                                    writer.WriteStartElement("cbc:ID");
                                    {
                                        writer.WriteAttributeString("schemeAgencyName", ValoresUbl.SchemeAgencyNameInei);
                                        writer.WriteAttributeString("schemeName", "Ubigeos");
                                        writer.WriteValue(invoiceLine.Delivery.DeliveryLocation.DespatchAddress.Id);
                                    }
                                    writer.WriteEndElement();
                                    writer.WriteStartElement("cac:AddressLine");
                                    {
                                        writer.WriteElementString("cbc:Line", invoiceLine.Delivery.DeliveryLocation.DespatchAddress.AddressLine);
                                    }
                                    writer.WriteEndElement();
                                }
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();

                            writer.WriteStartElement("cac:Despatch");
                            {
                                writer.WriteElementString("cbc:Instructions", invoiceLine.Delivery.Despatch.Instructions);
                                writer.WriteStartElement("cac:DespatchAddress");
                                {
                                    writer.WriteStartElement("cbc:ID");
                                    {
                                        writer.WriteAttributeString("schemeAgencyName", ValoresUbl.SchemeAgencyNameInei);
                                        writer.WriteAttributeString("schemeName", "Ubigeos");
                                        writer.WriteValue(invoiceLine.Delivery.Despatch.DespatchAddress.Id);
                                    }
                                    writer.WriteEndElement();
                                    writer.WriteStartElement("cac:AddressLine");
                                    {
                                        writer.WriteElementString("cbc:Line", invoiceLine.Delivery.Despatch.DespatchAddress.AddressLine);
                                    }
                                    writer.WriteEndElement();
                                }
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                            foreach (var deliveryTerm in invoiceLine.Delivery.DeliveryTerms)
                            {
                                writer.WriteStartElement("cac:DeliveryTerms");
                                {
                                    writer.WriteElementString("cbc:ID", deliveryTerm.Id);
                                    writer.WriteStartElement("cbc:Amount");
                                    {
                                        writer.WriteAttributeString("currencyID", deliveryTerm.Amount.CurrencyId);
                                        writer.WriteValue(deliveryTerm.Amount.Value.ToString(Formatos.FormatoNumerico, Formato));
                                    }
                                    writer.WriteEndElement();
                                }
                                writer.WriteEndElement();
                            }
                        }
                        writer.WriteEndElement();
                    }
                    #endregion

                    #region AllowanceCharge

                    if (invoiceLine.AllowanceCharge.Amount.Value > 0)
                    {
                        writer.WriteStartElement("cac:AllowanceCharge");
                        {
                            writer.WriteElementString("cbc:ChargeIndicator", invoiceLine.AllowanceCharge.ChargeIndicator.ToString().ToLower());
                            writer.WriteElementString("cbc:AllowanceChargeReasonCode", invoiceLine.AllowanceCharge.ReasonCode);

                            #region Amount

                            writer.WriteStartElement("cbc:Amount");
                            {
                                writer.WriteAttributeString("currencyID", invoiceLine.AllowanceCharge.Amount.CurrencyId);
                                writer.WriteValue(invoiceLine.AllowanceCharge.Amount.Value.ToString(Formatos.FormatoNumerico, Formato));
                            }
                            writer.WriteEndElement();

                            #endregion Amount
                        }
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

                            foreach (var taxSubTotal in taxTotal.TaxSubTotals)
                            {
                                writer.WriteStartElement("cac:TaxSubtotal");
                                {
                                    if (taxSubTotal.TaxCategory.TaxScheme.Name != "ICBPER")
                                    {
                                        writer.WriteStartElement("cbc:TaxableAmount");
                                        {
                                            writer.WriteAttributeString("currencyID", taxSubTotal.TaxAmount.CurrencyId);
                                            decimal monto;

                                            if (taxSubTotal.TaxableAmount.Value > 0)
                                                monto = taxSubTotal.TaxableAmount.Value;
                                            else
                                            {
                                                monto = invoiceLine.Price.PriceAmount.Value * invoiceLine.InvoicedQuantity.Value;
                                                if (monto == 0)
                                                    monto = invoiceLine.PricingReference
                                                                .AlternativeConditionPrices
                                                                .First().PriceAmount.Value
                                                            * invoiceLine.InvoicedQuantity.Value;
                                            }


                                            writer.WriteValue(monto.ToString(Formatos.FormatoNumerico, Formato));
                                        }
                                        writer.WriteEndElement();
                                    }

                                    writer.WriteStartElement("cbc:TaxAmount");
                                    {
                                        writer.WriteAttributeString("currencyID", taxSubTotal.TaxAmount.CurrencyId);
                                        writer.WriteValue(taxSubTotal.TaxAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                                    }
                                    writer.WriteEndElement();

                                    if (taxSubTotal.BaseUnitMeasure.Value > 0)
                                    {
                                        writer.WriteStartElement("cbc:BaseUnitMeasure");
                                        {
                                            writer.WriteAttributeString("unitCode", taxSubTotal.BaseUnitMeasure.UnitCode);
                                            writer.WriteValue(taxSubTotal.BaseUnitMeasure.Value.ToString("#0", Formato));
                                        }
                                        writer.WriteEndElement();
                                    }
                                    if (taxSubTotal.TaxCategory.PerUnitAmount.Value > 0)
                                    {
                                        writer.WriteStartElement("cbc:PerUnitAmount");
                                        {
                                            writer.WriteAttributeString("currencyID", taxSubTotal.TaxAmount.CurrencyId);
                                            writer.WriteValue(taxSubTotal.TaxCategory.PerUnitAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                                        }
                                        writer.WriteEndElement();
                                    }

                                    #region TaxCategory
                                    {
                                        writer.WriteStartElement("cac:TaxCategory");
                                        {
                                            if (taxSubTotal.TaxCategory.TaxScheme.Name != "ICBPER")
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
                                                    //writer.WriteAttributeString("listAgencyName", ValoresUbl.SchemeAgencyName);
                                                    //writer.WriteAttributeString("listName", ValoresUbl.TaxExemptionListName);
                                                    //writer.WriteAttributeString("listURI", ValoresUbl.TaxExemptionUri);
                                                    writer.WriteValue(taxSubTotal.TaxCategory.TaxExemptionReasonCode);
                                                }
                                                writer.WriteEndElement();
                                            }

                                            if (!string.IsNullOrEmpty(taxSubTotal.TaxCategory.TierRange))
                                            {
                                                writer.WriteElementString("cbc:TierRange", taxSubTotal.TaxCategory.TierRange);
                                            }

                                            #region TaxScheme

                                            writer.WriteStartElement("cac:TaxScheme");
                                            {
                                                writer.WriteStartElement("cbc:ID");
                                                {
                                                    //if (taxSubTotal.TaxCategory.TaxScheme.Name == "ICBPER")
                                                    //    writer.WriteAttributeString("schemeURI",
                                                    //        "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo05");
                                                    //else
                                                    //    writer.WriteAttributeString("schemeID", ValoresUbl.TaxSchemeId);
                                                    //writer.WriteAttributeString("schemeName", ValoresUbl.TaxCategorySchemeName);
                                                    //writer.WriteAttributeString("schemeAgencyName", ValoresUbl.SchemeAgencyName);

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
                        #region Description

                        writer.WriteElementString("cbc:Description", invoiceLine.Item.Description);

                        #endregion Description

                        #region SellersItemIdentification

                        writer.WriteStartElement("cac:SellersItemIdentification");
                        {
                            writer.WriteElementString("cbc:ID", invoiceLine.Item.SellersItemIdentification.Id);
                        }
                        writer.WriteEndElement();

                        #endregion SellersItemIdentification

                        #region CommodytiClassification
                        if (!string.IsNullOrEmpty(invoiceLine.Item.CommodityClassification.ItemClassificationCode))
                        {
                            writer.WriteStartElement("cac:CommodityClassification");
                            {
                                writer.WriteStartElement("cbc:ItemClassificationCode");
                                {
                                    writer.WriteAttributeString("listID", ValoresUbl.UnspscListId);
                                    writer.WriteAttributeString("listAgencyName", ValoresUbl.UnspscListAgencyName);
                                    writer.WriteAttributeString("listName", ValoresUbl.UnspscListName);
                                    writer.WriteValue(invoiceLine.Item.CommodityClassification.ItemClassificationCode);
                                }
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                        }
                        #endregion

                        #region AdditionalProperties
                        foreach (var additionalProperty in invoiceLine.Item.AdditionalItemProperties)
                        {
                            writer.WriteStartElement("cac:AdditionalItemProperty");
                            {
                                if (!string.IsNullOrEmpty(additionalProperty.Name))
                                    writer.WriteElementString("cbc:Name", additionalProperty.Name);

                                writer.WriteStartElement("cbc:NameCode");
                                {
                                    writer.WriteAttributeString("listName", "Propiedad del item");
                                    writer.WriteAttributeString("listAgencyName", ValoresUbl.SchemeAgencyName);
                                    writer.WriteAttributeString("listURI", ValoresUbl.AdditionalPropertyListUri);
                                    writer.WriteValue(additionalProperty.NameCode);
                                }
                                writer.WriteEndElement();

                                if (!string.IsNullOrEmpty(additionalProperty.Value))
                                    writer.WriteElementString("cbc:Value", additionalProperty.Value);

                                if (!string.IsNullOrEmpty(additionalProperty.UsabilityPeriod.StartDate))
                                {
                                    writer.WriteStartElement("cac:UsabilityPeriod");
                                    {
                                        writer.WriteElementString("cbc:StartDate", additionalProperty.UsabilityPeriod.StartDate);
                                        writer.WriteElementString("cbc:EndDate", additionalProperty.UsabilityPeriod.EndDate);
                                        if (additionalProperty.UsabilityPeriod.DurationMeasure > 0)
                                        {
                                            writer.WriteStartElement("cbc:DurationMeasure");
                                            {
                                                writer.WriteAttributeString("unitCode", "DAY");
                                                writer.WriteValue(additionalProperty.UsabilityPeriod.DurationMeasure.ToString());
                                            }
                                            writer.WriteEndElement();
                                        }
                                    }
                                    writer.WriteEndElement();
                                }
                            }
                            writer.WriteEndElement();
                        }
                        #endregion
                    }
                    writer.WriteEndElement();

                    #endregion Item

                    #region Price

                    writer.WriteStartElement("cac:Price");
                    {
                        writer.WriteStartElement("cbc:PriceAmount");
                        {
                            writer.WriteAttributeString("currencyID", invoiceLine.Price.PriceAmount.CurrencyId);
                            writer.WriteString(invoiceLine.Price.PriceAmount.Value.ToString(Formatos.FormatoNumericoExtenso, Formato));
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                    #endregion Price

                }
                writer.WriteEndElement();
            }

            #endregion InvoiceLines


        }
    }
}