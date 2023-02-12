using Proyecto_final.Models;
using System.Data.SqlClient;

namespace Proyecto_Final.Repository
{
    internal class ManejadorUsuario
    {
        public static Usuario GetUsuarioByID(long idToSearch)
        {
            Usuario user = new Usuario();
            const string connectionString = "Data Source=DESKTOP-JR4NFDN;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var query = "SELECT * FROM Usuario WHERE Id = @Id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand(query, conn);
                var parametro = new SqlParameter();
                parametro.ParameterName = "Id";
                parametro.SqlDbType = System.Data.SqlDbType.BigInt;
                parametro.Value = idToSearch;
                comando.Parameters.Add(parametro);
                conn.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    user.Id = Convert.ToInt64(reader.GetInt64(0));
                    user.Nombre = reader.GetString(1);
                    user.Apellido = reader.GetString(2);
                    user.NombreUsuario = reader.GetString(3);
                    user.Contraseña = reader.GetString(4);
                    user.Mail = reader.GetString(5);
                }
                conn.Close();
            }
            return user;
        }
        public static Usuario Login(string nombreUsuario, string contraseña)
        {
            Usuario usuario = new Usuario();
            const string cadenaConexion = "Data Source=DESKTOP-JR4NFDN;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var query = "SELECT * FROM Usuario WHERE NombreUsuario = @nombreUsuario AND Contraseña = @contraseña";
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand(query, conn);
                comando.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                comando.Parameters.AddWithValue("@contraseña", contraseña);
                conn.Open();
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        usuario.Id = Convert.ToInt64(reader.GetInt64(0));
                        usuario.Nombre = reader.GetString(1);
                        usuario.Apellido = reader.GetString(2);
                        usuario.NombreUsuario = reader.GetString(3);
                        usuario.Contraseña = reader.GetString(4);
                        usuario.Mail = reader.GetString(5);

                    }
                    conn.Close();
                }


            }
            return usuario;
        }
        public static void ModificarUsuario(Usuario usuario)
        {
            const string cadenaConexion = "Data Source=DESKTOP-JR4NFDN;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var query = "UPDATE Usuario SET Nombre = @UsuarioNombre, Apellido = @nuevoApellido, NombreUsuario = @nuevoNombreUsuario, Contraseña = @nuevaContraseña, Mail = @nuevoMail WHERE Id = @idUsuario";
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand(query, conn);
                comando.Parameters.AddWithValue("@idUsuario", usuario.Id);
                comando.Parameters.AddWithValue("@UsuarioNombre", usuario.Nombre);
                comando.Parameters.AddWithValue("@nuevoApellido", usuario.Apellido);
                comando.Parameters.AddWithValue("@nuevoNombreUsuario", usuario.NombreUsuario);
                comando.Parameters.AddWithValue("@nuevaContraseña", usuario.Contraseña);
                comando.Parameters.AddWithValue("@nuevoMail", usuario.Mail);
                conn.Open();
                int rowsAffected = comando.ExecuteNonQuery();
                conn.Close();
            }

        }

    }
}
