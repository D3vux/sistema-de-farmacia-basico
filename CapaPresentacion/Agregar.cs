using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Agregar : Form
    {
        public Agregar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*openChildForm(new Agregar_Medicamento());*/
            open();
        }
        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            Form1.Controls.Add(childForm);
            Form1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public void open()
        {
            openChildForm(new Agregar_Medicamento());
        }
        public void open1()
        {
            openChildForm(new Venta_de_Medicamento());
        }
        public void open2()
        {
            openChildForm(new Buscar());
        }
        public void open3()
        {
            openChildForm(new Inventario_de_Ventas());
        }
        public void open4()
        {
            openChildForm(new Estado_de_Inventario());
        }

        private void btnMedia_Click(object sender, EventArgs e)
        {
            open1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            open2();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            open3();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            open4();
        }
    }
}
