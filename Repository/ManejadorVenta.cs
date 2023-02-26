using Proyecto_final.Models;
using System.Data.SqlClient;

namespace Proyecto_Final.Repository
{
    public static class ManejadorVenta
    {
        public static List<Venta> GetVentaByUser(long idUsuario)
        {
            List<Venta> ventas = new List<Venta>();
            using (SqlConnection conn = new SqlConnection(CadenaConexioncs.cadenaConexion))
            {
                using (SqlCommand comando = new SqlCommand("SELECT * FROM Venta WHERE IdUsuario = @idUsuario", conn))
                {
                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                    conn.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Venta venta = new Venta();
                                venta.Id = reader.GetInt64(0);
                                venta.Comentarios = reader.GetString(1);
                                venta.IdUsuario = reader.GetInt64(2);
                                ventas.Add(venta);
                            }
                        }
                        conn.Close();
                    }
                }
            }
            return ventas;
        }
        public static void CargarVenta(long idUsuario, List<Producto> listaProducto)
        {
            long idNuevaVenta = 0;
            using (SqlConnection conn = new SqlConnection(CadenaConexioncs.cadenaConexion))
            {
                using (SqlCommand comando = new SqlCommand("INSERT INTO Venta (Comentarios, IdUsuario) VALUES (@comentarios, @idUsuario); SELECT @@IDENTITY", conn))
                {
                    comando.Parameters.AddWithValue("@comentarios", "");
                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                    conn.Open();
                    idNuevaVenta = Convert.ToInt64(comando.ExecuteScalar());
                    conn.Close();
                }

            }
            foreach (Producto producto in listaProducto)
            {
                ProductoVendido temporal = new ProductoVendido();
                temporal.Stock= producto.Stock;
                temporal.IdProducto = producto.Id;
                temporal.IdVenta = idNuevaVenta;
                ManejadorProductoVendido.InsertarProductoVendido(temporal);
                ManejadorProducto.ActualizarStockProducto(producto.Id, producto.Stock);
            }
        }
    }
}
