![Open Invoice Perú](http://frameworkperu.com/OpenInvoicePeruLogo.png "Open Invoice Perú")
# OpenInvoicePeru v1.3.0 #
OpenInvoicePeru es un proyecto Open Source construido con C#, haciendo sencilla la Facturación Electrónica de SUNAT, este proyecto está orientado al desarrollador (muy pronto para usuarios).
Permite la generacion de XML, empaquetado, envío y recepción de documentos electrónicos a través de una API REST.

Actualmente ya se puede usar en entornos de Producción, si encuentras algún bug por favor reportalo a la zona de [Issues de GitHub](https://github.com/erickorlando/facturacionelectronicasunat/issues).

Puedes leer la documentación del proyecto en la sección [Wiki](https://github.com/erickorlando/openinvoiceperu/wiki).

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
- Guardado de XML firmados y CDR de SUNAT en una carpeta local.
- Consulta de Tickets de los Resúmenes y Bajas.
- API REST bajo ASP.NET Web API 2.
- Aplicación Windows de prueba de envío a SUNAT.

### Ejemplos de Clientes ###
He movido los ejemplos en VB y C# para el consumo de la API REST con PostSharp bajo .NET 4.0 en el siguiente [repositorio](https://goo.gl/adgBmv).

Si quieres un ejemplo para conectarte a la API REST desde .NET Framework 2.0 revisa este [repositorio](https://goo.gl/wGkAmu).

## Ramas (branches) ##

El proyecto contiene dos ramas:

- master (versión estable)
- develop (versión de desarrollo)

## Consideraciones ##
El proyecto se ha desarrollado con VS2015 Update 3, usando como base el .NET Framework 4.6.1
Se recomienda usar encarecidamente VS2015, la edición [Community Edition](https://www.visualstudio.com/downloads/download-visual-studio-vs), es gratis y mucho mejor que sus predecesores.
Puedes usar la versión Professional o Enterprise si lo deseas.

Para poder ejecutar correctamente el proyecto **debes iniciar Visual Studio como Administrador** y tener instalado IIS 7.0 o posterior.

Si quieres colaborar con tu granito de arena puedes hacer un Fork y enviar tu Pull Request.

Si tienes dudas con respecto al proyecto, escríbeme tu pregunta al [Foro Oficial](http://forotecnico.frameworkperu.com).

Y no te olvides de darte una vuelta por mi [Blog](http://erickorlando.com/2016/11/29/tutorial-creacion-de-facturas-con-openinvoiceperu/).

## Disclaimer ##

Este software se entrega como tal y eres libre de modificarlo a tu gusto, copiarlo en su totalidad 
o de manera parcial, lo unico que pido es que se respete la creación del autor, un agradecimiento público no cuesta nada.

Así mismo no hay garantía expresa de este producto, cualquier inconveniente que se presente con SUNAT 
es enteramente responsabilidad del usuario al usar este Software. 

Si tienes errores con SUNAT fijate en el código devuelto:

- Del 0100 al 1999 Excepciones (Usuarios mal escritos, RUCs no validos, etc.)
- Del 2000 al 3999 Errores que generan rechazo (Se envia pero rebota)
- Del 4000 en adelante Observaciones (Correcciones menores)

Si tienes mas dudas con SUNAT comunícate con ellos al [+51 1 3150730](tel:+5113150730).

## Asesoría personalizada ##

Si necesitas que te apoye con la Homologación (Emisor o Proveedor) o necesitas que te ayude a integrar tu sistema con OpenInvoicePeru, puedes contactarme directamente a mi correo personal [evelascom@frameworkperu.com](mailto:evelascom@frameworkperu.com) y podemos concertar una reunión virtual.
Recuerda que si bien mi proyecto es de código abierto, yo vendo el soporte y asesoría técnica.
