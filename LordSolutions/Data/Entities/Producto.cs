namespace LordSolutions.Data.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }

}
