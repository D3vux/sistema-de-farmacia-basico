using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaNegocio
{
    public class NEstadoLA
    {
        EstadoLA obje = new EstadoLA();

        public void insertarLab(string laboratorio, string fechaCompra, string fechaVencimiento)
        {
            obje.insertarL(laboratorio, fechaCompra, fechaVencimiento);
        }
    }
}
