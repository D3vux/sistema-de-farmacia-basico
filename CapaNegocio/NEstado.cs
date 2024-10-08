using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaNegocio
{
    public class NEstado
    {
        DEstado obj = new DEstado();
        public void insertarEs(string nombre, string cantidad, string precioCompra, string precioVenta)
        {
            obj.insertarM(nombre, cantidad, precioCompra, precioVenta);
        }
        public void editarEs(string nombre, string cantidad, string preciocompra, string precioventa, string laboratorio, string fechacompra, string fechavencimiento, string IdMedicamento, string IdLaboratorio)
        {
            obj.editarM(nombre, cantidad, preciocompra, precioventa, laboratorio, fechacompra, fechavencimiento, IdMedicamento, IdLaboratorio);
        }
        public void EliminarEs(string IdMedicamento)
        {
            obj.Eliminar(Convert.ToInt32(IdMedicamento));
        }
    }
}
