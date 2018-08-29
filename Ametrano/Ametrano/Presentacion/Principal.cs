using Ametrano.Logica;
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

        private void btnDocentes_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }
        private void btnCursos_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            boxSexoAlumno.SelectedIndex = 0;
            boxEstadoCivilAlumno.SelectedIndex = 0;
            boxNivelEducativo.SelectedIndex = 0;
            boxJefeHogar.SelectedIndex = 0;
            tabControl5.Controls.Remove(tabPage6);
            tabControl5.Controls.Remove(tabPage7);
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            tabControl5.Controls.Remove(tabPage5);
            tabControl5.Controls.Add(tabPage6);
            tabControl5.SelectedIndex= 1;         
        }
        private void btnSiguinete2_Click(object sender, EventArgs e)
        {
            tabControl5.Controls.Remove(tabPage6);
            tabControl5.Controls.Add(tabPage7);
            tabControl5.SelectedIndex = 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl5.Controls.Remove(tabPage6);
            tabControl5.Controls.Add(tabPage5);
            tabControl5.SelectedIndex = 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl5.Controls.Remove(tabPage7);
            tabControl5.Controls.Add(tabPage6);
            tabControl5.SelectedIndex = 2;
        }
    }
}
