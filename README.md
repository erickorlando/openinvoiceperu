# Facturación Electrónica SUNAT
Repositorio para la conexión con el Servicio Web de Facturación Electrónica SUNAT

## Novedades del 16/06/2016 ##
Ahora el programa puede leer la respuesta que envía a SUNAT una vez que el proceso se completó correctamente.

## Como crear un XML con las clases de generacion ##
Por ejemplo para crear un XML de Factura (Invoice) se debe escribir lo siguiente:

```csharp
// Llenamos los datos de la factura.
var documento = new Invoice
{
	UblExtensions = new UBLExtensions
	{
		Extension2 = new UBLExtension()
		{
			ExtensionContent = new ExtensionContent()
			{
				AdditionalInformation = new AdditionalInformation()
				{
					AdditionalMonetaryTotals = new List<AdditionalMonetaryTotal>
					{ new AdditionalMonetaryTotal()
					{
						ID = "1001",
						PayableAmount = new PayableAmount()
						{
							currencyID = "PEN",
							value = 92.37m
						}
					}},
					AdditionalProperties = new List<AdditionalProperty>
					{
					new AdditionalProperty()
					{
						ID = 1000,
						Value = "CIENTO NUEVE CON 00/100  SOLES"
					}}
				}
			}
		},
	},
	ID = "F669-131",
	IssueDate = new DateTime(2016, 1, 6),
	InvoiceTypeCode = "01",
	DocumentCurrencyCode = "PEN",
	Signature = new SignatureCac
	{
		ID = "SF669-131",
		SignatoryParty = new SignatoryParty
		{
			PartyIdentification = new PartyIdentification
			{
				ID = new PartyIdentificationID { value = "20378890161" }
			},
			PartyName = new PartyName()
			{
				Name = "SUNAT"
			}
		},
		DigitalSignatureAttachment = new DigitalSignatureAttachment()
		{
			ExternalReference = new ExternalReference()
			{
				URI = "#SF669-131-160106192920"
			}
		}
	}
};
// LLenar los demas datos ....
var serializador = new Serializador();
serializador.TipoDocumento = 1;
var tramaXmlFirmado = serializador.GenerarXml(documento);
// Como el texto devuelto es un Base64 lo convertimos a un array de Bytes.
var tramaBinaria = new MemoryStream(Convert.FromBase64String(tramaXmlFirmado));
var nombreArchivo = "20378890161-01-F669-131";
ruta = string.Format(@"{0}\{1}.xml", Directory.GetCurrentDirectory(), nombreArchivo);
using (var fs = new FileStream(ruta, FileMode.Create))
{
	byte[] buffer = new byte[tramaBinaria.Length];
	int sourceBytes;
	do
	{
		sourceBytes = tramaBinaria.Read(buffer, 0, buffer.Length);
		fs.Write(buffer, 0, sourceBytes);
	} while (sourceBytes > 0);
}
// Abrir el documento XML con el programa predeterminado de extensiones XML
System.Diagnostics.Process.Start(ruta);
```
### Consideraciones ###
El proyecto se ha desarrollado con VS2015 Update 2, pero usando como base el 
.NET Framework 4.5.

Si tienes problemas para compilar revisa las [características de C# 6.0](https://msdn.microsoft.com/es-es/magazine/dn879355.aspx) que se usan en este proyecto.
Pon especial énfasis en la interpolación de cadenas.

Si quieres colaborar con tu granito de arena puedes hacer un Pull Request.

Si tienes dudas escribeme a mi página de [Faceebok](http://m.me/erickorlandoblog)

Visita mi [Blog](http://erickorlando.com)
