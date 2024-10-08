using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DRegistrar
    {
        private Conexion cxn = new Conexion();
        OleDbDataReader leer;
        DataTable tabla = new DataTable();
        OleDbCommand comando = new OleDbCommand();
        public DataTable Mostrar()
        {
            comando.Connection = cxn.AbrirConexion();
            comando.CommandText = "SELECT RegistrarM.*, RegistrarLab.* FROM RegistrarM INNER JOIN RegistrarLab ON RegistrarM.IdMedicamento = RegistrarLab.IdMedicamento";
            comando.CommandType = CommandType.TableDirect;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            cxn.CerrarConexion();
            return tabla;
        }
        public void insertarM(string nombre, string cantidad, string precioCompra, string precioVenta)
        {
            comando.Connection = cxn.AbrirConexion();
            comando.CommandText = "INSERT INTO RegistrarM(Nombre, Cantidad, PrecioCompra, PrecioVenta)VALUES(@nombre, @cantidad, @precioCompra, @precioVenta);";
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("Nombre",nombre);
            comando.Parameters.AddWithValue("Cantidad",cantidad);
            comando.Parameters.AddWithValue("PrecioCompra",precioCompra);
            comando.Parameters.AddWithValue("PrecioVenta",precioVenta);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            cxn.CerrarConexion();
        }
        public void editarM(string nombre, string cantidad, string preciocompra, string precioventa, string laboratorio, string fechacompra, string fechavencimiento, string IdMedicamento, string IdLaboratorio)
        {
            comando.Connection = cxn.AbrirConexion();
            comando.CommandText = "UPDATE RegistrarM INNER JOIN RegistrarLab ON RegistrarM.IdMedicamento = RegistrarLab.IdMedicamento SET RegistrarM.Nombre = @nombre, RegistrarM.Cantidad =@cantidad, RegistrarM.PrecioCompra =@preciocompra, RegistrarM.PrecioVenta = @precioventa, RegistrarLab.Laboratorio = @laboratorio, RegistrarLab.FechaCompra = @fechacompra, RegistrarLab.FechaVencimiento = @fechavencimiento WHERE (((RegistrarM.IdMedicamento)=@IdMedicamento) AND ((RegistrarLab.IdLaboratorio)=@IdLaboratorio))";
            comando.CommandType = CommandType.Text;       
            comando.Parameters.AddWithValue("@Nombre",nombre);
            comando.Parameters.AddWithValue("@Cantidad",cantidad);
            comando.Parameters.AddWithValue("@PrecioCompra",preciocompra);
            comando.Parameters.AddWithValue("@PrecioVenta",precioventa);
            comando.Parameters.AddWithValue("@Laboratorio",laboratorio);
            comando.Parameters.AddWithValue("@FechaCompra",fechacompra);
            comando.Parameters.AddWithValue("@FechaVencimiento",fechavencimiento);
            comando.Parameters.AddWithValue("@IdMedicamento",IdMedicamento);
            comando.Parameters.AddWithValue("@IdLaboratorio", IdLaboratorio);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            cxn.CerrarConexion();
        }
        public void Eliminar(int IdMedicamento)
        {
            comando.Connection = cxn.AbrirConexion();
            comando.CommandText = "DELETE FROM RegistrarM WHERE IdMedicamento=@IdMedicamento";
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("@IdMedicamento", IdMedicamento);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            cxn.CerrarConexion();
        }

        public DataTable BuscarNombre(string textobuscar)
        {
            comando.Connection = cxn.AbrirConexion();
            comando.CommandText = "SELECT EstadoME.*, EstadoLA.* FROM EstadoME INNER JOIN EstadoLA ON EstadoME.IdMedicamento = EstadoLA.IdMedicamento  WHERE Nombre like @textobuscar";
            //"SELECT * FROM Estudiante WHERE nombre like @textobuscar + '%'";
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("@textobuscar", textobuscar);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            cxn.CerrarConexion();
            return tabla;


        }
    }
}
