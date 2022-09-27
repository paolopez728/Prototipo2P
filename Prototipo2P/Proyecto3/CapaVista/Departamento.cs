using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class Departamento : Form
    {
        string table = "tbl_departamento";
        CapaControlador.Controlador cn = new CapaControlador.Controlador();
        public Departamento()
        {
            InitializeComponent();
        }

        public void checkbox()
        {
            if (checkBox1.Checked)
            {
                txtEstado.Text = "1";
            }
            else
            {
                txtEstado.Text = "0";
            }
        }
        public void limpiar()
        {
            txtCodigoEmpleado.Text = "";
            txtNombre.Text = "";
            txtEstado.Text = "";
        }

        public void Actualizar()
        {
            DataTable dt = cn.llenarTbl(table);

            // string idUsuario = txtCodigoEmpleado.Text;
            // cn.llenarListApliUsuariosstring(listMaestro.Tag.ToString(), listMaestro, idUsuario);
        }

        public void IngresarData()
        {
            DataTable dt = cn.llenarTbl(table);
            listdepartamento.DataSource = dt;
        }



        private void btnIngresar_Click(object sender, EventArgs e)
        {
            checkbox();
            TextBox[] textbox = { txtCodigoEmpleado, txtNombre, txtEstado };
            cn.ingresar(textbox, table);
            string message = "Registro Guardado";
            Actualizar();
            limpiar();
            MessageBox.Show(message);
        }
        private void Maestros_Load(object sender, EventArgs e)
        {
            txtEstado.Visible = false;
            txtEliminar.Visible = false;
            IngresarData();
        }

        private void listMaestro_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            checkbox();
            TextBox[] textbox = { txtCodigoEmpleado, txtNombre, txtEstado };
            int valor1 = int.Parse(txtBuscar.Text);
            string campo = "pk_codigo_departamento = ";
            cn.actualizar(textbox, table, campo, valor1);
            IngresarData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string message = "Deseas Eliminar el Registro?";
            string title = "Eliminar Registro";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            try
            {


                if (result == DialogResult.Yes)
                {

                    int campo = int.Parse(txtBuscar.Text);
                    string condicion = "pk_codigo_departamento = ";
                    cn.eliminar(table, condicion, campo);
                    string message1 = "Registro eliminado";
                    limpiar();
                    MessageBox.Show(message1);
                }
                else
                {
                    limpiar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se puede eliminar por permisos asignados");
                Console.WriteLine(ex.Message.ToString() + " \nNo se puede eliminar por permisos asignados");
            }
        }
    }
    }

