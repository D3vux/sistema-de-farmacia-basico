using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion;
using System.Drawing.Drawing2D;


namespace SisFarmaciaKemuel
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            
        }      
        private void button1_Click(object sender, EventArgs e)
        {
            Agregar sc = new Agregar();
            Menu sr = new Menu();
            sc.Show();
            sc.open();
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            Agregar v = new Agregar();
            v.Show();
            v.open3();
            Close();
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            
            Agregar vm = new Agregar();
            vm.Show();
            vm.open1();
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Agregar cm = new Agregar();
            cm.Show();
            cm.open2();
            Close();
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            Agregar es = new Agregar();
            es.Show();
            es.open4();
            Close();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            prueba();
        }
        public void prueba()
        {
            Estado_de_Inventario es = new Estado_de_Inventario();
            es.llenar();
           
            es.buscar();
            es.mensaje();
           
        }
    }
}
