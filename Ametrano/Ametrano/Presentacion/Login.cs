using Ametrano.Logica;
using Ametrano.Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ametrano.Presentacion
{
    public partial class Login : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private Login_Controlador controlador = new Login_Controlador();

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public Login()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCerrar2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Equals("Usuario"))
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Equals(""))
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.Gray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text.Equals("Contraseña"))
            {
                txtPass.Text = "";
                txtPass.PasswordChar = '●';
                txtPass.ForeColor = Color.Black;
            }else
            {
                txtPass.PasswordChar = '●';
                txtPass.ForeColor = Color.Black;
            }
           
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text.Equals(""))
            {
                txtPass.Text = "Contraseña";
                txtPass.PasswordChar = '\0';
                txtPass.ForeColor = Color.Gray;
            }
            else
            {
                txtPass.PasswordChar = '●';
                txtPass.ForeColor = Color.Black;
            }
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String usuario = txtUsuario.Text;
            String contrasenia = txtPass.Text;

            //luego se debe verificar que no sean vacios

            
            bool valorRetornado = controlador.loginbtn_function(usuario, contrasenia);
            if (valorRetornado)
            {
                this.Hide();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {


            txtUsuario.Focus();
            
            
            

        }

       
    }
}
