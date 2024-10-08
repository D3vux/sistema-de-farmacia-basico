using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class EstadoLA
    {
        private Conexion cxn = new Conexion();
        OleDbDataReader leer;
        DataTable tabla = new DataTable();
        OleDbCommand comando = new OleDbCommand();
        public int obtenerID()
        {
            comando.Connection = cxn.AbrirConexion();
            comando.CommandText = "Select max(IdMedicamento)as idMax From EstadoME";
            comando.CommandType = CommandType.TableDirect;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            cxn.CerrarConexion();
            int respuesta;
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                respuesta = int.Parse(row["idMax"].ToString());
            }
            else
            {
                throw new Exception("no hay registro");
            }
            return respuesta;
        }
        public void insertarL(string laboratorio, string fechaCompra, string fechaVencimiento)
        {
            int IdMedicamento = obtenerID();
            comando.Connection = cxn.AbrirConexion();
            comando.CommandText = "INSERT INTO EstadoLA(IdMedicamento,Laboratorio, FechaCompra, FechaVencimiento)VALUES(@IdMedicamento, @laboratorio, @fechaCompra, @fechaVencimiento);";
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("@IdMedicamento", IdMedicamento);
            comando.Parameters.AddWithValue("@Laboratorio", laboratorio);
            comando.Parameters.AddWithValue("@FechaCompra", fechaCompra);
            comando.Parameters.AddWithValue("@FechaVencimiento", fechaVencimiento);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            cxn.CerrarConexion();
        }
    }
}
