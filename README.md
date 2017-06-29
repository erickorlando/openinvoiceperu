![Open Invoice Perú](http://frameworkperu.com/OpenInvoicePeruLogo.png "Open Invoice Perú")
# OpenInvoicePeru v1.4.0 #
OpenInvoicePeru es un proyecto Open Source construido con C#, haciendo sencilla la Facturación Electrónica de SUNAT, este proyecto está orientado al desarrollador.
Permite la generacion de XML, empaquetado, envío y recepción de documentos electrónicos a través de una API REST.

Actualmente ya se puede usar en entornos de Producción, si encuentra algún bug por favor reportarlo a la zona de [Issues de GitHub](https://github.com/FrameworkPeru/facturacionelectronicasunat/issues).

Puede leer la documentación del proyecto en la sección [Wiki](https://github.com/FrameworkPeru/openinvoiceperu/wiki).

# Características #
- Generación de XML los siguientes documentos electrónicos:
  - Facturas
  - Boletas 
  - Notas de Crédito
  - Notas de Débito
  - Resumen Diario de Boletas
  - Comunicaciones de Baja
  - Retenciones
  - Percepciones
  - Guías de Remisión
 
- Firmado del XML con un certificado digital elegido por el usuario.
- Envío al servicio Web de SUNAT de los documentos electrónicos generados (Beta, Homologación y Producción).
- Envío de Resumen Diario y Comunicación de Baja.
- Desempaquetado y Lectura del contenido del CDR de SUNAT.
- Guardado de XML firmados y CDR de SUNAT en la base de datos de OpenInvoicePeru.
- Consulta de Tickets de los Resúmenes y Bajas.
- API REST bajo ASP.NET Web API 2.
- Aplicación Windows de prueba de envío a SUNAT.

### Clientes API REST de Ejemplo ###
- Los ejemplos en VB y C# para el consumo de la API REST con PostSharp bajo .NET 4.0 en el siguiente [repositorio](https://goo.gl/adgBmv).

- Ejemplo para conectarte a la API REST desde .NET Framework 2.0 revisa este [repositorio](https://goo.gl/wGkAmu).

- Ejemplo de conexión en Silverlight 5.0 entre a [repositorio](https://github.com/FrameworkPeru/ClienteSLOpenInvoicePeru).

## Ramas (branches) ##

El proyecto contiene dos ramas:

- master (versión estable)
- develop (versión de desarrollo)

## Consideraciones ##
- El proyecto se ha desarrollado con VS2015 Update 3, usando como base el .NET Framework 4.6.1.
- Se recomienda usar encarecidamente VS2015 o superior, la edición [Community Edition](https://www.visualstudio.com/downloads/download-visual-studio-vs), es gratis y mucho mejor que sus predecesores.
Puede usar la versión Professional o Enterprise si lo desea.

- Para poder ejecutar correctamente el proyecto **debe iniciar Visual Studio como Administrador** y tener instalado IIS 7.0 o posterior.

- Si quiere colaborar con su granito de arena puede hacer un Fork y enviar un Pull Request.

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

Si necesita apoyo con la Homologación (Emisor o Proveedor) o necesita integrar su sistema con **OpenInvoicePeru**, puede contactarnos al correo [soporte@frameworkperu.com](mailto:soporte@frameworkperu.com) y se puede concertar una reunión virtual, ya sea Skype, Hangouts, [Telegram](http://t.me/ErickOrlando) o TeamViewer.
Recuerde que si bien el proyecto es de código abierto, el soporte y asesoría técnica tienen un costo.
