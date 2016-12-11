![Open Invoice Perú](https://raw.githubusercontent.com/erickorlando/facturacionelectronicasunat/master/openinvoiceperulogo.PNG "Open Invoice Perú")
# OpenInvoicePeru v1.1.0.1205 #
OpenInvoicePeru es un proyecto Open Source construido con C#, haciendo sencilla la Facturación Electrónica de SUNAT, este proyecto está más orientado al desarrollador.
Permite la generacion de XML, empaquetado, envío y recepción de documentos electrónicos a través de una API REST.

Actualmente ya se puede usar en entornos de Producción, si encuentras algún bug por favor reportalo a la zona de [Issues de GitHub](https://github.com/erickorlando/facturacionelectronicasunat/issues).

# Características #
- Generacion de XML para Facturas, Boletas, Notas de Crédito, Notas de Débito, Resumen Diario de Boletas, Comunicaciones de Baja y Retenciones.
- Firmado del XML con un certificado digital elegido por el usuario.
- Envío al servicio Web de SUNAT de los documentos electrónicos generados.
- Envío de Resumen Diario y Comunicación de Baja.
- Desempaquetado y Lectura del contenido del CDR de SUNAT.
- Guardado de XML firmados y CDR de SUNAT.
- Consulta de Tickets de los Resúmenes y Bajas.
- API REST bajo ASP.NET Web API 2.
- Aplicación Windows de prueba de envío a SUNAT.
- Ejemplos en VB y C# para el consumo de la API REST con PostSharp bajo .NET 4.0.

## Ramas (branches) ##

El proyecto contiene dos ramas:

- master (versión estable)
- develop (versión de desarrollo)

## Consideraciones ##
El proyecto se ha desarrollado con VS2015 Update 3, usando como base el .NET Framework 4.6.1
Se recomienda usar encarecidamente VS2015, la edición [Community Edition](https://www.visualstudio.com/downloads/download-visual-studio-vs), es gratis y mucho mejor que sus predecesores.
Puedes usar la versión Professional o Enterprise si lo deseas.

Para poder ejecutar correctamente el proyecto debes iniciar la depuración de los siguientes proyectos al [mismo tiempo](https://msdn.microsoft.com/es-es/library/ms165413.aspx):

* OpenInvoicePeru.WinApp (Proyecto Windows)
* OpenInvoicePeru.WebApi (API REST)

![Open Invoice Perú](https://raw.githubusercontent.com/erickorlando/facturacionelectronicasunat/master/InicioMultiple.png "Open Invoice Perú")

Si quieres colaborar con tu granito de arena puedes hacer un Fork.

Si tienes dudas escribeme a mi página de [Facebook](http://m.me/erickorlandoblog)

Y no te olvides de darte una vuelta por mi [Blog](http://erickorlando.com/2016/05/07/proyecto-opensource-facturacion-electronica-sunat/)

## Disclaimer ##

Este software se entrega como tal y eres libre de modificarlo a tu gusto, copiarlo en su totalidad 
o de manera parcial, lo unico que pido es que se respete la creación del autor.

Así mismo no hay garantía expresa de este producto, cualquier inconveniente que se presente con SUNAT 
es enteramente responsabilidad del usuario al usar este Software. 

Si tienes errores con SUNAT fijate en el código devuelto:

- Del 0100 al 1999 Excepciones (Usuarios mal escritos, RUCs no validos, etc.)
- Del 2000 al 3999 Errores que generan rechazo (Se envia pero rebota)
- Del 4000 en adelante Observaciones (Correcciones menores)

Si tienes mas dudas con SUNAT comunícate con ellos al +51 1 3150730.

## Asesoría personalizada ##

Si necesitas que te apoye con la Homologación (Emisor o Proveedor) puedes contactarme 
directamente a mi correo personal (erickorlando@live.com.pe) y podemos concertar una reunión virtual.
Recuerda que si bien mi proyecto es de código abierto, yo vendo el soporte y consultoría técnica.
