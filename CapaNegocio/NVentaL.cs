using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaNegocio
{
    public class NVentaL
    {
        DVentaL obje = new DVentaL();
        public void insertarLab(string laboratorio, string fechaVencimiento)
        {
            obje.insertarL(laboratorio,  fechaVencimiento);
        }
    }
}
