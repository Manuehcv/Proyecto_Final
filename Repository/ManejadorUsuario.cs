using Proyecto_final.Models;
using Proyecto_Final.Models;
using System.Data.SqlClient;

namespace Proyecto_Final.Repository
{
    internal class ManejadorUsuario
    {
        public static Usuario GetUsuarioByID(long idToSearch)
        {
            Usuario user = new Usuario();
            var query = "SELECT * FROM Usuario WHERE Id = @Id";
            using (SqlConnection conn = new SqlConnection(CadenaConexioncs.cadenaConexion))
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
            var query = "SELECT * FROM Usuario WHERE NombreUsuario = @nombreUsuario AND Contraseña = @contraseña";
            using (SqlConnection conn = new SqlConnection(CadenaConexioncs.cadenaConexion))
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
            var query = "UPDATE Usuario SET Nombre = @UsuarioNombre, Apellido = @nuevoApellido, NombreUsuario = @nuevoNombreUsuario, Contraseña = @nuevaContraseña, Mail = @nuevoMail WHERE Id = @idUsuario";
            using (SqlConnection conn = new SqlConnection(CadenaConexioncs.cadenaConexion))
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
        public static void CrearUsuario(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexioncs.cadenaConexion))
            {
                using SqlCommand comando = new SqlCommand("INSERT INTO Usuario (Nombre, Apellido, NombreUsuario, Contraseña, Mail) VALUES (@nombre, @apellido, @nombreUsuario, @contraseña, @mail)", conn);
                {
                    comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    comando.Parameters.AddWithValue("@apellido", usuario.Apellido);
                    comando.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                    comando.Parameters.AddWithValue("@contraseña", usuario.Contraseña);
                    comando.Parameters.AddWithValue("@mail", usuario.Mail);
                    conn.Open();
                    int rowsAffected = comando.ExecuteNonQuery();
                    conn.Close();
                }

            }

        }
        public static Usuario GetUsuarioBynombreUsuario(string nombreUsuarioBuscar)
        {
            Usuario user = new Usuario();
            using (SqlConnection conn = new SqlConnection(CadenaConexioncs.cadenaConexion))
            {
                using (SqlCommand comando = new SqlCommand("SELECT * FROM Usuario WHERE NombreUsuario = @nombreUsuarioBuscar", conn))
                {
                    comando.Parameters.AddWithValue("@nombreUsuarioBuscar", nombreUsuarioBuscar);
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
            }
            return user;
        }

    }

}

