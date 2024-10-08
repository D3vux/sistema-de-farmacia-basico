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
    public partial class Venta_de_Medicamento : Form
    {
        NVentaM obj = new NVentaM();
        NVentaL obj2 = new NVentaL();
        private bool Editar = false;
        private bool EditarV = false;
        private string IdEst = null;
        private string IdLab = null;
        public Venta_de_Medicamento()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                IdEst = Convert.ToString(this.dataGridView1.CurrentRow.Cells["VentaM.IdMedicamento"].Value);
                obj.EliminarME(IdEst);              
                MessageBox.Show("se elimino correctamente");
                mostrarEstudiante();
            }
            else
                MessageBox.Show("Seleccione una fila para eliminar por favor");
        }

        private void Venta_de_Medicamento_Load(object sender, EventArgs e)
        {
            
           mostrarEstudiante();
            ocultarCol();
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
        private void ocultarCol2()
        {
            this.dataGridView2.Columns[0].Visible = false;
            this.dataGridView2.Columns[3].Visible = false;
            this.dataGridView2.Columns[5].Visible = false;
            this.dataGridView2.Columns[6].Visible = false;
            this.dataGridView2.Columns[8].Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string fecha2;           
            fecha2 = dtFecha2.Text;
            //INSERTAR
            if (Editar == false )
            {
                try
                {
                    obj.insertarV(txtNombre.Text, txtCantidad.Text, txtPrecioV.Text);
                    obj2.insertarLab(txtLaboratorio.Text,  fecha2);
                    MessageBox.Show("se inserto correctamente");
                    mostrarEstudiante();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se puede insertar por :" + ex);
                }
            }
            //EDITAR
            if (Editar == true )
            {
                try
                {
                    obj.editarME(txtNombre.Text, txtCantidad.Text, txtPrecioV.Text, txtLaboratorio.Text,  fecha2, IdEst, IdLab);                  
                    MessageBox.Show("Se edito correctamente");
                    mostrarEstudiante();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puede editar los datos por:" + ex);
                }
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                this.IdEst = Convert.ToString(this.dataGridView1.CurrentRow.Cells["VentaM.IdMedicamento"].Value);
                this.txtNombre.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["Nombre"].Value);
                this.txtCantidad.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["Cantidad"].Value);              
                this.txtPrecioV.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["PrecioVenta"].Value);
                this.IdLab = Convert.ToString(this.dataGridView1.CurrentRow.Cells["IdLaboratorio"].Value);
                this.txtLaboratorio.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["Laboratorio"].Value);              
                this.dtFecha2.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["FechaVencimiento"].Value);
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            dataGridView2.DataSource = obj.BuscarME(txtBuscar.Text);
            ocultarCol2();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                
                this.IdEst = Convert.ToString(this.dataGridView2.CurrentRow.Cells["EstadoME.IdMedicamento"].Value);
                this.txtNombre.Text = Convert.ToString(this.dataGridView2.CurrentRow.Cells["Nombre"].Value);
                this.txtCantidad.Text = Convert.ToString(this.dataGridView2.CurrentRow.Cells["Cantidad"].Value);
                this.txtPrecioV.Text = Convert.ToString(this.dataGridView2.CurrentRow.Cells["PrecioVenta"].Value);
                this.IdLab = Convert.ToString(this.dataGridView2.CurrentRow.Cells["IdLaboratorio"].Value);
                this.txtLaboratorio.Text = Convert.ToString(this.dataGridView2.CurrentRow.Cells["Laboratorio"].Value);
                this.dtFecha2.Text = Convert.ToString(this.dataGridView2.CurrentRow.Cells["FechaVencimiento"].Value);
                Editar= true;
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
            string fecha2;
            fecha2 = dtFecha2.Text;
            //INSERTAR
            
            obj.resta(txtNombre.Text, txtCantidad.Text, txtPrecioV.Text, IdEst);
            if (Editar == false)
            {
                try
                {
                   
                    obj.insertarV(txtNombre.Text, txtCantidad.Text, txtPrecioV.Text);
                    obj2.insertarLab(txtLaboratorio.Text, fecha2);
                   
                    //MessageBox.Show("se inserto correctamente");
                    mostrarEstudiante();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se puede insertar por :" + ex);
                }
            }
            //EDITAR
            if (Editar == true)
            {
                try
                {
                    obj.editarME(txtNombre.Text, txtCantidad.Text, txtPrecioV.Text, txtLaboratorio.Text, fecha2, IdEst, IdLab);
                    //MessageBox.Show("Se edito correctamente");
                    mostrarEstudiante();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puede editar los datos por:" + ex);
                }
            }
        }


    }
}
