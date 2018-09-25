using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace Ametrano.Presentacion
{
    public partial class ReporteErrores : Form
    {
        public ReporteErrores()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailMessage mmsg = new MailMessage();
            mmsg.To.Add("junsei.contacto@gmail.com");
            mmsg.Subject = "Ametrano software: " + txtAsuntoError.Text;
            mmsg.SubjectEncoding = Encoding.UTF8;
            mmsg.Body = txtDescripcionError.Text;
            mmsg.BodyEncoding = Encoding.UTF8;
            mmsg.From = new MailAddress("junsei.errores@gmail.com");

            SmtpClient cliente = new SmtpClient();
            cliente.Credentials = new System.Net.NetworkCredential("junsei.errores@gmail.com", "arekushizu");
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";

            try
            {
                cliente.Send(mmsg);
                MessageBox.Show("Reporte enviado satisfactoriamente");
                Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Error al enviar el reporte de error, verifique su conexion a internet");
                throw;
            }


        }
    }
}
