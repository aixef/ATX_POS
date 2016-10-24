using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace ATX_POS
{
    class ConexionSQL
    {
        public static SqlConnection Cadenaconexion(string conString)
        {
            try
            {
                string conexion = ConfigurationManager.ConnectionStrings[conString].ConnectionString;
                SqlConnection miConexion = new SqlConnection(conexion);
                return miConexion;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Error de conexion: ", e);
            }
        }
    }
}
