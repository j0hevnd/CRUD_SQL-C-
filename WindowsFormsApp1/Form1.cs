using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        N_productos objeptoCN = new N_productos();
        private string idProducto = null;
        private bool editar = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostarProductos();
        }
        // MÉTODO PARA MOSTRAR TODOS LOS PRODUCTOS
        private void MostarProductos()
        {
            N_productos objepto = new N_productos();
            dataGridView1.DataSource = objepto.MostarProductos();

        }

        // MÉTODO PARA QUE EL BOTON  GUARDE O EDITE
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // GUARDAR
            if (txtNombre.Text == "" || txtDescripcion.Text == "" || txtMarca.Text == "" || txtPrecio.Text == "" || 
                txtStock.Text == "" )
            {
                MessageBox.Show("Debe llenar todos los campos");

            } 
            else if (editar == false)
            { 
                try
                {
                    objeptoCN.InsetarProducto(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                    MessageBox.Show("Se ha Guardado Correctamente");
                    MostarProductos();
                    LimpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar el registro" + ex);
                }
            } 
            else if (editar == true)
            {
                // EDITAR
                try
                {
                    objeptoCN.EditarProducto(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text, idProducto);
                    MessageBox.Show("Se ha Editado Correctamente");
                    MostarProductos();
                    editar = false;
                    LimpiarForm();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("error al Editar" + ex);
                }
            }

        }

        // MÉTODO PARA EDITAR
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells["marca"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["precio"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["stock"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["id_producto"].Value.ToString();
            } else
            {
                MessageBox.Show("Seleccione la fila a Editar");
            }
        }

        // MÉTODO DE ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["id_producto"].Value.ToString();
                objeptoCN.EliminarProducto(idProducto);
                MessageBox.Show("Se ha Eliminado Correctamente");
                MostarProductos();
            }
            else
            {
                MessageBox.Show("Seleccione la fila a Eliminar");
            }

        }


        //MÉTODO PARA LIMPIAR EL FORMULARIO
        private void LimpiarForm()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Adiós");
            Application.Exit();
        }
    }
}
