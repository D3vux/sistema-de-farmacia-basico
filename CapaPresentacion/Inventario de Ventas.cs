using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using System.Linq;
namespace CapaPresentacion
{
    public partial class Inventario_de_Ventas : Form
    {
        public Inventario_de_Ventas()
        {
            InitializeComponent();
        }

        private void Inventario_de_Ventas_Load(object sender, EventArgs e)
        {
            mostrarEstudiante();
            ocultarCol();
            botones();
        }
        private void mostrarEstudiante()
        {
            NVentaM objeto = new NVentaM();
            dataGridView1.DataSource = objeto.mostrarEst();
        }
        private void ocultarCol()
        {
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[4].Visible = false;
            this.dataGridView1.Columns[5].Visible = false;
        }

        private void btncantidad_Click(object sender, EventArgs e)
        {
            double total = dataGridView1.Rows.Cast<DataGridViewRow>().Sum(row=>Convert.ToDouble(row.Cells["Cantidad"].Value));          
            txtcantidad.Text = total+" Medicamentos Vendidos.".ToString();

        }
        public void botones()
        {
            txtcantidad.Enabled = false;
        }

        private void btnprecio_Click(object sender, EventArgs e)
        {
            double total = dataGridView1.Rows.Cast<DataGridViewRow>().Sum(row => Convert.ToDouble(row.Cells["PrecioVenta"].Value));
            txtprecio.Text = total + " Bs Precio Total Vendido".ToString();
        }
    }
}