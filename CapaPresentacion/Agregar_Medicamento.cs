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
    public partial class Agregar_Medicamento : Form      
    {
        NRegistrar obj = new NRegistrar();
        NLaboratorio obj2 = new NLaboratorio();
        NEstado obj3 = new NEstado();
        NEstadoLA obj4 = new NEstadoLA();
        Agregar chi = new Agregar();
        private bool Editar = false;
        private string IdEst = null;
        private string IdLab=null;
       
        public Agregar_Medicamento()
        {
            InitializeComponent();
        }

        private void Agregar_Medicamento_Load(object sender, EventArgs e)
        {
            mostrarEstudiante();
            ocultarCol();
           
        }
        private void mostrarEstudiante()
        {
            NRegistrar objeto = new NRegistrar();
            dataGridView1.DataSource = objeto.mostrarEst();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fecha1,fecha2;
            fecha1 = dtFecha1.Text;
            fecha2 = dtFecha2.Text;
            string venci;
            venci = dtFecha2.Text;
            DateTime elab = DateTime.Parse(venci);
            int util = 4;
            DateTime Hoy = DateTime.Today;
            DateTime vence = elab.AddDays(util);
            TimeSpan VidaUtil = vence.Subtract(Hoy);
            string vencimiento;
            vencimiento=vence.ToString("dd/MM/yyyy");
            //INSERTAR
            if(Editar==false)
            {
                try
                {
                    obj.insertarME(txtNombre.Text, txtCantidad.Text, txtPrecioC.Text, txtPrecioV.Text);                  
                    obj2.insertarLab(txtLaboratorio.Text, fecha1, fecha2,vencimiento);

                   obj3.insertarEs(txtNombre.Text, txtCantidad.Text, txtPrecioC.Text, txtPrecioV.Text);
                   obj4.insertarLab(txtLaboratorio.Text, fecha1, fecha2);
                    
                    MessageBox.Show("se inserto correctamente");
                    
                    mostrarEstudiante();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se puede insertar por :" + ex);
                }
            }
            //EDITAR
            if(Editar==true)
            {
                try
                {
                    //obj.editarME(txtNombre.Text, txtCantidad.Text, txtPrecioC.Text, txtPrecioV.Text,  IdEst);
                    obj.editarME(txtNombre.Text, txtCantidad.Text, txtPrecioC.Text, txtPrecioV.Text, txtLaboratorio.Text, fecha1,fecha2, IdEst,IdLab);
                    //obj2.editarLab(txtLaboratorio.Text, fecha1,fecha2,IdEst);
                   obj3.editarEs(txtNombre.Text, txtCantidad.Text, txtPrecioC.Text, txtPrecioV.Text, txtLaboratorio.Text, fecha1, fecha2, IdEst, IdLab);
                    MessageBox.Show("Se edito correctamente");
                    mostrarEstudiante();
                    Editar = false;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("No se puede editar los datos por:"+ex);
                }
            }
           
        }
         private void ocultarCol()
         {
             this.dataGridView1.Columns[0].Visible = false;
             this.dataGridView1.Columns[5].Visible = false;
             this.dataGridView1.Columns[6].Visible = false;                 
         }

         private void button2_Click(object sender, EventArgs e)
         {
             if(dataGridView1.SelectedRows.Count>0)
             {
                 Editar = true;
                 this.IdEst = Convert.ToString(this.dataGridView1.CurrentRow.Cells["RegistrarM.IdMedicamento"].Value);
                 this.txtNombre.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["Nombre"].Value);
                 this.txtCantidad.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["Cantidad"].Value);
                 this.txtPrecioC.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["PrecioCompra"].Value);
                 this.txtPrecioV.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["PrecioVenta"].Value);
                 this.IdLab = Convert.ToString(this.dataGridView1.CurrentRow.Cells["IdLaboratorio"].Value);
                 this.txtLaboratorio.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["Laboratorio"].Value);
                 this.dtFecha1.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["FechaCompra"].Value);
                 this.dtFecha2.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["FechaVencimiento"].Value);
             }
             else
             {
                 MessageBox.Show("Seleccione una fila por favor");
             }
         }
         
         private void btnSalir_Click(object sender, EventArgs e)
         {
            Close();
            
         }

         private void btnEliminar_Click(object sender, EventArgs e)
         {
             if (dataGridView1.SelectedRows.Count > 0)
             {
                 IdEst = Convert.ToString(this.dataGridView1.CurrentRow.Cells["RegistrarM.IdMedicamento"].Value);               
                 obj.EliminarME(IdEst);
               obj3.EliminarEs(IdEst);
                 MessageBox.Show("se elimino correctamente");
                 mostrarEstudiante();
             }
             else
                 MessageBox.Show("Seleccione una fila para eliminar por favor");
         }

         private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {

         }

      
    }
}
