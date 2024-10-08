using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    class Conexion
    {
        private OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=SisFar.accdb");

        public OleDbConnection AbrirConexion()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            return con;

        }
        public OleDbConnection CerrarConexion()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            return con;

        }
    }
}
