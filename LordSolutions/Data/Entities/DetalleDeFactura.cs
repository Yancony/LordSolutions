namespace LordSolutions.Data.Entities
{
    public class DetalleDeFactura
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdFactura { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }

}
