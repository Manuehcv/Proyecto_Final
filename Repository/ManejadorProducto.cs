using Proyecto_final.Models;
using System.Data.SqlClient;

namespace Proyecto_Final.Repository
{
    static internal class ManejadorProducto
    {
        const string cadenaConexion = "Data Source=DESKTOP-JR4NFDN;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Producto> GetProductosByUser(long idUsuario)
        {
            List<Producto> productos = new List<Producto>();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {

                using SqlCommand comando = new SqlCommand("SELECT * FROM Producto WHERE IdUsuario = @idUsuario", conn);
                {
                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                    conn.Open();
                    using SqlDataReader reader = comando.ExecuteReader();
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Producto producto = new Producto();
                                producto.Id = reader.GetInt64(0);
                                producto.Descripciones = reader.GetString(1);
                                producto.Costo = reader.GetDecimal(2);
                                producto.PrecioVenta = reader.GetDecimal(3);
                                producto.Stock = reader.GetInt32(4);
                                producto.IdUsuario = reader.GetInt64(5);
                                productos.Add(producto);
                            }
                        }
                        conn.Close();
                    }
                }
            }
            return productos;
        }
        public static Producto GetProductosByIdProducto(long idProducto)
        {
            Producto productos = new Producto();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {

                using SqlCommand comando = new SqlCommand("SELECT * FROM Producto WHERE Id = @IdProducto", conn);
                {
                    comando.Parameters.AddWithValue("@IdProducto", idProducto);
                    conn.Open();
                    using SqlDataReader reader = comando.ExecuteReader();
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            Producto producto = new Producto();
                            producto.Id = reader.GetInt64(0);
                            producto.Descripciones = reader.GetString(1);
                            producto.Costo = reader.GetDecimal(2);
                            producto.PrecioVenta = reader.GetDecimal(3);
                            producto.Stock = reader.GetInt32(4);
                            producto.IdUsuario = reader.GetInt64(5);
                            productos = producto;
                        }
                        conn.Close();
                    }
                }
            }
            return productos;
        }
        public static void CrearProductos(Producto producto)
        {
            const string cadenaConexion = "Data Source=DESKTOP-JR4NFDN;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                using SqlCommand comando = new SqlCommand("INSERT INTO Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) VALUES (@descripciones, @costo, @precioVenta, @stock, @idUsuario)", conn);
                {
                    comando.Parameters.AddWithValue("@descripciones", producto.Descripciones);
                    comando.Parameters.AddWithValue("@costo", producto.Costo);
                    comando.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
                    comando.Parameters.AddWithValue("@stock", producto.Stock);
                    comando.Parameters.AddWithValue("@idUsuario", producto.IdUsuario);
                    conn.Open();
                    int rowsAffected = comando.ExecuteNonQuery();
                    conn.Close();
                }

            }

        }
        public static void ModificarProducto(Producto producto)
        {
            const string cadenaConexion = "Data Source=DESKTOP-JR4NFDN;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var query = "UPDATE Producto SET Descripciones = @descripciones, Costo = @costo, PrecioVenta = @precioventa, Stock = @stock, IdUsuario = @idUsuario WHERE Id = @id";
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand(query, conn);
                comando.Parameters.AddWithValue("@descripciones", producto.Descripciones);
                comando.Parameters.AddWithValue("@costo", producto.Costo);
                comando.Parameters.AddWithValue("@precioventa", producto.PrecioVenta);
                comando.Parameters.AddWithValue("@stock", producto.Stock);
                comando.Parameters.AddWithValue("@idUsuario", producto.IdUsuario);
                comando.Parameters.AddWithValue("@id", producto.Id);
                conn.Open();
                int rowsAffected = comando.ExecuteNonQuery();
                conn.Close();
            }

        }
    }
}
