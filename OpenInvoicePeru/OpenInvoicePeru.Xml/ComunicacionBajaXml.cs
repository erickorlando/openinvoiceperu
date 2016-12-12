using System;
using OpenInvoicePeru.Comun.Dto.Modelos;
using OpenInvoicePeru.Estructuras;

namespace OpenInvoicePeru.Xml
{
    public class ComunicacionBajaXml : IDocumentoXml<ComunicacionBaja, VoidedDocuments>
    {
        VoidedDocuments IDocumentoXml<ComunicacionBaja, VoidedDocuments>.Generar(ComunicacionBaja documento)
        {
            var voidedDocument = new VoidedDocuments
            {
                Id = documento.IdDocumento,
                IssueDate = Convert.ToDateTime(documento.FechaEmision),
                ReferenceDate = Convert.ToDateTime(documento.FechaReferencia),
                CustomizationId = "1.0",
                UblVersionId = "2.0",
                Signature = new SignatureCac
                {
                    Id = documento.IdDocumento,
                    SignatoryParty = new SignatoryParty
                    {
                        PartyIdentification = new PartyIdentification
                        {
                            Id = new PartyIdentificationId
                            {
                                Value = documento.Emisor.NroDocumento
                            }
                        },
                        PartyName = new PartyName
                        {
                            Name = documento.Emisor.NombreLegal
                        }
                    },
                    DigitalSignatureAttachment = new DigitalSignatureAttachment
                    {
                        ExternalReference = new ExternalReference
                        {
                            Uri = $"{documento.Emisor.NroDocumento}-{documento.IdDocumento}"
                        }
                    }
                },
                AccountingSupplierParty = new AccountingSupplierParty
                {
                    CustomerAssignedAccountId = documento.Emisor.NroDocumento,
                    AdditionalAccountId = documento.Emisor.TipoDocumento,
                    Party = new Party
                    {
                        PartyLegalEntity = new PartyLegalEntity
                        {
                            RegistrationName = documento.Emisor.NombreLegal
                        }
                    }
                }
            };

            foreach (var baja in documento.Bajas)
            {
                voidedDocument.VoidedDocumentsLines.Add(new VoidedDocumentsLine
                {
                    LineId = baja.Id,
                    DocumentTypeCode = baja.TipoDocumento,
                    DocumentSerialId = baja.Serie,
                    DocumentNumberId = Convert.ToInt32(baja.Correlativo),
                    VoidReasonDescription = baja.MotivoBaja
                });
            }

            return voidedDocument;
        }
    }
}