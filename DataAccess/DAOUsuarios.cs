using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Soporte.Cache;

namespace DataAccess
{
    public class DAOUsuarios : Conexion
    {
        public bool Login(string usuario, string pass)
        {
            using (var con = GetSqlConnection())
            {
                con.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = con;
                    comando.CommandText = "select * from Usuarios where alias=@user and contrasenia=@pass";
                    comando.Parameters.AddWithValue("@user", usuario);
                    comando.Parameters.AddWithValue("@pass", pass);

                    comando.CommandType = CommandType.Text;
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            InicioSesionUsuario.IdUsuario = reader.GetInt32(0);
                            InicioSesionUsuario.Nombre = reader.GetString(3);

                        }
                        return true;

                    }
                    else
                        return false;


                }
            }

        }
    }
}
