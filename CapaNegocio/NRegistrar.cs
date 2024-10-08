using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaNegocio
{
    public class NRegistrar
    {
        DRegistrar obj = new DRegistrar();
        public DataTable mostrarEst()
        {
            DataTable tabla = new DataTable();
            tabla = obj.Mostrar();
            return tabla;

        }
        public void insertarME(string nombre, string  cantidad, string precioCompra, string precioVenta)
        {
            obj.insertarM(nombre, cantidad, precioCompra, precioVenta);
        }
        public void editarME(string nombre, string cantidad, string preciocompra, string precioventa, string laboratorio, string fechacompra, string fechavencimiento, string IdMedicamento, string IdLaboratorio)
        {
            obj.editarM(nombre, cantidad, preciocompra, precioventa, laboratorio, fechacompra, fechavencimiento, IdMedicamento, IdLaboratorio);
        }
        public void EliminarME(string IdMedicamento)
        {
            obj.Eliminar(Convert.ToInt32(IdMedicamento));
        }
        public DataTable BuscarME(string textobuscar)
        {
            DataTable tabla = new DataTable();
            tabla = obj.BuscarNombre(textobuscar);
            return tabla;
        }
    }
}
