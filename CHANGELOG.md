# Control de Cambios

## v3.0

- Redondeo a 8 decimales para PrecioUnitario, PrecioReferencial y Cantidad en los Items de los comprobantes.
- Se remueve clases innecesarias que pertenecían al UBL 2.0 (aun faltan eliminar clases).
- Se crea el campo _TasaImpuesto_ del tipo _decimal_ en la clase _DocumentoElectronico_ para que se indique la tasa del Impuesto, esto con el 
  fin de multiplicarlo por el valor base para las operaciones gratuitas.
- El proyecto de Consola se convierte a .NET 5 y se adiciona una DLL de los DTO para .NET Standard 2.0