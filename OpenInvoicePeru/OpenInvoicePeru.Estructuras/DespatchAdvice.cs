using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using OpenInvoicePeru.Comun;

namespace OpenInvoicePeru.Estructuras
{
    [Serializable]
    public class DespatchAdvice : IXmlSerializable, IEstructuraXml
    {
        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}