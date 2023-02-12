namespace Proyecto_final.Models
{
    public class Producto
    {
        private long id;
        private string descripcion;
        private decimal costo;
        private decimal precioVenta;
        private int stock;
        private long idUsuario;

        public long Id { get => id; set => id = value; }
        public string Descripciones { get => descripcion; set => descripcion = value; }
        public decimal Costo { get => costo; set => costo = value; }
        public decimal PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public int Stock { get => stock; set => stock = value; }
        public long IdUsuario { get => idUsuario; set => idUsuario = value; }
    }
}
