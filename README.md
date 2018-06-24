![Open Invoice Perú](http://frameworkperu.com/OpenInvoicePeruLogo.png "Open Invoice Perú")
# OpenInvoicePeru v2.0 #
Esta es  una versión privada de OpenInvoicePeru construido con C#, haciendo sencilla la Facturación Electrónica de SUNAT, este proyecto está orientado al desarrollador.
Permite la generacion de XML, empaquetado, envío y recepción de documentos electrónicos a través de una API REST.

Si encuentra algún bug por favor reportarlo a la zona de [Issues de GitHub](https://github.com/FrameworkPeru/facturacionelectronicasunat/issues).

Puede leer la documentación de SUNAT en el repositorio de [OpenInvoicePeruDocs](https://github.com/FrameworkPeru/openinvoiceperudocs).

Para consultar las novedades y cambios del proyecto revise el [Control de Cambios](CHANGELOG.md)

# Características #
- Generación de XML los siguientes documentos electrónicos:
  - Facturas (UBL 2.1)
  - Boletas  (UBL 2.1)
  - Notas de Crédito (UBL 2.1)
  - Notas de Débito (UBL 2.1)
  - Resumen Diario de Boletas
  - Comunicaciones de Baja
  - Retenciones
  - Percepciones
  - Guías de Remisión (UBL 2.1)
 
- Firmado del XML con un certificado digital elegido por el usuario.
- Envío al servicio Web de SUNAT de los documentos electrónicos generados (Beta y Producción).
- Envío de Resumen Diario y Comunicación de Baja.
- Desempaquetado y Lectura del contenido del CDR de SUNAT.
- Consulta de Tickets de los Resúmenes y Bajas.
- API REST bajo ASP.NET Web API 2.

### Cliente API REST de Ejemplo ###
- Ejemplos en C# para el consumo de la API REST con PostSharp.

## Consideraciones ##
- El proyecto se ha desarrollado con VS2017, usando como base el .NET Framework 4.7.1.
- Se recomienda usar encarecidamente VS2017 o superior, la edición [Community Edition](https://www.visualstudio.com/downloads/download-visual-studio-vs), es gratis y mucho mejor que sus predecesores.
Puede usar la versión Professional o Enterprise si lo desea.

- Para poder ejecutar correctamente el proyecto **debe iniciar Visual Studio como Administrador** y tener instalado IIS 7.0 o posterior.

## Enlaces de Interes ##

- [Framework Peru](http://frameworkperu.com)
- [Foro Técnico de OpenInvoicePeru](http://forotecnico.frameworkperu.com)
- [Canal Oficial de OpenInvoicePeru en Telegram](http://t.me/OpenInvoicePeru)
- [Framework Peru en Facebook](http://facebook.com/FrameworkPe)

## Descargo de Responsabilidad ##

Este software se entrega como tal y es libre de modificarlo a su gusto, copiarlo en su totalidad 
o de manera parcial, un agradecimiento público no cuesta nada.

Así mismo no hay garantía expresa de este producto, cualquier inconveniente que se presente con SUNAT 
es enteramente responsabilidad del usuario al usar este Software, a menos que haya recibido soporte por parte de **Framework Peru**. 

Si tiene errores con SUNAT fíjese en el código devuelto:

- Del 0100 al 1999 Excepciones (Usuarios mal escritos, RUCs no validos, etc.).
- Del 2000 al 3999 Errores que generan rechazo (Se envia pero rebota).
- Del 4000 en adelante Observaciones (Correcciones menores).

Si tiene mas dudas con SUNAT comuníquese con ellos al [+51 1 3150730](tel:+5113150730).

## Asesoría y Soporte ##

Si necesita Asesoría, Desarrollo, Implementación o necesita Integrar su Sistema de Ventas o ERP con **OpenInvoicePeru**, puede contactarnos al correo [soporte@frameworkperu.com](mailto:soporte@frameworkperu.com) y se puede concertar una reunión virtual, ya sea Skype, Hangouts, [Telegram](http://t.me/ErickOrlando) o TeamViewer.
Recuerde que si bien el proyecto es de código abierto, el soporte y asesoría técnica son de pago, para más información ingrese [aquí](https://goo.gl/9xkUtB).
