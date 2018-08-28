using Ametrano.Logica;
using MaterialSkin.Controls;
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
    public partial class Principal : Form

    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }
    }
}
