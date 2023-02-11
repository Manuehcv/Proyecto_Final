using Proyecto_final;
using Proyecto_final.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

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
                                producto.Descripcion = reader.GetString(1);
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
                            producto.Descripcion = reader.GetString(1);
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
    }
}
