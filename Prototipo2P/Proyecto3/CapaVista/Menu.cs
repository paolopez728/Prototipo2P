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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empleados b = new Empleados();
            b.MdiParent = this;
            b.Show();
        }

        private void módulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Departamento b = new Departamento();
            b.MdiParent = this;
            b.Show();
        }

        private void aplicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Puesto b = new Puesto();
            b.MdiParent = this;
            b.Show();
        }
    }
}
