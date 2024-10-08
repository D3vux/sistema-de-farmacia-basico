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
namespace CapaPresentacion
{
   
    public partial class Estado_de_Inventario : Form
    {
        Boolean sw = false;
      
        public Estado_de_Inventario()
        {
            InitializeComponent();
            
        }

        private void Estado_de_Inventario_Load(object sender, EventArgs e)
        {
            
            llenar();
            
        }
        public void llenar()
        {
            NRegistrar objeto = new NRegistrar();
            dataGridView1.DataSource = objeto.mostrarEst();
            ocultar();
        }
        public void tdfechas()
        {
            DataGridView dtfechas = new DataGridView();
            dtfechas.Columns.Add("nombre","Nombre");
        }
        public void ocultar()
        {
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[5].Visible = false;
            this.dataGridView1.Columns[6].Visible = false;
            this.dataGridView1.Columns[10].Visible = false; 
        }
        public  void BuscarEnColumna(string textoBusqueda, int columna)
       {                 
                sw = true;           
       }
        public void buscar()
        {
        string date = DateTime.UtcNow.ToString("dd/MM/yyyy");          
            textBox1.Text = date;
            string textoBusqueda = textBox1.Text;
            int columnaDeseada = 10; // Índice de la columna en la que se realizará la búsqueda (por ejemplo, la decima columna)
            BuscarEnColumna(textoBusqueda, columnaDeseada);

        }
        public void seleccionar()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Se encontró una coincidencia, seleccionar la fila               
                row.Selected = true;
                dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;

            }
        }
        public void fechas()
        {
            DateTime fechaActual = DateTime.Today;

            // Mostrar fechas cercanas al vencimiento
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DateTime fecha = Convert.ToDateTime(dataGridView1.Rows[i].Cells[9].Value);

                // Calcular días restantes hasta el vencimiento
                TimeSpan diferencia = fecha - fechaActual;
                int diasRestantes = diferencia.Days;

                // Si quedan menos de 7 días para el vencimiento, mostrar el aviso
                if (diasRestantes <= 7 && diasRestantes >= 0)
                {
                    MessageBox.Show($"El vencimiento está próximo: \nNOMBRE: {dataGridView1.Rows[i].Cells[1].Value} \nLABORATORIO: {dataGridView1.Rows[i].Cells[7].Value} \nFECHA DE VENCIMIENTO: {dataGridView1.Rows[i].Cells[9].Value}", "Medicamentos por vencer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtfechas.Rows.Add(dataGridView1.Rows[i].Cells[1].Value, dataGridView1.Rows[i].Cells[7].Value, dataGridView1.Rows[i].Cells[9].Value);
                    
                }
            }
        }
        private void btnvenci_Click(object sender, EventArgs e)
        {
            
            mensaje2();
            fechas();
        }
        public void mensaje()
        {
           if(sw==true)
           {
               MessageBox.Show("Medicamentos estan por vencer IR A FECHA DE VENCIMIENTO.", "Medicamentos por vencer", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
        }
        public void mensaje2()
        {
            MessageBox.Show("Los medicamentos que estan por vencer apareceran en un cuadro indicando el NOMBRE, LABORATORIO, FECHA DE VENCIMIENTO,", "AVISO",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

