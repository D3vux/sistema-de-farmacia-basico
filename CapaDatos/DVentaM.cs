using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DVentaM
    {
        private Conexion cxn = new Conexion();
        OleDbDataReader leer;
        DataTable tabla = new DataTable();
        OleDbCommand comando = new OleDbCommand();
        public DataTable Mostrar()
        {
            //VentaM
            //VentaL
            comando.Connection = cxn.AbrirConexion();
            comando.CommandText = "SELECT VentaM.*, VentaL.* FROM VentaM INNER JOIN VentaL ON VentaM.IdMedicamento = VentaL.IdMedicamento";
            //comando.CommandText = "SELECT * FROM VentaM";
            comando.CommandType = CommandType.TableDirect;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            cxn.CerrarConexion();
            return tabla;
        }
        public void insertarM(string nombre, string cantidad,  string precioVenta)
        {
            comando.Connection = cxn.AbrirConexion();
            comando.CommandText = "INSERT INTO VentaM(Nombre, Cantidad, PrecioVenta)VALUES(@nombre, @cantidad, @precioVenta);";
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("Nombre", nombre);
            comando.Parameters.AddWithValue("Cantidad", cantidad);
            comando.Parameters.AddWithValue("PrecioVenta", precioVenta);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            cxn.CerrarConexion();
        }
        public void editarM(string nombre, string cantidad, string precioventa, string laboratorio, string fechavencimiento, string IdMedicamento, string IdLaboratorio)
        {
            comando.Connection = cxn.AbrirConexion();
            comando.CommandText = "UPDATE VentaM INNER JOIN VentaL ON VentaM.IdMedicamento = VentaL.IdMedicamento SET VentaM.Nombre = @nombre, VentaM.Cantidad =@cantidad, VentaM.PrecioVenta = @precioventa, VentaL.Laboratorio = @laboratorio,  VentaL.FechaVencimiento = @fechavencimiento WHERE (((VentaM.IdMedicamento)=@IdMedicamento) AND ((VentaL.IdLaboratorio)=@IdLaboratorio))";
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Cantidad", cantidad);         
            comando.Parameters.AddWithValue("@PrecioVenta", precioventa);
            comando.Parameters.AddWithValue("@Laboratorio", laboratorio);           
            comando.Parameters.AddWithValue("@FechaVencimiento", fechavencimiento);
            comando.Parameters.AddWithValue("@IdMedicamento", IdMedicamento);
            comando.Parameters.AddWithValue("@IdLaboratorio", IdLaboratorio);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            cxn.CerrarConexion();
        }
        public void Eliminar(int IdMedicamento)
        {
            comando.Connection = cxn.AbrirConexion();
            comando.CommandText = "DELETE FROM VentaM WHERE IdMedicamento=@IdMedicamento";
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
        public void restar(string nombre, string cantidad,string precioventa, string IdMedicamento)
        {
            comando.Connection = cxn.AbrirConexion();
            comando.CommandText = "UPDATE EstadoME SET Cantidad = @Cantidad where IdMedicamento = @IdMedicamento";
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Cantidad",cantidad);
            
            comando.Parameters.AddWithValue("@PrecioVenta", precioventa);
            comando.Parameters.AddWithValue("@IdMedicamento", IdMedicamento);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            cxn.CerrarConexion();
        }
    }
}
