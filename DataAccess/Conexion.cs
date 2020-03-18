using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Conexion
    {
        private readonly string cadenaConexion;

        public Conexion()
        {
            this.cadenaConexion = "data source=LAPTOP-QOMJAHVK;initial catalog=GrupoIDAII; user id=sa;password=123456789; MultipleActiveResultSets=true";
        }
        protected SqlConnection GetSqlConnection()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
