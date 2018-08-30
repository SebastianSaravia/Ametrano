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
        private Principal_Controlador controlador = new Principal_Controlador();
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
            tabControlPrincipal.SelectedIndex = 0;
        }
        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            tabControlPrincipal.SelectedIndex = 1;
        }
        private void btnCursos_Click(object sender, EventArgs e)
        {
            tabControlPrincipal.SelectedIndex = 2;
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            boxSexoAlumno.SelectedIndex = 0;
            boxEstadoCivilAlumno.SelectedIndex = 0;
            boxNivelEducativo.SelectedIndex = 0;
            boxJefeHogar.SelectedIndex = 0;
            tabControlIngresarAlumno.Controls.Remove(tabPage6);
            tabControlIngresarAlumno.Controls.Remove(tabPage7);
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            tabControlIngresarAlumno.Controls.Remove(tabPage5);
            tabControlIngresarAlumno.Controls.Add(tabPage6);
            tabControlIngresarAlumno.SelectedIndex= 1;         
        }
        private void btnSiguinete2_Click(object sender, EventArgs e)
        {
            tabControlIngresarAlumno.Controls.Remove(tabPage6);
            tabControlIngresarAlumno.Controls.Add(tabPage7);
            tabControlIngresarAlumno.SelectedIndex = 2;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            tabControlIngresarAlumno.Controls.Remove(tabPage6);
            tabControlIngresarAlumno.Controls.Add(tabPage5);
            tabControlIngresarAlumno.SelectedIndex = 1;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            tabControlIngresarAlumno.Controls.Remove(tabPage7);
            tabControlIngresarAlumno.Controls.Add(tabPage6);
            tabControlIngresarAlumno.SelectedIndex = 2;
        }
        private void TimePickerFechaNac_ValueChanged(object sender, EventArgs e)
        {
            txtFechaNacimiento.Text = TimePickerFechaNac.Text;
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlador.abrirConfiguracion();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.login_rol = "";
            Properties.Settings.Default.login_ususario = "";
            Properties.Settings.Default.login_contraseña = "";
            Login.ActiveForm.Show();
        }
    }
}
