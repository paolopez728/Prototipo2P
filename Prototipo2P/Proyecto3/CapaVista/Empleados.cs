using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador;


namespace CapaVista
{
    public partial class Empleados : Form
    {
        string table = "tbl_empleado";
        Controlador cn = new Controlador();
        public Empleados()
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

            txtSueldo.Text = "";
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
            listEmpleado.DataSource = dt;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            checkbox();
            TextBox[] textbox = { txtCodigoEmpleado, txtNombre, txtSueldo,txtEstado };
            cn.ingresar(textbox, table);
            string message = "Registro Guardado";
            Actualizar();
            limpiar();
            MessageBox.Show(message);
        }

        private void listAplicacionPerfil_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Maestros_Load(object sender, EventArgs e)
        {
            txtEstado.Visible = false;
            txtEliminar.Visible = false;
            IngresarData();
        }

        private void listMaestro_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string dato;
                dato = listEmpleado.CurrentCell.Value.ToString();
                txtEliminar.Text = dato;


                string message = "Deseas Eliminar el Registro?";
                string title = "Eliminar Registro";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    //int campo = int.Parse(txtBusacar.Text);
                    string condicion = "pk_codigo_empleado = ";
                    cn.eliminar(table, condicion, Int32.Parse(dato));
                    IngresarData();
                    //this.Close();
                }
                else
                {
                    limpiar();
                    //this.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            checkbox();
            TextBox[] textbox = { txtCodigoEmpleado, txtNombre, txtSueldo, txtEstado };
            int valor1 = int.Parse(txtBuscar.Text);
            string campo = "pk_codigo_empleado = ";
            cn.actualizar(textbox, table, campo, valor1);
            IngresarData();
        }
    }
}
