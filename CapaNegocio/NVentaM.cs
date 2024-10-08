using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaNegocio
{
    public class NVentaM
    {
        
        DVentaM obj = new DVentaM();
        public DataTable mostrarEst()
        {
            DataTable tabla = new DataTable();
            tabla = obj.Mostrar();
            return tabla;
        }
        public DataTable BuscarME(string textobuscar)
        {
            DataTable tabla = new DataTable();
            tabla = obj.BuscarNombre(textobuscar);
            return tabla;
        }
        public void insertarV(string nombre, string cantidad, string precioVenta)
        {
            obj.insertarM(nombre, cantidad, precioVenta);          
        }
        public void editarME(string nombre, string cantidad,  string precioventa, string laboratorio,  string fechavencimiento, string IdMedicamento, string IdLaboratorio)
        {
            obj.editarM(nombre, cantidad,  precioventa, laboratorio,  fechavencimiento, IdMedicamento, IdLaboratorio);
        }
        public void EliminarME(string IdMedicamento)
        {
            obj.Eliminar(Convert.ToInt32(IdMedicamento));
        }
        public void resta(string nombre, string cantidad, string precioventa, string IdMedicamento)
        {
            obj.restar(nombre, cantidad, precioventa, IdMedicamento);
        }
    }

}
