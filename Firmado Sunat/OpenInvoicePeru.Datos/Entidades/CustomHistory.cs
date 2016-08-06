using System;
using SQLite.CodeFirst;

namespace OpenInvoicePeru.Datos.Entidades
{
    public class CustomHistory : IHistory
    {
        public int Id { get; set; }
        public string Hash { get; set; }
        public string Context { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
