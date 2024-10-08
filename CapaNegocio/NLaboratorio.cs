using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaNegocio
{
    public class NLaboratorio
    {
        DLaboratorio obje = new DLaboratorio();

        public void insertarLab(string laboratorio, string fechaCompra, string fechaVencimiento,string vencimiento)
        {
            obje.insertarL(laboratorio, fechaCompra, fechaVencimiento,vencimiento );
        }
      
        public void ob()
        {
            obje.obtenerID();
        }
    }
}
