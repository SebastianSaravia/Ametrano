using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ametrano.Presentacion
{
    public partial class Configuracion : Form
    {
        public Configuracion()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void listaConfiguracion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaConfiguracion.SelectedIndex == 0)
            {
                tabControlConfiguracion.SelectedTab = tabPageUsuarios;
            }
            else if (listaConfiguracion.SelectedIndex == 1)
            {
                tabControlConfiguracion.SelectedTab = tabPageBD;
            }
        }
    }
}
