using Proyecto_final.Models;
using Proyecto_Final.Models;
using System.Data.SqlClient;

namespace Proyecto_Final.Repository
{
    internal class ManejadorProductoVendido
    {
        public static List<ProductoVendido> GetProductoVendidoByIdVenta(long idVenta)
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
            using (SqlConnection conn = new SqlConnection(CadenaConexioncs.cadenaConexion))
            {
                using SqlCommand comando = new SqlCommand("SELECT * FROM ProductoVendido WHERE IdVenta = @idVenta", conn);
                {
                    comando.Parameters.AddWithValue("@idVenta", idVenta);
                    conn.Open();
                    using SqlDataReader reader = comando.ExecuteReader();
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ProductoVendido productovendido = new ProductoVendido();
                                productovendido.Id = reader.GetInt64(0);
                                productovendido.Stock = reader.GetInt32(1);
                                productovendido.IdProducto = reader.GetInt64(2);
                                productovendido.IdVenta = reader.GetInt64(3);
                                productosVendidos.Add(productovendido);
                            }
                        }
                        conn.Close();
                    }
                }
            }
            return productosVendidos;
        }
        public static List<ProductoVendido> GetProductosVendidosByUser(long idUsuario)
        {
            List<ProductoVendido> productosvendidosby = new List<ProductoVendido>();
            List<Venta> VentasDeUsuario = ManejadorVenta.GetVentaByUser(idUsuario);
            foreach (Venta venta in VentasDeUsuario)
            {
                List<ProductoVendido> productoVendidoTemporal = GetProductoVendidoByIdVenta(venta.Id);
                foreach (ProductoVendido productovendidotemporaldos in productoVendidoTemporal)
                {
                    if (!productosvendidosby.Contains(productovendidotemporaldos))
                    {
                        productosvendidosby.Add(productovendidotemporaldos);
                    }
                }
            }

            return productosvendidosby;
        }
        public static List<string> GetNombresDeProductosVendidos(long idUsuario)
        {
            List<string> nombresProductos = new List<string>();
            List<ProductoVendido> nombrarProducto = GetProductosVendidosByUser(idUsuario);
            foreach (ProductoVendido item in nombrarProducto)
            {
                Producto temporal = ManejadorProducto.GetProductosByIdProducto(item.IdProducto);
                nombresProductos.Add(temporal.Descripciones);
            }
            return nombresProductos;

        }
        
        public static void BorrarProductoVendido(long idProducto)
        {
            var query = "DELETE FROM ProductoVendido WHERE IdProducto = @idProducto";
            using (SqlConnection conn = new SqlConnection(CadenaConexioncs.cadenaConexion))
            {
                SqlCommand comando = new SqlCommand(query, conn);
                comando.Parameters.AddWithValue("@idProducto", idProducto);
                conn.Open();
                int rowsAffected = comando.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static void InsertarProductoVendido(ProductoVendido productoVendido)
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexioncs.cadenaConexion))
            {
                using SqlCommand comando = new SqlCommand("INSERT INTO ProductoVendido (Stock, IdProducto, IdVenta) VALUES (@stock, @idProducto, @idVenta)", conn);
                {
                    comando.Parameters.AddWithValue("@stock", productoVendido.Stock);
                    comando.Parameters.AddWithValue("@idProducto", productoVendido.IdProducto);
                    comando.Parameters.AddWithValue("@idVenta", productoVendido.IdVenta);
                    conn.Open();
                    int rowsAffected = comando.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }

    }
}
