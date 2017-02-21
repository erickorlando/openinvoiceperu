namespace OpenInvoicePeru.Entidades
{
    public class Ubigeo : EntidadBase
    {
        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public int Nivel { get; set; }

        public int? IdParent { get; set; }

        public virtual Ubigeo UbigeoPadre { get; set; }
    }
}