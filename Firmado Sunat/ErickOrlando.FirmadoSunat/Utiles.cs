using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace OpenInvoicePeru.FirmadoSunat
{
    public static class Utiles
    {
        /// <summary>
        /// Permite una clonación en profundidad de origen
        /// </summary>
        /// <param name="origen">Objeto serializable</param>
        /// <exception cref="ArgumentExcepcion">
        /// Se produce cuando el objeto no es serializable.
        /// </exception>
        /// <remarks>Extraido de 
        /// http://es.debugmodeon.com/articulo/clonar-objetos-de-estructura-compleja
        /// </remarks>
        public static T Copia<T>(T origen)
        {
            // Verificamos que sea serializable antes de hacer la copia            
            if (!typeof(T).IsSerializable)
                throw new ArgumentException(string.Format("La clase {0} no es serializable", typeof(T).ToString()));

            // En caso de ser nulo el objeto, se devuelve tal cual
            if (Object.ReferenceEquals(origen, null))
                return default(T);

            //Creamos un stream en memoria            
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                try
                {
                    formatter.Serialize(stream, origen);
                    stream.Seek(0, SeekOrigin.Begin);
                    //Deserializamos la porcón de memoria en el nuevo objeto                
                    return (T)formatter.Deserialize(stream);
                }
                catch (SerializationException ex)
                { throw new ArgumentException(ex.Message, ex); }
                catch { throw; }
            }
        }
    }
}
