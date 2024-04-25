using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.VETE
{
    public class Conexion
    {
        private readonly string? _cadenaConexion;

        public Conexion()
        {
            string? cadenaConexion;

            //Obtener la cadena de conexion desde variable del entorno
            cadenaConexion = Environment.GetEnvironmentVariable("SQLServerXE");

            _cadenaConexion = cadenaConexion;
        }
        public SqlConnection Conectar()
        {
            SqlConnection sqlConn;

            // Instanciar la conexion utilizando la cadena de conexion obtenida
            sqlConn = new SqlConnection(_cadenaConexion);

            return sqlConn;
        }
    }
}
