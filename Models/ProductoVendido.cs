using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    internal class ProductoVendido
    {
        private long id;
        private long idProducto;
        private int stock;
        private long idVenta;

        public long Id { get => id; set => id = value; }
        public long IdProducto { get => idProducto; set => idProducto = value; }
        public int Stock { get => stock; set => stock = value; }
        public long IdVenta { get => idVenta; set => idVenta = value; }
    }
}
